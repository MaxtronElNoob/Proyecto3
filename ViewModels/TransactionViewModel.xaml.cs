using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto3_pago.Models;

namespace Proyecto3_pago.ViewModels;

public partial class TransactionViewModel : ObservableObject
{
	[ObservableProperty]
	private List<Transaccion> listaTransacciones;

	public Transaccion new_transaction;

	private Usuario usuario;

	public double Balance => usuario.Ingresos - usuario.Egresos;

	public TransactionViewModel()
	{
		usuario = new Usuario { Nombre = "Juan", Apellido = "Perez", Ingresos = 0, Egresos = 0 };
		listaTransacciones = new List<Transaccion>();
		new_transaction = new Transaccion();
	}

	[RelayCommand]
	private async Task UploadTransaction()
	{
		ListaTransacciones.Add(new_transaction);

		if (new_transaction.es_ingreso)
		{
			usuario.Ingresos += new_transaction.Monto;
		}
		else
		{
			usuario.Egresos += new_transaction.Monto;
		}

		//Aqui deberia haber un async para subirlo a la base de datos el new_transaction

		//Reset de new_transaction
		new_transaction.es_ingreso = false;
		new_transaction.Fecha = DateTime.Today;
		new_transaction.Glosa = "";
		new_transaction.Monto = 0;

		await Shell.Current.GoToAsync(nameof(MainPage));
	}

	[RelayCommand]
	private async Task GoToAddTransaction()
	{
		await Shell.Current.GoToAsync(nameof(AddTransaction));
	}
}
