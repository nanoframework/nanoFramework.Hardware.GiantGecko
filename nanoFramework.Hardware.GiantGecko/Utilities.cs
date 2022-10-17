//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.GiantGecko
{
    /// <summary>
    /// Utilities for managing and handling Silabs Giant Gecko target devices.
    /// </summary>
    public class Utilities
    {
        private static byte[] _deviceUniqueId;
        private static byte _productionRevision;
        private static byte _deviceFamily;
        private static byte _deviceNumber;

        /// <summary>
        /// Gets the 64 bits of the device unique number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is composed of the UNIQUEL and UNIQUEH from MCU. Check product manual for details.
        /// </para>
        /// </remarks>
        public static byte[] UniqueDeviceId
        {
            get
            {
                if (_deviceUniqueId == null)
                {
                    _deviceUniqueId = new byte[16];
                    NativeGetDeviceUniqueId(_deviceUniqueId);
                }

                return _deviceUniqueId;
            }
        }

        /// <summary>
        /// Gets the Production revision.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is coming from bits 31:24 of PART address in MCU. Check product manual for details.
        /// </para>
        /// </remarks>
        public static byte ProductionRevision
        {
            get
            {
                if (_productionRevision == 0)
                {
                    _productionRevision = NativeGetProductionRevision();
                }

                return _productionRevision;
            }
        }

        /// <summary>
        /// Gets the Device Family.
        /// </summary>
        /// <remarks>
        /// <para>
        /// e.g. 72 for EFM32 Giant Gecko Device Family.
        /// </para>
        /// <para>
        /// This is coming from bits 23:16 of PART address in MCU. Check product manual for details.
        /// </para>
        /// </remarks>
        public static byte DeviceFamily
        {
            get
            {
                if (_deviceFamily == 0)
                {
                    _deviceFamily = NativeGetDeviceFamily();
                }

                return _deviceFamily;
            }
        }

        /// <summary>
        /// Gets the Device number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Part number as unsigned integer (e.g. 233 for EFR32BG1P233F256GM48-B0).
        /// </para>
        /// <para>
        /// This is coming from bits 15:0 of PART address in MCU. Check product manual for details.
        /// </para>
        /// </remarks>
        public static uint DeviceNumber
        {
            get
            {
                if (_deviceNumber == 0)
                {
                    _deviceNumber = NativeGetDeviceNumber();
                }

                return _deviceNumber;
            }
        }

        #region native methods calls

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void NativeGetDeviceUniqueId(byte[] data);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern byte NativeGetProductionRevision();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern byte NativeGetDeviceFamily();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern byte NativeGetDeviceNumber();

        #endregion
    }
}
