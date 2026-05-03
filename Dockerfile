FROM mcr.microsoft.com/dotnet/sdk:latest

WORKDIR /app

COPY . /app/

ENTRYPOINT [ "dotnet", "run", "Program.cs" ]
