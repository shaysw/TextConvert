FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /TextConvert

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /TextConvert
COPY --from=build-env /TextConvert/out .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "TextConvertWebApp.dll"]