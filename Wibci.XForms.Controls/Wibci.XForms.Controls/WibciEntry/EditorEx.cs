using Xamarin.Forms;

namespace Wibci.XForms.Controls
{
	public class EditorEx : Editor
    {
		public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
			propertyName: nameof(IsValidProperty),
			returnType: typeof(bool),
			declaringType: typeof(EditorEx),
			defaultValue: true,
			defaultBindingMode: BindingMode.OneWay);


		public bool IsValid
		{
			get { return (bool)GetValue(IsValidProperty); }
			set { SetValue(IsValidProperty, value); }
		}
	
	}
}
