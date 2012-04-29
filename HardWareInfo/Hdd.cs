using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows;

namespace HardWareInfo
{
    public class Hdd
    {

        private Wmi wmi;
        private string mDeviceID = "";

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="DeviceID">use Hdd.DrivesList</param>
        public Hdd(string DeviceID)
        {

            wmi = new Wmi("Win32_DiskDrive");
            mDeviceID = DeviceID;

            


        }

       
        /// <summary>
        /// Initialization
        /// </summary>
        public Hdd()
        {

            wmi = new Wmi("Win32_DiskDrive");
            


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <returns></returns>
        public string GetDeviceIdFromCaption(string caption)
        {

            Wmi TWmi = new Wmi("Win32_DiskDrive", "WHERE Caption='" + caption + "'");

            return TWmi.GetInfo("DeviceID");

        }

        /// <summary>
        /// Number of bytes in each sector for the physical disk drive.
        /// </summary>
        public string BytesPerSector
        {
            get
            {

                if (mDeviceID != "") { return wmi.GetInfo("BytesPerSector", mDeviceID); }
                return wmi.GetInfo("BytesPerSector");
            }

        }


        /// <summary>
        /// Interface type of physical disk drive. 
        /// </summary>
        public string InterfaceType
        {

            get
            {

                if (mDeviceID != "") { return wmi.GetInfo("InterfaceType", mDeviceID); }


                return wmi.GetInfo("InterfaceType");

            }

                               

        }

        /// <summary>
        /// Short description (one-line string) of the object. 
        /// </summary>
        public string Caption
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("Caption", mDeviceID); }

                return wmi.GetInfo("Caption");
            }

        }

        /// <summary>
        /// Manufacturer's model number of the disk drive.
        /// </summary>
        public string Model
        {

            get
            {

                if (mDeviceID != "") { return wmi.GetInfo("Model", mDeviceID); }

                return wmi.GetInfo("Model");
            }


        }

        /// <summary>
        /// Revision for the disk drive firmware that is assigned by the manufacturer.
        /// </summary>

        public string FirmwareRevision
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("FirmwareRevision", mDeviceID); }
                return wmi.GetInfo("FirmwareRevision");
            }

        }

        /// <summary>
        /// Type of media used or accessed by this device. 
        /// </summary>
        public string MediaType
        {
            get
            {

                if (mDeviceID != "") { return wmi.GetInfo("MediaType", mDeviceID); }
                return wmi.GetInfo("MediaType");
            }

        }


        /// <summary>
        /// Physical drive number of the given drive. 
        /// </summary>
        public string Index
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("Index", mDeviceID); }
                return wmi.GetInfo("Index");
            }

        }

        /// <summary>
        /// Number of partitions on this physical disk drive that are recognized by the operating system.
        /// </summary>
        public string Partitions
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("Partitions", mDeviceID); }
                return wmi.GetInfo("Partitions");
            }


        }

        /// <summary>
        /// Windows Plug and Play device identifier of the logical device.
        /// </summary>
        public string PNPDeviceID
        
        {
            get {
            if (mDeviceID != "") { return wmi.GetInfo("PNPDeviceID", mDeviceID); }
            return wmi.GetInfo("PNPDeviceID");
            }

        }

        /// <summary>
        /// Number allocated by the manufacturer to identify the physical media.
        /// </summary>
        public string SerialNumber
        {

            get
            {

                if (mDeviceID != "") { return wmi.GetInfo("SerialNumber", mDeviceID); }
                return wmi.GetInfo("SerialNumber");
            }

        }

        /// <summary>
        /// Number of sectors in each track for this physical disk drive.
        /// </summary>
        public string SectorsPerTrack
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("SectorsPerTrack", mDeviceID); }
                return wmi.GetInfo("SectorsPerTrack");
            }

        }


        /// <summary>
        /// Size of the disk drive. It is calculated by multiplying the total number of cylinders, tracks in each cylinder, sectors in each track, and bytes in each sector.
        /// </summary>
        public string TotalSizeInBytes
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("Size", mDeviceID); }
                return wmi.GetInfo("Size");
            }

        }

    
        /// <summary>
        /// Total number of cylinders on the physical disk drive. Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. Consult the manufacturer for accurate drive specifications.
        /// </summary>
        public string TotalCylinders
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("TotalCylinders", mDeviceID); }
                return wmi.GetInfo("TotalCylinders");
            }


        }


        /// <summary>
        /// Total number of heads on the disk drive. Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. Consult the manufacturer for accurate drive specifications.
        /// </summary>
        public string TotalHeads
        {
            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("TotalHeads", mDeviceID); }
                return wmi.GetInfo("TotalHeads");
            }


        }


        /// <summary>
        /// Total number of sectors on the physical disk drive. Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. Consult the manufacturer for accurate drive specifications.
        /// </summary>

        public string TotalSectors
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("TotalSectors", mDeviceID); }
                return wmi.GetInfo("TotalSectors");
            }

        }

        /// <summary>
        /// Total number of tracks on the physical disk drive. Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. Consult the manufacturer for accurate drive specifications.
        /// </summary>
        public string TotalTracks
        {
            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("TotalTracks", mDeviceID); }
                return wmi.GetInfo("TotalTracks");
            }

        }


        /// <summary>
        /// Number of tracks in each cylinder on the physical disk drive. Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. Consult the manufacturer for accurate drive specifications.
        /// </summary>
        public string TracksPerCylinder
        {

            get
            {
                if (mDeviceID != "") { return wmi.GetInfo("TracksPerCylinder", mDeviceID); }
                return wmi.GetInfo("TracksPerCylinder");
            }


        }


        /// <summary>
        /// capabilities of the media access device. For example, the device may support random access (3), removable media (7), and automatic cleaning (9).
        /// </summary>

        public string[] Capabilities
        {
            get
            {

                string[] cap = (string[])wmi.GetManagementObject().GetPropertyValue("CapabilityDescriptions");

                return cap;
            }

        }
        


 



        /// <summary>
        /// List of All Drives
        /// </summary>
        public static List<string> DrivesList
        {
            get {
            Wmi tmp = new Wmi("Win32_DiskDrive");
            return tmp.GetAllData("DeviceID");
            }



        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="DeviceID"></param>

        public void setDeviceID(string DeviceID) { mDeviceID = DeviceID; }
    }

}
