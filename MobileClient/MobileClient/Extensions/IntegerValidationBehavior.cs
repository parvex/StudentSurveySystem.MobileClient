﻿using System.Linq;
using Xamarin.Forms;

namespace MobileClient.Extensions
{
    public class IntegerValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {

            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                if (args.NewTextValue == "-")
                {
                    ((Entry) sender).Text = args.NewTextValue;
                    return;
                }
                bool isValid = args.NewTextValue.ToCharArray().All(x => char.IsDigit(x) || x == '-'); //Make sure all characters are numbers

                ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }

    }
}