# Kubernetes - K8

is an open-source system for automating deployment, scaling, and management of containerized applications

## Programs

### Docker Desktop

### Kubernetes in Docker desktop

## Commands

Cheat Sheet : https://kubernetes.io/docs/reference/kubectl/cheatsheet/

### Get

    - Commands that shows resources

#### Get Nodes

```bash
kubectl get nodes
```

| Name           | Status |         Roles |  Age | Version |
| -------------- | -----: | ------------: | ---: | ------: |
| docker-desktop |  Ready | control-plane | 109m | v1.27.2 |

#### Get Pods

```bash
kubectl get pods
```

| Name                                       | Ready |  Status |      Restarts | Age |
| ------------------------------------------ | ----: | ------: | ------------: | --: |
| weatherforecastdeployment-85fdfcd967-g2bjw |   1/1 | Running | 2 (4m13s ago) | 85m |

#### Get Deployments

```bash
kubectl get deployments
```

| Name                      | Ready | Up-To-Date | Available | Age |
| ------------------------- | ----: | ---------: | --------: | --: |
| weatherforecastdeployment |   1/1 |          1 |         1 | 91m |

#### Get Services

```bash
kubectl get services
```

| Name                   |         Type |     Cluster-Ip | External-Ip |        Port(S) |  Age |
| ---------------------- | -----------: | -------------: | ----------: | -------------: | ---: |
| kubernetes             |    ClusterIP |      10.96.0.1 |    \<none\> |        443/TCP | 121m |
| weatherforecastservice | LoadBalancer | 10.107.221.198 |   localhost | 8080:30524/TCP |  88m |

#### Get Horizontal Pod Autoscaler

```bash
kubectl get hpa
```

| Name               |                            Reference | Targets | Minpods | Maxpods | Replicas | Age |
| ------------------ | -----------------------------------: | ------: | ------: | ------: | -------: | --: |
| weatherforecasthpa | Deployment/weatherforecastdeployment |  0%/20% |       1 |      10 |        1 | 75m |

##### To watch changes

```bash
kubectl get hpa <hps-name> --watch
```

### Describe

Will print debug information about the given resource.

```bash
kubectl describe <resource>
Ex : kubectl describe pods
```

```cmd
Name:             weatherforecastdeployment-85fdfcd967-g2bjw
Namespace:        default
Priority:         0
Service Account:  default
Node:             docker-desktop/192.168.65.3
Start Time:       Sun, 15 Oct 2023 09:33:12 +0300
Labels:           app=weatherforecast
                  pod-template-hash=85fdfcd967
Annotations:      <none>
Status:           Running
IP:               10.1.0.168
IPs:
  IP:           10.1.0.168
Controlled By:  ReplicaSet/weatherforecastdeployment-85fdfcd967
Containers:
  weatherforecastcontainer:
    Container ID:   docker://cfa4057e2412aef19e79e9504ba90d8ca4684bd8a01b1a361959202cec6bd800
    Image:          uurdemir/weatherforecast:1.0.0.0
    Image ID:       docker-pullable://uurdemir/weatherforecast@sha256:eca82384f322b44265b6c9f85f865b9f7ba63682a3f2f1f3982db435cbb94877
    Port:           80/TCP
    Host Port:      0/TCP
    State:          Running
      Started:      Sun, 15 Oct 2023 10:55:07 +0300
    Last State:     Terminated
      Reason:       Error
      Exit Code:    255
      Started:      Sun, 15 Oct 2023 10:07:01 +0300
      Finished:     Sun, 15 Oct 2023 10:54:55 +0300
    Ready:          True
    Restart Count:  2
    Limits:
      cpu:  500m
    Requests:
      cpu:        200m
    Environment:  <none>
    Mounts:
      /var/run/secrets/kubernetes.io/serviceaccount from kube-api-access-xzxb2 (ro)
Conditions:
  Type              Status
  Initialized       True
  Ready             True
  ContainersReady   True
  PodScheduled      True
Volumes:
  kube-api-access-xzxb2:
    Type:                    Projected (a volume that contains injected data from multiple sources)
    TokenExpirationSeconds:  3607
    ConfigMapName:           kube-root-ca.crt
    ConfigMapOptional:       <nil>
    DownwardAPI:             true
QoS Class:                   Burstable
Node-Selectors:              <none>
Tolerations:                 node.kubernetes.io/not-ready:NoExecute op=Exists for 300s
                             node.kubernetes.io/unreachable:NoExecute op=Exists for 300s
Events:
  Type    Reason          Age                 From               Message
  ----    ------          ----                ----               -------
  Normal  Scheduled       107m                default-scheduler  Successfully assigned default/weatherforecastdeployment-85fdfcd967-g2bjw to docker-desktop
  Normal  Pulled          107m                kubelet            Successfully pulled image "uurdemir/weatherforecast:1.0.0.0" in 1.43168794s (3.522948979s including waiting)
  Normal  Pulling         73m (x2 over 107m)  kubelet            Pulling image "uurdemir/weatherforecast:1.0.0.0"
  Normal  Created         73m (x2 over 107m)  kubelet            Created container weatherforecastcontainer
  Normal  Started         73m (x2 over 107m)  kubelet            Started container weatherforecastcontainer
  Normal  Pulled          73m                 kubelet            Successfully pulled image "uurdemir/weatherforecast:1.0.0.0" in 1.651945484s (1.651963924s including waiting)
  Normal  SandboxChanged  25m                 kubelet            Pod sandbox changed, it will be killed and re-created.
  Normal  Pulling         25m                 kubelet            Pulling image "uurdemir/weatherforecast:1.0.0.0"
  Normal  Pulled          25m                 kubelet            Successfully pulled image "uurdemir/weatherforecast:1.0.0.0" in 1.580117979s (1.580137879s including waiting)
  Normal  Created         25m                 kubelet            Created container weatherforecastcontainer
  Normal  Started         25m                 kubelet            Started container weatherforecastcontainer

```

