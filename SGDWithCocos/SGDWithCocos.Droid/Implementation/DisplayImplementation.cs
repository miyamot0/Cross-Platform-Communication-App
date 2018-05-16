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
using Android.Views;
using Android.Content;
using Android.Runtime;
using SGDWithCocos.Droid.Implementation;

[assembly: Xamarin.Forms.Dependency(typeof(DisplayImplementation))]
namespace SGDWithCocos.Droid.Implementation
{
    public class DisplayImplementation : IDisplay
    {
        public DisplayImplementation() { }

        public static void Init() { }

        int IDisplay.Height
        {
            get
            {
                IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
                return windowManager.DefaultDisplay.Height;
            }
        }

        int IDisplay.Width
        {
            get
            {
                IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
                return windowManager.DefaultDisplay.Width;
            }
        }
    }
}