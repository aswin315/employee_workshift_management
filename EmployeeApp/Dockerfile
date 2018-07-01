FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63976
EXPOSE 44354

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY EmployeeApp/EmployeeApp.csproj EmployeeApp/
RUN dotnet restore EmployeeApp/EmployeeApp.csproj
COPY . .
WORKDIR /src/EmployeeApp
RUN dotnet build EmployeeApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EmployeeApp.csproj -c Release -o /app
RUN dotnet dev-certs https --trust
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeApp.dll"]
