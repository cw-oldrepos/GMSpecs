using System;
using System.Collections.Generic;
using System.Text;
using System.Management;




namespace HardWareInfo
{
     
    public class Cpu
    {

    private  Wmi wmi;
    private Dictionary<int, string> AbilityList = new Dictionary<int, string>();
    private Dictionary<int, string> CpuStatusList = new Dictionary<int, string>();
    private Dictionary<int, string> FamilyList = new Dictionary<int, string>();
    private Dictionary<int, string> ArchitectureList = new Dictionary<int, string>();
    private Dictionary<int, string> ProcessorTypeList = new Dictionary<int, string>();
    private Dictionary<int, string> VolatageCapList = new Dictionary<int, string>();
    private string mDeviceID;


        /// <summary>
        /// Initialization
        /// </summary>
        public Cpu()   
        {
        wmi = new Wmi("Win32_Processor");
                    

        }


        /// <summary>
        /// DeviceID you can use Cpu.CpusList() to get all installed CPUs
        /// </summary>
     
        public Cpu(string DeviceID) // 
        {

              wmi = new Wmi("Win32_Processor");
              mDeviceID = DeviceID;
              ArchitectureList.Add(0,"x86");
              ArchitectureList.Add(1,"MIPS");
              ArchitectureList.Add(2,"Alpha");
              ArchitectureList.Add(3, "PowerPC");
              ArchitectureList.Add(6, "Intel Itanium Processor Family (IPF)");
              ArchitectureList.Add(9, "x64");

              /* Ability List */
              AbilityList.Add(1, "Other");
              AbilityList.Add(2, "Unknown");
              AbilityList.Add(3, "Running or Full Power");
              AbilityList.Add(4, "Warning");
              AbilityList.Add(5, "In Test");
              AbilityList.Add(6, "Not Applicable");
              AbilityList.Add(7, "Power Off");
              AbilityList.Add(8, "Off Line");
              AbilityList.Add(9, "Off Duty");
              AbilityList.Add(10, "Degraded");
              AbilityList.Add(11, "Not Intalled");
              AbilityList.Add(12, "Install Error");
              AbilityList.Add(13, "Power Save ,exact Status Unknown");
              AbilityList.Add(14, "Power Save - Low Power Mode");
              AbilityList.Add(15, "Power Save - Standby");
              AbilityList.Add(16, "Power Cycle");
              AbilityList.Add(17, "Power Save - Warning");

              /* CpuStatus List */
              CpuStatusList.Add(0, "Unknown");
              CpuStatusList.Add(1, "CPU Enabled");
              CpuStatusList.Add(2, "CPU Disabled by User via BIOS Setup");
              CpuStatusList.Add(3, "CPU Disabled by BIOS (POST Error)");
              CpuStatusList.Add(4, "Cpu is Idle");
              CpuStatusList.Add(5, "Reserved");
              CpuStatusList.Add(6, "Reserved");
              CpuStatusList.Add(7, "Other");

              /*Family List */
              FamilyList.Add(1, "Other");
              FamilyList.Add(2, "Unknown");
              FamilyList.Add(3, "8086");
              FamilyList.Add(4, "80286");
              FamilyList.Add(5, "Intel386 Processor");
              FamilyList.Add(6, "Intel486 Processor");
              FamilyList.Add(7, "8087");
              FamilyList.Add(8, "80287");
              FamilyList.Add(9, "80387");
              FamilyList.Add(10, "80487");
              FamilyList.Add(11, "Pentium Brand");
              FamilyList.Add(12, "Pentium Pro");
              FamilyList.Add(13, "Pentium II");
              FamilyList.Add(14, "Pentium Processor with MMX Technology");
              FamilyList.Add(15, "Celeron");
              FamilyList.Add(16, "Pentium II Xeon");
              FamilyList.Add(17, "Pentium III");
              FamilyList.Add(18, "M1 Family");
              FamilyList.Add(19, "M2 Family");
              FamilyList.Add(24, "AMD Duron Processor Family");
              FamilyList.Add(25, "K5 Family");
              FamilyList.Add(26, "K6 Family");
              FamilyList.Add(27, "K6-2");
              FamilyList.Add(28, "K6-3");
              FamilyList.Add(29, "AMD Athlon Processor Family");
              FamilyList.Add(30, "AMD2900 Family");
              FamilyList.Add(31, "K6-2+");
              FamilyList.Add(32, "Power PC Family");
              FamilyList.Add(33, "Power PC 601");
              FamilyList.Add(34, "Power PC 603");
              FamilyList.Add(35, "Power PC 603+");
              FamilyList.Add(36, "Power PC 604");
              FamilyList.Add(37, "Power PC 620");
              FamilyList.Add(38, "Power PC X704");
              FamilyList.Add(39, "Power PC 750");
              FamilyList.Add(48, "Alpha Family");
              FamilyList.Add(49, "Alpha 21064");
              FamilyList.Add(50, "Alpha 21066");
              FamilyList.Add(51, "Alpha 21164");
              FamilyList.Add(52, "Alpha 21164PC");
              FamilyList.Add(53, "Alpha 21164a");
              FamilyList.Add(54, "Alpha 21264");
              FamilyList.Add(55, "Alpha 21364");
              FamilyList.Add(64, "MIPS Family");
              FamilyList.Add(65, "MIPS R4000");
              FamilyList.Add(66, "MIPS R4200");
              FamilyList.Add(67, "MIPS R4400");
              FamilyList.Add(68, "MIPS R4600");
              FamilyList.Add(69, "MIPS R10000");
              FamilyList.Add(80, "SPARC Family");
              FamilyList.Add(81, "SuperSPARC");
              FamilyList.Add(82, "microSPARC II");
              FamilyList.Add(83, "microSPARC IIep");
              FamilyList.Add(84, "UltraSPARC");
              FamilyList.Add(85, "UltraSPARC II");
              FamilyList.Add(86, "UltraSPARC IIi");
              FamilyList.Add(87, "UltraSPARC III");
              FamilyList.Add(88, "UltraSPARC IIIi");
              FamilyList.Add(96, "68040");
              FamilyList.Add(97, "68xxx Family");
              FamilyList.Add(98, "68000");
              FamilyList.Add(99, "68010");
              FamilyList.Add(100, "68020");
              FamilyList.Add(101, "68030");
              FamilyList.Add(112, "Hobbit Family");
              FamilyList.Add(120, "Crusoe TM5000 Family");
              FamilyList.Add(121, "Crusoe TM3000 Family");
              FamilyList.Add(122, "Efficeon TM8000 Family");
              FamilyList.Add(128, "Weitek");
              FamilyList.Add(130, "Itanium Processor");
              FamilyList.Add(131, "AMD Athlon 64 Processor Famiily");
              FamilyList.Add(132, "AMD Opteron Processor Family");
              FamilyList.Add(144, "PA-RISC Family");
              FamilyList.Add(145, "PA-RISC 8500");
              FamilyList.Add(146, "PA-RISC 8000");
              FamilyList.Add(147, "PA-RISC 7300LC");
              FamilyList.Add(148, "PA-RISC 7200");
              FamilyList.Add(149, "PA-RISC 7100LC");
              FamilyList.Add(150, "PA-RISC 7100");
              FamilyList.Add(160, "V30 Family");
              FamilyList.Add(176, "Pentium III Xeon Processor");
              FamilyList.Add(177, "Pentium III Processor with Intel SpeedStep&trade; Technology");
              FamilyList.Add(178, "Pentium 4");
              FamilyList.Add(179, "Intel Xeon");
              FamilyList.Add(180, "AS400 Family");
              FamilyList.Add(181, "Intel Xeon Processor MP");
              FamilyList.Add(182, "AMD Athlon XP Family");
              FamilyList.Add(183, "AMD Athlon MP Family");
              FamilyList.Add(184, "Intel Itanium 2");
              FamilyList.Add(185, "Intel Pentium M Processor");
              FamilyList.Add(190, "K7");
              FamilyList.Add(200, "IBM390 Family");
              FamilyList.Add(201, "G4");
              FamilyList.Add(202, "G5");
              FamilyList.Add(203, "G6");
              FamilyList.Add(204, "z/Architecture Base");
              FamilyList.Add(250, "i860");
              FamilyList.Add(251, "i960");
              FamilyList.Add(260, "SH-3");
              FamilyList.Add(261, "SH-4");
              FamilyList.Add(280, "ARM");
              FamilyList.Add(281, "StrongARM");
              FamilyList.Add(300, "6x86");
              FamilyList.Add(301, "MediaGX");
              FamilyList.Add(302, "MII");
              FamilyList.Add(320, "WinChip");
              FamilyList.Add(350, "DSP");
              FamilyList.Add(500, "Video Processor");

              /* Processor Type */
              ProcessorTypeList.Add(1, "Other");
              ProcessorTypeList.Add(2, "Unknown");
              ProcessorTypeList.Add(3, "Central Processor");
              ProcessorTypeList.Add(4, "Math Processor");
              ProcessorTypeList.Add(5, "DSP Processor");
              ProcessorTypeList.Add(6, "Video Processor");

              /*Voltage Cap List */
              VolatageCapList.Add(1, "5 volts");
              VolatageCapList.Add(2, "3.3 volts");
              VolatageCapList.Add(4, "2.9 volts");
                   

        }

