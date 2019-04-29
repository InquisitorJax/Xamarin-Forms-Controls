
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wibci.XForms.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WibciEntry : ContentView
	{
		public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), 
			typeof(string), 
			typeof(WibciEntry), 
			null, 
			BindingMode.TwoWay, 
			propertyChanged: OnEntryTextChanged);

		public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), 
			typeof(bool), 
			typeof(WibciEntry), 
			false, 
			BindingMode.Default, 
			null, 
			(bindable, oldValue, newValue) =>
			{
				var ctrl = (WibciEntry)bindable;
				ctrl.IsPassword = (bool)newValue;
			});


		public static readonly BindableProperty IsMultiLineProperty = BindableProperty.Create(nameof(IsMultiLine),
			typeof(bool),
			typeof(WibciEntry),
			false,
			BindingMode.Default,
			null,
			(bindable, oldValue, newValue) =>
			{
				var ctrl = (WibciEntry)bindable;
				ctrl.IsPassword = (bool)newValue;
			});

		public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), 
			typeof(string), 
			typeof(WibciEntry), 
			null);

		public static readonly BindableProperty ValidationTextProperty = BindableProperty.Create(nameof(ValidationText), 
			typeof(string), 
			typeof(WibciEntry),
			null,
			BindingMode.OneWay,
			propertyChanged: OnValidationTextPropertyChanged);

		public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), 
			typeof(Keyboard), 
			typeof(WibciEntry), 
			Keyboard.Default,
			BindingMode.Default, 
			null, 
			(bindable, oldValue, newValue) =>
			{
				var ctrl = (WibciEntry)bindable;
				ctrl._entry.Keyboard = (Keyboard)newValue;
				ctrl._editor.Keyboard = (Keyboard)newValue;
			});


		public WibciEntry ()
		{
			InitializeComponent ();
			_entry.Focused += Entry_Focused;
			_entry.Unfocused += Entry_Unfocused;

		}

		public string EntryText
		{
			get { return (string)GetValue(EntryTextProperty); }
			set { SetValue(EntryTextProperty, value); }
		}

		public bool IsPassword
		{
			get { return (bool)GetValue(Entry.IsPasswordProperty); }
			set
			{
				SetValue(Entry.IsPasswordProperty, value);
				_entry.IsPassword = value;
			}
		}

		public bool IsMultiLine
		{
			get => (bool)GetValue(IsMultiLineProperty);
			set => SetValue(IsMultiLineProperty, value);
		}

		public Keyboard Keyboard
		{
			get { return (Keyboard)GetValue(KeyboardProperty); }
			set { SetValue(KeyboardProperty, value); }
		}

		public string LabelText
		{
			get { return (string)GetValue(LabelTextProperty); }
			set { SetValue(LabelTextProperty, value); }
		}

		public string ValidationText
		{
			get { return (string)GetValue(ValidationTextProperty); }
			set { SetValue(ValidationTextProperty, value); }
		}

		private static async void OnEntryTextChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var entry = (WibciEntry)bindable;
			if (!string.IsNullOrEmpty((string)newValue))
			{
				double yTranslate = -20;
				if (Device.RuntimePlatform == Device.UWP)
				{
					yTranslate = -25;
				}
				await Task.WhenAll(
						entry._label.TranslateTo(-2, yTranslate, 350, Easing.Linear),
						entry._label.FadeTo(1, 350, Easing.Linear)
					);
			}
			else
			{
				await Task.WhenAll(
					entry._label.TranslateTo(-2, 5),
					entry._label.FadeTo(0)
				);				
			}
		}

		private static void OnValidationTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is WibciEntry entry)
			{
				string validationText = newValue as string;
				bool isValid = string.IsNullOrEmpty(validationText);
				entry._entry.SetValue(EntryEx.IsValidProperty, isValid);

				var opacity = isValid ? 0 : 1;
				var endHeight = isValid ? 0 : 35;
				var startHeight = isValid ? 35 : 0;
				var animate = new Animation(d => entry._validationGrid.HeightRequest = d, startHeight, endHeight, Easing.SpringIn);
				animate.Commit(entry, "animate!", length: 350);
				Task.Run(async () => await entry._validationGrid.FadeTo(opacity, 350));
			}
		}

		private void Entry_Focused(object sender, FocusEventArgs e)
		{
			_label.TextColor = Color.Accent;
		}

		private void Entry_Unfocused(object sender, FocusEventArgs e)
		{
			_label.TextColor = Color.Default;
		}

		private void ClearText_Tapped(object sender, EventArgs e)
		{
			_entry.Text = null;
		}
	}
}