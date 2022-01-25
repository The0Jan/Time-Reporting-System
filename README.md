# NTR21Z-Walczak-Jan
## Na początek by byc w odpowiednim katalogu
```bash
cd lab4/NTR
```

## Urachamianie 
### Bazy danych
```
docker-compose up
dotnet ef database update
```

### Development (serwer i klient na osobnych portach)

```bash
dotnet run
```

### Produkcja (czyli serwer i klient na wspólnym porcie)

```bash
dotnet publish -c Production
cd bin/Production/net6.0/publish
./NTR.exe
```
