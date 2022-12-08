#!/bin/sh

# change to directory containing frontendclone
cd ../inventory-frontend
echo  "building inventory frontend image"
docker build -t inventory-app .