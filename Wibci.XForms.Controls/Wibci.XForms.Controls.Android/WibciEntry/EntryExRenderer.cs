using Android.Content;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Wibci.XForms.Controls;
using Wibci.XForms.Controls.Droid.WibciEntry;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryEx), typeof(EntryExRenderer))]
namespace Wibci.XForms.Controls.Droid.WibciEntry
{
	public class EntryExRenderer : EntryRenderer
	{
		public EntryExRenderer(Context context) : base (context)
		{

		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control != null && e.PropertyName == EntryEx.IsValidProperty.PropertyName && Element is EntryEx entry)
			{
				var isValid = entry.IsValid;
				SetBackgroundAttributes(isValid);
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement == null)
				return;

			//TODO: TextColor property
			Control.SetTextColor(Color.Black.ToAndroid());			
			SetBackgroundAttributes(true);
		}

		private void SetBackgroundAttributes(bool isValid)
		{
			GradientDrawable shape = new GradientDrawable();
			shape.SetShape(ShapeType.Rectangle);
			shape.SetCornerRadius(10);
			shape.SetColor(Color.White.ToAndroid());

			if (!((EntryEx)Element).IsValid)
			{
				shape.SetStroke(3, Color.Red.ToAndroid());
			}
			else
			{
				shape.SetStroke(3, Android.Graphics.Color.LightGray);
			}
			Control.SetBackground(shape);
		}
	}
}