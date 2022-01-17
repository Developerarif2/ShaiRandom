﻿using System;
using System.Diagnostics.CodeAnalysis;
using ShaiRandom.Generators;
using Xunit;

namespace ShaiRandom.UnitTests
{
    [SuppressMessage("ReSharper", "UselessBinaryOperation")]
    public class KnownSeriesRandomTests
    {
        private const int ReturnedValue = 10;

        private static readonly float s_floatAdjust = MathF.Pow(2f, -24f);
        private static readonly double s_doubleCloseTo1 = 1 - Math.Pow(2, -53);

        private readonly KnownSeriesRandom _boundedRNG = new KnownSeriesRandom(
            new []{ReturnedValue},
            new []{(uint)ReturnedValue},
            new []{(double)ReturnedValue},
            byteSeries: new []{(byte)ReturnedValue},
            floatSeries: new []{(float)ReturnedValue},
            longSeries: new []{(long)ReturnedValue},
            ulongSeries: new []{(ulong)ReturnedValue}
        );

        private readonly KnownSeriesRandom _unboundedRNG = new KnownSeriesRandom(
            new []{int.MinValue, int.MaxValue},
            new []{uint.MinValue, uint.MaxValue},
            new []{0.0, 1.0 - s_doubleCloseTo1},
            byteSeries: new []{byte.MinValue, byte.MaxValue},
            floatSeries: new []{0.0f, 1.0f - s_floatAdjust},
            longSeries: new []{long.MinValue, long.MaxValue},
            ulongSeries: new []{ulong.MinValue, ulong.MaxValue}
        );

        #region Template Tests
        private static void TestUnboundedIntFunction<T>(Func<T> unboundedGenFunc)
        {
            T minValue = (T)typeof(T).GetField("MinValue")!.GetValue(null)!;
            T maxValue = (T)typeof(T).GetField("MaxValue")!.GetValue(null)!;

            Assert.Equal(minValue, unboundedGenFunc());
            Assert.Equal(maxValue,unboundedGenFunc());
        }

        private static void TestLowerBoundIntFunction<T>(Func<T, T> upperBoundFunc, Func<T, T, T> dualBoundFunc)
            where T : IConvertible
        {
            // Duck-type the generic type so that we can add/subtract from it using the type's correct operators.
            dynamic value = (T)Convert.ChangeType(ReturnedValue, typeof(T));

            Assert.Equal(value, upperBoundFunc(value + 1));
            Assert.Equal(value, dualBoundFunc(value, value + 1));

            Assert.Throws<ArgumentException>(() => dualBoundFunc(value + 1, value + 2));
        }

        private static void TestCrossedBoundIntFunction<T>(Func<T, T, T> generatorFunc)
            where T : IConvertible
        {
            // Duck-type the generic type so that we can add/subtract from it using the type's correct operators.
            dynamic value = (T)Convert.ChangeType(ReturnedValue, typeof(T));

            // Allowed range: value
            Assert.Equal(value, generatorFunc(value, value));
            // Allowed range: value
            Assert.Equal(value, generatorFunc(value, value - 1));
            // Allowed range: [value - 1, value]
            Assert.Equal(value, generatorFunc(value, value - 2));
        }

        private static void TestUpperBoundIntFunction<T>(Func<T, T> upperBoundFunc, Func<T, T, T> dualBoundFunc)
            where T : IConvertible
        {
            // Duck-type the generic type so that we can add/subtract from it using the type's correct operators.
            dynamic value = (T)Convert.ChangeType(ReturnedValue, typeof(T));

            Assert.Equal(value, upperBoundFunc(value + 1));
            Assert.Equal(value, dualBoundFunc(value, value + 1));

            Assert.Throws<ArgumentException>(() => upperBoundFunc(value));
            Assert.Throws<ArgumentException>(() => dualBoundFunc(value - 1, value));
        }

        private static void TestUnboundedFloatingFunction<T>(Func<T> unboundedGenFunc, T maxValueLessThanOne)
            where T : IConvertible
        {
            T zero = (T)Convert.ChangeType(0.0, typeof(T));
            Assert.Equal(zero, unboundedGenFunc());
            Assert.Equal(maxValueLessThanOne, unboundedGenFunc());
        }

        private static void TestLowerBoundFloatingFunction<T>(Func<T, T> upperBoundFunc, Func<T, T, T> dualBoundFunc)
            where T : IConvertible
        {
            // Duck-type the generic type so that we can add/subtract from it using the type's correct operators.
            dynamic value = (T)Convert.ChangeType(ReturnedValue, typeof(T));

            Assert.Equal(value, upperBoundFunc(value + 0.1));
            Assert.Equal(value, dualBoundFunc(value, value + 0.1));

            Assert.Throws<ArgumentException>(() => dualBoundFunc(value + 0.1, value + 0.2));
        }

        private static void TestCrossedBoundFloatingFunction<T>(Func<T, T, T> generatorFunc)
            where T : IConvertible
        {
            // Duck-type the generic type so that we can add/subtract from it using the type's correct operators.
            dynamic value = (T)Convert.ChangeType(ReturnedValue, typeof(T));

            // Allowed range: value
            Assert.Equal(value, generatorFunc(value, value));
            // Allowed range: Allowed range: (value - 0.1, value]
            Assert.Equal(value, generatorFunc(value, value - 0.1));
        }

        private static void TestUpperBoundFloatingFunction<T>(Func<T, T> upperBoundFunc, Func<T, T, T> dualBoundFunc)
            where T : IConvertible
        {
            // Duck-type the generic type so that we can add/subtract from it using the type's correct operators.
            dynamic value = (T)Convert.ChangeType(ReturnedValue, typeof(T));

            Assert.Equal(value, upperBoundFunc(value + 0.1));
            Assert.Equal(value, dualBoundFunc(value, value + 0.1));

            Assert.Throws<ArgumentException>(() => upperBoundFunc(value));
            Assert.Throws<ArgumentException>(() => dualBoundFunc(value - 0.1, value));
        }
        #endregion

        #region Test Int

        [Fact]
        public void NextIntUnbounded() => TestUnboundedIntFunction(_unboundedRNG.NextInt);

        [Fact]
        public void NextIntLowerBound() => TestLowerBoundIntFunction<int>(_boundedRNG.NextInt, _boundedRNG.NextInt);

        [Fact]
        public void NextIntCrossedBounds() => TestCrossedBoundIntFunction<int>(_boundedRNG.NextInt);

        [Fact]
        public void NextIntUpperBound() => TestUpperBoundIntFunction<int>(_boundedRNG.NextInt, _boundedRNG.NextInt);

        #endregion

        #region Test Double

        [Fact]
        public void NextDoubleUnbounded()
            => TestUnboundedFloatingFunction(_unboundedRNG.NextDouble, 1 - s_doubleCloseTo1);

        [Fact]
        public void NextDoubleLowerBound()
            => TestLowerBoundFloatingFunction<double>(_boundedRNG.NextDouble, _boundedRNG.NextDouble);

        [Fact]
        public void NextDoubleCrossedBounds() => TestCrossedBoundFloatingFunction<double>(_boundedRNG.NextDouble);

        [Fact]
        public void NextDoubleUpperBound()
            => TestUpperBoundFloatingFunction<double>(_boundedRNG.NextDouble, _boundedRNG.NextDouble);
        #endregion
    }
}
