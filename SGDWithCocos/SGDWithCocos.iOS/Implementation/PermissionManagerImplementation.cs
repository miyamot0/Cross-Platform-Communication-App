//----------------------------------------------------------------------------------------------
// <copyright file="PermissionManagerImplementation.cs" 
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
using SGDWithCocos.iOS.Implementation;
using Xamarin.Forms;

[assembly: Dependency(typeof(PermissionManagerImplementation))]
namespace SGDWithCocos.iOS.Implementation
{
    public class PermissionManagerImplementation : IPermissionManager
    {
        void IPermissionManager.CheckPhotoPermission()
        {
            Photos.PHPhotoLibrary.RequestAuthorization(status =>
            {

            });
        }
    }
}