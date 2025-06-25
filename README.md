# Proyecto 3 - Aplicaciones Moviles

## Correr el repositorio

Correr el emulador (si se esta en Linux por ej.):

```bash
emulator -avd <nombre-del-emulador>
```

En windows se puede iniciar o crear un emulador desde android studio.

Correr los comandos en la carpeta del proyecto:

```bash
dotnet workload restore
dotnet build -f net8.0-android -t:Run
```

## Correr DB SQLite

```bash
sqlite3 ./DataBases/mydatabase.db
```
