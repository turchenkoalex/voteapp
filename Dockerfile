FROM microsoft/aspnet:1.0.0-beta4
ADD ./build /app
WORKDIR /app
RUN ["dnu", "restore", "--packages=/packages"]

EXPOSE 5004
ENTRYPOINT ["dnx", "./", "--packages=/packages", "kestrel"]