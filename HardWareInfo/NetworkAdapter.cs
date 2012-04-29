using System;
using System.Collections.Generic;
using System.Text;

namespace HardWareInfo
{
   public  class NetworkAdapter
    {

       private Wmi wmi;
       private string mDeviceID;

 

       /// <summary>
       /// Initialization
       /// </summary>
       public NetworkAdapter()
       {

         wmi = new Wmi("Win32_NetworkAdapter", "WHERE AdapterType = 'Ethernet 802.3'" );
       
       


       }

       /// <summary>
       /// Initialization
       /// </summary>
       /// <param name="DeviceID">Unique id use NetworkAdapter.NetworkAdapterList </param>
       public NetworkAdapter(string DeviceID)
       {
           wmi = new Wmi("Win32_NetworkAdapter", "WHERE AdapterType = 'Ethernet 802.3'");
           mDeviceID = DeviceID;
       }


       public void setDeviceID(string DeviceID) { mDeviceID = DeviceID; }


       /// <summary>
       /// Short description of the object
       /// </summary>
       public string Caption
       {

           get
           {
               return wmi.GetInfo("Caption",mDeviceID);
           }

                      

       }

       /// <summary>
       /// Description of the object.
       /// </summary>
       public string Description
       {
           get {
               return wmi.GetInfo("Description", mDeviceID);
           }
       }

       /// <summary>
       /// Unique identifier of the network adapter from other devices on the system. 
       /// </summary>
       public string DeviceID
       {

           get
           {
               return wmi.GetInfo("DeviceID", mDeviceID);

           }

       }

       /// <summary>
       /// Media access control address for this network adapter. A MAC address is a unique 48-bit number assigned to the network adapter by the manufacturer. It uniquely identifies this network adapter and is used for mapping TCP/IP network communications.
       /// </summary>
       public string MACAddress
       {
           get
           {
               return wmi.GetInfo("MACAddress", mDeviceID);
           }


       }

       /// <summary>
       /// Name of the network adapter's manufacturer.
       /// </summary>
       public string Manufacturer
       {
           get
           {
               return wmi.GetInfo("Manufacturer", mDeviceID);
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
       /// Name of the network connection as it appears in the Network Connections Control Panel program. 
       /// </summary>

       public string NetConnectionID
       {
           get
           {
               return wmi.GetInfo("NetConnectionID", mDeviceID);
           }

       }

       /// <summary>
       /// Globally unique identifier for the connection. 
       /// </summary>
       public string GUID
       {
           get
           {
               return wmi.GetInfo("GUID", mDeviceID);
           }



       }

       /// <summary>
       /// Indicates whether the adapter is enabled or not. If True, the adapter is enabled.
       /// </summary>
      public bool IsNetEnabled
       {
          
           get
           {


              Wmi Twmi = new Wmi("Win32_NetworkAdapter", "WHERE AdapterType = 'Ethernet 802.3' AND DeviceID ='"+ mDeviceID + "'");
              return (bool)Twmi.GetManagementObject().GetPropertyValue("NetEnabled");


           }
          
          
       }


      public string GetDeviceIdFromCaption(string caption)
      {

          Wmi TWmi = new Wmi("Win32_NetworkAdapter", "WHERE Caption='" + caption + "'");

          return TWmi.GetInfo("DeviceID");

      }


       /// <summary>
       /// Index value that uniquely identifies the local network interface.
       /// </summary>
       public string InterfaceIndex
       {

           get
           {
               return wmi.GetInfo("InterfaceIndex", mDeviceID);
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
       /// Service name of the network adapter. This name is usually shorter than the full product name.
       /// </summary>
       public string ServiceName
       {
           get
           {
               return wmi.GetInfo("ServiceName", mDeviceID);
           }

       }

       /// <summary>
       /// Estimate of the current bandwidth in bits per second. For endpoints which vary in bandwidth or for those where no accurate estimation can be made, this property should contain the nominal bandwidth. 
       /// </summary>
       public string Speed
       {
           get
           {
               return wmi.GetInfo("Speed", mDeviceID);
           }

       }


       /// <summary>
       /// List of all Network Adapters
       /// </summary>
       public static List<string> NetworkAdapterList
       {
           get
           {
               Wmi tmp = new Wmi("Win32_NetworkAdapter", "WHERE AdapterType = 'Ethernet 802.3'" );
               return tmp.GetAllData("DeviceID");
           }


       }


        
    }
}
