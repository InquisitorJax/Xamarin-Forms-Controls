using System;
using System.ComponentModel;
using UIKit;
using Wibci.XForms.Controls;
using Wibci.XForms.Controls.iOS.WibciEntry;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryEx), typeof(EntryExRenderer))]
namespace Wibci.XForms.Controls.iOS.WibciEntry
{
	public class EntryExRenderer : EntryRenderer
	{
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control != null && e.PropertyName == nameof(EntryEx.IsValid) && Element is EntryEx entry)
			{
				//TODO: ValidationColor property with default of red
				var isValid = entry.IsValid;
				var validationColor = Color.Red;
				Control.Layer.BorderWidth = isValid ? 0 : 1;
				Control.Layer.BorderColor = validationColor.ToCGColor();
				Control.Layer.BorderColor = isValid ? UIColor.LightGray.CGColor : validationColor.ToCGColor();				
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			//TODO: TextColor property with default of black

			Control.Layer.BorderWidth = new nfloat(0.8);
			//Control.Layer.CornerRadius = 5;
			Control.BorderStyle = UITextBorderStyle.RoundedRect;
			Control.BackgroundColor = UIColor.White;
			Control.TextColor = UIColor.Black;
		}
	}
}