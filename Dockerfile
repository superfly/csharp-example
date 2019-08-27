# Use the offical dotnet core image to build the app
# https://hub.docker.com/_/microsoft-dotnet-core-sdk/
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy code to the image
COPY . .

# Build the app
RUN dotnet publish -c Release -o out

# Start a new image for production with the optimized runtime image
# https://hub.docker.com/_/microsoft-dotnet-core-runtime/
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app

# Copy the app from the builder to the production image
COPY --from=build /app/out ./

# Run the app when the vm starts
ENTRYPOINT ["dotnet", "fly-example.dll"]
