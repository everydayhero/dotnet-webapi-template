#!/usr/bin/env bash

# Get OS Name
OS=`uname -s`

# Set Development Environment Variable.
export ASPNETCORE_ENVIRONMENT=Development
export ASPNETCORE_HTTPS_PORT=5001

# Bug with OSX 10.12 runtimes
if [ "$OS" = Darwin ]; then
    export DOTNET_RUNTIME_ID=osx.10.11-x64
fi

# Delete .IncrementalCache..
# Probably not needed anymore.. But hey.. We're sentimental.
find . -name ".IncrementalCache" -delete

# CWD and run watch
# Make sure your Web Application follows the *.Web naming convention.
dotnet restore
cd sln/src/*
dotnet watch run
popd
