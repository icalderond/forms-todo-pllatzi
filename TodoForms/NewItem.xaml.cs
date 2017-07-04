using System;
using System.Collections.Generic;
using TodoForms.Clases;
using Xamarin.Forms;

namespace TodoForms
{
    public partial class NewItem : ContentPage
    {
        public NewItem()
        {
            InitializeComponent();
            buttonGuardar.Clicked += ButtonGuardar_Clicked;
        }

        void ButtonGuardar_Clicked(object sender, EventArgs e)
        {
            Tarea tarea = new Tarea()
            {
                Nombre = nombreEntry.Text,
                Fecha = FechaLimiteDataPicker.Date,
                Hora = HoraLimiteDatePicker.Time,
                Completa = false
            };
            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaDB))
            {
                conexion.CreateTable<Tarea>();
                var resultado = conexion.Insert(tarea);

                if (resultado > 0)
                    DisplayAlert("Exito", "El elemento se guardo", "Ok");
                else
                    DisplayAlert("Error", "Intentar de nuevo", "Ok");
            }
        }
    }
}
