#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Src/WebApi/FinalCase_TosunBank.WebApi/FinalCase_TosunBank.WebApi.csproj", "Src/WebApi/FinalCase_TosunBank.WebApi/"]
COPY ["Src/Core/FinalCase_TosunBank.Application/FinalCase_TosunBank.Application.csproj", "Src/Core/FinalCase_TosunBank.Application/"]
COPY ["Src/Infrastructure/FinalCase_TosunBank.Persistence/FinalCase_TosunBank.Persistence.csproj", "Src/Infrastructure/FinalCase_TosunBank.Persistence/"]
COPY ["Src/Core/FinalCase_TosunBank.Domain/FinalCase_TosunBank.Domain.csproj", "Src/Core/FinalCase_TosunBank.Domain/"]
RUN dotnet restore "Src/WebApi/FinalCase_TosunBank.WebApi/FinalCase_TosunBank.WebApi.csproj"
COPY . .
WORKDIR "/src/Src/WebApi/FinalCase_TosunBank.WebApi"
RUN dotnet build "FinalCase_TosunBank.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinalCase_TosunBank.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinalCase_TosunBank.WebApi.dll"]