Install using;

```bash
helm upgrade --install anz cerzen-mvc
```

Uninstall all charts

```bash
helm uninstall anz
```

## Create Images

```bash
docker build -t cerzen-mvc -f src\CerZen.Web.Mvc\Dockerfile .
docker build -t cerzen-migrator -f src\CerZen.Migrator\Dockerfile .
```
