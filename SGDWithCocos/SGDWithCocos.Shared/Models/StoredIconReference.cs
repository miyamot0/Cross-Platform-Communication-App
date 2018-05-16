//----------------------------------------------------------------------------------------------
// <copyright file="StoredIconReference.cs" 
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

using CocosSharp;

namespace SGDWithCocos.Models
{
    public class StoredIconReference
    {
        public CCSprite Sprite;
        public string Base64;
        public string FolderName;
        public float Scale;
        public float TextScale;
        public bool TextVisible;

        public StoredIconReference(CCSprite sprite, string base64, string folderName, float scale, float textScale, bool textVisible)
        {
            Sprite = sprite;
            Base64 = base64;
            FolderName = folderName;
            Scale = scale;
            TextScale = textScale;
            TextVisible = textVisible;
        }
    }
}
