using System;
using System.ComponentModel;
using UIKit;
using Wibci.XForms.Controls;
using Wibci.XForms.Controls.iOS.WibciEntry;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EditorEx), typeof(EditorExRenderer))]
namespace Wibci.XForms.Controls.iOS.WibciEntry
{
	public class EditorExRenderer : EditorRenderer
	{
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control != null && e.PropertyName == EditorEx.IsValidProperty.PropertyName && Element is EditorEx editor)
			{
				//TODO: ValidationColor property with default of red
				var isValid = editor.IsValid;
				var validationColor = Color.Red;
				Control.Layer.BorderColor = isValid ? UIColor.LightGray.CGColor : validationColor.ToCGColor();
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			//TODO: TextColor property with default of black
			Control.Layer.BorderWidth = new nfloat(0.8);
			Control.Layer.CornerRadius = 5;
			Control.BackgroundColor = UIColor.White;
			Control.TextColor = UIColor.Black;
		}

	}
}