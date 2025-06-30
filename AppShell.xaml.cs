namespace Proyecto3_pago;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddTransaction), typeof(AddTransaction));
	}
}
