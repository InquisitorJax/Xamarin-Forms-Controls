
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wibci.XForms.Controls.EntrySuggestions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntrySuggestionPage : ContentPage
	{
		private EntrySuggestionViewModel _viewModel;
		public EntrySuggestionPage()
		{
			InitializeComponent();
			_viewModel = new EntrySuggestionViewModel();
			BindingContext = _viewModel;
			_entry.KeyPressed += Entry_KeyPressed;
		}

		private void Entry_KeyPressed(object sender, KeyPressEventArgs e)
		{
			if (e.KeyCode == KeyCode.DownArrow || e.KeyCode == KeyCode.UpArrow)
			{
				if (e.KeyCode == KeyCode.DownArrow)
				{
					_viewModel.SelectNextSuggestionCommand.Execute(null);
				}
				else
				{
					_viewModel.SelectPreviousSuggestionCommand.Execute(null);
				}
			}
		}
	}
}