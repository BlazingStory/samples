#!/bin/bash
set -euo pipefail

# Start Blazor Server (Kestrel) on port 5000 in background
# Assembly name assumed from project: ServerApp1.Stories.dll
(dotnet /app/ServerApp1.Stories.dll &) 

# Start nginx in foreground (PID 1)
exec nginx -g 'daemon off;'