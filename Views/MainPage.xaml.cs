using Proyecto3_pago.Models;

namespace Proyecto3_pago;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new Transaccion();
	}
}

