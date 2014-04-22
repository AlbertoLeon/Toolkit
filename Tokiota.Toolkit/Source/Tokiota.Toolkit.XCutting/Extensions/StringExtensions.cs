using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Tokiota.Toolkit.XCutting.Helpers;

namespace Tokiota.Toolkit.XCutting.Extensions
{
    public static class StringExtensions
    {
        #region Public Methods and Operators


        /// <summary>
        /// Determines whether [contains] [the specified source].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="input">The input.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns></returns>
        public static bool Contains(this string source, string input, StringComparison comparison)
        {
            Ensure.NotNull(source);

            return source.IndexOf(input, comparison) >= 0;
        }

        /// <summary>
        /// Formats the with.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            Ensure.NotNull(format);

            return string.Format(format, args);
        }

        /// <summary>
        /// Determines whether [is not null or empty] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }

        /// <summary>
        /// Determines whether [is null or empty] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }


        /// <summary>
        /// Limits the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns></returns>
        public static string Limit(this string source, int maxLength, string suffix = null)
        {
            Ensure.NotNull(source);

            if(!string.IsNullOrEmpty(suffix))
                maxLength = maxLength - suffix.Length;

            if(source.Length <= maxLength)
                return source;

            return string.Concat(source.Substring(0, maxLength).Trim(), suffix ?? string.Empty);
        }

        /// <summary>
        /// Nulls if empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string NullIfEmpty(this string value)
        {
            if(value == string.Empty)
                return null;

            return value;
        }

        /// <summary>
        /// Separates the pascal case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string SeparatePascalCase(this string value)
        {
            Ensure.Argument.NotNullOrEmpty(value, "value");
            return Regex.Replace(value, "([A-Z])", " $1").Trim();
        }

        /// <summary>
        /// Splits the and trim.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="separators">The separators.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitAndTrim(this string value, params char[] separators)
        {
            Ensure.Argument.NotNull(value, "value");
            return value.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
        }

        /// <summary>
        /// To the slug.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns></returns>
        public static string ToSlug(this string value, int? maxLength = null)
        {
            Ensure.Argument.NotNull(value, "value");

            // if it's already a valid slug, return it
            if(RegexUtils.SlugRegex.IsMatch(value))
                return value;

            return GenerateSlug(value, maxLength);
        }

        /// <summary>
        /// To the slug with segments.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToSlugWithSegments(this string value)
        {
            Ensure.Argument.NotNull(value, "value");

            string[] segments = value.Split(new[]
                                            {
                                                '/'
                                            },
                StringSplitOptions.RemoveEmptyEntries);
            string result = segments.Aggregate(string.Empty, (slug, segment) => slug += "/" + ToSlug(segment));
            return result.Trim('/');
        }

        #endregion

        #region Methods

        private static string GenerateSlug(string value, int? maxLength = null)
        {
            string result = RemoveAccent(value).Replace("-", " ").ToUpperInvariant();
            // remove invalid characters
            result = Regex.Replace(result, RegexUtils.SlugBasicPattern, string.Empty);
            // convert multiple spaces into one space
            result = Regex.Replace(result, @"\s+", " ").Trim();

            // cut and trim
            if(maxLength.HasValue)
            {
                result = result.Substring(0,
                    result.Length <= maxLength
                        ? result.Length
                        : maxLength.Value).Trim();
            }

            return Regex.Replace(result, @"\s", "-"); // replace all spaces with hyphens
        }

        private static string RemoveAccent(string value)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.GetEncoding("ASCII").GetString(bytes, 0, bytes.Length);
        }

        #endregion
    }
}