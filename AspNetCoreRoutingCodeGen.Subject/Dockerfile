FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["AspNetCoreRoutingCodeGen.Subject/AspNetCoreRoutingCodeGen.Subject.csproj", "AspNetCoreRoutingCodeGen.Subject/"]
RUN dotnet restore "AspNetCoreRoutingCodeGen.Subject/AspNetCoreRoutingCodeGen.Subject.csproj"
COPY . .
WORKDIR "/src/AspNetCoreRoutingCodeGen.Subject"
RUN dotnet build "AspNetCoreRoutingCodeGen.Subject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreRoutingCodeGen.Subject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreRoutingCodeGen.Subject.dll"]