### Apply

Apply a configuration to a resource by file name or stdin. The resource name must be specified. This resource will be created if it doesn't exist yet. To use 'apply', always create the resource initially with either 'apply' or 'create --save-config'.

JSON and YAML formats are accepted.

Alpha Disclaimer: the --prune functionality is not yet complete. Do not use unless you are aware of what the current state is. See https://issues.k8s.io/34274.

```bash
kubectl apply (-f FILENAME | -k DIRECTORY)
Ex : kubectl apply deployment.yml
```

## Metric Server

https://github.com/kubernetes-sigs/metrics-server

Metrics Server is a scalable, efficient source of container resource metrics for Kubernetes built-in autoscaling pipelines.

Metrics Server collects resource metrics from Kubelets and exposes them in Kubernetes apiserver through Metrics API for use by Horizontal Pod Autoscaler and Vertical Pod Autoscaler. Metrics API can also be accessed by kubectl top, making it easier to debug autoscaling pipelines.

Metrics Server is not meant for non-autoscaling purposes. For example, don't use it to forward metrics to monitoring solutions, or as a source of monitoring solution metrics. In such cases please collect metrics from Kubelet /metrics/resource endpoint directly.

Metrics Server offers:

A single deployment that works on most clusters (see Requirements)
Fast autoscaling, collecting metrics every 15 seconds.
Resource efficiency, using 1 mili core of CPU and 2 MB of memory for each node in a cluster.
Scalable support up to 5,000 node clusters.

### Installation

```bash
kubectl apply -f https://github.com/kubernetes-sigs/metrics-server/releases/latest/download/components.yaml
```

#### SSL Error Fix

```bash
kubectl patch deployment metrics-server -n kube-system --type='json' -p='[{"op": "add", "path": "/spec/template/spec/containers/0/args/-", "value": "--kubelet-insecure-tls"}]'
```

## Generate Load

```bash
kubectl run -i --tty load-generator --rm --image=busybox:1.28 --restart=Never -- /bin/sh -c "while sleep 0.01; do wget -q -O- http://<deployment-service-name>:8080/weatherforecast; done"
```

## K8 Configuration Files

### Deployment.yml

```yml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: weatherforecastdeployment
  labels:
    app: weatherforecast
spec:
  replicas: 1
  selector:
    matchLabels:
      app: weatherforecast
  template:
    metadata:
      labels:
        app: weatherforecast
    spec:
      containers:
        - name: weatherforecastcontainer
          image: uurdemir/weatherforecast:1.0.0.0
          imagePullPolicy: Always
          ports:
            - containerPort: 80
          resources:
            limits:
              cpu: 500m
            requests:
              cpu: 200m
```

### Service.yml

```yml
apiVersion: v1
kind: Service
metadata:
  name: weatherforecastservice
spec:
  selector:
    app: weatherforecast
  ports:
    - protocol: TCP
      port: 8080
      targetPort: 80
  type: LoadBalancer
```

### Hpa.yml

```yml
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  name: weatherforecasthpa
spec:
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: weatherforecastdeployment
  minReplicas: 1
  maxReplicas: 10
  metrics:
    - type: Resource
      resource:
        name: cpu
        target:
          type: Utilization
          averageUtilization: 20
```

#### Service Types

- ClusterIP. Exposes a service which is only accessible from within the cluster.
- NodePort. Exposes a service via a static port on each node’s IP.
- LoadBalancer. Exposes the service via the cloud provider’s load balancer.
- ExternalName. Maps a service to a predefined externalName field by returning a value for the CNAME record.
