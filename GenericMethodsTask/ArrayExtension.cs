using System;
using System.Collections.Generic;
using GenericMethodsTask.Interfaces;

namespace GenericMethodsTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Filters a source array based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source array.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="predicate">A <see cref="IPredicate{T}"/> to test each element for a condition.</param>
        /// <returns>An array of elements from the source array that satisfy the condition.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source array or predicate is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static TSource[] Filter<TSource>(this TSource[] source, IPredicate<TSource> predicate)
        {
            if (source is null || predicate is null)
            {
                throw new ArgumentNullException($"Source array or predicate can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"Array can not be empty.");
            }

            var list = new List<TSource>();
            for (int i = 0; i < source.Length; i++)
            {
                if (predicate.Verify(source[i]))
                {
                    list.Add(source[i]);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Transforms each element of source array from one type to another type by some rule.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source array.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result array.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="transformer">A <see cref="ITransformer{TSource,TResult}"/> that defines the rule of transformation.</param>
        /// <returns>An array, each element of which is transformed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array or transformer is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            if (source is null || transformer is null)
            {
                throw new ArgumentNullException($"Source array or transformer can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"Array can not be empty.");
            }

            var list = new List<TResult>();
            for (int i = 0; i < source.Length; i++)
            {
                list.Add(transformer.Transform(source[i]));
            }

            return list.ToArray();
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        /// <returns>An ordered by comparer array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when comparer is null, and one or more elements
        /// in array do not implement the <see cref="IComparable{T}"/>  interface.</exception>
        public static TSource[] SortBy<TSource>(this TSource[] source, IComparer<TSource> comparer)
        {
            if (source is null || comparer is null)
            {
                throw new ArgumentNullException($"Source array or comparer can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"Array can not be empty.");
            }

            Array.Sort(source, comparer);
            return source;
        }

        /// <summary>
        /// Filters the elements of source array based on a specified type.
        /// </summary>
        /// <typeparam name="TResult">Type selector to return.</typeparam>
        /// <param name="source">The source array.</param>
        /// <returns>A array that contains the elements from source that have type TResult.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array length equal to zero.</exception>
        public static TResult[] TypeOf<TResult>(this object[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"Source array can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"Array can not be empty.");
            }

            var list = new List<TResult>();

            for (int i = 0; i < source.Length; i++)
            {
                // You cannot use the as operator with a generic type with no restriction. Since the as operator uses null to represent that it was not of the type, you cannot use it on value types. If you want to use obj as T, T will have to be a reference type. see https://stackoverflow.com/questions/693463/operator-as-and-generic-classes
                if (source[i] is TResult result)
                {
                    list.Add(result);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Inverts the order of the elements in a array.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of array.</typeparam>
        /// <param name="source">A array of elements to reverse.</param>
        /// <returns>Revers array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array length equal to zero.</exception>
        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"Source array can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"Array can not be empty.");
            }

            for (int i = 0, j = source.Length - 1; i < j; i++, j--)
            {
                Swap(ref source[i], ref source[j]);
            }

            return source;
        }

        /// <summary>
        /// Swaps two objects.
        /// </summary>
        /// <typeparam name="T">The type of parameters.</typeparam>
        /// <param name="left">First object.</param>
        /// <param name="right">Second object.</param>
        internal static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }
    }
}
