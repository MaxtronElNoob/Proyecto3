using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace MauiApp2_Tips;

public partial class TransactionViewModel : ObservableObject
{
	[ObservableProperty]
	private List<Transaccion>? listaTransacciones;

	public double Ingresos => ListaTransacciones?.Sum(t => t.Tipo == TipoTransaccion.Ingreso ? t.Monto : 0) ?? 0;
	public double Egresos => ListaTransacciones?.Sum(t => t.Tipo == TipoTransaccion.Retiro ? t.Monto : 0) ?? 0;
	public double Balance => Ingresos - Egresos;
	public string Nombre;
	public string Apellido;


	private
	

	// public int tipAmount => (int)Math.Round(subtotal * Bill.TipPercent);
	// public int perPersonAmount => subtotal + tipAmount;
	// public string TipPercentText => $"{Math.Round(Bill.TipPercent * 100)}%";

	// public string BillTotalText
	// {
	// 	get => Bill.BillTotal.ToString();
	// 	set
	// 	{
	// 		if (int.TryParse(value, out var result))
	// 		{
	// 			Bill.BillTotal = result;
	// 			OnPropertyChanged(nameof(subtotal));
	// 			OnPropertyChanged(nameof(tipAmount));
	// 			OnPropertyChanged(nameof(perPersonAmount));
	// 		}
	// 	}
	// }

	// private void OnBillChanged(object sender, PropertyChangedEventArgs e)
	// {
	// 	Console.WriteLine("Actualizando Valores...");
	// 	OnPropertyChanged(nameof(subtotal));
	// 	OnPropertyChanged(nameof(tipAmount));
	// 	OnPropertyChanged(nameof(perPersonAmount));
	// 	OnPropertyChanged(nameof(TipPercentText));
	// }

	// public BillViewModel()
	// {
	// 	Bill = new RestaurantBill { BillTotal = 0, TipPercent = 0.0, NPeople = 1 };
	// 	Bill.PropertyChanged += OnBillChanged;
	// }

	// [RelayCommand]
	// private void UpdateTip(string? Button_porcentage)
	// {
	// 	Bill.TipPercent = float.Parse(Button_porcentage ?? "0");
	// }

	// [RelayCommand]
	// public void updateTotal(int? Label_total)
	// {
	// 	Bill.BillTotal = Label_total ?? 0;

	// }
	// [RelayCommand]
	// public void updateNPeople(int? Label_people)
	// {
	// 	Bill.NPeople = Label_people ?? 1;
	// }
	// [RelayCommand]
	// public void incrementNPeople()
	// {
	// 	Bill.NPeople++;
	// }
	// [RelayCommand]
	// public void decrementNPeople()
	// {
	// 	if (Bill.NPeople > 1)
	// 	{
	// 		Bill.NPeople--;
	// 	}
	// }

}
