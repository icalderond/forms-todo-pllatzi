using System;
using System.Collections.Generic;
using System.Linq;
using TodoForms.Clases;
using Xamarin.Forms;

namespace TodoForms
{
    public partial class ListaTareas : ContentPage
    {
        public ListaTareas()
        {
            InitializeComponent();
            var botonNuevo = new ToolbarItem()
            {
                Text = "+"
            };

            botonNuevo.Clicked += async (s, a) =>
            {
                await Navigation.PushAsync(new NewItem());
            };
            ToolbarItems.Add(botonNuevo);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                connection.CreateTable<Tarea>();
                List<Tarea> listaTareas = new List<Tarea>();
                listaTareas = connection.Table<Tarea>().Where(item => !item.Completa).ToList();

                listaTareasListView.ItemsSource = listaTareas;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            using (var connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                connection.CreateTable<Tarea>();
                var tareaCompletar = (sender as MenuItem).CommandParameter as Tarea;
                tareaCompletar.Completa = true;

                connection.Update(tareaCompletar);

                List<Tarea> listaTareasFiltrada = connection.Table<Tarea>().Where(item => !item.Completa).ToList();
                listaTareasListView.ItemsSource = listaTareasFiltrada;
            }
        }
    }
}