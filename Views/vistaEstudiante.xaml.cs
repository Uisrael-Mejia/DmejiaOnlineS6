using DmejiaOnlineS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace DmejiaOnlineS6.Views;

public partial class vistaEstudiante : ContentPage
{
	private const string Url = "http://192.168.0.102:8080/wsestudiante/restEstudiantes.php"; // url de la api php - colocar la ip   192.168.0.103
    private HttpClient client = new HttpClient();
	private ObservableCollection<Estudiante> _estudiantes;

	public async void Mostrar()
	{
		var content = await client.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		_estudiantes = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = _estudiantes;
	}
    public vistaEstudiante()
	{
		InitializeComponent();
		Mostrar();
    }

    

    private void btnAgregar_Clicked_1(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vistaAgregar());
    }


    private void listaEstudiantes_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
    {
        var objetoestudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vistaActualizarEliminar(objetoestudiante));
    }
}