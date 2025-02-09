FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MexicanBankTest.Presentation/MexicanBankTest.Presentation.csproj", "MexicanBankTest.Presentation/"]
COPY ["MexicanBankTest.DAL/MexicanBankTest.DAL.csproj", "MexicanBankTest.DAL/"]
COPY ["MexicanBankTest.BLL/MexicanBankTest.BLL.csproj", "MexicanBankTest.BLL/"]
RUN dotnet restore "MexicanBankTest.Presentation/MexicanBankTest.Presentation.csproj"
COPY . .
WORKDIR "/src/MexicanBankTest.Presentation"
RUN dotnet build "MexicanBankTest.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MexicanBankTest.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MexicanBankTest.Presentation.dll"]
