using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace Wibci.XForms.Controls
{
	public class MainViewModel : BindableBase
    {

		public MainViewModel()
		{
			OpenEntryPageCommand = new DelegateCommand(OpenEntryPage);

		}

		private void OpenEntryPage()
		{
			App.Current.MainPage.Navigation.PushAsync(new EntryPage());
		}

		public ICommand OpenEntryPageCommand { get; }

	}
}
