//----------------------------------------------------------------------------------------------
// <copyright file="IconModel.cs" 
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

using System;

namespace SGDWithCocos.Models
{
    [Serializable()]
    public class IconModel 
    {
        public string Text { get; set; }
        public string Base64 { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Scale { get; set; }
        public int Tag { get; set; }
        public float TextScale { get; set; }
        public bool TextVisible { get; set; }

        public IconModel(string text, string base64, float x, float y, int tag, float scale)
        {
            Text = text;
            Base64 = base64;
            X = x;
            Y = y;
            Tag = tag;
            Scale = scale;
            TextScale = 1f;
            TextVisible = true;
        }
    }
}
