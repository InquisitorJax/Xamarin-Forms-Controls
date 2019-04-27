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
			propertyName: nameof(IsValidProperty),
			returnType: typeof(bool),
			declaringType: typeof(EntryEx),
			defaultValue: true,
			defaultBindingMode: BindingMode.OneWay);

		public bool IsValid
		{
			get { return (bool)GetValue(IsValidProperty); }
			set { SetValue(IsValidProperty, value); }
		}
		
	}
}
