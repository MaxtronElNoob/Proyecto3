// using CommunityToolkit.Mvvm.ComponentModel;
// using CommunityToolkit.Mvvm.Input;
// using Proyecto3_pago.Models;
// using Proyecto3_pago.DataBases;
// using Proyecto3_pago.DataBases.Models;

// namespace Proyecto3_pago.ViewModels;

// public partial class TransactionViewModel : ObservableObject {
// 	[ObservableProperty]
// 	private List<Transaccion> listaTransacciones;
// 	public Transaccion new_transaction;
// 	private Usuario? usuario;
// 	public double Balance => usuario?.Ingresos - usuario?.Egresos ?? 0;
// 	private readonly TransactionDatabase _database;
	
// 	public TransactionViewModel(TransactionDatabase database) {
// 		_database = database;
// 		listaTransacciones = new List<Transaccion>();
// 		new_transaction = new Transaccion();
// 		InitializeAsync();
// 	}

// 	private async void InitializeAsync() {
// 		User user = await _database.GetUserAsync(0);
// 		if (user != null) {
// 			usuario = new Usuario {
// 				Id = user.ID,
// 				Nombre = user.Name,
// 				Ingresos = user.Earnings,
// 				Egresos = user.Spending
// 			};
// 		}
// 		else {
// 			usuario = new Usuario {
// 				Id = 0,
// 				Nombre = "Alonso Herrera",
// 				Ingresos = 0,
// 				Egresos = 0
// 			};
// 		}
// 		List<Transaction> transactions = await _database.GetTransactionsAsync();
// 		ListaTransacciones = transactions.Select(t => new Transaccion
// 		{
// 			Monto = t.Amount,
// 			Glosa = t.Detail,
// 			Fecha = t.Date,
// 			es_ingreso = t.IsEarning
// 		}).ToList();
// 		OnPropertyChanged(nameof(Balance));
// 	}

// 	[RelayCommand]
// 	private async Task UploadTransaction() {
// 		ListaTransacciones.Add(new_transaction);

// 		if (usuario != null)
// 		{
// 			if (new_transaction.es_ingreso) {
// 				usuario.Ingresos += new_transaction.Monto;
// 			}
// 			else {
// 				usuario.Egresos += new_transaction.Monto;
// 			}
// 		}

// 		//Aqui deberia haber un async para subirlo a la base de datos el new_transaction
// 		var dbTransaction = new DataBases.Models.Transaction
// 		{
// 			// Map properties from new_transaction to dbTransaction
// 			Amount = (int)new_transaction.Monto,
// 			Detail = new_transaction.Glosa ?? string.Empty,
// 			Date = new_transaction.Fecha,
// 			IsEarning = new_transaction.es_ingreso
// 			// Add other property mappings as needed
// 		};
// 		await _database.SaveTransactionAsync(dbTransaction);

// 		//Reset de new_transaction
// 		new_transaction.es_ingreso = false;
// 		new_transaction.Fecha = DateTime.Today;
// 		new_transaction.Glosa = "";
// 		new_transaction.Monto = 0;

// 		await Shell.Current.GoToAsync(nameof(MainPage));
// 	}

// 	[RelayCommand]
// 	private async Task GoToAddTransaction() {
// 		await Shell.Current.GoToAsync(nameof(AddTransaction));
// 	}
// }

using Proyecto3_pago.DataBases.Models;
using Proyecto3_pago.DataBases; // Add this line if AppDbContext is in this namespace
using System.ComponentModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace Proyecto3_pago.ViewModels;

public partial class TransaccionesViewModel : INotifyPropertyChanged
{
    private readonly TransactionDatabase database;

    public TransaccionesViewModel()
    {
        database = new TransactionDatabase();
        NuevaTransaccion = new Transaction();
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        user = await database.GetUserAsync(1);
        if (user == null)
        {
            user = new User { Name = "Alonso Herrera", Earnings = 0, Spending = 0 };
            await database.SaveUserAsync(user);
        }
    }
    public User user;
    public Transaction NuevaTransaccion { get; set; }

    public Command GuardarTransaccionCommand => new Command(async () => await GuardarTransaccion());

    public event PropertyChangedEventHandler PropertyChanged;

    private async Task GuardarTransaccion()
    {
        try
        {
            await database.SaveTransactionAsync(NuevaTransaccion);

            if (NuevaTransaccion.IsEarning)
            {
                user.Earnings += NuevaTransaccion.Amount;
            }
            else
            {
                user.Spending += NuevaTransaccion.Amount;
            }
            
            await database.SaveUserAsync(user);
            // Limpiar formulario o notificar éxito
            NuevaTransaccion = new Transaction();
            OnPropertyChanged(nameof(NuevaTransaccion));
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al guardar transacción: {ex.Message}"); // Manejo de errores
        }
    }

    protected void OnPropertyChanged(string nombre) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));

    [RelayCommand]
	private async Task GoToAddTransaction() {
		await Shell.Current.GoToAsync(nameof(AddTransaction));
	}
}