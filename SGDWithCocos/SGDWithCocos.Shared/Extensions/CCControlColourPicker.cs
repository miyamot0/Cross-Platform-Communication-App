﻿using System;

namespace CocosSharp
{
    public class CCControlColourPicker : CCControl
    {
		protected HSV Hsv;


		#region Properties

		public CCControlSaturationBrightnessPicker ColourPicker { get; set; }
		public CCControlHuePicker HuePicker { get; set; }
		public CCSprite Background { get; set; }

		public override CCColor3B Color
		{
			get { return base.Color; }
			set
			{
				base.Color = value;

				RGBA rgba;
				rgba.R = value.R / 255.0f;
				rgba.G = value.G / 255.0f;
				rgba.B = value.B / 255.0f;
				rgba.A = 1.0f;

				Hsv = CCControlUtils.HSVfromRGB(rgba);
				UpdateHueAndControlPicker();
			}
		}

		public override bool Enabled
		{
			get { return base.Enabled; }
			set 
			{
				base.Enabled = value;
				if (HuePicker != null) {
					HuePicker.Enabled = value;
				}
				if (ColourPicker != null) {
					ColourPicker.Enabled = value;
				}
			}
		}

		#endregion Properties


        #region Constructors

        public CCControlColourPicker()
        {
			// Register Touch Event
			var touchListener = new CCEventListenerTouchOneByOne();
			touchListener.IsSwallowTouches = true;
			touchListener.OnTouchBegan = OnTouchBegan;

            AddEventListener(touchListener);

            CCSpriteFrameCache.SharedSpriteFrameCache.AddSpriteFrames("extensions/CCControlColourPickerSpriteSheet.plist");

            Hsv.H = 0;
            Hsv.S = 0;
            Hsv.V = 0;

            // Add image
			Background 
				= CCControlUtils.AddSpriteToTargetWithPosAndAnchor("menuColourPanelBackground.png", this, CCPoint.Zero, CCPoint.AnchorMiddle);

			CCPoint backgroundPointZero 
				= Background.Position - Background.ContentSize.Center;

            // Setup panels
            float hueShift = 8;
            float colourShift = 28;

            CCPoint huePickerPos = new CCPoint(backgroundPointZero.X + hueShift, backgroundPointZero.Y + hueShift);
            HuePicker = new CCControlHuePicker(this, huePickerPos);

            CCPoint colourPickerPos = new CCPoint(backgroundPointZero.X + colourShift, backgroundPointZero.Y + colourShift);
            ColourPicker = new CCControlSaturationBrightnessPicker(this, colourPickerPos);

            // Setup events
            HuePicker.ValueChanged += HuePicker_ValueChanged;
            ColourPicker.ValueChanged += ColourPicker_ValueChanged;

            UpdateHueAndControlPicker();
            AddChild(HuePicker);
            AddChild(ColourPicker);

            ContentSize = Background.ContentSize;
        }

        private void ColourPicker_ValueChanged(object sender, CCControlEventArgs e)
        {
            ColourSliderValueChanged(sender, e.ControlEvent);
        }

        private void HuePicker_ValueChanged(object sender, CCControlEventArgs e)
        {
            HueSliderValueChanged(sender, e.ControlEvent);
        }

        #endregion Constructors


        bool OnTouchBegan(CCTouch touch, CCEvent touchEvent)
		{
			return false;
		}

        public void HueSliderValueChanged(Object sender, CCControlEvent controlEvent)
        {
            Hsv.H = ((CCControlHuePicker) sender).Hue;

            RGBA rgb = CCControlUtils.RGBfromHSV(Hsv);
            // XXX fixed me if not correct
            base.Color = new CCColor3B((byte) (rgb.R * 255.0f), (byte) (rgb.G * 255.0f), (byte) (rgb.B * 255.0f));

            // Send Control callback
            OnValueChanged();
            UpdateControlPicker();
        }

        public void ColourSliderValueChanged(Object sender, CCControlEvent controlEvent)
        {
            Hsv.S = ((CCControlSaturationBrightnessPicker) sender).Saturation;
            Hsv.V = ((CCControlSaturationBrightnessPicker) sender).Brightness;

            RGBA rgb = CCControlUtils.RGBfromHSV(Hsv);
            // XXX fixed me if not correct
            base.Color = new CCColor3B((byte) (rgb.R * 255.0f), (byte) (rgb.G * 255.0f), (byte) (rgb.B * 255.0f));

            // Send Control callback
            OnValueChanged();
        }

        protected void UpdateControlPicker()
        {
            HuePicker.Hue = Hsv.H;
            ColourPicker.UpdateWithHSV(Hsv);
        }

        protected void UpdateHueAndControlPicker()
        {
            HuePicker.Hue = Hsv.H;
            ColourPicker.UpdateWithHSV(Hsv);
            ColourPicker.UpdateDraggerWithHSV(Hsv);
        }
    }
}