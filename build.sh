# build the application
docker build -t czechify .

# run the application inside the container
docker stop czechify_dev || true 
docker rm czechify_dev || true 
docker run -d -p 8080:80 --name czechify_dev czechify