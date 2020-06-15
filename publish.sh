#!/bin/bash

# read env vars from your file
source "dev.env"

# read version from file
version=$(cat version)
# login to Azure container registry
docker login testimages.azurecr.io
# tag the image
docker tag czechify testimages.azurecr.io/czechify:v$version
# push it!
docker push testimages.azurecr.io/czechify:v$version
# delete existing container instance
az container delete --name $containerName --resource-group $resourceGroup --yes
# re-create container instance
az container create --registry-username $registryUsername --registry-password  $registryPassword -g $resourceGroup --name $containerName --image testimages.azurecr.io/czechify:v$version --cpu 1 --memory 0.5 --ports 80 443 --dns-name-label czechify
