using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace HardWareInfo
{
   internal class Wmi
    {

      
        private ManagementObject Mo;
        private ManagementScope mMScope;
        private ManagementObjectCollection mCollection;
        private ManagementObjectSearcher mObjSea;
       
       
       
       

       
        public Wmi(string d)
        {

         
            mMScope = new ManagementScope("\\\\.\\root\\cimv2");
            ObjectQuery aObjectQuery = new ObjectQuery("SELECT * FROM " + d); 
            mObjSea = new ManagementObjectSearcher(mMScope, aObjectQuery);
            mCollection = mObjSea.Get();
      

            foreach (ManagementObject obj in mCollection)
            {
                Mo = obj;
                break;


            }



        }

        public Wmi(string d, string f)
        {
            mMScope = new ManagementScope("\\\\.\\root\\cimv2");
            ObjectQuery aObjectQuery = new ObjectQuery("SELECT * FROM " + d +" "+f);
            mObjSea = new ManagementObjectSearcher(mMScope, aObjectQuery);
            mCollection = mObjSea.Get();


            foreach (ManagementObject obj in mCollection)
            {
                Mo = obj;
                break;


            }

        }

    

        public  String GetInfo(string sInfo)
        {

            string ret = null;
                try
                {
                    try
                    {


                        if (sInfo == null) { return "error"; }
                        ret = Mo.GetPropertyValue(sInfo).ToString();
                    }
                    catch (Exception )
                    {


                    }

                } catch (ManagementException e)

                {

                    return e.Message;
                }

                return ret;
               
            }

       public String GetInfo(string sinfo,string DeviceID)
        {
           
      
            string ret = "";

            foreach (ManagementObject mo in mCollection)
            {

                try
                {

                    if (mo["DeviceID"].ToString() == DeviceID)
                    {
                        ret = mo[sinfo].ToString();
                        break;
                    }

                }

                catch (Exception )
                {
                   
                }

              

               
            }

            return ret;

        }


             

       public List<string> GetAllData(string id)
        {
            List<string> liSt = null;
           
            liSt = new List<string>();

            foreach (ManagementObject mob in mCollection)
            {

                liSt.Add(mob[id].ToString());
                

            }

            return liSt;

        }

    

       public ManagementObject GetManagementObject()
       {
           return this.Mo;
       }

    


    



      
   

    }
}
