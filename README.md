
# Requisitos Previos Visual Studio (2022 o superior).

SQL Server Express instalado con la base de datos BANCO y la tabla Cuenta.


# Estructura de la tabla Cuenta:

CREATE TABLE Cuenta (
  NumeroCuenta  varchar(255) NOT NULL,
  TipoCuenta  varchar(255) NOT NULL,
  Saldo float NOT NULL
  );
  
Ejemplo:

ACC-001

Ahorros

500



# Creación del Servidor (BancoAPI)
Pasos:

1. En Visual Studio 2026, crea un nuevo proyecto de tipo ASP.NET Core Web API.


2. Configura el proyecto con el nombre BancoAPI.


3. Selecciona .NET 10.0 como framework.


4. Asegúrate de instalar el paquete NuGet Microsoft.Data.SqlClient para manejar la base de datos SQL Server.


5. Código del Servidor (Program.cs):
