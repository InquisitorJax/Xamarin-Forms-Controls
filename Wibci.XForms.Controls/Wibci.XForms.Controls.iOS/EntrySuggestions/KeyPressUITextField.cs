using CoreGraphics;
using Foundation;
using System;
using System.Linq;
using UIKit;
using Wibci.XForms.Controls.EntrySuggestions;

namespace Wibci.XForms.Controls.iOS.EntrySuggestions
{
	public class KeyPressUITextField : UITextField
	{
		// doc: https://www.hackingwithswift.com/example-code/uikit/how-to-detect-keyboard-input-using-pressesbegan-and-pressesended

		public event EventHandler<KeyPressEventArgs> KeyPressed;

		public KeyPressUITextField()
		{
		}

		public KeyPressUITextField(CGRect frame) : base(frame)
		{
		}

		public KeyPressUITextField(NSCoder coder) : base(coder)
		{
		}

		public KeyPressUITextField(NSObjectFlag t) : base(t)
		{
		}

		public KeyPressUITextField(System.IntPtr handle) : base(handle)
		{
		}

		public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
		{
			base.PressesBegan(presses, evt);
			var pressesList = presses.ToArray().ToList();
			var firstPress = pressesList.FirstOrDefault();

			if (firstPress != null)
			{
				var keyCode = KeyCode.Unknown;

				switch (firstPress.Key.KeyCode)
				{
					case UIKeyboardHidUsage.KeyboardUpArrow:
						keyCode = KeyCode.UpArrow;
						break;
					case UIKeyboardHidUsage.KeyboardDownArrow:
						keyCode = KeyCode.DownArrow;
						break;
				}

				if (keyCode != KeyCode.Unknown)
				{
					KeyPressed?.Invoke(this, new KeyPressEventArgs(keyCode, firstPress.Key.Characters));
				}
			}
		}
	}
}