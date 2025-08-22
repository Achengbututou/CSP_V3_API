#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#FROM learunsoft/dotnet:8.0-office AS base

FROM learunteam-docker.pkg.coding.net/learunlowcode/net/runtime:8.0.1-office AS base
WORKDIR /app
EXPOSE 8080

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

#clear ssl cert
ENV SSL_CERT_FILE=""
#Git
ENV GIT_SSL_NO_VERIFY=true
#curl
ENV CURL_INSECURE=1
#.NET
ENV DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0
#NuGet
ENV NUGET_HTTP_CLIENT_HANDLER_DEFAULT_SSL_ERRORS_ACTION=Allow

# ARG ARTIFACTS_PAT  # 通过 --build-arg 传入

RUN dotnet restore "learun.webapi/learun.webapi.csproj" --ignore-failed-sources --verbosity detailed
WORKDIR "/src/learun.webapi"
RUN dotnet build "learun.webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "learun.webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
RUN sed -i 's/TLSv1.2/TLSv1/g' /etc/ssl/openssl.cnf &&\
	ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
ENTRYPOINT ["dotnet", "learun.webapi.dll"]