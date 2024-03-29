﻿using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Extensions
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }


    public class ImageHelper
    {
        public static object GetImageFromResource(string source)
        {
            if (source == null)
            {
                return null;
            }

            var imageSource = ImageSource.FromResource(source, typeof(ImageHelper).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}