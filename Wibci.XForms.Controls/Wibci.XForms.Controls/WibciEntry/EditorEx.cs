using Xamarin.Forms;

namespace Wibci.XForms.Controls
{
	public class EditorEx : Editor
    {
		public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
			propertyName: nameof(IsValid),
			returnType: typeof(bool),
			declaringType: typeof(EditorEx),
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
