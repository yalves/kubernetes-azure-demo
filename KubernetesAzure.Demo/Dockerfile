FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY KubernetesAzure.Demo/KubernetesAzure.Demo.csproj KubernetesAzure.Demo/
RUN dotnet restore KubernetesAzure.Demo/KubernetesAzure.Demo.csproj
COPY . .
WORKDIR /src/KubernetesAzure.Demo
RUN dotnet build KubernetesAzure.Demo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish KubernetesAzure.Demo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KubernetesAzure.Demo.dll"]
