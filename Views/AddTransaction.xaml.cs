using Proyecto3_pago.Models;

namespace Proyecto3_pago;

public partial class AddTransaction : ContentPage
{
    public AddTransaction()
    {
        InitializeComponent();
        BindingContext = new Transaccion();
    }
}

