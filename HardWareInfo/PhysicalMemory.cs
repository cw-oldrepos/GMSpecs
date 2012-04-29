using System;
using System.Collections.Generic;
using System.Text;

namespace HardWareInfo
{
    public class PhysicalMemory
    {
        
        /// <summary>
        ///  PhysicalMemory info
        /// </summary>

        Wmi wmi;
        private string mTag;
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="Tag">unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory.</param>
        public PhysicalMemory(string Tag)
        {

            
            setTag(Tag);

            wmi = new Wmi("Win32_PhysicalMemory","WHERE Tag='"+Tag+"'");



        }

        /// <summary>
        /// set a unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory. 
        /// </summary>
        /// <param name="Tag">Unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory. use PhysicalMemory.MemoryList to get it </param>
        public void setTag(string Tag) { mTag = Tag; }


        /// <summary>
        /// Initialization
        /// </summary>
        public PhysicalMemory()
        {
            wmi = new Wmi("Win32_PhysicalMemory");

        }


        /// <summary>
        /// capacity of the physical memory—in bytes. 
        /// </summary>
        public string Capacity
        {
            get
            {
                string ret = null;
                if (mTag != "")
                {

                    ret = wmi.GetInfo("Capacity");


                }

                return ret;
            }

        }


        /// <summary>
        /// Physically-labeled bank where the memory is located.
        /// </summary>
        public string BankLabel
        {
            get
            {
                string ret = null;
                if (mTag != "")
                {

                    ret = wmi.GetInfo("BankLabel");


                }

                return ret;
            }

                        

        }

        /// <summary>
        /// Short description of the object
        /// </summary>
        public string Caption
        {

            get
            {
                string ret = null;
                if (mTag != "")
                {

                    ret = wmi.GetInfo("Caption");


                }

                return ret;
            }


        }

        /// <summary>
        /// Label of the socket or circuit board that holds the memory.
        /// </summary>
        public string DeviceLocator
        {

            get
            {
                string ret = null;
                if (mTag != "")
                {

                    ret = wmi.GetInfo("DeviceLocator");


                }

                return ret;
            }


        }

        /// <summary>
        /// Speed of the physical memory—in nanoseconds.
        /// </summary>
        public string Speed
        {
            get
            {

                string ret = null;
                if (mTag != "")
                {

                    ret = wmi.GetInfo("Speed");


                }

                return ret;
            }


        }

        /// <summary>
        /// Unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory. 
        /// </summary>
        public string Tag
        {

            get
            {
                string ret = null;
                if (mTag != "")
                {

                    ret = wmi.GetInfo("Tag");


                }

                return ret;
            }


        }

        /// <summary>
        /// Short description of the object
        /// </summary>
        /// <param name="tag">Unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory. </param>
        /// <returns>Caption</returns>
        public string GetCaptionFromTag(string tag)
        {

            Wmi tmp = new Wmi("Win32_PhysicalMemory", "WHERE Tag='" + tag + "'");
            return tmp.GetInfo("Caption");
           

        }

        /// <summary>
        /// Total capacity of the physical memory in bytes.
        /// </summary>
        public static string TotalPhysicalMemory
        {
            get
            {

                Wmi tmp = new Wmi("Win32_ComputerSystem");

                return tmp.GetInfo("TotalPhysicalMemory");
            }


        }

           /// <summary>
           ///  Memory List
           /// </summary>

        public static List<string> MemoryList
        {
            get
            {
                Wmi tmp = new Wmi("Win32_PhysicalMemory");
                return tmp.GetAllData("Tag");
            }




        }



    }

   
}
