using System;
using System.Collections.Generic;
using System.Linq;

namespace Sport.Common.Utilities
{
    //COPIED from real Sport.Core
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether the specified enumerable is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable" />.</typeparam>
        /// <param name="enumerable">any IEnumerable</param>
        /// <returns>true if the specified enumerable is null or contains no elements</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable != null)
                return !enumerable.Any<T>();
            return true;
        }

        /// <summary>
        /// Determines whether the sequence contains exactly the given number of elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to check.</param>
        /// <param name="count">The expected number of items.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> is a negative integer.</exception>
        /// <returns><c>true</c> if the <paramref name="source" /> sequence contains <paramref name="count" /> elements; otherwise, <c>false</c>.</returns>
        public static bool HasExactly<T>(this IEnumerable<T> source, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", (object)count, "Positive integer required.");
            return source.HasInRange<T>(count, count);
        }

        /// <summary>
        /// Determines whether the sequence contains the given number of elements or more.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to check.</param>
        /// <param name="count">The expected minimum number of items.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> is not a greater than 0 integer.</exception>
        /// <returns><c>true</c> if the <paramref name="source" /> sequence contains <paramref name="count" /> or more elements; otherwise, <c>false</c>.</returns>
        public static bool HasAtLeast<T>(this IEnumerable<T> source, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("count", (object)count, "An greater than 0 integer is required.");
            return source.HasInRange<T>(count, int.MaxValue);
        }

        /// <summary>
        /// Determines whether the sequence contains the given number of elements or less.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to check.</param>
        /// <param name="count">The expected maximum number of items.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> is not a greater than 0 integer.</exception>
        /// <returns><c>true</c> if the <paramref name="source" /> sequence contains <paramref name="count" /> or less elements; otherwise, <c>false</c>.</returns>
        public static bool HasAtMost<T>(this IEnumerable<T> source, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("count", (object)count, "An greater than 0 integer is required.");
            return source.HasInRange<T>(0, count);
        }

        /// <summary>
        /// Determines whether the sequence contains the number of elements between the given bounds.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to check.</param>
        /// <param name="lowerBound">The lower bound (1-based index).</param>
        /// <param name="upperBound">The upper bound (1-based index).</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="lowerBound" /> is not a positive integer or <paramref name="upperBound" /> is lower than <paramref name="lowerBound" />.</exception>
        /// <returns><c>false</c> if the <paramref name="source" /> sequence contains less than <paramref name="lowerBound" /> elements or more than <paramref name="upperBound" />;
        /// otherwise, <c>true</c>.</returns>
        public static bool HasInRange<T>(this IEnumerable<T> source, int lowerBound, int upperBound)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (lowerBound < 0)
                throw new ArgumentOutOfRangeException("lowerBound", (object)lowerBound, "lowerBound must be equal to or greater than 0.");
            if (upperBound < lowerBound)
                throw new ArgumentOutOfRangeException("upperBound", (object)upperBound, "upperBound must be equal to or greater than lowerBound.");
            ICollection<T> objs = source as ICollection<T>;
            if (objs != null)
            {
                int count = objs.Count;
                if (lowerBound <= count)
                    return count <= upperBound;
                return false;
            }
            bool flag = lowerBound == 0;
            int num = 1;
            foreach (T obj in source)
            {
                if (num > upperBound)
                    return false;
                if (num >= lowerBound)
                    flag = true;
                ++num;
            }
            return flag;
        }

        /// <summary>
        /// Returns the given sequence as a <see cref="T:System.Collections.Generic.IReadOnlyCollection`1" />, by solidifying it if needed.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable" />.</typeparam>
        /// <param name="enumerable">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to convert.</param>
        /// <returns>The result collection.</returns>
        public static IReadOnlyCollection<T> AsReadOnlyCollection<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            return enumerable as IReadOnlyCollection<T> ?? (IReadOnlyCollection<T>)enumerable.ToList<T>();
        }
    }
}
