using System.Drawing;
using UIKit;
using Wibci.XForms.Controls.EntrySuggestions;
using Wibci.XForms.Controls.iOS.EntrySuggestions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(KeyboardEntry), typeof(KeyboardEntryRenderer))]

namespace Wibci.XForms.Controls.iOS.EntrySuggestions
{
	public class KeyboardEntryRenderer : EntryRenderer
	{
		private KeyPressUITextField _textField;
		protected override UITextField CreateNativeControl()
		{
			// https://github.com/xamarin/Xamarin.Forms/blob/master/Xamarin.Forms.Platform.iOS/Renderers/EntryRenderer.cs
			_textField = new KeyPressUITextField(RectangleF.Empty)
			{
				BorderStyle = UITextBorderStyle.RoundedRect,
				ClipsToBounds = true
			};
			_textField.KeyPressed += TextField_KeyPressed;
			return _textField;
		}

		private void TextField_KeyPressed(object sender, KeyPressEventArgs e)
		{
			if (Element != null && Element is KeyboardEntry entry)
			{
				entry.OnKeyPressed(e.KeyCode, e.Key);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (_textField != null)
			{
				_textField.KeyPressed -= TextField_KeyPressed;
				_textField = null;
			}
			base.Dispose(disposing);
		}

	}
}