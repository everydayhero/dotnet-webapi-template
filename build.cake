// Tools
// #tool "nuget:?package=GitVersion.CommandLine"

// Namespaces
// Need this to modify CSProj later down the track.
using System.Xml;
using System.Xml.Linq;

// Allow us to run specific targets
var target = Argument("Target", "Default");

// Build Configuration
var configuration = "Release";

var netcoreAppVersion = Argument("netcore", "netcoreapp2.1");

// Local Variables..
var isContinuousIntegrationBuild = !BuildSystem.IsLocalBuild;

var preReleaseTag = "-dev";
var majorMinorPatch = "0.0.1";
var nugetVersion = "0.0.1";

// Artificats Directory
EnsureDirectoryExists("./artifacts");

// Projects that are going to be published.
var projectsToPublish = new[] { "src/WebApi.Web/WebApi.Web.csproj" };

/********************************************************************
 * Actual Build Steps
 *******************************************************************/
Task("GenerateNextVersion")
    .Does(() => 
    {
        try
        {
            GitVersion(new GitVersionSettings {
                UpdateAssemblyInfo = true
            });

            // Git Version \\(^_^)//
            var gitVersionInfo = GitVersion(new GitVersionSettings {
                OutputType = GitVersionOutput.Json
            });

            majorMinorPatch = gitVersionInfo.MajorMinorPatch;
            preReleaseTag = gitVersionInfo.PreReleaseTag;
            nugetVersion = gitVersionInfo.NuGetVersion;
        }
        catch (System.Exception)
        {
            Warning("Could not get version from GitVersion. Using defaults.");
        }
    }
);

Task("Clean")
    .Does(() =>
    {
        // Build Artifacts
        CleanDirectories("./src/**/bin");
        CleanDirectories("./src/**/obj");

        // Testing Artifacts
        CleanDirectories("./test/**/bin");
        CleanDirectories("./test/**/obj");
        DeleteFiles("./test/**/TestResult.xml");
    }
);

Task("Build")
    .IsDependentOn("SetVersion")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetCoreBuild("./", new DotNetCoreBuildSettings {
            Configuration = configuration
        });
    }
);

Task("SetVersion")
    .Does(() =>
    {
        var projects = GetFiles("./src/**/*.csproj");

        foreach(var project in projects)
        {
            var document = XDocument.Load(project.FullPath);
            var propertyGroup = document.Descendants("PropertyGroup")
                .FirstOrDefault();
            var versionPrefix = propertyGroup.Descendants("VersionPrefix")
                .FirstOrDefault();
            var versionSuffix = propertyGroup.Descendants("VersionSuffix")
                .FirstOrDefault();

            if (versionPrefix != null)
            {
                Information("Version Prefix is present, Setting {0}", majorMinorPatch);
                versionPrefix.SetValue(majorMinorPatch);
            } else
            {
                Information("Version Prefix is not present, Writing {0}", majorMinorPatch);
                propertyGroup.SetElementValue("VersionPrefix", majorMinorPatch);
            }

            if (versionSuffix != null)
            {
                Information("Version Suffix is present, Setting {0}", preReleaseTag);
                versionSuffix.SetValue(preReleaseTag);
            }
            else
            {
                Information("Version Suffix is not present, Writing {0}", preReleaseTag);
                propertyGroup.SetElementValue("VersionSuffix", preReleaseTag);
            }

            document.Save(project.FullPath);
        }
    }
);

Task("Restore")
    .Does(() =>
    {
        DotNetCoreRestore();
    }
);

Task("Test")
    .Does(() =>
    {
        var testProjects = GetFiles("./sln/test/**/*.csproj");

        foreach(var testProject in testProjects)
        {
            DotNetCoreTool(testProject.FullPath, "xunit", "-xml TestResult.xml");
        }
    });

Task("Release")
    .Does(() =>
    {
        DotNetCorePublish("./", new DotNetCorePublishSettings
        {
            Configuration = configuration,
            OutputDirectory = "./artifacts"
        });
    }
);

/********************************************************************
 * Default Build Target
 *******************************************************************/
Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("GenerateNextVersion")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Release")
    .Does(() => {
        Information("Finished building version: {0}", nugetVersion);
    });

RunTarget(target);