# run the application inside the container
docker stop czechify_dev || true 
docker rm czechify_dev || true 
# docker run -d -p 8080:80 --name czechify_dev --mount source=logs-vol,destination=//logs czechify 
docker run -d -p 8080:80 --name czechify_dev -v //c/work/tmp://logs czechify 