﻿// Copyright (c) Alessio Parma <alessio.parma@gmail.com>. All rights reserved.
//
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using ShaiRandom.Generators;

namespace ShaiRandom.Distributions
{
    /// <summary>
    ///   Models a distribution with an alpha parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface IAlphaDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter alpha which is used for generation of distributed random numbers.
        /// </summary>
        TNum Alpha { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Alpha"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Alpha"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidAlpha(TNum value);
    }

    /// <summary>
    ///   Models a distribution with a beta parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface IBetaDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter beta which is used for generation of distributed random numbers.
        /// </summary>
        TNum Beta { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Beta"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Beta"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidBeta(TNum value);
    }

    /// <summary>
    ///   Declares common functionality for all continuous random number distributions.
    /// </summary>
    public interface IContinuousDistribution : IDistribution
    {
    }

    /// <summary>
    ///   Declares common functionality for all discrete random number distributions.
    /// </summary>
    public interface IDiscreteDistribution : IDistribution
    {
        /// <summary>
        ///   Returns a distributed random number.
        /// </summary>
        /// <returns>A distributed 32-bit signed integer.</returns>
        int NextInt();
    }

    /// <summary>
    ///   Declares common functionality for all random number distributions.
    /// </summary>
    public interface IDistribution
    {

        /// <summary>
        ///   Gets the <see cref="IEnhancedRandom"/> object that is used as underlying random number generator.
        /// </summary>
        IEnhancedRandom Generator { get; }

        /// <summary>
        ///   Gets the maximum possible value of distributed random numbers.
        /// </summary>
        double Maximum { get; }

        /// <summary>
        ///   Gets the mean of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if mean is not defined for given distribution with some parameters.
        /// </exception>
        double Mean { get; }

        /// <summary>
        ///   Gets the median of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if median is not defined for given distribution with some parameters.
        /// </exception>
        double Median { get; }

        /// <summary>
        ///   Gets the minimum possible value of distributed random numbers.
        /// </summary>
        double Minimum { get; }

        /// <summary>
        ///   Gets the mode of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if mode is not defined for given distribution with some parameters.
        /// </exception>
        double[] Mode { get; }

        /// <summary>
        ///   Gets the variance of distributed random numbers.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   Thrown if variance is not defined for given distribution with some parameters.
        /// </exception>
        double Variance { get; }

        /// <summary>
        ///   Returns a distributed floating point random number.
        /// </summary>
        /// <returns>A distributed double-precision floating point number.</returns>
        double NextDouble();
    }

    /// <summary>
    ///   Models a distribution with a gamma parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface IGammaDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter gamma which is used for generation of distributed random numbers.
        /// </summary>
        TNum Gamma { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Gamma"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Gamma"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidGamma(TNum value);
    }

    /// <summary>
    ///   Models a distribution with a lambda parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface ILambdaDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter lambda which is used for generation of distributed random numbers.
        /// </summary>
        TNum Lambda { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Lambda"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Lambda"/>;
        ///   otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidLambda(TNum value);
    }

    /// <summary>
    ///   Models a distribution with a mu parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface IMuDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter mu which is used for generation of distributed random numbers.
        /// </summary>
        TNum Mu { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Mu"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Mu"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidMu(TNum value);
    }

    /// <summary>
    ///   Models a distribution with a nu parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface INuDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter nu which is used for generation of distributed random numbers.
        /// </summary>
        TNum Nu { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Nu"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Nu"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidNu(TNum value);
    }

    /// <summary>
    ///   Models a distribution with a sigma parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface ISigmaDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter sigma which is used for generation of distributed random numbers.
        /// </summary>
        TNum Sigma { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Sigma"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Sigma"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidSigma(TNum value);
    }

    /// <summary>
    ///   Models a distribution with a theta parameter.
    /// </summary>
    /// <typeparam name="TNum">The numeric type of the parameter.</typeparam>
    public interface IThetaDistribution<TNum> where TNum : struct
    {
        /// <summary>
        ///   Gets or sets the parameter theta which is used for generation of distributed random numbers.
        /// </summary>
        TNum Theta { get; set; }

        /// <summary>
        ///   Determines whether the specified value is valid for parameter <see cref="Theta"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Theta"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsValidTheta(TNum value);
    }

    /// <summary>
    ///   Models a distribution with a weights parameter.
    /// </summary>
    /// <typeparam name="T">The numeric type of the parameter.</typeparam>
    public interface IWeightsDistribution<T> where T : struct
    {
        /// <summary>
        ///   Gets or sets the parameter weights which is used for generation of distributed random numbers.
        /// </summary>
        ICollection<T> Weights { get; set; }

        /// <summary>
        ///   Determines whether specified values are valid for parameter <see cref="Weights"/>.
        /// </summary>
        /// <param name="values">The values to check.</param>
        /// <returns>
        ///   <see langword="true"/> if value is valid for parameter <see cref="Weights"/>;
        ///   otherwise, <see langword="false"/>.
        /// </returns>
        bool AreValidWeights(IEnumerable<T> values);
    }
}
