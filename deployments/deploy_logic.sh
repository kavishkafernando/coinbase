#!/usr/bin/env bash

GREEN_POINT_APP=GREEN_APP=$(kubectl get svc coinbase-green -o=jsonpath='{.spec.selector.app}')


if [$GREEN_POINT_APP == "coinbase-green"];then
  kubectl apply -f deployments/blue_deployment.yaml
  kubectl rollout restart -f deployments/blue_deployment.yaml
  echo "Deployed in Blue pods"
else
  kubectl apply -f deployments/green_deployment.yaml
  kubectl rollout restart -f deployments/green_deployment.yaml
  echo "Deployed in Green pods"
fi