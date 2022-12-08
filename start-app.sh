#!/usr/bin/env sh
# NB: set permission for this file as well
chmod +x ./docker/build.sh

# build images
./docker/build.sh

# connect to kubernetes cluster
echo "connecting to cluster"
CLUSTER_NAME=docker-deskop
NAMESPACE=default
kubectl config set-context $CLUSTER_NAME --namespace=$NAMESPACE && kubectl config use-context $CLUSTER_NAME

echo "show current nodes"
kubectl get nodes -o wide

# setup nginx controller
echo "setting up ingress-nginx controller"
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.1/deploy/static/provider/cloud/deploy.yaml

# configs
kubectl apply -f infra/k8s/config/
# deployment
kubectl apply -f infra/k8s/deployment/
# service
kubectl apply -f infra/k8s/service

# ingress
kubectl apply -f infra/k8s/ingress

# ingress ip
echo "inventory Load balancer ip"
kubectl get svc -n ingress-nginx
