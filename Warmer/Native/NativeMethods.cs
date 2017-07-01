using System;
using System.Runtime.InteropServices;

namespace Warmer.Native
{
    /// <summary>
    /// External native methods
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Gets the device with the given handle
        /// </summary>
        /// <param name="hWnd">Window handle (Can be IntPtr.Zero)</param>
        /// <returns>Device handle</returns>
        [DllImport("user32.dll", EntryPoint = "GetDC")]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// Releases a device handle
        /// </summary>
        /// <param name="hWnd">Window handle (Can be IntPtr.Zero)</param>
        /// <param name="hDC">Device handle</param>
        /// <returns>Success or not</returns>
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        internal static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Changes the given device gamma ramp
        /// </summary>
        /// <param name="hDC">Device handle</param>
        /// <param name="lpRamp">Gamma ramp</param>
        /// <returns>Success or not</returns>
        [DllImport("gdi32.dll", EntryPoint = "SetDeviceGammaRamp")]
        internal static extern bool SetDeviceGammaRamp(IntPtr hDC, ref GammaRamp lpRamp);
    }
}
