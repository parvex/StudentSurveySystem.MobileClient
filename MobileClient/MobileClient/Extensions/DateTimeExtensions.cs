﻿using System;

namespace MobileClient.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime SetHours(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
    }
}