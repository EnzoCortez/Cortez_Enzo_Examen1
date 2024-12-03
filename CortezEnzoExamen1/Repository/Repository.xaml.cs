using CortezEnzoExamen1.Models;

private void OnRecargarClicked(object sender, EventArgs e)
{
    string numero = entryNumero.Text;
    string nombre = entryNombre.Text;

    // Validar campos vacíos
    if (string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(nombre))
    {
        DisplayAlert("Error", "Debe ingresar todos los datos.", "OK");
        return;
    }

    // Crear instancia de Usuario y guardar datos
    Usuario usuario = new Usuario
    {
        Nombre = nombre,
        Numero = numero
    };

    // Guardar en el archivo
    string datos = $"Nombre: {usuario.Nombre}\nNúmero: {usuario.Numero}";
    File.WriteAllText(filePath, datos);

    // Mostrar confirmación
#if ANDROID
            Android.Widget.Toast.MakeText(Android.App.Application.Context, "Recarga exitosa", Android.Widget.ToastLength.Short).Show();
#else
    DisplayAlert("Éxito", "Recarga realizada exitosamente.", "OK");
#endif

    // Recargar datos en la interfaz
    CargarUltimaRecarga();
}

private void CargarUltimaRecarga()
{
    // Leer datos del archivo si existe
    if (File.Exists(filePath))
    {
        string datos = File.ReadAllText(filePath);
        labelDetalleUltimaRecarga.Text = datos;
    }
    else
    {
        labelDetalleUltimaRecarga.Text = "No hay recargas registradas.";
    }
}
    }
}
