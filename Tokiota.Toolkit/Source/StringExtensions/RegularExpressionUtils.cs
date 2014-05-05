using System.Text.RegularExpressions;

namespace Tokiota.Toolkit.StringExtensions
{
    public static class RegularExpressionUtils
    {
        #region Constants

        public const string SlugBasicPattern = @"[^a-z0-9\s-]";

        #endregion

        #region Static Fields

        public static readonly Regex EmailRegex = new Regex(@"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$");

        public static readonly Regex IpAddressRegex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

        public static readonly Regex PasswordRegex = new Regex(@"^[a-z0-9_-]{8,18}$");

        public static readonly Regex PositiveNumberRegex = new Regex(@"^[1-9]+[0-9]*$");

        public static readonly Regex SlugBasic = new Regex(SlugBasicPattern);

        public static readonly Regex SlugRegex = new Regex(@"(^[a-z0-9])([a-z0-9_-]+)*([a-z0-9])$");

        public static readonly Regex SlugWithSegmentsRegex = new Regex(@"^(?!-)[a-z0-9_-]+(?<!-)(/(?!-)[a-z0-9_-]+(?<!-))*$");

        public static readonly Regex UrlRegex = new Regex(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$");

        public static readonly Regex UserNameRegex = new Regex(@"^[a-z0-9_-]{5,16}$");

        #endregion
    }
}