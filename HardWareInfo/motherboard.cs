using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace HardWareInfo
{
    public class Motherboard
    {
        /// <summary>
        /// 
        /// </summary>
        private Wmi wmi;

        /// <summary>
        /// Initialization
        /// </summary>
        public Motherboard()
        {

            wmi = new Wmi("Win32_BaseBoard");


        }

        /// <summary>
        /// Manufacturer
        /// </summary>
        public string Manufacturer
        {

          get{

            return wmi.GetInfo("Manufacturer");
          }

        }

        /// <summary>
        /// Baseboard part number defined by the manufacturer.
        /// </summary>
        public string Product
        {
            get
            {
                
                return wmi.GetInfo("Product");
            }

        }

        /// <summary>
        /// Manufacturer-allocated number used to identify the physical element.
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return wmi.GetInfo("SerialNumber");
            }

        }

        /// <summary>
        /// Version of the physical element.
        /// </summary>
        public string Version
        {

            get
            {
                return wmi.GetInfo("version");

            }


        }
    

    }
}
