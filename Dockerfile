FROM microsoft/aspnet:1.0.0-beta4
ADD ./build /app
WORKDIR /app
RUN ["dnu", "restore", "--packages=/packages"]

EXPOSE 5001
ENTRYPOINT ["dnx", "/app", "--packages=/packages", "kestrel"]