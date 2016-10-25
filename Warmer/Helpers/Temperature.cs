using System;
using Warmer.Native;

namespace Warmer.Helpers
{
    /// <summary>
    /// Temperature helper
    /// </summary>
    public class TemperatureHelper
    {
        /// <summary>
        /// Creates a new TemperatureHelper
        /// </summary>
        public TemperatureHelper()
        {
            temperature_ = -1;
            current_ = null;
        }

        /// <summary>
        /// Resets the screen temperature
        /// </summary>
        /// <returns>Success or not</returns>
        public bool Reset()
        {
            return Set(NeutralTemp);
        }

        /// <summary>
        /// Sets the screen temperature
        /// </summary>
        /// <param name="temperature">New screen temperature</param>
        /// <returns>Success or not</returns>
        public bool Set(int temperature)
        {
            if (temperature < 1100 || temperature > 25100)
            {
                return false;
            }

            var device = NativeMethods.GetDC(IntPtr.Zero);

            if (device == IntPtr.Zero)
            {
                return false;
            }

            if (!current_.HasValue || temperature_ != temperature)
            {
                current_ = GammaRamp.Create(temperature);
                temperature_ = temperature;
            }

            var ramp = current_.Value;

            bool result = NativeMethods.SetDeviceGammaRamp(device, ref ramp);

            NativeMethods.ReleaseDC(IntPtr.Zero, device);

            return result;
        }

        /// <summary>
        /// Neutral screen temperature
        /// </summary>
        private const int NeutralTemp = 6500;

        /// <summary>
        /// Current gamma ramp
        /// </summary>
        private GammaRamp? current_;

        /// <summary>
        /// Current temperature
        /// </summary>
        private int temperature_;
    }
}
