using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace CortezEnzoExamen1
{
    public partial class RecargaPage : ContentPage
    {
        private string filePath = Path.Combine(FileSystem.AppDataDirectory, "EnzoCortez.txt");

        public RecargaPage()
        {
            InitializeComponent();
            LoadLastRecarga();
        }

        private void OnRecargarClicked(object sender, EventArgs e)
        {
            string phone = entry_phone.Text;
            string name = entry_name.Text;

            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(name))
            {
                DisplayAlert("Error", "Debe ingresar todos los datos.", "OK");
                return;
            }

            string data = $"Nombre: {name}\nNúmero: {phone}";
            File.WriteAllText(filePath, data);

            // Mostrar alerta de éxito
            DisplayAlert("Éxito", "Recarga realizada correctamente.", "OK");

            // Cargar datos de la última recarga
            LoadLastRecarga();
        }

        private void LoadLastRecarga()
        {
            if (File.Exists(filePath))
            {
                label_lastRecargaDetails.Text = File.ReadAllText(filePath);
            }
            else
            {
                label_lastRecargaDetails.Text = "No hay recargas guardadas.";
            }
        }
    }
}
