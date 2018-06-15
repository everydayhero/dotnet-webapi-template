# Build image
FROM microsoft/dotnet:2.1.300-sdk AS builder

# Install mono for Cake
ENV MONO_VERSION 5.12.0.226

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF

RUN echo "deb http://download.mono-project.com/repo/debian stretch/snapshots/$MONO_VERSION main" > /etc/apt/sources.list.d/mono-official.list \  
  && apt-get update \
  && apt-get install -y mono-runtime \
  && rm -rf /var/lib/apt/lists/* /tmp/*

RUN apt-get update \  
  && apt-get install -y unzip binutils curl mono-devel ca-certificates-mono fsharp mono-vbnc nuget referenceassemblies-pcl libgit2-24 \
  && rm -rf /var/lib/apt/lists/* /tmp/* 

RUN curl -L -o /tmp/GitVersion_3.6.5.zip https://github.com/GitTools/GitVersion/releases/download/v3.6.5/GitVersion_3.6.5.zip \
  && unzip -d /opt/GitVersion /tmp/GitVersion_3.6.5.zip \
  && rm /tmp/GitVersion_3.6.5.zip \
  && echo '<configuration><dllmap os="linux" cpu="x86-64" wordsize="64" dll="git2-baa87df" target="/usr/lib/libgit2.so" /></configuration>' > \
   /opt/GitVersion/LibGit2Sharp.dll.config

WORKDIR /sln

COPY ./build.cake ./build.sh ./WebApi.sln ./  

COPY ./sln ./sln  

RUN ls

# Build, Test, and Publish
RUN ./build.sh -v=Verbose

#App image
FROM microsoft/dotnet:2.1.0-aspnetcore-runtime-alpine 
WORKDIR /app  
ENV ASPNETCORE_ENVIRONMENT Production  
ENV ASPNETCORE_URLS http://0.0.0.0:80;http://0.0.0.0:81
ENTRYPOINT ["dotnet", "WebApi.Web.dll"]  
COPY --from=builder ./sln/artifacts .