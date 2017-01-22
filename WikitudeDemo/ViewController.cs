using System;
using Foundation;

using UIKit;
using Wikitude.Architect;


namespace WikitudeDemo
{
	public partial class ViewController : UIViewController
	{
		protected WTArchitectView arView;
		protected WTNavigation wtNav;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			NSError error;
			if (WTArchitectView.IsDeviceSupportedForRequiredFeatures(WTFeatures.WTFeature_2DTracking, out error))
			{
				arView = new WTArchitectView();
				arView.Frame = UIScreen.MainScreen.Bounds;

				arView.SetLicenseKey("YOUR_LICENSE_KEY");

				var url = NSBundle.MainBundle.BundleUrl.AbsoluteString + "ARchitectWorld/index.html";
				wtNav = arView.LoadArchitectWorldFromURL(new NSUrl(url), WTFeatures.WTFeature_2DTracking);

				View.AddSubview(arView);
			}
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (arView != null)
			{
				arView.Start(null, null);
			}
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			if (arView != null)
				arView.Stop();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
