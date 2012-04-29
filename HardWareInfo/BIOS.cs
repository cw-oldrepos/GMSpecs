using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace HardWareInfo
{
 
    public class Bios
    {
        /// <summary>
        ///  Bios information
        /// </summary>

      private  Wmi wmi;

   
      private Dictionary<int, string> BIOSCharacteristicsList = new Dictionary<int, string>();


      /// <summary>
      /// Initialization
      /// </summary>
      /// <remarks></remarks>
        public Bios()
      {

          wmi = new Wmi("Win32_BIOS");
          BIOSCharacteristicsList.Add(0, "Reserved");
          BIOSCharacteristicsList.Add(1, "Reserved");
          BIOSCharacteristicsList.Add(2, "Unknown");
          BIOSCharacteristicsList.Add(3, "BIOS Characteristics Not Supported");
          BIOSCharacteristicsList.Add(4, "ISA is supported");
          BIOSCharacteristicsList.Add(5, "MCA is supported");
          BIOSCharacteristicsList.Add(6, "EISA is supported");
          BIOSCharacteristicsList.Add(7, "PCI is supported");
          BIOSCharacteristicsList.Add(8, "PC Card (PCMCIA) is supported");
          BIOSCharacteristicsList.Add(9, "Plug and Play is supported");
          BIOSCharacteristicsList.Add(10, "APM is supported");
          BIOSCharacteristicsList.Add(11, "BIOS is Upgradable (Flash)");
          BIOSCharacteristicsList.Add(12, "BIOS shadowing is allowed");
          BIOSCharacteristicsList.Add(13, "VL-VESA is supported");
          BIOSCharacteristicsList.Add(14, "ESCD support is available");
          BIOSCharacteristicsList.Add(15, "Boot from CD is supported");
          BIOSCharacteristicsList.Add(16, "Selectable Boot is supported");
          BIOSCharacteristicsList.Add(17, "BIOS ROM is socketed");
          BIOSCharacteristicsList.Add(18, "Boot From PC Card (PCMCIA) is supported");
          BIOSCharacteristicsList.Add(19, "EDD (Enhanced Disk Drive) Specification is supported");
          BIOSCharacteristicsList.Add(20, "Int 13h - Japanese Floppy for NEC 9800 1.2mb (3.5, 1k Bytes/Sector, 360 RPM) is supported");
          BIOSCharacteristicsList.Add(21, "Int 13h - Japanese Floppy for Toshiba 1.2mb (3.5, 360 RPM) is supported");
          BIOSCharacteristicsList.Add(22, "Int 13h - 5.25 / 360 KB Floppy Services are supported");
          BIOSCharacteristicsList.Add(23, "Int 13h - 5.25 /1.2MB Floppy Services are supported");
          BIOSCharacteristicsList.Add(24, "Int 13h - 3.5 / 720 KB Floppy Services are supported");
          BIOSCharacteristicsList.Add(25, "Int 13h - 3.5 / 2.88 MB Floppy Services are supported");
          BIOSCharacteristicsList.Add(26, "Int 5h, Print Screen Service is supported");
          BIOSCharacteristicsList.Add(27, "Int 9h, 8042 Keyboard services are supported");
          BIOSCharacteristicsList.Add(28, "Int 14h, Serial Services are supported");
          BIOSCharacteristicsList.Add(29, "Int 17h, printer services are supported");
          BIOSCharacteristicsList.Add(30, "Int 10h, CGA/Mono Video Services are supported");
          BIOSCharacteristicsList.Add(31, "NEC PC-98");
          BIOSCharacteristicsList.Add(32, "ACPI is supported");
          BIOSCharacteristicsList.Add(33, "USB Legacy is supported");
          BIOSCharacteristicsList.Add(34, "AGP is supported");
          BIOSCharacteristicsList.Add(35, "I2O boot is supported");
          BIOSCharacteristicsList.Add(36, "LS-120 boot is supported");
          BIOSCharacteristicsList.Add(37, "ATAPI ZIP Drive boot is supported");
          BIOSCharacteristicsList.Add(38, "1394 boot is supported");
          BIOSCharacteristicsList.Add(39, "Smart Battery is supported");
          




      }


        /// <summary>
        /// 
        /// </summary>
      
       public UInt16[] BIOSCharDigits
        {
            get
            {
                UInt16[] Bcd = (UInt16[])wmi.GetManagementObject().GetPropertyValue("BiosCharacteristics");
                return Bcd;
            }

        }

       /// <summary>
       /// BIOS characteristics supported by the system as defined by the System Management BIOS Reference Specification.
       /// </summary>
       /// <returns></returns>
       /// <remarks></remarks>
        public List<string> BIOSCharacteristics
       {

           
          get {


               List<string> BIOSChara = new List<string>();
               foreach (UInt16 uin in BIOSCharDigits)
               {
                   try
                   {


                       BIOSChara.Add(BIOSCharacteristicsList[uin]);
                   }
                   catch
                   {


                   }


               }
               return BIOSChara;

           }


       }

        /// <summary>
        /// caption.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>


        public string Caption
        {
            get{
                        
            return wmi.GetInfo("caption");

            }


        }

        /// <summary>
        /// Name of the current BIOS language
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>

        public string CurrentLanguage
        {

            get 
            {
            return wmi.GetInfo("CurrentLanguage");
            }


        }

        /// <summary>
        /// Manufacturer of this software element.
        /// </summary>
   

        public string Manufacturer
        {
            get
            {
                return wmi.GetInfo("Manufacturer");
            }

        }

        /// <summary>
        ///release date.
        /// </summary>

        public string ReleaseDate
        {
            get
            {
                return wmi.GetInfo("ReleaseDate");
            }

        }

        /// <summary>
        /// SMBIOSBIOS version.
        /// </summary>
   
        public string SMBIOSBIOSVersion
        {
            get
            {
                return wmi.GetInfo("SMBIOSBIOSVersion");
            }


        }

        /// <summary>
        /// SMBIOS major version.
        /// </summary>
       
        public string SMBIOSMajorVersion
        {
            get
            {
                return wmi.GetInfo("SMBIOSMajorVersion");

            }


        }

        /// <summary>
        /// SMBIOS minor version.
        /// </summary>
     
        public string SMBIOSMinorVersion
        {
            get
            {
                return wmi.GetInfo("SMBIOSMinorVersion");
            }


        }







       

    }
}
