//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.GiantGecko
{
    /// <summary>
    /// Provides methods to control power mode of the target CPU.
    /// </summary>
    /// <remarks>
    /// This API is available only for Silabs Giant Gecko targets.
    /// </remarks>
    public static partial class Power
    {
        /// <summary>
        /// Sets the target device to enter Gecko EFM32 "EM4 Hibernate" mode.
        /// </summary>
        /// <remarks>
        /// If no wakeup sources configured then it will be a indefinite sleep.
        /// This call never returns.
        /// After the device enters standby a wakeup source will wake the device and the execution will start as if it was a reset.
        /// Keep in mind that the execution WILL NOT continue after the call to this method.
        /// </remarks>
        public static void EnterHibernateMode()
        {
            NativeEnterHibernateMode();

            // force an infinite sleep to allow execution engine to exit this thread and pick the reboot flags set on the call above
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }

        /// <summary>
        /// Sets the target device to enter Gecko EFM32 "EM4 Shutoff" mode.
        /// </summary>
        /// <remarks>
        /// If no wakeup sources configured then it will be a indefinite sleep.
        /// This call never returns.
        /// After the device enters standby a wakeup source will wake the device and the execution will start as if it was a reset.
        /// Keep in mind that the execution WILL NOT continue after the call to this method.
        /// </remarks>
        public static void EnterShutoffMode()
        {
            NativeEnterShutoffMode();

            // force an infinite sleep to allow execution engine to exit this thread and pick the reboot flags set on the call above
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }

        #region native methods calls

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void NativeEnterHibernateMode();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void NativeEnterShutoffMode();

        #endregion
    }
}