    public void setDeviceID(string DeviceID) { mDeviceID = DeviceID; }


        /// <summary>
        /// Processor information that describes the processor features. For an x86 class CPU, the field format depends on the processor support of the CPUID instruction. If the instruction is supported, the property contains 2 (two) DWORD formatted values. The first is an offset of 08h-0Bh, which is the EAX value that a CPUID instruction returns with input EAX set to 1. The second is an offset of 0Ch-0Fh, which is the EDX value that the instruction returns. Only the first two bytes of the property are significant and contain the contents of the DX register at CPU reset—all others are set to 0 (zero), and the contents are in DWORD format.
        /// </summary>
        /// 

        public string ProcessorId
        {

        get
        {
            return wmi.GetInfo("ProcessorId", mDeviceID);
        }
        }

        /// <summary>
        /// System revision level that depends on the architecture. The system revision level contains the same values as the Version property, but in a numerical format. 
        /// </summary>
        public string Revision
        {
            get
            {
                return wmi.GetInfo("Revision", mDeviceID);
            }


        }

        /// <summary>
        /// Type of chip socket used on the circuit.
        /// </summary>
        public string Socket
        {
            get
            {
                return wmi.GetInfo("SocketDesignation", mDeviceID);
            }


        }

     
      

  
        /// <summary>
        /// Size of the Level 2 processor cache. A Level 2 cache is an external memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public  string L2CacheSize
     {

         get
         {


             return wmi.GetInfo("L2CacheSize", mDeviceID);
         }

       
     }

