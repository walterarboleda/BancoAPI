using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Cadena de conexión 
string connectionString = @"Server=DESKTOP-R9RN64N\SQLEXPRESS;Database=BANCO;Integrated Security=True;TrustServerCertificate=True";

// Endpoint REST que reemplaza al WebMethod SOAP
app.MapGet("/verificar-saldo", (string numeroCuenta, string tipoCuenta, decimal montoCompra) =>
{
    bool puedeComprar = false;
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        // Consulta SQL
        string query = "SELECT Saldo FROM Cuenta WHERE NumeroCuenta = @num AND TipoCuenta = @tipo";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@num", numeroCuenta);
        cmd.Parameters.AddWithValue("@tipo", tipoCuenta);

        try
        {
            conn.Open();
            object resultado = cmd.ExecuteScalar(); 
            if (resultado != null)
            {
                decimal saldoActual = Convert.ToDecimal(resultado);
                if (saldoActual >= montoCompra) 
                {
                    puedeComprar = true;
                }
            }
            return Results.Ok(new { autorizado = puedeComprar });
        }
        catch (Exception ex)
        {
            return Results.Problem("Error en la consulta: " + ex.Message); 
        }
    }
});

app.Run();