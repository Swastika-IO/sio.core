#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 54647
EXPOSE 44319

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Sio.Cms.Web/Sio.Cms.Web.csproj", "Sio.Cms.Web/"]
RUN dotnet restore "Sio.Cms.Web/Sio.Cms.Web.csproj"
COPY . .
WORKDIR "/src/Sio.Cms.Web"
RUN dotnet build "Sio.Cms.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sio.Cms.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sio.Cms.Web.dll"]
