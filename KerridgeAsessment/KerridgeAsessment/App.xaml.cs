namespace KerridgeAsessment;

public partial class App : Application
{
	//Ideally we could keep these in Azure key vault or similar.
	public const string AuthBaseUrl = "https://staging.identity.eos.kerridgecs.online/";
	public const string BaseUrl = "https://staging.api.eos.kerridgecs.online/location/";

    public const string ClientID = "94eb850d-448f-48ef-a085-5fee4807606e.apps.kerridgecs.com";
	public const string ClientSecret = "b609f130-2d13-43d4-93df-f8ab9f1cafde";

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
