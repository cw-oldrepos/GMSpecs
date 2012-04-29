using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace HardWareInfo
{
    public static class NativeMethods
    {

        /// <summary>
        /// Determines whether the specified processor feature is supported by the current computer.
        /// </summary>
        /// <param name="ProcessorFeature">The processor feature to be tested.</param>
        /// <returns></returns>

        [DllImport("kernel32.dll")]
        public static extern bool IsProcessorFeaturePresent(uint ProcessorFeature);

     
        public const uint PF_3DNOW_INSTRUCTIONS_AVAILABLE = 7; 
        public const uint PF_CHANNELS_ENABLED = 16;
        public const uint PF_COMPARE_EXCHANGE_DOUBLE = 2;
        public const uint PF_COMPARE_EXCHANGE128 = 14;
        public const uint PF_COMPARE64_EXCHANGE128 = 15;
        public const uint PF_FLOATING_POINT_EMULATED = 1;
        public const uint PF_FLOATING_POINT_PRECISION_ERRATA = 0;
        public const uint PF_MMX_INSTRUCTIONS_AVAILABLE = 3;
        public const uint PF_NX_ENABLED = 12;   
        public const uint PF_PAE_ENABLED = 9;
        public const uint PF_RDTSC_INSTRUCTION_AVAILABLE = 8;
        public const uint PF_SSE3_INSTRUCTIONS_AVAILABLE = 13;
        public const uint PF_XMMI_INSTRUCTIONS_AVAILABLE = 6;
        public const uint PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10;
        public const uint PF_XSAVE_ENABLED = 17;






    }
}
