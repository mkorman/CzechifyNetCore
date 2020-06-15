# build the application
docker build -t czechify .
# run the application inside the container
docker run -d -p 8080:80 czechify