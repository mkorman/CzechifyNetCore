rem login to Azure container registry
docker login testimages.azurecr.io
rem tag the image
docker tag czechify testimages.azurecr.io/czechify:v1
rem push it!
docker push testimages.azurecr.io/czechify:v1
