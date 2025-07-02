using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto3_pago.DataBases.Models;
using Proyecto3_pago.DataBases; // Add this line if AppDbContext is in this namespace
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Proyecto3_pago.ViewModels;

public partial class UserInfoViewModel : ObservableObject
{
    private readonly TransactionDatabase _database;

    [ObservableProperty]
    private ObservableCollection<Transaction> listaTransacciones = new();

    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private double? earnings;

    [ObservableProperty]
    private double? spending;

    public double? Balance => Earnings - Spending;


    public UserInfoViewModel(TransactionDatabase database)
    {
        _database = database;
    }

    private void OnEarningsChanged(double value)
    {
        OnPropertyChanged(nameof(Balance));
    }

    private void OnSpendingChanged(double value)
    {
        OnPropertyChanged(nameof(Balance));
    }

    public async Task LoadUserAsync()
    {
        var user = await _database.GetUserAsync(1);
        if (user != null)
        {
            Name = user.Name;         // Esto dispara OnPropertyChanged y actualiza la UI
            Earnings = user.Earnings;
            Spending = user.Spending;
            OnPropertyChanged(nameof(Balance));
        }
        var transactions = await _database.GetTransactionsByUserAsync(1);
        foreach (var t in transactions)
        {
            Debug.WriteLine($"Transaccion: {t.Amount}, {t.Date}, {t.Detail}");

        }
        ListaTransacciones = new ObservableCollection<Transaction>(transactions);
    }

    [RelayCommand]
    private async Task GoToAddTransaction()
    {
        await Shell.Current.GoToAsync(nameof(AddTransaction));
    }
}

