FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

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
COPY entrypoint.sh .

EXPOSE 80/tcp
ENTRYPOINT ["./dotnetapp"]



