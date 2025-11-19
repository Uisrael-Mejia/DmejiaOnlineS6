using System.Net;

namespace DmejiaOnlineS6.Views;

public partial class vistaAgregar : ContentPage
{
	public vistaAgregar()
	{
		InitializeComponent();
	}

   

    private void btnGuardar_Clicked_1(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);

			cliente.UploadValues("http://192.168.0.102:8080/wsestudiante/restEstudiantes.php","POST", parametros);
			DisplayAlert("Alerta", "Estudiante Agregado", "OK");
			Navigation.PushAsync(new vistaEstudiante());
        }
		catch (Exception ex)
		{

			Console.Write("Error: " + ex);
		}
    }
}