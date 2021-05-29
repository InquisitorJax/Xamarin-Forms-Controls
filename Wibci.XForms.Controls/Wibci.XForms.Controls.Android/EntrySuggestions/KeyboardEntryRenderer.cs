using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Wibci.XForms.Controls.Droid.EntrySuggestions;
using Wibci.XForms.Controls.EntrySuggestions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;

[assembly: ExportRenderer(typeof(KeyboardEntry), typeof(KeyboardEntryRenderer))]

namespace Wibci.XForms.Controls.Droid.EntrySuggestions
{
	public class KeyboardEntryRenderer : EntryRenderer
	{
		public KeyboardEntryRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement == null)
				return;

			var editText = Control as EditText;
			var entry = e.NewElement as KeyboardEntry;
			editText.SetOnKeyListener(new OnKeyListener(entry));
		}
	}

	public class OnKeyListener : Java.Lang.Object, IOnKeyListener
	{
		private readonly KeyboardEntry _entry;

		public OnKeyListener(KeyboardEntry entry)
		{
			_entry = entry;
		}

		public bool OnKey(Android.Views.View v, [GeneratedEnum] Keycode keyCode, KeyEvent e)
		{
			// event fires for both up and down
			if (e.Action == KeyEventActions.Down)
			{
				var entryKeyCode = KeyCode.Unknown;

				switch (e.KeyCode)
				{
					case Keycode.DpadUp:
						entryKeyCode = KeyCode.UpArrow;
						break;
					case Keycode.DpadDown:
						entryKeyCode = KeyCode.DownArrow;
						break;
				}

				if (entryKeyCode != KeyCode.Unknown)
				{
					_entry.OnKeyPressed(entryKeyCode, e.KeyCode.ToString());
				}
			}

			return false;
		}
	}
}