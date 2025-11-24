# BlazingStory with nginx PathBase Demo

## Overview

This project demonstrates how to run a **BlazingStory Server** application behind **nginx** as a reverse proxy, hosted on a subpath (`/foo`). Both nginx and the Blazor Server app run in the same Docker container.

## Requirements

- **Docker** - For building and running the containerized application
- **.NET 10 SDK** - Used in the multi-stage Docker build to publish the Blazor app

## Build and Run with Docker

### Build the Docker image

```bash
docker build -t blazingstory-nginx-pathbase .
```

### Run the container

```bash
docker run -d -p 8080:80 --name blazingstory blazingstory-nginx-pathbase
```

### Access the application

Open your browser and navigate to:

```
http://localhost:8080/foo
```

The Blazor Server app is accessible under the `/foo` subpath, proxied by nginx.

## Architecture

- **nginx** listens on port 80 and forwards requests from `/foo` to the Blazor app **without URL rewriting**
- **Blazor Server** app runs on port 5000 with `app.UsePathBase("/foo");`

## Configuration Files

- `nginx/nginx.conf` - nginx reverse proxy configuration
- `Dockerfile` - Multi-stage build for .NET app and nginx runtime
- `docker-entrypoint.sh` - Startup script for both services

## License

This project is licensed under the Unlicense. See the [LICENSE](LICENSE) file for details.