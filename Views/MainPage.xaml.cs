using Proyecto3_pago.ViewModels;

namespace Proyecto3_pago;

public partial class MainPage : ContentPage
{
    public MainPage(TransaccionesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

