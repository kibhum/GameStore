## Setting the connection string to secret storage
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=kibethh; Password=$sa_password;TrustServerCertificate=True"
```