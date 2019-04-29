using Android.Content;
using Wibci.XForms.Controls.Droid.WibciEntry;
using Wibci.XForms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

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
			if (isValid)
			{
				Control.Background = Context.GetDrawable(Resource.Drawable.EditorEx);
			}
			else
			{
				Control.Background = Context.GetDrawable(Resource.Drawable.EditorExError);
			}
		}
	}
}