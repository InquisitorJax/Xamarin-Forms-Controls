using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Wibci.XForms.Controls.Droid.WibciEntry;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Wibci")]
[assembly: ExportEffect(typeof(ClearEntryEffect), nameof(ClearEntryEffect))]
namespace Wibci.XForms.Controls.Droid.WibciEntry
{
	//doc: https://github.com/jimbobbennett/Effects/blob/master/src/Effects.Android/Effects/ClearEntryEffect.cs

	[Preserve(AllMembers = true)]
	public class ClearEntryEffect : PlatformEffect
	{
		public static void SetClearIcon(EditText editText, bool showIcon)
		{
			if (showIcon)
			{
				editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.ic_clear_icon, 0);
			}
			else
			{
				editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, 0, 0);
			}
		}

		protected override void OnAttached()
		{
			ConfigureControl();
		}

		protected override void OnDetached()
		{
			var editText = (EditText)Control;
			editText.FocusChange -= EditText_FocusChange;
		}

		private void ConfigureControl()
		{
			var editText = Control as EditText;
			if (editText == null)
				return;

			editText.SetOnTouchListener(new OnDrawableTouchListener());
			editText.AddTextChangedListener(new OnTextChangedListener(editText));
			editText.FocusChange += EditText_FocusChange;
		}

		private void EditText_FocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
		{
			var editText = (EditText)sender;
			bool showIcon = e.HasFocus == true && !string.IsNullOrEmpty(editText.Text);
			SetClearIcon(editText, showIcon);
		}
	}

	public class OnTextChangedListener : Java.Lang.Object, ITextWatcher
	{
		private readonly EditText _editText;

		public OnTextChangedListener(EditText editText)
		{
			_editText = editText;
		}

		public void AfterTextChanged(IEditable s)
		{
		}

		public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
		{
		}

		public void OnTextChanged(ICharSequence s, int start, int before, int count)
		{
			ClearEntryEffect.SetClearIcon(_editText, s.Length() > 0);
		}
	}

	public class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
	{
		public bool OnTouch(Android.Views.View v, MotionEvent e)
		{
			if (v is EditText && e.Action == MotionEventActions.Up)
			{
				var editText = (EditText)v;
				var drawable = editText.GetCompoundDrawables()[2];
				
				if (drawable != null)
				{
					if (e.RawX >= (editText.Right - drawable.Bounds.Width()))
					{
						editText.Text = string.Empty;
						return true;
					}
				}
			}

			return false;
		}
	}
}