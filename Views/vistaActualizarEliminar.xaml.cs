using DmejiaOnlineS6.Models;
using System.Net;

namespace DmejiaOnlineS6.Views;

public partial class vistaActualizarEliminar : ContentPage
{
	public vistaActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
    }

    

    private async void btnActualizar_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            HttpClient client = new HttpClient();
            string url = $"http://192.168.0.102:8080/wsestudiante/restEstudiantes.php?codigo={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";


            var parametros = new Dictionary<string, string>
        {
            { "codigo", txtCodigo.Text },
            { "nombre", txtNombre.Text },
            { "apellido", txtApellido.Text },
            { "edad", txtEdad.Text }
        };

            var content = new FormUrlEncodedContent(parametros);

            
            var response = await client.PutAsync(url + "?codigo=" + txtCodigo.Text, content);
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("OK", "Estudiante actualizado", "Cerrar");
                Navigation.PushAsync(new vistaEstudiante());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmar", "¿Eliminar estudiante?", "Sí", "No");

        if (!confirm) return;

        try
        {
            HttpClient client = new HttpClient();
            var url = $"http://192.168.0.102:8080/wsestudiante/restEstudiantes.php?codigo={txtCodigo.Text}";


       
            var response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("OK", "Estudiante eliminado", "Cerrar");
                Navigation.PushAsync(new vistaEstudiante());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo eliminar", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}