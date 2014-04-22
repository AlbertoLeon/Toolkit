using System;

namespace Tokiota.Toolkit.XCutting.Extensions
{
    public static class FunctionalExtensions
    {

        /// <summary>
        /// Applies all the actions in the target object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <param name="actions">The actions.</param>
        public static void ApplyTo<T>(this T target, params Action<T>[] actions)
        {
            actions.ForEach(action => action.Invoke(target));
        }
    }
}