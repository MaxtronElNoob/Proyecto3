using Proyecto3_pago.ViewModels;
using Proyecto3_pago.DataBases;

namespace Proyecto3_pago;

public partial class MainPage : ContentPage
{
    TransactionDatabase database;
    public MainPage(UserInfoViewModel viewModel, TransactionDatabase transactionDatabase)
    {
        InitializeComponent();
        BindingContext = viewModel;
        database = transactionDatabase;
        _ = viewModel.LoadUserAsync(); // Esto lo ejecuta al cargar la página
    }
}

