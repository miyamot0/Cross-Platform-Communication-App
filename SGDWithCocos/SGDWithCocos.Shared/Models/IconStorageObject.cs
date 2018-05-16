//----------------------------------------------------------------------------------------------
// <copyright file="IconStorageObject.cs" 
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

using System.Collections.Generic;

namespace SGDWithCocos.Models
{
    public class IconStorageObject
    {
        public List<IconModel> Icons { get; set; }
        public List<StoredIconModel> StoredIcons { get; set; }
        public List<FolderModel> Folders { get; set; }
        public bool SingleMode { get; set; }

        public IconStorageObject()
        {
            Icons = new List<IconModel>();
            StoredIcons = new List<StoredIconModel>();
            Folders = new List<FolderModel>();
            SingleMode = true;
        }
    }
}
