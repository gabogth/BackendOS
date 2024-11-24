#!/bin/bash

# Wait for the database to be available
until nc -z sqlserver 1433; do
  echo "Waiting for database..."
  sleep 2
done

# Run EF migrations
dotnet ef database update

# Start the application
dotnet myapp.dll