        /// <summary>
        /// Maximum speed of the processor, in MHz.
        /// </summary>
        public  string MaxClockSpeed
        {
            get
            {
                return wmi.GetInfo("MaxClockSpeed", mDeviceID);
            }
          
              }

        /// <summary>
        /// Number of cores for the current instance of the processor. A core is a physical processor on the integrated circuit. For example, in a dual-core processor this property has a value of 2. For more information.
        /// </summary>

        public string NumberofCores
        {
            get
            {
                return wmi.GetInfo("NumberOfCores", mDeviceID);
            }
        }

        /// <summary>
        /// Number of logical processors for the current instance of the processor. For processors capable of hyperthreading, this value includes only the processors which have hyperthreading enabled. For more information.
        /// </summary>
        public string NumberofLogicalProcessor
        {
            get
            {
                return wmi.GetInfo("NumberOfLogicalProcessors", mDeviceID);
            }
        }

        /// <summary>
        /// Name of the processor manufacturer.
        /// </summary>
        public string Manufacturer
        {
            get
            {


                return wmi.GetInfo("Manufacturer", mDeviceID);
            }

        }
        /// <summary>
        /// On a 32-bit processor, the value is 32 and on a 64-bit processor it is 64.
        /// </summary>
        public string DataWidth
        {
            get
            {
                return wmi.GetInfo("DataWidth", mDeviceID);
            }

        
        }

