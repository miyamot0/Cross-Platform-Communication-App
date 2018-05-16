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

using SGDWithCocos.Interface;
using Android.Graphics;
using System;
using System.IO;
using SGDWithCocos.Droid.Implementation;
using Xamarin.Forms;

[assembly: Dependency(typeof(ResizerImplementation))]
namespace SGDWithCocos.Droid.Implementation
{
    class ResizerImplementation : IResizer
    {
        void IResizer.ResizeBitmaps(string photoPath, string newPhotoPath)
        {
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InPreferredConfig = Bitmap.Config.Argb8888;
            Bitmap bitmap = BitmapFactory.DecodeFile(photoPath, options);
            Bitmap croppedBitmap = null;

            if (bitmap.Width >= bitmap.Height)
            {
                croppedBitmap = Bitmap.CreateBitmap(
                   bitmap,
                   bitmap.Width / 2 - bitmap.Height / 2,
                   0,
                   bitmap.Height,
                   bitmap.Height
                   );

            }
            else
            {
                croppedBitmap = Bitmap.CreateBitmap(
                   bitmap,
                   0,
                   bitmap.Height / 2 - bitmap.Width / 2,
                   bitmap.Width,
                   bitmap.Width
                   );
            }

            FileStream stream = null;

            try
            {
                stream = new FileStream(newPhotoPath, FileMode.Create);
                croppedBitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Failed to write: " + e.ToString());
            }
            finally
            {
                try
                {
                    if (stream != null) {
                        stream.Close();
                    }
                }
                catch (System.IO.IOException e)
                {
                    System.Console.WriteLine("Failed to close: " + e.ToString());
                }
            }
        }
    }
}