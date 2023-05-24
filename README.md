# Dotnet-MVC-20CN2
- Sync model from database
```sh
dotnet ef dbcontext scaffold "Server=localhost;Database=test_mvc;User=root;Password=1234;Allow User Variables=True;" Pomelo.EntityFrameworkCore.MySql -o Models -f
``` 
