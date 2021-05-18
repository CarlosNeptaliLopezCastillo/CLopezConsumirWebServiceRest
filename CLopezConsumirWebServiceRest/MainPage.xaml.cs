using CLopezConsumirWebServiceRest.Ws;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CLopezConsumirWebServiceRest
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.104/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<CLopezConsumirWebServiceRest.Ws.Datos> _post;


        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<CLopezConsumirWebServiceRest.Ws.Datos> posts = JsonConvert.DeserializeObject<List<CLopezConsumirWebServiceRest.Ws.Datos>>(content);
                _post = new ObservableCollection<CLopezConsumirWebServiceRest.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertPost());
        }

        private async void btnPost_Clicked(object sender, ItemTappedEventArgs e)
        {
            var datos = e.Item as Datos;
            //var codigo = lblCodigo.Text;
            // var nombre = lblNombre.Text;
            //var apellido = lblApellido.Text;
            //var edad = lblEdad.Text;

            await Navigation.PushAsync(new UpdatePut(datos.codigo, datos.nombre, datos.apellido, datos.edad));//codigo, nombre, apellido, edad));            
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteDel());
        }
    }
}
