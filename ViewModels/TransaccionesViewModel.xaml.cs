using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto3_pago.DataBases.Models;
using Proyecto3_pago.DataBases; // Add this line if AppDbContext is in this namespace
using System.Diagnostics;

namespace Proyecto3_pago.ViewModels;

public partial class TransaccionesViewModel : ObservableObject
{
    private TransactionDatabase database;
    private Transaction nuevaTransaccion = new Transaction();
    public Transaction NuevaTransaccion
    {
        get => nuevaTransaccion;
        set
        {
            SetProperty(ref nuevaTransaccion, value);
        }
    }

    public TransaccionesViewModel(TransactionDatabase db)
    {
        database = db;
        NuevaTransaccion = new Transaction();
    }


    [RelayCommand]
    private async Task GuardarTransaccion()
    {
        try
        {
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
        await Shell.Current.GoToAsync("///MainPage");
    }
}
