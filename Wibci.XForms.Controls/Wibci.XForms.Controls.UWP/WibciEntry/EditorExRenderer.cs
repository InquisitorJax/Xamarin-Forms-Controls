﻿using System.ComponentModel;
using Wibci.XForms.Controls;
using Wibci.XForms.Controls.UWP.WibciEntry;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(EditorEx), typeof(EditorExRenderer))]
namespace Wibci.XForms.Controls.UWP.WibciEntry
{
	public class EditorExRenderer : EditorRenderer
	{
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control != null && e.PropertyName == EntryEx.IsValidProperty.PropertyName && Element is EditorEx entry)
			{
				//TODO: ValidationColor property with default of red
				var isValid = entry.IsValid;
				var validationColor = new SolidColorBrush(Color.Red.ToWindowsColor()); ;
				var normalColor = new SolidColorBrush(Color.LightGray.ToWindowsColor());
				Control.BorderBrush = isValid ? normalColor : validationColor;
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);
			if (Control == null)
				return;

			//TODO: TextColor property with default of black
			Control.BorderBrush = new SolidColorBrush(Color.LightGray.ToWindowsColor());
			Control.BorderThickness = new Windows.UI.Xaml.Thickness(1);
			//Control.CornerRadius = 5;
			Control.Background = new SolidColorBrush(Color.White.ToWindowsColor());
			Control.Foreground = new SolidColorBrush(Color.Black.ToWindowsColor());
		}

	}
}
