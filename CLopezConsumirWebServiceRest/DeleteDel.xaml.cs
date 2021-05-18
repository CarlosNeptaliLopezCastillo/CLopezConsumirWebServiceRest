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
    public partial class DeleteDel : ContentPage
    {
        public DeleteDel()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigoDel.Text);

                cliente.UploadValues("http://192.168.1.104/moviles/post.php?codigo="+ txtCodigoDel.Text, "DELETE", parametros);

                var mensaje = "Dato eliminado con exito";
                DependencyService.Get<Mensaje>().LongAlert(mensaje.ToString());

                //txtCodigoDel.Text = "";
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