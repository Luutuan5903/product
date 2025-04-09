FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/FinallyProject.Web.Mvc/FinallyProject.Web.Mvc.csproj", "src/FinallyProject.Web.Mvc/"]
COPY ["src/FinallyProject.Web.Core/FinallyProject.Web.Core.csproj", "src/FinallyProject.Web.Core/"]
COPY ["src/FinallyProject.Application/FinallyProject.Application.csproj", "src/FinallyProject.Application/"]
COPY ["src/FinallyProject.Core/FinallyProject.Core.csproj", "src/FinallyProject.Core/"]
COPY ["src/FinallyProject.EntityFrameworkCore/FinallyProject.EntityFrameworkCore.csproj", "src/FinallyProject.EntityFrameworkCore/"]
WORKDIR "/src/src/FinallyProject.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/FinallyProject.Web.Mvc", "src/FinallyProject.Web.Mvc"]
COPY ["src/FinallyProject.Web.Core", "src/FinallyProject.Web.Core"]
COPY ["src/FinallyProject.Application", "src/FinallyProject.Application"]
COPY ["src/FinallyProject.Core", "src/FinallyProject.Core"]
COPY ["src/FinallyProject.EntityFrameworkCore", "src/FinallyProject.EntityFrameworkCore"]
WORKDIR "/src/src/FinallyProject.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "FinallyProject.Web.Mvc.dll"]
