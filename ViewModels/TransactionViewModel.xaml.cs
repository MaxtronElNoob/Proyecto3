using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto3_pago.Models;
using Proyecto3_pago.DataBases;

namespace Proyecto3_pago.ViewModels;

public partial class TransactionViewModel : ObservableObject {
	[ObservableProperty]
	private List<Transaccion> listaTransacciones;
	public Transaccion new_transaction;
	private Usuario? usuario;
	public double Balance => usuario?.Ingresos - usuario?.Egresos ?? 0;
	private readonly TransactionDatabase _database;
	
	public TransactionViewModel(TransactionDatabase database) {
		_database = database;
		listaTransacciones = new List<Transaccion>();
		new_transaction = new Transaccion();
		InitializeAsync();
	}

	private async void InitializeAsync() {
		var user = await _database.GetUserAsync(0);
		usuario = new Usuario {
			Id = user.ID,
			Nombre = user.Name,
			Ingresos = user.Earnings,
			Egresos = user.Spending
		};
		var transactions = await _database.GetTransactionsAsync();
		ListaTransacciones = transactions.Select(t => new Transaccion
		{
			Monto = t.Amount,
			Glosa = t.Detail,
			Fecha = t.Date,
			es_ingreso = t.IsEarning
		}).ToList();
		OnPropertyChanged(nameof(Balance));
	}

	[RelayCommand]
	private async Task UploadTransaction() {
		ListaTransacciones.Add(new_transaction);

		if (usuario != null)
		{
			if (new_transaction.es_ingreso) {
				usuario.Ingresos += new_transaction.Monto;
			}
			else {
				usuario.Egresos += new_transaction.Monto;
			}
		}

		//Aqui deberia haber un async para subirlo a la base de datos el new_transaction
		var dbTransaction = new Proyecto3_pago.DataBases.Models.Transaction
		{
			// Map properties from new_transaction to dbTransaction
			Amount = (int)new_transaction.Monto,
			Detail = new_transaction.Glosa ?? string.Empty,
			Date = new_transaction.Fecha,
			IsEarning = new_transaction.es_ingreso
			// Add other property mappings as needed
		};
		await _database.SaveTransactionAsync(dbTransaction);

		//Reset de new_transaction
		new_transaction.es_ingreso = false;
		new_transaction.Fecha = DateTime.Today;
		new_transaction.Glosa = "";
		new_transaction.Monto = 0;

		await Shell.Current.GoToAsync(nameof(MainPage));
	}

	[RelayCommand]
	private async Task GoToAddTransaction() {
		await Shell.Current.GoToAsync(nameof(AddTransaction));
	}
}
