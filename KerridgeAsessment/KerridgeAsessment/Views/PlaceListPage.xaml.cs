using KerridgeAsessment.ViewModels;

namespace KerridgeAsessment.Views;

public partial class PlaceListPage : ContentPage
{
	public PlaceListPage(PlaceListViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
		
	}
}