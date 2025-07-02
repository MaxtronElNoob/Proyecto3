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
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is UserInfoViewModel vm)
            await vm.LoadUserAsync();
    }
}

