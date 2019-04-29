using Xamarin.Forms;

namespace Wibci.XForms.Controls
{
	/// <summary>
	/// Entry class that could have platform specific custom renderers 
	/// </summary>
	public class EntryEx : Entry
	{
		//doc: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/entry

		public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
			propertyName: nameof(IsValid),
			returnType: typeof(bool),
			declaringType: typeof(EntryEx),
			defaultValue: true,
			defaultBindingMode: BindingMode.OneWay);

		public static readonly BindableProperty ValidationColorProperty = BindableProperty.Create(
			propertyName: nameof(ValidationColor),
			returnType: typeof(Color),
			declaringType: typeof(EntryEx),
			defaultValue: Color.Red,
			defaultBindingMode: BindingMode.OneWay);


		public bool IsValid
		{
			get { return (bool)GetValue(IsValidProperty); }
			set { SetValue(IsValidProperty, value); }
		}

		public Color ValidationColor
		{
			get { return (Color)GetValue(ValidationColorProperty); }
			set { SetValue(ValidationColorProperty, value); }
		}

	}
}
