using System;
using System.IO;
using System.Text.RegularExpressions;
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

            // Validar que solo se ingresen n�meros en el campo de tel�fono
            if (!Regex.IsMatch(phone, @"^\d+$"))
            {
                DisplayAlert("Error", "El n�mero de tel�fono solo puede contener d�gitos.", "OK");
                return;
            }

            string data = $"Nombre: {name}\nN�mero: {phone}";
            File.WriteAllText(filePath, data);

            // Mostrar alerta de �xito
            DisplayAlert("�xito", "Recarga realizada correctamente.", "OK");

            // Cargar datos de la �ltima recarga
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
