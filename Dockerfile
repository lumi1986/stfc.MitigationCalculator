FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /App
COPY /Drop .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Service.dll"]