﻿/*
 *  Copyright July 1, 2016 Shawn Gilroy 
 *  HybridWebApp - Selection based communication aide
 *  File="TextToSpeechInterface.cs"
 *  
 *  ===================================================
 *  
 *  Based on code samples shared by Xamarin
 *  https://developer.xamarin.com/guides/xamarin-forms/dependency-service/text-to-speech/
 *    
 */

namespace SGDWithCocos.Interface
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
