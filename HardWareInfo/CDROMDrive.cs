using System;
using System.Collections.Generic;
using System.Text;

namespace HardWareInfo
{
    public class CdromDrive
    {
        /// <summary>
        /// 
        /// </summary>
        Wmi wmi;
        string mDeviceID;


        /// <summary>
        ///  initialization
        /// </summary>
        /// <param name="DeviceID">DeviceID for the Device you can use CDromDriveList to get a full list of installed Device </param>
        public CdromDrive(string DeviceID)
        {

            wmi = new Wmi("Win32_CDROMDrive");

            mDeviceID = DeviceID;

        }

        /// <summary>
        /// initialization
        /// </summary>
        public CdromDrive()
        {
            wmi = new Wmi("Win32_CDROMDrive");
        }

        /// <summary>
        /// DeviceID from Caption
        /// </summary>
        /// <param name="caption">Caption of the Device</param>
        /// <returns>DeviceID</returns>
        public string GetDeviceIdFromCaption(string caption)
        {

            Wmi TWmi = new Wmi("Win32_DiskDrive", "WHERE Caption='" + caption + "'");

            return TWmi.GetInfo("DeviceID");

        }
       

        /// <summary>
        /// capabilities of the media access device. For example, the device may support random access (3), removable media (7), and automatic cleaning (9).
        /// </summary>
        public string[] Capability
        {
            get
            {
                Wmi tmp = new Wmi("Win32_CDROMDrive", "WHERE DeviceID='" + mDeviceID + "'");
                return (string[])tmp.GetManagementObject().GetPropertyValue("CapabilityDescriptions");
            }




        }

        /// <summary>
        /// Drive letter of the  drive.
        /// </summary>
        public string DriveLetter
        {
            get
            {
                return wmi.GetInfo("Drive", mDeviceID);
            }
        }

        /// <summary>
        /// Short description of the object
        /// </summary>
        public string Caption
        {
            get
            {
                return wmi.GetInfo("Caption", mDeviceID);
            }

        }


        /// <summary>
        /// Unique identifier for the drive.
        /// </summary>

        public string DeviceID
        {
            get
            {
                return wmi.GetInfo("DeviceID", mDeviceID);
            }

        }

        /// <summary>
        /// Windows Plug and Play device identifier of the logical device. 
        /// </summary>
        public string PNPDeviceID
        {
            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("PNPDeviceID", mDeviceID); }
                return wmi.GetInfo("PNPDeviceID");
            }

        }


        /// <summary>
        /// Lists of all installed CDVD-ROMs 
        /// </summary>
        public static  List<string> CDromDriveList
        {
            get {
            Wmi tmp = new Wmi("Win32_CDROMDrive");
            return tmp.GetAllData("DeviceID");
            }


        }


        /// <summary>
        /// Label for the object.
        /// </summary>
        public string Name
        {
            get
            {
                return wmi.GetInfo("Name", mDeviceID);
            }

        }

        /// <summary>
        /// Type of media that can be used or accessed by this device. Possible values are: 
        /// CdRomOnly
        /// CdRomWrite
        /// DVDRomOnly
        /// DVDRomWrite
        /// Windows Server 2003, Windows XP, Windows 2000, and Windows NT 4.0:  Possible values are:
        /// Random Access
        /// Supports Writing
        /// Removable Media
        /// CD-ROM
        /// </summary>
          
      



        public string MediaType
        {
            get
            {
                return wmi.GetInfo("MediaType", mDeviceID);
            }
        }






    }
}
