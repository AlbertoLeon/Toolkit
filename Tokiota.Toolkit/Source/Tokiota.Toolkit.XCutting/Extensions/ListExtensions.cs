using System;
using System.Collections.Generic;
using System.Linq;

using Tokiota.Toolkit.XCutting.Helpers;

namespace Tokiota.Toolkit.XCutting.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Moves the item matching to the end of the list.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public static void MoveToEnd<T>(this List<T> list, Predicate<T> itemSelector)
        {
            Ensure.Argument.NotNull(list, "list");
            if (list.Count > 1)
                list.Move(itemSelector, list.Count - 1);
        }

        /// <summary>
        /// Moves the item matching to the beginning of the list.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public static void MoveToBeginning<T>(this List<T> list, Predicate<T> itemSelector)
        {
            Ensure.Argument.NotNull(list, "list");
            list.Move(itemSelector, 0);
        }

        /// <summary>
        /// Moves the item matching to the position newIndex in the list.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex) 
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.NotNull(itemSelector, "itemSelector");
            Ensure.Argument.Is(newIndex >= 0, "New index must be greater than or equal to zero.");

            var finded = list.FirstOrDefault(itemSelector.Invoke);

            Ensure.That<ArgumentException>(!Equals(finded, default(T)), "No item was found that matches the specified selector.");

            var currentIndex = list.IndexOf(finded);
            //var currentIndex = list.FindIndex(itemSelector);
            

            if (currentIndex == newIndex)
                return;

            // Copy the item
            var item = list[currentIndex];

            // Remove the item from the list
            list.RemoveAt(currentIndex);

            // Finally insert the item at the new index
            list.Insert(newIndex, item);
        }
    }
}