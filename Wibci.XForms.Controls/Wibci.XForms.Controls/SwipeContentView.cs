using System.Diagnostics;
using Xamarin.Forms;

namespace Wibci.XForms.Controls
{
	public class SwipeContentView : ContentView
	{
		public SwipeContentView()
		{
			GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Left));
			GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Right));
			GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Up));
			GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Down));

		}

		SwipeGestureRecognizer GetSwipeGestureRecognizer(SwipeDirection direction)
		{
			var swipe = new SwipeGestureRecognizer { Direction = direction };
			swipe.Swiped += (sender, e) => OnSwipe(e.Direction);
			return swipe;
		}

		private void OnSwipe(SwipeDirection direction)
		{
			Debug.WriteLine($"=================> SWIPE! {direction}");
		}

	}
}
