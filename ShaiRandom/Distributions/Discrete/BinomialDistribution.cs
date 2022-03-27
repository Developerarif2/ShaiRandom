﻿// Copyright (c) Alessio Parma <alessio.parma@gmail.com>. All rights reserved.
//
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using ShaiRandom.Generators;

namespace ShaiRandom.Distributions.Discrete
{
    /// <summary>
    ///   Provides generation of binomial distributed random numbers.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The binomial distribution generates only discrete numbers. <br/> The implementation of
    ///     the <see cref="BinomialDistribution"/> type bases upon information presented on
    ///     <a href="http://en.wikipedia.org/wiki/binomial_distribution">Wikipedia - Binomial distribution</a>.
    ///   </para>
    ///   <para>The thread safety of this class depends on the one of the underlying generator.</para>
    /// </remarks>
    [Serializable]
    public sealed class BinomialDistribution : AbstractDistribution, IDiscreteDistribution, IAlphaDistribution<double>, IBetaDistribution<int>
    {
        #region Constants

        /// <summary>
        ///   The default value assigned to <see cref="Alpha"/> if none is specified.
        /// </summary>
        public const double DefaultAlpha = 0.5;

        /// <summary>
        ///   The default value assigned to <see cref="Beta"/> if none is specified.
        /// </summary>
        public const int DefaultBeta = 1;

        #endregion Constants

        #region Fields

        /// <summary>
        ///   Stores the parameter alpha which is used for generation of binomial distributed random numbers.
        /// </summary>
        private double _alpha;

        /// <summary>
        ///   Stores the parameter beta which is used for generation of binomial distributed random numbers.
        /// </summary>
        private int _beta;

        /// <summary>
        ///   Gets or sets the parameter alpha which is used for generation of binomial distributed
        ///   random numbers.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="value"/> is less than zero or greater than one.
        /// </exception>
        /// <remarks>
        ///   Calls <see cref="AreValidParams"/> to determine whether a value is valid and therefore assignable.
        /// </remarks>
        public double Alpha
        {
            get { return _alpha; }
            set
            {
                if (!IsValidAlpha(value)) throw new ArgumentOutOfRangeException(nameof(Alpha), ErrorMessages.InvalidParams);
                _alpha = value;
            }
        }

        /// <summary>
        ///   Gets or sets the parameter beta which is used for generation of binomial distributed
        ///   random numbers.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="value"/> is less than zero.
        /// </exception>
        /// <remarks>
        ///   Calls <see cref="AreValidParams"/> to determine whether a value is valid and therefore assignable.
        /// </remarks>
        public int Beta
        {
            get { return _beta; }
            set
            {
                if (!IsValidBeta(value)) throw new ArgumentOutOfRangeException(nameof(Beta), ErrorMessages.InvalidParams);
                _beta = value;
            }
        }

        #endregion Fields

        #region Construction

