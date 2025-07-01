using Proyecto3_pago.ViewModels; // Add this line or the correct namespace for TransactionViewModel
using Proyecto3_pago.DataBases; // Add this line or replace with the correct namespace for TransactionDatabase

namespace Proyecto3_pago;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}