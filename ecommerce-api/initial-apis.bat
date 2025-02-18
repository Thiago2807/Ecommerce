@echo off
dotnet build "E:\Projetos\ecommerce\ecommerce-api\ecommerce-core\ecommerce-core.csproj"

if %ERRORLEVEL% neq 0 (
    echo Erro na compilacao. Pressione qualquer tecla para sair.
    pause > nul
    exit /b %ERRORLEVEL%
)

start "gtw" cmd /k "dotnet run --project E:\Projetos\ecommerce\ecommerce-api\api-ecommerce-gtw\api-ecommerce-gtw.csproj"

start "auth" cmd /k "dotnet run --project  E:\Projetos\ecommerce\ecommerce-api\api-ecommerce-iua\api-ecommerce-iua.csproj"