using Xamarin.Forms;

namespace Wibci.XForms.Controls
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			BindingContext = new MainViewModel();
			InitializeComponent();
		}
	}
}
