using KerridgeAsessment.ViewModels;

namespace KerridgeAsessment.Views;

public partial class PlacePage : ContentPage
{
	public PlacePage(PlaceViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
		
	}
}