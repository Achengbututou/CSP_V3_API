#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["learun.webapi/learun.webapi.csproj", "learun.webapi/"]
RUN dotnet restore "learun.webapi/learun.webapi.csproj"
COPY . .
WORKDIR "/src/learun.webapi"
RUN dotnet build "learun.webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "learun.webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN sed -i 's/TLSv1.2/TLSv1/g' /etc/ssl/openssl.cnf
ENTRYPOINT ["dotnet", "learun.webapi.dll"]