        /// <summary>
        ///   Initializes a new instance of the <see cref="BinomialDistribution"/> class, using a
        ///   <see cref="TrimRandom"/> as underlying random number generator.
        /// </summary>
        public BinomialDistribution() : this(new TrimRandom(), DefaultAlpha, DefaultBeta)
        {
            Debug.Assert(Generator is TrimRandom);
            Debug.Assert(Equals(Alpha, DefaultAlpha));
            Debug.Assert(Equals(Beta, DefaultBeta));
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BinomialDistribution"/> class, using a
        ///   <see cref="TrimRandom"/> with the specified seed value.
        /// </summary>
        /// <param name="seed">
        ///   An unsigned number used to calculate a starting value for the pseudo-random number sequence.
        /// </param>
        public BinomialDistribution(uint seed) : this(new TrimRandom(seed), DefaultAlpha, DefaultBeta)
        {
            Debug.Assert(Generator is TrimRandom);
            Debug.Assert(Equals(Alpha, DefaultAlpha));
            Debug.Assert(Equals(Beta, DefaultBeta));
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BinomialDistribution"/> class, using the
        ///   specified <see cref="IEnhancedRandom"/> as underlying random number generator.
        /// </summary>
        /// <param name="generator">An <see cref="IEnhancedRandom"/> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="generator"/> is <see langword="null"/>.</exception>
        public BinomialDistribution(IEnhancedRandom generator) : this(generator, DefaultAlpha, DefaultBeta)
        {
            Debug.Assert(ReferenceEquals(Generator, generator));
            Debug.Assert(Equals(Alpha, DefaultAlpha));
            Debug.Assert(Equals(Beta, DefaultBeta));
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BinomialDistribution"/> class, using a
        ///   <see cref="TrimRandom"/> as underlying random number generator.
        /// </summary>
        /// <param name="alpha">
        ///   The parameter alpha which is used for generation of binomial distributed random numbers.
        /// </param>
        /// <param name="beta">
        ///   The parameter beta which is used for generation of binomial distributed random numbers.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="alpha"/> is less than zero or greater than one, or
        ///   <paramref name="beta"/> is less than zero.
        /// </exception>
        public BinomialDistribution(double alpha, int beta) : this(new TrimRandom(), alpha, beta)
        {
            Debug.Assert(Generator is TrimRandom);
            Debug.Assert(Equals(Alpha, alpha));
            Debug.Assert(Equals(Beta, beta));
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BinomialDistribution"/> class, using a
        ///   <see cref="TrimRandom"/> with the specified seed value.
        /// </summary>
        /// <param name="seed">
        ///   An unsigned number used to calculate a starting value for the pseudo-random number sequence.
        /// </param>
        /// <param name="alpha">
        ///   The parameter alpha which is used for generation of binomial distributed random numbers.
        /// </param>
        /// <param name="beta">
        ///   The parameter beta which is used for generation of binomial distributed random numbers.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="alpha"/> is less than zero or greater than one, or
        ///   <paramref name="beta"/> is less than zero.
        /// </exception>
        public BinomialDistribution(uint seed, double alpha, int beta)
            : this(new TrimRandom(seed), alpha, beta)
        {
            Debug.Assert(Generator is TrimRandom);
            Debug.Assert(Equals(Alpha, alpha));
            Debug.Assert(Equals(Beta, beta));
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BinomialDistribution"/> class, using the
        ///   specified <see cref="IEnhancedRandom"/> as underlying random number generator.
        /// </summary>
        /// <param name="generator">An <see cref="IEnhancedRandom"/> object.</param>
        /// <param name="alpha">
        ///   The parameter alpha which is used for generation of binomial distributed random numbers.
        /// </param>
        /// <param name="beta">
        ///   The parameter beta which is used for generation of binomial distributed random numbers.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="generator"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="alpha"/> is less than zero or greater than one, or
        ///   <paramref name="beta"/> is less than zero.
        /// </exception>
        public BinomialDistribution(IEnhancedRandom generator, double alpha, int beta) : base(generator)
        {
            var vp = AreValidParams;
            if (!vp(alpha, beta)) throw new ArgumentOutOfRangeException($"{nameof(alpha)}/{nameof(beta)}", ErrorMessages.InvalidParams);
            _alpha = alpha;
            _beta = beta;
        }

        #endregion Construction

        #region Instance Methods

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Alpha"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is greater than or equal to 0.0, and less than or
        ///   equal to 1.0; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsValidAlpha(double value) => AreValidParams(value, Beta);

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Beta"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is greater than or equal to 0; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsValidBeta(int value) => AreValidParams(Alpha, value);

        #endregion Instance Methods

        #region IDiscreteDistribution Members

        /// <summary>
        ///   Gets the maximum possible value of distributed random numbers.
        /// </summary>
        public double Maximum => Beta;

        /// <summary>
        ///   Gets the mean of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if mean is not defined for given distribution with some parameters.
        /// </exception>
        public double Mean => Alpha * Beta;

        /// <summary>
        ///   Gets the median of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if median is not defined for given distribution with some parameters.
        /// </exception>
        public double Median
        {
            get { throw new NotSupportedException(ErrorMessages.UndefinedMedian); }
        }

        /// <summary>
        ///   Gets the minimum possible value of distributed random numbers.
        /// </summary>
        public double Minimum => 0.0;

        /// <summary>
        ///   Gets the mode of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if mode is not defined for given distribution with some parameters.
        /// </exception>
        public double[] Mode => new[] { Math.Floor(Alpha * (Beta + 1.0)) };

        /// <summary>
        ///   Gets the variance of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if variance is not defined for given distribution with some parameters.
        /// </exception>
        public double Variance => Alpha * (1.0 - Alpha) * Beta;

        /// <summary>
        ///   Returns a distributed random number.
        /// </summary>
        /// <returns>A distributed 32-bit signed integer.</returns>
        public int Next() => Sample(Generator, _alpha, _beta);

        /// <summary>
        ///   Returns a distributed floating point random number.
        /// </summary>
        /// <returns>A distributed double-precision floating point number.</returns>
        public double NextDouble() => Sample(Generator, _alpha, _beta);

        #endregion IDiscreteDistribution Members

        #region TRandom Helpers

        /// <summary>
        ///   Determines whether binomial distribution is defined under given parameters. The
        ///   default definition returns true if alpha is greater than or equal to zero and less
        ///   than or equal to one, and if beta is greater than or equal to zero; otherwise, it
        ///   returns false.
        /// </summary>
        /// <remarks>
        ///   This is an extensibility point for the <see cref="BinomialDistribution"/> class.
        /// </remarks>
        public static Func<double, int, bool> AreValidParams { get; set; } = (alpha, beta) =>
        {
            return alpha >= 0.0 && alpha <= 1.0 && beta >= 0;
        };

        /// <summary>
        ///   Declares a function returning a binomial distributed 32-bit signed integer.
        /// </summary>
        /// <remarks>
        ///   This is an extensibility point for the <see cref="BinomialDistribution"/> class.
        /// </remarks>
        public static Func<IEnhancedRandom, double, int, int> Sample { get; set; } = (generator, alpha, beta) =>
        {
            var successes = 0;
            for (var i = 0; i < beta; i++)
            {
                if (generator.NextDouble() < alpha)
                {
                    successes++;
                }
            }
            return successes;
        };

        #endregion TRandom Helpers
    }
}