        /// <summary>
        /// On a 32-bit operating system, the value is 32 and on a 64-bit operating system it is 64. 
        /// </summary>
        public string AddressWidth
        {
            get
            {
                return wmi.GetInfo("AddressWidth", mDeviceID);
            }

        }

        /// <summary>
        /// Processor architecture used by the platform.
        /// </summary>
        public string Architecture
        {
            get
            {
                string temp = null;
                ArchitectureList.TryGetValue(int.Parse(wmi.GetInfo("Architecture", mDeviceID)), out temp);
                return temp;
            }

        }

        /// <summary>
        /// Unique identifier of a processor on the system.
        /// </summary>
        public string DeviceID
        {
            get
            {
                return wmi.GetInfo("DeviceID", mDeviceID);
            }

        }

        /// <summary>
        /// Availability and status of the device.
        /// </summary>

        public string Availability
        {
            get
            {


                string temp = "";
                AbilityList.TryGetValue(Convert.ToInt32(wmi.GetInfo("Availability", mDeviceID)), out temp);
                return temp;
            }

        }
        /// <summary>
        /// Short description of an object (a one-line string).
        /// </summary>
        public string Caption
        {
            get
            {
                return wmi.GetInfo("Caption", mDeviceID);
            }

        }

        /// <summary>
        /// Current status of the processor. Status changes indicate processor usage, but not the physical condition of the processor.
        /// </summary>
        public string Status
        {
            get
            {
                string temp = "";
                CpuStatusList.TryGetValue(Convert.ToInt32(wmi.GetInfo("CpuStatus", mDeviceID)), out temp);
                return temp;
            }


        }

        /// <summary>
        /// Current speed of the processor, in MHz.
        /// </summary>

        public string CurrentClockSpeed
        {
            get
            {
                return wmi.GetInfo("CurrentClockSpeed", mDeviceID);
            }

        }

        /// <summary>
        /// Voltage of the processor. If the eighth bit is set, bits 0-6 contain the voltage multiplied by 10. If the eighth bit is not set, then the bit setting in VoltageCaps represents the voltage value. CurrentVoltage is only set when SMBIOS designates a voltage value. 
        /// </summary>
        public string CurrentVoltage
        {
            get
            {
                return wmi.GetInfo("CurrentVoltage'Salut'", mDeviceID) + " volts";
            }

        }
        /// <summary>
        /// Description of the object. 
        /// </summary>
        public string Description
        {
            get
            {
                return wmi.GetInfo("Description", mDeviceID);

            }


        }
         
        /// <summary>
        /// External clock frequency, in MHz. If the frequency is unknown, this property is set to NULL. 
        /// </summary>
        public string ExternalClockFreq
        {

            get
            {
                return wmi.GetInfo("ExtClock", mDeviceID);
            }

        }

        /// <summary>
        /// Processor family type. 
        /// </summary>
        public string Familiy
        {
            get
            {
                string temp = "";
                try
                {
                    FamilyList.TryGetValue(int.Parse(wmi.GetInfo("Family", mDeviceID)), out temp);
                }
                catch
                {
                }
                return temp;

            }

        }

        /// <summary>
        /// If TRUE, the power of the device can be managed, which means that it can be put into suspend mode, and so on. The property does not indicate that power management features are enabled, but it does indicate that the logical device power can be managed. 
        /// </summary>
        public string PowerManagementSupported
        {
            get
            {
                return wmi.GetInfo("PowerManagementSupported", mDeviceID);
            }

        }

