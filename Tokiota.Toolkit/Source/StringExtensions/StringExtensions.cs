using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Tokiota.Toolkit.XCutting.Helpers;

namespace Tokiota.Toolkit.StringExtensions
{
    public static class StringExtensions
    {
        #region Public Methods and Operators

        public static bool AsBoolean(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            var stringTrueValues = new[]
                                   {
                                       "true", "ok", "yes", "1", "да"
                                   };
            return stringTrueValues.Contains(input.ToLower());
        }

        public static byte[] AsByteArray(this string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }

        public static string AsContentType(this string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
                return "application/octet-stream";

            var contentType = new Dictionary<string, string>
                              {
                                  {
                                      "jpg", "image/jpeg"
                                  },
                                  {
                                      "jpeg", "image/jpeg"
                                  },
                                  {
                                      "png", "image/x-png"
                                  },
                                  {
                                      "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                  },
                                  {
                                      "doc", "application/msword"
                                  },
                                  {
                                      "pdf", "application/pdf"
                                  },
                                  {
                                      "txt", "text/plain"
                                  },
                                  {
                                      "rtf", "application/rtf"
                                  }
                              };
            return contentType.ContainsKey(fileExtension.Trim())
                ? contentType [fileExtension.Trim()]
                : "application/octet-stream";
        }

        public static DateTime AsDate(this string input, bool throwExceptionIfFailed = false)
        {
            DateTime result;
            bool valid = DateTime.TryParse(input, out result);
            if(valid)
                return result;
            if(throwExceptionIfFailed)
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, "'{0}' cannot be converted as Date Time", input));
            return result;
        }

        public static double AsDouble(this string input, bool throwExceptionIfFailed = false)
        {
            double result;
            bool valid = double.TryParse(input,
                NumberStyles.AllowDecimalPoint,
                new NumberFormatInfo
                {
                    NumberDecimalSeparator = "."
                },
                out result);
            if(valid)
                return result;
            if(throwExceptionIfFailed)
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, "'{0}' cannot be converted as double", input));
            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "integer")]
        public static int AsInteger(this string input, bool throwExceptionIfFailed = false)
        {
            int result;
            bool valid = int.TryParse(input, out result);
            if(valid)
                return result;
            if(throwExceptionIfFailed)
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, "'{0}' cannot be converted as int", input));
            return result;
        }

        public static string AsSentence(this string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                return input;
            //return as is if the input is just an abbreviation
            if(Regex.Match(input, "[0-9A-Z]+$").Success)
                return input;
            //add a space before each capital letter, but not the first one.
            string result = Regex.Replace(input, "(\\B[A-Z])", " $1");
            return result;
        }

        public static string CapitalizeFirstLetter(this string input)
        {
            return string.IsNullOrEmpty(input)
                ? input
                : string.Format(CultureInfo.CurrentCulture, "{0}{1}", input.Substring(0, 1).ToUpper(), input.Substring(1, input.Length - 1));
        }

        public static bool Contains(this string source, string input, StringComparison comparison)
        {
            Ensure.NotNull(source);

            return source.IndexOf(input, comparison) >= 0;
        }

        public static char First(this string source)
        {
            if(source == null)
                throw new ArgumentNullException("source");

            if(source.Length == 0)
                throw new InvalidOperationException("The source string cannot be empty but is.");

            return source [0];
        }

        public static string FormatWith(this string format, params object[] args)
        {
            Ensure.NotNull(format);

            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

        public static string GetFileExtension(this string fileName)
        {
            if(string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            string[] fileParts = fileName.Split(new[]
                                                {
                                                    "."
                                                },
                StringSplitOptions.None);
            if(fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
                return string.Empty;

            return fileParts.Last().Trim().ToLower();
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNumber(this string input)
        {
            Match match = Regex.Match(input, @"^[0-9]+$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static string Left(this string source, int characters)
        {
            Ensure.NotNullOrEmpty(source);

            if(characters < 0)
                throw new ArgumentOutOfRangeException("characters");
            if(characters > source.Length)
                characters = source.Length;
            return source.Substring(0, characters);
        }

        public static string Limit(this string source, int maxLength, string suffix = null)
        {
            Ensure.NotNull(source);

            if(!string.IsNullOrEmpty(suffix))
                maxLength = maxLength - suffix.Length;

            if(source.Length <= maxLength)
                return source;

            return string.Concat(source.Substring(0, maxLength).Trim(), suffix ?? string.Empty);
        }

        public static string NullIfEmpty(this string source)
        {
            Ensure.NotNull(source);

            return source.Length == 0
                ? null
                : source;
        }

        public static string Reverse(this string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                return string.Empty;

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        public static string Right(this string source, int characters)
        {
            Ensure.NotNull(source);

            if(characters < 0)
                throw new ArgumentOutOfRangeException("characters");
            if(characters > source.Length)
                characters = source.Length;
            return source.Substring(source.Length - characters, characters);
        }

        public static string SeparatePascalCase(this string value)
        {
            Ensure.Argument.NotNullOrEmpty(value, "value");
            return Regex.Replace(value, "([A-Z])", " $1").Trim();
        }

        public static IEnumerable<string> SplitAndTrim(this string value, params char[] separators)
        {
            Ensure.Argument.NotNull(value, "value");
            return value.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
        }

        public static char[] ToArray(this string source)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            return source.ToCharArray();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public static List<char> ToList(this string source)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            return new List<char>(source.ToCharArray());
        }

        public static string ToSlug(this string value, int? maxLength = null)
        {
            Ensure.Argument.NotNull(value, "value");

            // if it's already a valid slug, return it
            if(RegularExpressionUtils.SlugRegex.IsMatch(value))
                return value;

            return GenerateSlug(value, maxLength);
        }

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
            result = Regex.Replace(result, RegularExpressionUtils.SlugBasicPattern, string.Empty);
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