# Build stage - generate static files
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore
COPY HeliosWeb.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
ENV ASPNETCORE_ENVIRONMENT=Production
RUN dotnet run --configuration Release

# Production stage - serve with nginx
FROM nginx:alpine AS production
WORKDIR /usr/share/nginx/html

# Remove default nginx content
RUN rm -rf ./*

# Copy static files from build stage
COPY --from=build /src/output .

# Copy custom nginx config
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
