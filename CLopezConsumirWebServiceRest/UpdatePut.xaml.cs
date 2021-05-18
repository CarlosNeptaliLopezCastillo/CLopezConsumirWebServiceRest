using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CLopezConsumirWebServiceRest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePut : ContentPage
    {
        public UpdatePut(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigoPut.Text = codigo.ToString();
            txtNombrePut.Text = nombre;
            txtApellidoPut.Text = apellido;
            txtEdadPut.Text = edad.ToString();

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigoPut.Text);
                parametros.Add("nombre", txtNombrePut.Text);
                parametros.Add("apellido", txtApellidoPut.Text);
                parametros.Add("edad", txtEdadPut.Text);

                cliente.UploadValues("http://192.168.1.104/moviles/post.php?codigo="+ txtCodigoPut.Text+"&nombre="+ txtNombrePut.Text + "&apellido="+ txtApellidoPut.Text + "&edad="+ txtEdadPut.Text, "PUT", parametros);

                var mensaje = "Dato actualizado con exito";
                DependencyService.Get<Mensaje>().LongAlert(mensaje.ToString());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}