# NTR21Z-Walczak-Jan

## Urachamianie 
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