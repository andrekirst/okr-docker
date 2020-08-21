# Einfaches Docker-Image

Im folgenden wird ein einfaches Docker-Image erzeugt, lokal gestartet, veröffentlicht und auf anderen Systemen verteilt (Docker, Kubernetes)

## Dockerfile

### Was ist eine Dockerfile?

Eine Dockerfile ist eine Bauanleitung für ein Docker-Image. Die Bauanleitung besteht aus mehreren Schritten, sogenannten Steps, und hat zur Aufgabe, dass benötigte Komponenten installiert und Dateien für die Ausführung bereitgestellt werden.

-> Inhalt siehe Datei `Dockerfile`

## Bauen eines Docker-Image

Um ein Docker-Image mit einem Dockerfile zu erstellen, wird das Kommando `docker build` benutzt.

```bash
docker build . -t docker-alone:v1
```

### Parameterbeschreibung

* `.` Der Kontext. Also der Ordner, von dem aus der Build-Prozess gestartet wird. Es ist deshalb notwendig, damit Docker u.a. weiß, woher die Daten mit einem `COPY`-Befehl Dateien kopiert werden sollen.
* `-t` Legt einen Namen und den Tag fest. Damit man das erzeugte Image anhand dem Namen wiederfinden kann. Der Tag ist für die Versionierung wichtig. Falls kein Tag festgelegt wird, wird standardmäßig `latest` benutzt.

## Starten eines Containers

Nachdem das Docker-Image erzeugt wurde, kann man mit dem Befehl `docker run` einen Container starten.

```bash
docker run --rm -p 8000:80 docker-alone:v1
```

### Parameterbeschreibung

* `--rm` Nach dem Beenden, wird der Prozess auch automatisch gelöscht und kann nicht wiederverwendet werden.
* `-p <external-port>:<container-port>` Die Angabe erzeugt ein Port-Mapping zwischen dem Container-Port und einem Externen Port, um damit auf den Container zuzugreifen
* Der Name oder der Hash des Images

## Veröffentlichen eines Images


