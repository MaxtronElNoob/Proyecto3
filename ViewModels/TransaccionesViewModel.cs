using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto3_pago.DataBases.Models;
using Proyecto3_pago.DataBases; // Add this line if AppDbContext is in this namespace
using System.Diagnostics;

namespace Proyecto3_pago.ViewModels;

public partial class TransaccionesViewModel : ObservableObject
{
    private TransactionDatabase database;

    [ObservableProperty]
    private Transaction nuevaTransaccion = new();

    public TransaccionesViewModel(TransactionDatabase db)
    {
        database = db;
    }


    [RelayCommand]
    private async Task GuardarTransaccion()
    {
        try
        {
            Debug.WriteLine($"Guardando transaccion..."); // Manejo de errores
            NuevaTransaccion.UserId = 1;
            await database.SaveTransactionAsync(NuevaTransaccion);
            // Limpiar formulario o notificar éxito
            NuevaTransaccion = new Transaction();
            OnPropertyChanged(nameof(NuevaTransaccion));
            await GoToAddTransaction();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al guardar transacción: {ex.Message}"); // Manejo de errores
        }
    }

    [RelayCommand]
    private async Task GoToAddTransaction()
    {
        NuevaTransaccion = new Transaction();
        await Shell.Current.GoToAsync("///MainPage");
    }
}
