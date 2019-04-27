using Prism.Commands;
using Prism.Mvvm;
using System.Diagnostics;
using System.Windows.Input;

namespace Wibci.XForms.Controls
{
	public class EntryViewModel : BindableBase
    {

		public EntryViewModel()
		{
			ValidateCommand = new DelegateCommand(Validate);
		}

		public ICommand ValidateCommand { get; }

		private string _text;

		public string Text
		{
			get { return _text; }
			set
			{
				SetProperty(ref _text, value);
				ValidationMessage = null;
			}
		}

		private string _validationMessage;

		public string ValidationMessage
		{
			get { return _validationMessage; }
			set { SetProperty(ref _validationMessage, value); }
		}

		private void Validate()
		{
			ValidationMessage = !string.IsNullOrEmpty(Text) ? null : "Text must contain something!";
			Debug.WriteLine($"Validation {ValidationMessage}");
		}

	}
}
