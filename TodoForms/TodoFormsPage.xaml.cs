using Xamarin.Forms;

namespace TodoForms
{
    public partial class TodoFormsPage : ContentPage
    {

        public TodoFormsPage()
        {
            InitializeComponent();
            buttonIniciar.Clicked += ButtonIniciar_Clicked;
        }
        async void ButtonIniciar_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(entryUsuario.Text) || string.IsNullOrEmpty(entryContrasena.Text))
            {
                labelResultado.Text = "Debe escribir usuario y contraseña";
            }
            else
            {
                labelResultado.Text = "Inicio de sesion exitoso";
                await Navigation.PushAsync(new ListaTareas());
            }
        }

    }
}
