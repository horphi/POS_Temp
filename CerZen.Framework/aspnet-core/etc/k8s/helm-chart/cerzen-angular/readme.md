Install using;

```bash
helm upgrade --install anz cerzen-angular
```

Uninstall all charts

```bash
helm uninstall anz
```

## Create Images

### run in the aspnet-core folder
```bash
docker build -t cerzen-host -f src\CerZen.Web.Host\Dockerfile .
docker build -t cerzen-migrator -f src\CerZen.Migrator\Dockerfile .
```

### run in the angular folder
```bash
docker build -t cerzen-angular -f Dockerfile . 
```
