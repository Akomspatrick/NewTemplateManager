# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Set the Working Directory inside the container
WORKDIR /app
# Expose the port number
EXPOSE 8080
EXPOSE 8081
# use the sdk image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Set the build directory inside the container
WORKDIR /src

# copy all the layers' csproj files into respective build folders
COPY ["NewTemplateManager.Api/NewTemplateManager.Api.csproj", "NewTemplateManager.Api/"]
COPY ["NewTemplateManager.Application/NewTemplateManager.Application.csproj", "NewTemplateManager.Application/"]
COPY ["NewTemplateManager.Infrastructure/NewTemplateManager.Infrastructure.csproj", "NewTemplateManager.Infrastructure/"]
COPY ["NewTemplateManager.Domain/NewTemplateManager.Domain.csproj", "NewTemplateManager.Domain/"]
COPY ["NewTemplateManager.DomainBase/NewTemplateManager.DomainBase.csproj", "NewTemplateManager.DomainBase/"]
COPY ["NewTemplateManager.Contracts/NewTemplateManager.Contracts.csproj", "NewTemplateManager.Contracts/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "NewTemplateManager.Api/NewTemplateManager.Api.csproj"


#RUN dotnet restore "NewTemplateManager.Api/NewTemplateManager.Api.csproj"
#RUN dotnet restore "NewTemplateManager.Application/NewTemplateManager.Application.csproj"
#RUN dotnet restore "NewTemplateManager.Infrastructure/NewTemplateManager.Infrastructure.csproj"
#RUN dotnet restore "NewTemplateManager.Domain/NewTemplateManager.Domain.csproj"
#RUN dotnet restore "NewTemplateManager.Domain/NewTemplateManager.DomainBase.csproj"
#RUN dotnet restore "NewTemplateManager.Domain/NewTemplateManager.Contracts.csproj"

# copy all the layers' code into respective build folders
COPY . .
# Set the Working Directory inside the container
WORKDIR "/src/NewTemplateManager.Api/"

# run build over the API project
RUN dotnet build "NewTemplateManager.Api.csproj" -c Release -o /app/build


# run publish over the API project
FROM build AS publish
RUN dotnet publish "NewTemplateManager.Api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewTemplateManager.Api.dll"]
#src % docker build -t  oladeji1/newtemplatemanager:1 .