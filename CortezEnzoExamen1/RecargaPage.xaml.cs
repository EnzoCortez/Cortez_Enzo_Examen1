using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace CortezEnzoExamen1
{
    public partial class RecargaPage : ContentPage
    {
        private string FilePath => Path.Combine(FileSystem.AppDataDirectory, "UltimaRecarga.txt");

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
            File.WriteAllText(FilePath, data);

            // Mostrar Toast (dependiendo de la plataforma)


            // Recargar datos
            LoadLastRecarga();
        }

        private void LoadLastRecarga()
        {
            if (File.Exists(FilePath))
            {
                label_lastRecargaDetails.Text = File.ReadAllText(FilePath);
            }
        }
    }
}
