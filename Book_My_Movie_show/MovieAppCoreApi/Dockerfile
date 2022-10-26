#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MovieAppCoreApi/MovieAppCoreApi.csproj", "MovieAppCoreApi/"]
COPY ["Book_Show_BLL/Book_Show_BLL.csproj", "Book_Show_BLL/"]
COPY ["Book_Show_DAL/Book_Show_DAL.csproj", "Book_Show_DAL/"]
COPY ["Book_Show_Entity/Book_Show_Entity.csproj", "Book_Show_Entity/"]
RUN dotnet restore "MovieAppCoreApi/MovieAppCoreApi.csproj"
COPY . .
WORKDIR "/src/MovieAppCoreApi"
RUN dotnet build "MovieAppCoreApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieAppCoreApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieAppCoreApi.dll"]