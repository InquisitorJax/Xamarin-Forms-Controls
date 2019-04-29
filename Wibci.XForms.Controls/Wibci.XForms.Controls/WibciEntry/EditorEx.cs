using Xamarin.Forms;

namespace Wibci.XForms.Controls
{
	// https://stackoverflow.com/questions/32204361/border-color-for-editor-in-xamarin-forms
	// or https://stackoverflow.com/questions/44995914/how-to-make-rounded-editor-control-in-xamarin-forms
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
