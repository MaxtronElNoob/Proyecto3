using Proyecto3_pago.ViewModels;
using Proyecto3_pago.DataBases;

namespace Proyecto3_pago;

public partial class AddTransaction : ContentPage
{
    TransactionDatabase database;
    public AddTransaction(TransaccionesViewModel viewModel, TransactionDatabase transactionDatabase)
    {
        InitializeComponent();
        BindingContext = viewModel;
        database = transactionDatabase;

    }
}

