
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wibci.XForms.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryPage : ContentPage
	{
		public EntryPage ()
		{
			BindingContext = new EntryViewModel();
			InitializeComponent ();
		}
	}
}