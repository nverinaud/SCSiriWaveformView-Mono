//
//  Author:
//       Nicolas VERINAUD <n.verinaud@gmail.com>
//
//  Copyright (c) 2015 Nicolas Verinaud. All Rights Reserved.
//
using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SC
{
    [BaseType(typeof(UIView))]
    interface SCSiriWaveformView
    {
        [Export ("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        /// <summary>
        /// The total number of waves.
        /// Default: 5.
        /// </summary>
        [Export("numberOfWaves")]
        nuint NumberOfWaves { get; set; }

        /// <summary>
        /// Color to use when drawing the waves.
        /// Default: white.
        /// </summary>
        [Export("waveColor")]
        UIColor WaveColor { get; set; }

        /// <summary>
        /// Line width used for the proeminent wave.
        /// Default: 3.0f.
        /// </summary>
        [Export("primaryWaveLineWidth")]
        nfloat PrimaryWaveLineWidth { get; set; }

        /// <summary>
        /// Line width used for all secondary waves.
        /// Default: 1.0f.
        /// </summary>
        [Export("secondaryWaveLineWidth")]
        nfloat SecondaryWaveLineWidth { get; set; }

        /// <summary>
        /// The amplitude that is used when the incoming amplitude is near zero.
        /// Setting a value greater 0 provides a more vivid visualization.
        /// Default: 0.01.
        /// </summary>
        [Export("idleAmplitude")]
        nfloat IdleAmplitude { get; set; }

        /// <summary>
        /// The frequency of the sinus wave. The higher the value, the more sinus wave peaks you will have.
        /// Default: 1.5.
        /// </summary>
        [Export("frequency")]
        nfloat Frequency { get; set; }

        /// <summary>
        /// The current amplitude.
        /// </summary>
        [Export("amplitude")]
        nfloat Amplitude { get; }

        /// <summary>
        /// The lines are joined stepwise, the more dense you draw, the more CPU power is used.
        /// Default: 5.
        /// </summary>
        [Export("density")]
        nfloat Density { get; set; }

        /// <summary>
        /// The phase shift that will be applied with each level setting.
        /// Change this to modify the animation speed or direction.
        /// Default: -0.15.
        /// </summary>
        [Export("phaseShift")]
        nfloat PhaseShift { get; set; }

        /// <summary>
        /// Tells the waveform to redraw itself using the given level (normalized value).
        /// </summary>
        /// <param name="level">Level (normalized value).</param>
        [Export("updateWithLevel:")]
        void UpdateWithLevel(nfloat level);
    }
}