        /// <summary>
        /// Label by which the object is known.
        /// </summary>
        public string Name
        {
            get
            {
                return wmi.GetInfo("Name", mDeviceID);
            }


        }

        /// <summary>
        /// Primary function of the processor.
        /// </summary>
        public string ProcessorType
        {
            get
            {
                string temp = "";
                try
                {
                    ProcessorTypeList.TryGetValue(int.Parse(wmi.GetInfo("ProcessorType", mDeviceID)), out temp);
                }
                catch
                {
                }
                return temp;
            }

        }

        /// <summary>
        /// Voltage capabilities of the processor. Bits 0-3 of the field represent specific voltages that the processor socket can accept. All other bits should be set to 0 (zero). The socket is configurable if multiple bits are set. For more information about the actual voltage at which the processor is running, see CurrentVoltage. If the property is NULL, then the voltage capabilities are unknown. 
        /// </summary>
        public string VoltageCap
        {
            get
            {
                string temp = "";
                try
                {
                    VolatageCapList.TryGetValue(int.Parse(wmi.GetInfo("VoltageCaps", mDeviceID)), out temp);
                }
                catch
                {
                    temp = "Voltage Unknown";
                }
                return temp;
            }

        }
     
          /// <summary>
        /// Clock speed of the Level 2 processor cache. A Level 2 cache is an external memory area that has a faster access time than the main RAM memory.
          /// </summary>
        public string L2CacheSpeed
        {
            get
            {
                return wmi.GetInfo("L2CacheSpeed", mDeviceID);
            }

        }

        /// <summary>
        /// Size of the Level 3 processor cache. A Level 3 cache is an external memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public string L3CacheSize
        {
            get
            {
                return wmi.GetInfo("L3CacheSize", mDeviceID);
            }

        }
          
        /// <summary>
        /// Clockspeed of the Level 3 property cache. A Level 3 cache is an external memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public string L3CacheSpeed
        {
            get
            {
                return wmi.GetInfo("L3CacheSpeed", mDeviceID);
            }

        }

        /// <summary>
        /// List of All CPUs
        /// </summary>
      public static List<string> CpusList
        {
             get {         

          Wmi TMP = new Wmi("Win32_Processor");

          return TMP.GetAllData("DeviceID");
             }
          

        }

        /// <summary>
        /// The MMX instruction set is available.
        /// </summary>
      public bool IsMMXSupported
      {

          get
          {
             return NativeMethods.IsProcessorFeaturePresent(NativeMethods.PF_MMX_INSTRUCTIONS_AVAILABLE);

          }

      }

        /// <summary>
       /// The 3D-Now instruction set is available.
        /// </summary> 
      public bool Is3DNowSupported
        {

            get
            {

                return NativeMethods.IsProcessorFeaturePresent(NativeMethods.PF_3DNOW_INSTRUCTIONS_AVAILABLE);


            }
        }

        /// <summary>
        /// The SSE3 instruction set is available.
        /// </summary>
      public bool IsSSE3Supported
      {

          get
          {

              return NativeMethods.IsProcessorFeaturePresent(NativeMethods.PF_SSE3_INSTRUCTIONS_AVAILABLE);

          }
      }

        /// <summary>
        /// The SSE2 instruction set is available.
        /// </summary>
      public bool IsSSE2Supported
        {

            get
            {

                return NativeMethods.IsProcessorFeaturePresent(NativeMethods.PF_XMMI64_INSTRUCTIONS_AVAILABLE);


            }

        }

        /// <summary>
        /// The SSE instruction set is available.
        /// </summary>
      public bool IsSSESupported
        {

            get
            {
                return NativeMethods.IsProcessorFeaturePresent(NativeMethods.PF_XMMI_INSTRUCTIONS_AVAILABLE);

            }
        }




        
    }
}
