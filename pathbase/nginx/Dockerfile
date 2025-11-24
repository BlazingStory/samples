# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy full source and publish
COPY ServerApp1.Stories/ ServerApp1.Stories/
RUN dotnet publish ServerApp1.Stories/ServerApp1.Stories.csproj -o /app/publish

# =========================
# Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

# Install nginx (same container requirement)
RUN apt-get update \
    && apt-get install -y --no-install-recommends nginx \
    && rm -rf /var/lib/apt/lists/*

# Remove default site config if present
RUN rm -f /etc/nginx/sites-enabled/default /etc/nginx/conf.d/default.conf || true

# Copy custom nginx config
COPY nginx/nginx.conf /etc/nginx/nginx.conf

# Copy published Blazor Server app
WORKDIR /app
COPY --from=build /app/publish .

# Environment configuration
ENV ASPNETCORE_URLS=http://0.0.0.0:5000

# Expose nginx (reverse proxy) port
EXPOSE 80

# Entrypoint script to launch both processes
COPY docker-entrypoint.sh /docker-entrypoint.sh
RUN chmod +x /docker-entrypoint.sh

CMD ["/docker-entrypoint.sh"]
