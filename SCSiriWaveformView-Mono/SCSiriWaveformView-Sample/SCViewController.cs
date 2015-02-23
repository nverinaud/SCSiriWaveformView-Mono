//
//  Author:
//       Nicolas VERINAUD <n.verinaud@gmail.com>
//
//  Copyright (c) 2015 Nicolas Verinaud. All Rights Reserved.
//
using System;
using AudioToolbox;
using AVFoundation;
using Foundation;
using UIKit;
using System.Diagnostics;
using CoreAnimation;
using CoreGraphics;

namespace SCSiriWaveformViewSample
{
    public partial class SCViewController : UIViewController
    {
        AVAudioRecorder _recorder;

        protected internal SCViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var url = new NSUrl("/dev/null");
            var settings = new AudioSettings {
                SampleRate = 44100,
                Format = AudioFormatType.AppleLossless,
                NumberChannels = 2,
                EncoderAudioQualityForVBR = AVAudioQuality.Min
            };
            NSError err;

            _recorder = AVAudioRecorder.Create(url, settings, out err);

            if (err != null)
            {
                Debug.WriteLine("Ups, could not create recorder, {0}", err);
                return;
            }

            err = AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.PlayAndRecord);

            if (err != null)
            {
                Debug.WriteLine("Error setting category : {0}", err);
            }

            _recorder.PrepareToRecord();
            _recorder.MeteringEnabled = true;
            _recorder.Record();

            var displayLink = CADisplayLink.Create(UpdateMeters);
            displayLink.AddToRunLoop(NSRunLoop.Current, NSRunLoopMode.Common);
        }

        private void UpdateMeters()
        {
            _recorder.UpdateMeters();

            nfloat normalizedValue = (nfloat)Math.Pow(10, _recorder.AveragePower(0) / 20);

            WaveformView.UpdateWithLevel(normalizedValue);
        }
    }
}