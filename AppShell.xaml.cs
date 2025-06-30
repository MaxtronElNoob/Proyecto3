namespace Proyecto3_pago;

public partial class AppShell : Shell
{
	public AppShell(MainPage mainPage)
	{
		InitializeComponent();
		Items.Add(new ShellContent { Content = mainPage });
		Routing.RegisterRoute(nameof(AddTransaction), typeof(AddTransaction));
	}
}
