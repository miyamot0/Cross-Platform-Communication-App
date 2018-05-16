//----------------------------------------------------------------------------------------------
// <copyright file="MainActivity.cs" 
// Copyright August 18, 2016 Shawn Gilroy
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/. 
// This file is part of Cross Platform Communication App
//
// </copyright>
//
// <summary>
// The Cross Platform Communication App is a tool to assist clinicans and researchers in the treatment of communication disorders.
// 
// Email: shawn(dot)gilroy(at)temple.edu
//
// </summary>
//----------------------------------------------------------------------------------------------

using CoreGraphics;
using SGDWithCocos.Interface;
using SGDWithCocos.iOS.Implementation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ResizerImplementation))]
namespace SGDWithCocos.iOS.Implementation
{
    public class ResizerImplementation : IResizer
    {
        void IResizer.ResizeBitmaps(string photoPath, string newPhotoPath)
        {
            var sourceImage = UIImage.FromFile(photoPath);
            var imgSize = sourceImage.Size;

            if (imgSize.Width >= imgSize.Height)
            {
                var x = imgSize.Width / 2 - imgSize.Height / 2;
                var y = 0;
                var height = imgSize.Height;
                var width = imgSize.Height;

                UIGraphics.BeginImageContext(new CGSize(width, height));
                var context = UIGraphics.GetCurrentContext();
                var clippedRect = new CGRect(0, 0, width, height);
                context.ClipToRect(clippedRect);
                var drawRect = new CGRect(-x, -y, imgSize.Width, imgSize.Height);
                sourceImage.Draw(drawRect);
                var modifiedImage = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();
                
                modifiedImage.AsJPEG(1).Save(newPhotoPath, true);

            }
            else
            {
                var x = 0;
                var y = imgSize.Height / 2 - imgSize.Width / 2;
                var height = imgSize.Width;
                var width = imgSize.Width;

                UIGraphics.BeginImageContext(new CGSize(width, height));
                var context = UIGraphics.GetCurrentContext();
                var clippedRect = new CGRect(0, 0, width, height);
                context.ClipToRect(clippedRect);
                var drawRect = new CGRect(-x, -y, imgSize.Width, imgSize.Height);
                sourceImage.Draw(drawRect);
                var modifiedImage = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                modifiedImage.AsJPEG(1).Save(newPhotoPath, true);

            }
        }
    }
}