FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Core.Web/Core.Web.csproj", "Core.Web/"]
RUN dotnet restore "Core.Web/Core.Web.csproj"
COPY . .
WORKDIR "/src/Core.Web"
RUN dotnet build "Core.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Core.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Core.Web.dll"]