using Proyecto3_pago.Models;
using Proyecto3_pago.ViewModels;

namespace Proyecto3_pago;

public partial class AddTransaction : ContentPage
{
    public AddTransaction(TransactionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

