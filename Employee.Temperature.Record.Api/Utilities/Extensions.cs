﻿namespace Employee.Temperature.Record.Api.Utilities {
    public static class Extensions {
        public static bool IsNullOrEmpty(this object value) {
            return string.IsNullOrEmpty(value.ToString());
        }
        public static string FormatWith(this string pattern, params object[] values) {
            return string.Format(pattern, values);
        }
    }
}
