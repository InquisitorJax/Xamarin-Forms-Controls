using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using Wibci.XForms.Controls.EntrySuggestions;

namespace Wibci.XForms.Controls
{
	public class MainViewModel : BindableBase
    {

		public MainViewModel()
		{
			OpenEntryPageCommand = new DelegateCommand(OpenEntryPage);
			OpenKeyboardEntryPageCommand = new DelegateCommand(OpenKeyboardEntryPage);
		}

		public ICommand OpenEntryPageCommand { get; }

		public ICommand OpenKeyboardEntryPageCommand { get; }


		private void OpenEntryPage()
		{
			App.Current.MainPage.Navigation.PushAsync(new EntryPage());
		}

		private void OpenKeyboardEntryPage()
		{
			App.Current.MainPage.Navigation.PushAsync(new EntrySuggestionPage());
		}


	}
}
