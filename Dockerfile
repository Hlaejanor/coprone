FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

RUN ls
WORKDIR ./src/Coprone/Web
COPY ./src/Coprone/Web /app
WORKDIR /app
RUN ls
RUN dotnet restore
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build /app .
RUN ls

EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "coprone.dll"]



