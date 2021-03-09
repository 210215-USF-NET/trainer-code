# base image for the image. you need this to run the app
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

# baby of mkdir and cd (it makes the directory if it doesn't exist and navigates to that directory)
WORKDIR /app

# copy the sln and csproj files first to restore them and the deps
COPY *.sln ./
COPY ToHBL/*.csproj ToHBL/
COPY ToHDL/*.csproj ToHDL/
COPY ToHModels/*.csproj ToHModels/
COPY ToHMVC/*.csproj ToHMVC/
COPY ToHTests/*.csproj ToHTests/

RUN dotnet restore

# this is just me copying my codebase (but there are some things i don't want copied over)
COPY . ./

RUN dotnet publish ToHMVC -c Release -o publish --no-restore

# we're doing a multi stage build. after we restore our app and create a deployable version of it using publish,
# we leave the code base, and we only take the published version of it to the final image that will be built
# so that we won't have to deploy the SDK (which is memory heavy) or our codebase (to protect our implementation details)
# what we're deploying to the public is a runtime, and a executable version of our app
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
WORKDIR /app
#from the earlier build, get the publish folder
COPY --from=build /app/publish ./
CMD ["dotnet", "ToHMVC.dll"]