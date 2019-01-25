#### Tag da imagem para deployar no docker registry privado
> docker tag kubernetesazuredemo:latest kubernetesdemo.azurecr.io/kubernetesazuredemo

#### Login no registry via CLI
> docker login kubernetesdemo.azurecr.io -u USUÁRIO -p SENHA (Fornecidos pelo azure)

#### publicação da imagem
> docker push kubernetesdemo.azurecr.io/kubernetesazuredemo

#### login no azure CLI
> az login

#### Adicionar provider de Container Service
> az provider register -n Microsoft.ContainerService

#### Cria um grupo de recursos
> az group create --name KubeResources --location eastus

#### Cria um cluster no AKS(AzureKubernetesDemo) contendo 2 nodes, já vinculado ao grupo de recursos KubeResources
> az aks create --resource-group KubeResources --name AzureKubernetesDemo --node-count 2 --generate-ssh-keys

#### libera o acesso do kubectl ao Azure Container Registry
> az aks get-credentials --resource-group KubeResources --name AzureKubernetesDemo
> kubectl create secret docker-registry kubernetesdemoregistrykey --docker-server=kubernetesdemo.azurecr.io --docker-username=kubernetesdemo --docker-password=28AtSWghEf/aASPF6z7HgfluDhfAhoby --docker-email=yalves@stone.com.br

#### Cria o objeto deployment KubernetesAzureDemo
> kubectl create -f deployment.yaml

#### Cria o service(LoadBalancer)
> kubectl create -f service.yaml

#### Mudar numero de réplicas do deployment
> kubectl scale deployment kubernetesazuredemo-deployment --replicas=2

#### Deleta um pod
> kubectl delete pods

#### Abrir portal do kubernetes
> az aks browse -g KubeResources -n AzureKubernetesDemo

#### Obtém os deployments
> kubectl get deployment

#### Obtém os pods
> kubectl get pods

#### Obtém os services
> kubectl get services