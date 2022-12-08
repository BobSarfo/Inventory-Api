#!/bin/sh

echo  "building inventory frontend image"
docker build -t inventory-api .
