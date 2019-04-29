using Android.Content;
using Wibci.XForms.Controls.Droid.WibciEntry;
using Wibci.XForms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(EditorEx), typeof(EditorExRenderer))]
namespace Wibci.XForms.Controls.Droid.WibciEntry
{
	public class EditorExRenderer : EditorRenderer
	{
		public EditorExRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				var editor = (EditorEx)Element;
				SetBackgroundAttributes(editor.IsValid);
			}
		}
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control != null && e.PropertyName == EntryEx.IsValidProperty.PropertyName && Element is EditorEx editor)
			{				
				SetBackgroundAttributes(editor.IsValid);
			}
		}

		private void SetBackgroundAttributes(bool isValid)
		{
			GradientDrawable shape = new GradientDrawable();
			shape.SetShape(ShapeType.Rectangle);
			shape.SetCornerRadius(10);
			shape.SetColor(Color.White.ToAndroid());

			var entry = (EditorEx)Element;

			if (!entry.IsValid)
			{
				shape.SetStroke(3, entry.ValidationColor.ToAndroid());
			}
			else
			{
				shape.SetStroke(3, Android.Graphics.Color.LightGray);
			}
			Control.SetBackground(shape);
		}
	}
}