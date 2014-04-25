using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

using Tokiota.Toolkit.XCutting.Extensions;

namespace Tokiota.Toolkit.XCutting.Helpers
{
    public static class Ensure
    {
        #region Public Methods and Operators

        public static void Contains<T>(IEnumerable<T> collection, Func<T, bool> predicate, string message = "")
        {
            That(collection != null && collection.Any(predicate), message);
        }

        public static void Equal<T>(T left, T right, string message = "Values must be equal")
        {
            That(left != null && right != null && left.Equals(right), message);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static void Length(string stringValue, int maximum, string message)
        {
            NotNull(stringValue);

            int length = stringValue.Trim().Length;
            if(length > maximum)
                throw new InvalidOperationException(message);
        }

        public static void Length(string stringValue, int minimum, int maximum, string message)
        {
            NotNull(stringValue);

            int length = stringValue.Trim().Length;
            if(length < minimum || length > maximum)
                throw new InvalidOperationException(message);
        }

        public static void Matches(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            if(!regex.IsMatch(stringValue))
                throw new InvalidOperationException(message);
        }

        public static void Not<TException>(bool condition, string message = "") where TException : Exception
        {
            That<TException>(!condition, message);
        }

        public static void Not(bool condition, string message = "")
        {
            Not<Exception>(condition, message);
        }

        public static void NotEqual<T>(T left, T right, string message = "Values must not be equal")
        {
            That(left != null && right != null && !left.Equals(right), message);
        }

        public static void NotNull(object value, string message = "")
        {
            That<NullReferenceException>(value != null, message);
        }

        public static void NotNullOrEmpty(string value, string message = "String cannot be null or empty")
        {
            That(value.IsNotNullOrEmpty(), message);
        }

        public static void Range(double value, double minimum, double maximum, string message)
        {
            if(value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void Range(int value, int minimum, int maximum, string message)
        {
            if(value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void Range(long value, long minimum, long maximum, string message)
        {
            if(value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void That(bool condition, string message = "")
        {
            That<Exception>(condition, message);
        }

        public static void That<TException>(bool condition, string message = "") where TException : Exception
        {
            if(!condition)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void TrueForAll<T>(IEnumerable<T> collection, Func<T, bool> predicate, string message = "")
        {
            That(collection != null && collection.All(predicate),message);
        }

        #endregion

        public static class Argument
        {
            #region Public Methods and Operators

            public static void Is(bool condition, string message = "")
            {
                That<ArgumentException>(condition, message);
            }

            public static void IsNot(bool condition, string message = "")
            {
                Is(!condition, message);
            }

            public static void NotNull(object value, string parameterName = "")
            {
                That<ArgumentNullException>(value != null, parameterName);
            }

            public static void NotNullOrEmpty(string value, string parameterName = "")
            {
                if(value.IsNullOrEmpty())
                {
                    if(parameterName.IsNullOrEmpty())
                        throw new ArgumentException("String value cannot be empty");

                    throw new ArgumentException("String parameter " + parameterName + " cannot be null or empty", parameterName);
                }
            }

            #endregion
        }
    }
}