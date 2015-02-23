//
//  Author:
//       Nicolas VERINAUD <n.verinaud@gmail.com>
//
//  Copyright (c) 2015 Nicolas Verinaud. All Rights Reserved.
//
using Foundation;
using UIKit;

namespace SCSiriWaveformViewSample
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            return true;
        }
    }
}