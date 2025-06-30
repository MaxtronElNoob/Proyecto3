using Proyecto3_pago.ViewModels;

namespace Proyecto3_pago;

public partial class AddTransaction : ContentPage
{
    public AddTransaction(TransaccionesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

