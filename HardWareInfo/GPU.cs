using System;
using System.Collections.Generic;
using System.Text;

namespace HardWareInfo
{
    public class Gpu
    {

        Wmi wmi;
        private string mDeviceID;
        Dictionary<int, string> VideoArch = new Dictionary<int, string>();

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="DeviceID">DeviceID you can use GPUList to get all Installed GPUs</param>
        public Gpu(string DeviceID)
        {
            mDeviceID = DeviceID;
            wmi = new Wmi("Win32_VideoController");
            VideoArch.Add(1, "Other");
            VideoArch.Add(2, "Unknown");
            VideoArch.Add(3, "CGA");
            VideoArch.Add(4, "EGA");
            VideoArch.Add(5, "VGA");
            VideoArch.Add(6, "SVGA");
            VideoArch.Add(7, "MDA");
            VideoArch.Add(8, "HGC");
            VideoArch.Add(9, "MCGA");
            VideoArch.Add(10, "8514A");
            VideoArch.Add(11, "XGA");
            VideoArch.Add(12, "Linear Frame Buffer");
            VideoArch.Add(160, "PC-98");
        }
        /// <summary>
        /// Initialization
        /// </summary>
        public Gpu()
        {
            wmi = new Wmi("Win32_VideoController");
        }

     
        /// <summary>
        /// Label by which the object is known.
        /// </summary>
        public string Name
        {
            get {
                return wmi.GetInfo("Name", mDeviceID);
            }


        }

        /// <summary>
        /// Name or identifier of the digital-to-analog converter (DAC) chip. The character set of this property is alphanumeric.
        /// </summary>
        public string AdapterDACType
        {

            get
            {
                return wmi.GetInfo("AdaptersDACType", mDeviceID);
            }


        }

        /// <summary>
        /// Memory size of the video adapter.
        /// </summary>
        public string AdapterRAM
        {
            get
            {
                return wmi.GetInfo("AdapterRAM", mDeviceID);
            }
        }

        /// <summary>
        /// Short description (one-line string) of the object.
        /// </summary>
        public string Caption
        {
            get {
            return wmi.GetInfo("Caption", mDeviceID);
            }

        }

        /// <summary>
        /// Number of bits used to display each pixel. 
        /// </summary>
        public string CurrentBitsPerPixel
        {
            get
            {
                return wmi.GetInfo("CurrentBitsPerPixel", mDeviceID);
            }

        }

        /// <summary>
        /// Current number of horizontal pixels.
        /// </summary>
        public string CurrentHorizontalResolution
        {
            get
            {
                return wmi.GetInfo("CurrentHorizontalResolution", mDeviceID);
            }


        }

        /// <summary>
        /// Number of colors supported at the current resolution.
        /// </summary>
        public string CurrentNumberOfColors
        {
            get
            {
                return wmi.GetInfo("CurrentNumberOfColors", mDeviceID);
            }


        }

        /// <summary>
        /// requency at which the video controller refreshes the image for the monitor. A value of 0 (zero) indicates the default rate is being used, while 0xFFFFFFFF indicates the optimal rate is being used. 
        /// </summary>

        public string CurrentRefreshRate
        {
            get
            {
                return wmi.GetInfo("CurrentRefreshRate", mDeviceID);
            }


        }

        /// <summary>
        /// Version number of the video driver.
        /// </summary>
        public string DriverVersion
        {
            get
            {
                return wmi.GetInfo("DriverVersion", mDeviceID);
            }


        }

        /// <summary>
        /// Windows Plug and Play device identifier of the logical device.
        /// </summary>
        public string PNPDeviceID
        {
            get
            {
                return wmi.GetInfo("PNPDeviceID", mDeviceID);
            }


        }

        /// <summary>
        /// Free-form string describing the video processor. 
        /// </summary>
        public string VideoProcessor
        {
            get
            {
                return wmi.GetInfo("VideoProcessor", mDeviceID);
            }



        }

        /// <summary>
        /// Current resolution, color, and scan mode settings of the video controller.
        /// Example: "1024 x 768 x 256 colors"
        /// </summary>
        public string VideoModeDescription
        {
            get
            {
                return wmi.GetInfo("VideoModeDescription", mDeviceID);
            }


        }

        /// <summary>
        /// Type of video architecture. 
        /// </summary>
        public string VideoArchitecture
        {
            get
            {

                Wmi tmp = new Wmi("Win32_VideoController", "WHERE DeviceID='" + mDeviceID + "'");

                UInt16 ARch = (UInt16)tmp.GetManagementObject().GetPropertyValue("VideoArchitecture");

                return VideoArch[ARch];
            }

            

        }

        /// <summary>
        /// List of GPUs
        /// </summary>
        public static  List<string> GPUList
        {
            get
            {
                Wmi tmp = new Wmi("Win32_VideoController");
                return tmp.GetAllData("DeviceID");
            }



        }

        public string GetDeviceIdFromCaption(string caption) 
        {

            Wmi TWmi = new Wmi("Win32_VideoController", "WHERE Caption='" + caption + "'");

            return TWmi.GetInfo("DeviceID");

        }


        public void setDeviceID(string DeviceID) { mDeviceID = DeviceID; }


    }
}
