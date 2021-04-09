# Deploying applications to AKS (with ingress controller)

This demo leverages this [tutorial](https://medium.com/microsoftazure/deploy-a-full-stack-web-app-to-azure-kubernetes-service-with-docker-fb3d23f7294b)

## Before we begin (things to install)

1. az cli installed
2. kubectl installed
3. helm installed

## Actual deployment steps

1. Create an AKS Cluster
2. Connect to your created AKS Cluster
   - `az aks get-credentials --resource-group myResourceGroup --name myAKSCluster`
3. Create a namespace for the k8s objects that we'll be using in deploying our application
   - a namespace is a way of partioning your cluster, into virtual clusters
   - `kubectl create namespace nameOfNamespace`
4. Create ingress controller
   - you need this to be able to run your ingress resource
   - We'll be using nginx ingress controller
   1. We need to add in the ingress nginx repo
   - `helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx`
   - What is Helm?
     - Helm is the package manager for K8s
   2. Use Helm to deploy an NGINX ingress controller
   - ```
     helm install nginx-ingress ingress-nginx/ingress-nginx
         --namespace nameOfNamespace
         --set controller.replicaCount=2
         --set controller.nodeSelector."beta\.kubernetes\.io/os"=linux
         --set defaultBackend.nodeSelector."beta\.kubernetes\.io/os"=linux
     ```
5. Create the necessary resources in your deployment
   - You need to create a object config file
   - Just a document written in YAML that lets the master node know which resources to spin up and any management instructions
   - For my demo I've split it up to my ToH.yaml, and my ingress.yaml
   - When applying these yaml files, you're going to have to navigate to the root folder
   - `kubectl apply -f nameOfYamlFile --namespace nameofNamespace`
   - Create the ingress resource to be able to access my resources
   - `kubectl apply -f ingress.yaml`

### tldr; to be good at k8s all you need is to be able to format/write the object config file, and be good at the kubectl commands
