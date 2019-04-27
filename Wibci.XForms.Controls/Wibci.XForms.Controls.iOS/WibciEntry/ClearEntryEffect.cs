
using Foundation;
using UIKit;
using Wibci.XForms.Controls.iOS.WibciEntry;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Wibci")]
[assembly: ExportEffect(typeof(ClearEntryEffect), nameof(ClearEntryEffect))]
namespace Wibci.XForms.Controls.iOS.WibciEntry
{
	//doc: https://github.com/jimbobbennett/Effects/blob/master/src/Effects.iOS/Effects/ClearEntryEffect.cs

	[Preserve(AllMembers = true)]
	public class ClearEntryEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			((UITextField)Control).ClearButtonMode = UITextFieldViewMode.WhileEditing;
		}

		protected override void OnDetached()
		{
		}
	}
}