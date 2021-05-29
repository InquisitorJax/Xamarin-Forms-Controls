using System;
using Xamarin.Forms;

namespace Wibci.XForms.Controls.EntrySuggestions
{
	public class KeyboardEntry : Entry
	{
		public event EventHandler<KeyPressEventArgs> KeyPressed;

		public void OnKeyPressed(KeyCode keyCode, string key)
		{
			KeyPressed?.Invoke(this, new KeyPressEventArgs(keyCode, key));
		}

	}

	public class KeyPressEventArgs : EventArgs
	{
		public KeyPressEventArgs(KeyCode code, string key)
		{
			KeyCode = code;
			Key = key;
		}

		public KeyCode KeyCode { get; }
		public string Key { get; }
	}

}
