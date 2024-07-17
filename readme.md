## Setting the connection string to secret storage
From the Server directory:
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=sa; Password=$sa_password;TrustServerCertificate=True"
```