using System;
using System.Linq;

namespace Marathon.Core.ViewModel.Base
{
    /// <summary>
    /// Class of helper methods for design-time data of view model
    /// </summary>
    public static class DesignModelHelpers
    {
        /// <summary>
        /// Converts Hex string to byte array
        /// </summary>
        /// <param name="hex">Hex string that contains data</param>
        /// <returns>Array of bytes</returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}
