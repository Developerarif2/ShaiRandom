﻿using System;
using System.Collections.Generic;

namespace ShaiRandom
{
    public interface IEnhancedRandom
    {
        /**
         * Sets the seed of this random number generator using a single
         * {@code long} seed. This should behave exactly the same as if a new
         * object of this type was created with the constructor that takes a single
         * {@code long} value. This does not necessarily assign the state
         * variable(s) of the implementation with the exact contents of seed, so
         * {@link #getSelectedState(int)} should not be expected to return
         * {@code seed} after this, though it may. If this implementation has more
         * than one {@code long} of state, then the expectation is that none of
         * those state variables will be exactly equal to {@code seed} (almost all
         * of the time).
         *
         * @param seed the initial seed
         */
        public void Seed(long seed);

	/**
	 * Gets the number of possible state variables that can be selected with
	 * {@link #getSelectedState(int)} or {@link #SelectState(int, long)}.
	 * This defaults to returning 0, making no state variable available for
	 * reading or writing. An implementation that has only one {@code long}
	 * state, like a SplitMix64 generator, should return {@code 1}. A
	 * generator that permits setting two different {@code long} values, like
	 * {@link LaserRandom}, should return {@code 2}. Much larger values are
	 * possible for types like the Mersenne Twister or some CMWC generators.
	 * @return the non-negative number of selections possible for state variables
	 */
	public int StateCount => 0;
        /**
         * Gets a selected state value from this EnhancedRandom. The number of possible selections
         * is up to the implementing class, and is accessible via {@link #StateCount}, but
         * negative values for {@code selection} are typically not tolerated. This should return
         * the exact value of the selected state, assuming it is implemented. The default
         * implementation throws an NotSupportedException, and implementors only have to
         * allow reading the state if they choose to implement this differently. If this method
         * is intended to be used, {@link #StateCount} must also be implemented.
         * @param selection used to select which state variable to get; generally non-negative
         * @return the exact value of the selected state
         */
        public long SelectState(int selection)
        {
            throw new NotSupportedException("SelectState() not supported.");
        }

	/**
	 * Sets a selected state value to the given long {@code value}. The number of possible
	 * selections is up to the implementing class, but negative values for {@code selection}
	 * are typically not tolerated. Implementors are permitted to change {@code value} if it
	 * is not valid, but they should not alter it if it is valid. The public implementation
	 * calls {@link #setSeed(long)} with {@code value}, which doesn't need changing if the
	 * generator has one state that is set verbatim by setSeed(). Otherwise, this method
	 * should be implemented when {@link #getSelectedState(int)} is and the state is allowed
	 * to be set by users. Having accurate ways to get and set the full state of a random
	 * number generator makes it much easier to serialize and deserialize that class.
	 * @param selection used to select which state variable to set; generally non-negative
	 * @param value the exact value to use for the selected state, if valid
	 */
	public void SelectState(int selection, long value)
        {
            Seed(value);
        }

	/**
	 * Sets each state variable to the given {@code state}. If {@link #StateCount} is
	 * 1, then this should set the whole state to the given value using
	 * {@link #SelectState(int, long)}. If StateCount is more than 1, then all
	 * states will be set in the same way (using SelectState(), all to {@code state}).
	 * @param state the long value to use for each state variable
	 */
	public void SetState(long state)
        {
            for (int i = StateCount - 1; i >= 0; i--)
            {
                SelectState(i, state);
            }
        }

	/**
	 * Sets each state variable to either {@code stateA} or {@code stateB}, alternating.
	 * This uses {@link #SelectState(int, long)} to set the values. If there is one
	 * state variable ({@link #StateCount} is 1), then this only sets that state
	 * variable to stateA. If there are two state variables, the first is set to stateA,
	 * and the second to stateB. If there are more, it reuses stateA, then stateB, then
	 * stateA, and so on until all variables are set.
	 * @param stateA the long value to use for states at index 0, 2, 4, 6...
	 * @param stateB the long value to use for states at index 1, 3, 5, 7...
	 */
	public void SetState(long stateA, long stateB)
        {
            int c = StateCount;
            for (int i = 0; i < c; i += 2)
            {
                SelectState(i, stateA);
            }
            for (int i = 1; i < c; i += 2)
            {
                SelectState(i, stateB);
            }
        }

	/**
	 * Sets each state variable to {@code stateA}, {@code stateB}, or {@code stateC},
	 * alternating. This uses {@link #SelectState(int, long)} to set the values.
	 * If there is one state variable ({@link #StateCount} is 1), then this only
	 * sets that state variable to stateA. If there are two state variables, the first
	 * is set to stateA, and the second to stateB. With three state variables, the
	 * first is set to stateA, the second to stateB, and the third to stateC. If there
	 * are more, it reuses stateA, then stateB, then stateC, then stateA, and so on
	 * until all variables are set.
	 * @param stateA the long value to use for states at index 0, 3, 6, 9...
	 * @param stateB the long value to use for states at index 1, 4, 7, 10...
	 * @param stateC the long value to use for states at index 2, 5, 8, 11...
	 */
	public void SetState(long stateA, long stateB, long stateC)
        {
            int c = StateCount;
            for (int i = 0; i < c; i += 3)
            {
                SelectState(i, stateA);
            }
            for (int i = 1; i < c; i += 3)
            {
                SelectState(i, stateB);
            }
            for (int i = 2; i < c; i += 3)
            {
                SelectState(i, stateC);
            }
        }

	/**
	 * Sets each state variable to {@code stateA}, {@code stateB}, {@code stateC}, or
	 * {@code stateD}, alternating. This uses {@link #SelectState(int, long)} to
	 * set the values. If there is one state variable ({@link #StateCount} is 1),
	 * then this only sets that state variable to stateA. If there are two state
	 * variables, the first is set to stateA, and the second to stateB. With three
	 * state variables, the first is set to stateA, the second to stateB, and the third
	 * to stateC. With four state variables, the first is set to stateA, the second to
	 * stateB, the third to stateC, and the fourth to stateD. If there are more, it
	 * reuses stateA, then stateB, then stateC, then stateD, then stateA, and so on
	 * until all variables are set.
	 * @param stateA the long value to use for states at index 0, 4, 8, 12...
	 * @param stateB the long value to use for states at index 1, 5, 9, 13...
	 * @param stateC the long value to use for states at index 2, 6, 10, 14...
	 * @param stateD the long value to use for states at index 3, 7, 11, 15...
	 */
	public void SetState(long stateA, long stateB, long stateC, long stateD)
        {
            int c = StateCount;
            for (int i = 0; i < c; i += 4)
            {
                SelectState(i, stateA);
            }
            for (int i = 1; i < c; i += 4)
            {
                SelectState(i, stateB);
            }
            for (int i = 2; i < c; i += 4)
            {
                SelectState(i, stateC);
            }
            for (int i = 3; i < c; i += 4)
            {
                SelectState(i, stateD);
            }
        }

	/**
	 * Sets all state variables to alternating values chosen from {@code states}. If states is empty,
	 * then this does nothing, and leaves the current generator unchanged. This works for
	 * generators with any {@link #StateCount}, but may allocate an array if states is
	 * used as a varargs (you can pass an existing array without needing to allocate). This
	 * uses {@link #SelectState(int, long)} to change the states.
	 * @param states an array or varargs of long values to use as states
	 */
	public void SetState(params long[] states)
        {
            int c = StateCount;
            for (int s = 0; s < states.Length; s++)
            {
                long curr = states[s];
                for (int i = s; i < c; i += 3)
                {
                    SelectState(i, curr);
                }
            }
        }

    }
}
