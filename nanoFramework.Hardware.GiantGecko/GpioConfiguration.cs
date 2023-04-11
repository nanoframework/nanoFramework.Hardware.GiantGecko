//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.GiantGecko
{
    /// <summary>
    /// Class exposing various configurations for GPIO pins.
    /// </summary>
    public static class GpioConfiguration
    {
        /// <summary>
        /// Set slewrate limit for the GPIO port that a GPIO pin belongs to. Higher values represent faster slewrates.
        /// </summary>
        /// <param name="pin">Pin number of the general-purpose I/O (GPIO) pin.</param>
        /// <param name="slewRateLimit">Value of slewrate limit. Value has to be between 0 and 7.</param>
        /// <exception cref="InvalidOperationException">If the GPIO <paramref name="pin"/> hasn't been opened before with the appropriate GPIO API.</exception>
        /// <exception cref="ArgumentException">If the <paramref name="slewRateLimit"/> is &lt; 0 or &gt; 7.</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern static void SetSlewRate(
            int pin,
            byte slewRateLimit);

        /// <summary>
        /// Set slewrate limit for alternate modes of a GPIO port that a GPIO pin  belongs to. Higher values represent faster slewrates.
        /// </summary>
        /// <param name="pin">Pin number of the general-purpose I/O (GPIO) pin</param>
        /// <param name="slewRateLimit">Value of slewrate limit. Value has to be between 0 and 7.</param>
        /// <exception cref="ArgumentException">If the <paramref name="slewRateLimit"/> is &lt; 0 or &gt; 7.</exception>
        /// <remarks>No checking will be performed if the GPIO <paramref name="pin"/> is being used in an alternate funcion. That will be up to the caller.</remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern static void SetSlewRateAlternate(
            int pin,
            byte slewRateLimit);

        /// <summary>
        /// Set drive strength setting for the GPIO port that a GPIO pin belongs to.
        /// </summary>
        /// <param name="pin">Pin number of the general-purpose I/O (GPIO) pin</param>
        /// <param name="driveStrenght">Drive strenght setting.</param>
        /// <exception cref="InvalidOperationException">If the GPIO <paramref name="pin"/> hasn't been opened before with the appropriate GPIO API.</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern static void SetDriveStrenght(
            int pin,
            DriveStrenght driveStrenght);

        /// <summary>
        /// Set drive strength setting for alternate modes of GPIO port that a GPIO pin  belongs to.
        /// </summary>
        /// <param name="pin">Pin number of the general-purpose I/O (GPIO) pin</param>
        /// <param name="driveStrenght">Drive strenght setting.</param>
        /// <remarks>No checking will be performed if the GPIO <paramref name="pin"/> is being used in an alternate funcion. That will be up to the caller.</remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern static void SetDriveStrenghtAlternate(
            int pin,
            DriveStrenght driveStrenght);

        /// <summary>
        /// Drive strenght for configuring GPIO pins.
        /// </summary>
        public enum DriveStrenght
        {
            /// <summary>
            /// Strong drive strenght (10 mA drive current).
            /// </summary>
            Strong = 0,

            /// <summary>
            /// Waek drive strenght (1 mA drive current).
            /// </summary>
            Weak = 1
        }
    }
}
