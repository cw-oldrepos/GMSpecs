using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace HardWareInfo
{
    public class LogicalDisk
    {
        private Wmi wmi;
        private string mDeviceID;

        Dictionary<int, string> MediaType = new Dictionary<int, string>();
        Dictionary<int, string> TypeDrive = new Dictionary<int, string>();

        private void init()
        {

            wmi = new Wmi("Win32_LogicalDisk");
            MediaType.Add(0, "Format is unknown");
            MediaType.Add(1, "5 1/4-Inch Floppy Disk - 1.2 MB - 512 bytes/sector");
            MediaType.Add(2, "3 1/2-Inch Floppy Disk - 1.44 MB -512 bytes/sector");
            MediaType.Add(3, "3 1/2-Inch Floppy Disk - 2.88 MB - 512 bytes/sector");
            MediaType.Add(4, "3 1/2-Inch Floppy Disk - 20.8 MB - 512 bytes/sector");
            MediaType.Add(5, "3 1/2-Inch Floppy Disk - 720 KB - 512 bytes/sector");
            MediaType.Add(6, "5 1/4-Inch Floppy Disk - 360 KB - 512 bytes/sector");
            MediaType.Add(7, "5 1/4-Inch Floppy Disk - 320 KB - 512 bytes/sector");
            MediaType.Add(8, "5 1/4-Inch Floppy Disk - 320 KB - 1024 bytes/sector");
            MediaType.Add(9, "5 1/4-Inch Floppy Disk - 180 KB - 512 bytes/sector");
            MediaType.Add(10, "5 1/4-Inch Floppy Disk - 160 KB - 512 bytes/sector");
            MediaType.Add(11, "Removable media other than floppy");
            MediaType.Add(12, "Fixed hard disk media");
            MediaType.Add(13, "3 1/2-Inch Floppy Disk - 120 MB - 512 bytes/sector");
            MediaType.Add(14, "3 1/2-Inch Floppy Disk - 640 KB - 512 bytes/sector");
            MediaType.Add(15, "5 1/4-Inch Floppy Disk - 640 KB - 512 bytes/sector");
            MediaType.Add(16, "5 1/4-Inch Floppy Disk - 720 KB - 512 bytes/sector");
            MediaType.Add(17, "3 1/2-Inch Floppy Disk - 1.2 MB - 512 bytes/sector");
            MediaType.Add(18, "3 1/2-Inch Floppy Disk - 1.23 MB - 1024 bytes/sector");
            MediaType.Add(19, "5 1/4-Inch Floppy Disk - 1.23 MB - 1024 bytes/sector");
            MediaType.Add(20, "3 1/2-Inch Floppy Disk - 128 MB - 512 bytes/sector");
            MediaType.Add(21, "3 1/2-Inch Floppy Disk - 230 MB - 512 bytes/sector");
            MediaType.Add(22, "8-Inch Floppy Disk - 256 KB - 128 bytes/sector");


            TypeDrive.Add(0, "Unknown");
            TypeDrive.Add(1, "No Root Directory");
            TypeDrive.Add(2, "Removable Disk");
            TypeDrive.Add(3, "Local Disk");
            TypeDrive.Add(4, "Network Drive");
            TypeDrive.Add(5, "Compact Disc");
            TypeDrive.Add(6, "RAM Disk");

           

        }

     /// <summary>
     /// Initialization
     /// </summary>
        /// <param name="DeviceID">use LogicalDisk.LogicalDiskList</param>
        public LogicalDisk(string DeviceID)
        {


            init();
            mDeviceID = DeviceID;



        }

        /// <summary>
        /// Initialization
        /// </summary>

        public LogicalDisk()
        {
            init();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceID"></param>
        public void setDeviceID(string DeviceID)
        {
            mDeviceID = DeviceID;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <returns></returns>
        public string GetDeviceIdFromCaption(string caption)
        {

            Wmi TWmi = new Wmi("Win32_LogicalDisk", "WHERE Caption='" + caption + "'");

            return TWmi.GetInfo("DeviceID");

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
        /// Numeric value that corresponds to the type of disk drive this logical disk represents.
        /// </summary>
        public string DriveType
        {

            get
            {

                return TypeDrive[Convert.ToInt16(wmi.GetInfo("DriveType", mDeviceID))];
            }

        }


        /// <summary>
        /// File system on the logical disk.
        /// Example: "NTFS"
        /// </summary>
        public string FileSystem
        {

            get
            {
                return wmi.GetInfo("FileSystem", mDeviceID);
            }


        }

        /// <summary>
        /// Space, in bytes, available on the logical disk. 
        /// </summary>
        public string FreeSpace
        {

            get
            {
                return wmi.GetInfo("FreeSpace", mDeviceID);
            }


        }

        /// <summary>
        /// Volume serial number of the logical disk.
        /// </summary>
        public string VolumeSerialNumber
        {

            get
            {
                return wmi.GetInfo("VolumeSerialNumber", mDeviceID);
            }

        }

        /// <summary>
        /// List of All LogicalDisk
        /// </summary>
        public static List<string> LogicalDiskList
        {
            get
            {
                Wmi tmp = new Wmi("Win32_LogicalDisk");
                return tmp.GetAllData("DeviceID");
            }



        }
      

        /// <summary>
        /// Size of the disk drive.
        /// </summary>
        public string TotalSize // in Byte
        {
            get
            {
                return wmi.GetInfo("Size",mDeviceID);
            }


        }

     











    }
}
