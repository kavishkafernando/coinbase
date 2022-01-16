#!/usr/bin/env bash

GREEN_POINT_APP=$(kubectl get svc coinbase-green -o=jsonpath='{.spec.selector.app}')

echo "Green is pointed to"
echo $GREEN_POINT_APP

if [[ $GREEN_POINT_APP == "coinbase-green" ]];then
  kubectl delete -f deployments/blue_deployment.yaml
  kubectl apply -f deployments/blue_deployment.yaml
  echo "Deployed in Blue pods"
else
  kubectl delete -f deployments/green_deployment.yaml
  kubectl apply -f deployments/green_deployment.yaml
  echo "Deployed in Green pods"
fi
