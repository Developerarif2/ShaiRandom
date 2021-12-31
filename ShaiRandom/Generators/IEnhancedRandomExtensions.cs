﻿using System;
using System.Collections.Generic;

namespace ShaiRandom.Generators
{
    /// <summary>
    /// A collection of useful extension methods for IEnhancedRandom implementations.
    /// </summary>
    public static class EnhancedRandomExtensions
    {
        /// <summary>
        /// Returns the minimum result of trials calls to <see cref="IEnhancedRandom.NextInt(int, int)"/> using the
        /// given innerBound and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the lower the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the lowest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static int MinIntOf(this IEnhancedRandom rng, int innerBound, int outerBound, int trials)
        {
            int v = rng.NextInt(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Min(v, rng.NextInt(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the maximum result of trials calls to <see cref="IEnhancedRandom.NextInt(int, int)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the higher the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the highest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static int MaxIntOf(this IEnhancedRandom rng, int innerBound, int outerBound, int trials)
        {
            int v = rng.NextInt(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Max(v, rng.NextInt(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the minimum result of trials calls to <see cref="IEnhancedRandom.NextLong(long, long)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the lower the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the lowest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static long MinLongOf(this IEnhancedRandom rng, long innerBound, long outerBound, int trials)
        {
            long v = rng.NextLong(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Min(v, rng.NextLong(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the maximum result of trials calls to <see cref="IEnhancedRandom.NextLong(long, long)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the higher the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the highest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static long MaxLongOf(this IEnhancedRandom rng, long innerBound, long outerBound, int trials)
        {
            long v = rng.NextLong(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Max(v, rng.NextLong(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the minimum result of trials calls to <see cref="IEnhancedRandom.NextUInt(uint, uint)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the lower the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the lowest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static uint MinUIntOf(this IEnhancedRandom rng, uint innerBound, uint outerBound, int trials)
        {
            uint v = rng.NextUInt(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Min(v, rng.NextUInt(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the maximum result of trials calls to <see cref="IEnhancedRandom.NextUInt(uint, uint)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the higher the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the highest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static uint MaxUIntOf(this IEnhancedRandom rng, uint innerBound, uint outerBound, int trials)
        {
            uint v = rng.NextUInt(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Max(v, rng.NextUInt(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the minimum result of trials calls to <see cref="IEnhancedRandom.NextULong(ulong, ulong)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the lower the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the lowest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static ulong MinULongOf(this IEnhancedRandom rng, ulong innerBound, ulong outerBound, int trials)
        {
            ulong v = rng.NextULong(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Min(v, rng.NextULong(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the maximum result of trials calls to <see cref="IEnhancedRandom.NextULong(ulong, ulong)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the higher the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the highest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static ulong MaxULongOf(this IEnhancedRandom rng, ulong innerBound, ulong outerBound, int trials)
        {
            ulong v = rng.NextULong(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Max(v, rng.NextULong(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the minimum result of trials calls to <see cref="IEnhancedRandom.NextDouble(double, double)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the lower the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the lowest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static double MinDoubleOf(this IEnhancedRandom rng, double innerBound, double outerBound, int trials)
        {
            double v = rng.NextDouble(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Min(v, rng.NextDouble(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the maximum result of trials calls to <see cref="IEnhancedRandom.NextDouble(double, double)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the higher the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the highest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static double MaxDoubleOf(this IEnhancedRandom rng, double innerBound, double outerBound, int trials)
        {
            double v = rng.NextDouble(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Max(v, rng.NextDouble(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the minimum result of trials calls to <see cref="IEnhancedRandom.NextFloat(float, float)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the lower the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the lowest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static float MinFloatOf(this IEnhancedRandom rng, float innerBound, float outerBound, int trials)
        {
            float v = rng.NextFloat(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Min(v, rng.NextFloat(innerBound, outerBound));
            }
            return v;
        }

        /// <summary>
        /// Returns the maximum result of trials calls to <see cref="IEnhancedRandom.NextFloat(float, float)"/> using the given innerBound
        /// and outerBound. The innerBound is inclusive; the outerBound is exclusive.
        /// The higher trials is, the higher the average value this returns.
        /// </summary>
        /// <param name="rng" />
        /// <param name="innerBound">the inner inclusive bound; may be positive or negative</param>
        /// <param name="outerBound">the outer exclusive bound; may be positive or negative</param>
        /// <param name="trials">how many random numbers to acquire and compare</param>
        /// <returns>the highest random number between innerBound (inclusive) and outerBound (exclusive) this found</returns>
        public static float MaxFloatOf(this IEnhancedRandom rng, float innerBound, float outerBound, int trials)
        {
            float v = rng.NextFloat(innerBound, outerBound);
            for (int i = 1; i < trials; i++)
            {
                v = Math.Max(v, rng.NextFloat(innerBound, outerBound));
            }
            return v;
        }


        /// <summary>
        /// Gets a randomly-chosen item from the given non-null, non-empty array.
        /// </summary>
        /// <param name="rng" />
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="array">Must be non-null and non-empty.</param>
        /// <returns>A randomly-chosen item from array.</returns>
        public static T RandomElement<T>(this IEnhancedRandom rng, T[] array)
            => array[rng.NextInt(array.Length)];

        /// <summary>
        /// Gets a randomly-chosen item from the given non-null, non-empty IList.
        /// </summary>
        /// <param name="rng" />
        /// <typeparam name="T">The type of items in the list.</typeparam>
        /// <param name="list">Must be non-null and non-empty.</param>
        /// <returns>A randomly-chosen item from list.</returns>
        public static T RandomElement<T>(this IEnhancedRandom rng, IList<T> list)
            => list[rng.NextInt(list.Count)];

        /// <summary>
        /// Shuffles the given array in-place pseudo-randomly, using the Fisher-Yates (also called Knuth) shuffle algorithm.
        /// </summary>
        /// <param name="rng" />
        /// <param name="items">an array of some reference type; must be non-null but may contain null items</param>
        public static void Shuffle<T>(this IEnhancedRandom rng, T[] items)
            => rng.Shuffle(items, 0, items.Length);

        /// <summary>
        /// Shuffles the given IList in-place pseudo-randomly, using the Fisher-Yates (also called Knuth) shuffle algorithm.
        /// </summary>
        /// <param name="rng" />
        /// <param name="items">an IList; must be non-null but may contain null items</param>
        public static void Shuffle<T>(this IEnhancedRandom rng, IList<T> items)
            => rng.Shuffle(items, 0, items.Count);

        /// <summary>
        /// Shuffles a section of the given array in-place pseudo-randomly, using the Fisher-Yates (also called Knuth) shuffle algorithm.
        /// </summary>
        /// <param name="rng" />
        /// <param name="items">an array of some reference type; must be non-null but may contain null items</param>
        /// <param name="offset">the index of the first element of the array that can be shuffled</param>
        /// <param name="length">the length of the section to shuffle</param>
        public static void Shuffle<T>(this IEnhancedRandom rng, T[] items, int offset, int length)
        {
            offset = Math.Min(Math.Max(0, offset), items.Length);
            length = Math.Min(items.Length - offset, Math.Max(0, length));
            for (int i = offset + length - 1; i > offset; i--)
            {
                int ii = rng.NextInt(offset, i + 1);
                (items[i], items[ii]) = (items[ii], items[i]);
            }
        }

        /// <summary>
        /// Shuffles a section of the given IList in-place pseudo-randomly, using the Fisher-Yates (also called Knuth) shuffle algorithm.
        /// </summary>
        /// <param name="rng" />
        /// <param name="items">an IList; must be non-null but may contain null items</param>
        /// <param name="offset">the index of the first element of the IList that can be shuffled</param>
        /// <param name="length">the length of the section to shuffle</param>
        public static void Shuffle<T>(this IEnhancedRandom rng, IList<T> items, int offset, int length)
        {
            offset = Math.Min(Math.Max(0, offset), items.Count);
            length = Math.Min(items.Count - offset, Math.Max(0, length));
            for (int i = offset + length - 1; i > offset; i--)
            {
                int ii = rng.NextInt(offset, i + 1);
                (items[i], items[ii]) = (items[ii], items[i]);
            }
        }

        /// <summary>
        /// Gets a normally-distributed (Gaussian) double, with a the specified mean (default 0.0) and standard deviation (default 1.0).
        /// If the standard deviation is 1.0 and the mean is 0.0, then this can produce results between -8.209536145151493 and 8.209536145151493 (both extremely rarely).
        /// </summary>
        /// <param name="rng" />
        /// <param name="mean">Mean for normal distribution.</param>
        /// <param name="stdDev">Standard deviation for normal distribution.</param>
        /// <returns>A double from the normal distribution with the specified mean (default 0.0) and standard deviation (default 1.0).</returns>
        public static double NextNormal(this IEnhancedRandom rng, double mean = 0.0, double stdDev = 1.0)
        {
            return MathUtils.Probit(rng.NextExclusiveDouble()) * stdDev + mean;
        }

        /// <summary>
        /// Returns true if a random value between 0 and 1 is less than the specified value.
        /// </summary>
        /// <param name="rng" />
        /// <param name="chance">a float between 0.0 and 1.0; higher values are more likely to result in true</param>
        /// <returns>a bool selected with the given chance of being true</returns>
        public static bool NextBool(this IEnhancedRandom rng, float chance)
        {
            return rng.NextFloat() < chance;
        }

        /// <summary>
        /// Returns -1 or 1, randomly.
        /// </summary>
        /// <param name="rng" />
        /// <returns>-1 or 1, selected with approximately equal likelihood</returns>
        public static int NextSign(this IEnhancedRandom rng)
        {
            return 1 | rng.NextInt() >> 31;
        }

        /// <summary>
        /// Returns a triangularly distributed random number between -1.0 (exclusive) and 1.0 (exclusive), where values around zero are
        /// more likely. Typically advances the state twice.
        /// </summary>
        /// <remarks>
        /// This can be an optimized version of <see cref="NextTriangular(IEnhancedRandom, float, float, float)"/>, or: <code> NextTriangular(-1, 1, 0)</code>
        /// </remarks>
        /// <param name="rng" />
        public static float NextTriangular(this IEnhancedRandom rng)
        {
            return rng.NextFloat() - rng.NextFloat();
        }

        /// <summary>
        /// Returns a triangularly distributed random number between {@code -max} (exclusive) and max (exclusive), where values
        /// around zero are more likely. Advances the state twice.
        /// </summary>
        /// <remarks>
        /// This is an optimized version of <see cref="NextTriangular(IEnhancedRandom, float, float, float)"/>, or: <code> NextTriangular(-max, max, 0)</code>
        /// </remarks>
        /// <param name="rng" />
        /// <param name="max">the outer exclusive limit</param>
        public static float NextTriangular(this IEnhancedRandom rng, float max)
        {
            return (rng.NextFloat() - rng.NextFloat()) * max;
        }

        /// <summary>
        /// Returns a triangularly distributed random number between min (inclusive) and max (exclusive), where the
        /// mode argument defaults to the midpoint between the bounds, giving a symmetric distribution. Advances the state once.
        /// </summary>
        /// <remarks>
        /// This is an optimized version of <see cref="NextTriangular(IEnhancedRandom, float, float, float)"/>, or: <code> NextTriangular(min, max, (min + max) * 0.5f)</code>
        /// </remarks>
        /// <param name="rng" />
        /// <param name="min">the lower limit</param>
        /// <param name="max">the upper limit</param>
        public static float NextTriangular(this IEnhancedRandom rng, float min, float max)
        {
            return rng.NextTriangular(min, max, (min + max) * 0.5f);
        }

        /// <summary>
        /// Returns a triangularly distributed random number between min (inclusive) and max (exclusive), where values
        /// around mode are more likely.
        /// </summary>
        /// <param name="rng" />
        /// <param name="min"> the lower limit</param>
        /// <param name="max"> the upper limit</param>
        /// <param name="mode">the point around which the values are more likely</param>
        public static float NextTriangular(this IEnhancedRandom rng, float min, float max, float mode)
        {
            float u = rng.NextFloat();
            float d = max - min;
            if (u <= (mode - min) / d) { return min + MathF.Sqrt(u * d * (mode - min)); }
            return max - MathF.Sqrt((1 - u) * d * (max - mode));
        }

        /// <summary>
        /// Sets each state in this IEnhancedRandom to the corresponding state in the other IEnhancedRandom.
        /// This generally only works correctly if both objects have the same class.
        /// </summary>
        /// <param name="rng" />
        /// <param name="other">Another IEnhancedRandom that almost always should have the same class as this one.</param>
        public static void SetWith(this IEnhancedRandom rng, IEnhancedRandom other)
        {
            int myCount = rng.StateCount, otherCount = other.StateCount;
            int i = 0;
            for (; i < myCount && i < otherCount; i++)
            {
                rng.SetSelectedState(i, other.SelectState(i));
            }
            for (; i < myCount; i++)
            {
                rng.SetSelectedState(i, 0xFFFFFFFFFFFFFFFFUL);
            }
        }
    }
}
