# stop any running instances
docker stop czechify_dev || true 
docker rm czechify_dev || true 
# run the app mounting the "logs" volume to capture the logs locally 
docker run -d -p 8080:80 --name czechify_dev -v //c/work/tmp://logs czechify 