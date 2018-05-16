//----------------------------------------------------------------------------------------------
// <copyright file="IconReference.cs" 
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
    public class IconReference
    {
        public CCSprite Sprite;
        public string Base64;
        public float TextScale;
        public bool TextVisible;

        public IconReference(CCSprite sprite, string base64, float textScale, bool textVisible)
        {
            Sprite = sprite;
            Base64 = base64;
            TextScale = textScale;
            TextVisible = textVisible;
        }
    }
}
