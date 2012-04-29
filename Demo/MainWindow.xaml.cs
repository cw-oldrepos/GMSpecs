using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HardWareInfo;
using System.Management;

namespace WMIApps
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cpu cpu;
        Hdd hdd;
        Gpu gpu; 
        Bios bios = new Bios();
        Motherboard mb = new Motherboard();
        LogicalDisk LD = new LogicalDisk();
        NetworkAdapter Na = new NetworkAdapter();
        PhysicalMemory mem;
        int GPU_RealMem;

       
        public MainWindow()
        {
            InitializeComponent();
            cpu = new Cpu(Cpu.CpusList[0]);
            gpu = new Gpu(Gpu.GPUList[0]);
            hdd = new Hdd();
          Title = "HardWare Info";
         
                        
        }

      

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            string str = null;


            foreach (string d in bios.BIOSCharacteristics)
            {

                str += "\r\n" + d;

            }

            MessageBox.Show(str);
           
        }

   

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label2.Content = "";


            StringBuilder Str = new StringBuilder();
            Str.AppendLine("Processor: " + cpu.Name);
            Str.AppendLine("Caption: " + cpu.Caption);
            Str.AppendLine("Memeoria de sistems" + mem.Capacity);
            Str.AppendLine("Clock Speed: " + (decimal)Convert.ToInt16(cpu.MaxClockSpeed) / 1000 + " GHz");
            Str.AppendLine("Architecture: " + cpu.Architecture);
            Str.AppendLine("Familiy: " + cpu.Familiy);
            Str.AppendLine("Number Of Cores: " + cpu.NumberofCores);
            Str.AppendLine("Number Of Logical Processor: " + cpu.NumberofLogicalProcessor);
            
            Str.AppendLine("L2 Cache Size: " + cpu.L2CacheSize + " KB");
            Str.AppendLine("L3 Cache Size: " + cpu.L3CacheSize + " KB");

            Str.AppendLine();
            Str.AppendLine("Processor Id: " + cpu.ProcessorId );
            Str.AppendLine("Revision: " + cpu.Revision);
            Str.AppendLine("Socket: " + cpu.Socket);

            label1.Content = Str.ToString();


            StringBuilder BIOS_Str = new StringBuilder();

            BIOS_Str.AppendLine("Caption: " + bios.Caption);
            BIOS_Str.AppendLine("CurrentLanguage: " + bios.CurrentLanguage);
            BIOS_Str.AppendLine("SMBIOS Version: " + bios.SMBIOSBIOSVersion);
            BIOS_Str.AppendLine("SMBIOS Major Version: " + bios.SMBIOSMajorVersion);
            BIOS_Str.AppendLine("SMBIOS Minor Version: " + bios.SMBIOSMinorVersion);

            StringBuilder GPU_Str = new StringBuilder();

            GPU_Str.AppendLine("Caption: " + gpu.Caption); 
            GPU_Str.AppendLine("Driver Version: "+ gpu.DriverVersion);
            GPU_Str.AppendLine("VideoDescription: " + gpu.VideoModeDescription);
            GPU_Str.AppendLine("VideoProcessor: " + gpu.VideoProcessor);
            GPU_RealMem = (Convert.ToInt32(gpu.AdapterRAM)/1024/1024);
            GPU_Str.AppendLine("Video Memory: " + GPU_RealMem + " Mb ");
            
            GPU_Str.AppendLine("VideoArchitecture: " + gpu.VideoArchitecture); 

            label6.Content = GPU_Str.ToString();

            label2.Content = BIOS_Str.ToString();

            label3.Content = "";


            foreach (string str in Hdd.DrivesList)
            {
                hdd.setDeviceID(str);

                comboBox1.Items.Add(hdd.Caption);

            }


             foreach (string str in LogicalDisk.LogicalDiskList)
 		     {
                      LD.setDeviceID(str);
                        comboBox2.Items.Add(LD.Caption);
             }

             foreach (var str in NetworkAdapter.NetworkAdapterList)
             {
                 Na.setDeviceID(str);
                 comboBox3.Items.Add(Na.Caption);


             }

             foreach (var str in Gpu.GPUList)
             {
                 gpu.setDeviceID(str);
                 comboBox4.Items.Add(gpu.Caption);
             }

            
        

        }

      
       
      

        private void HDDGetInfos( string DeviceID ) 
        {

            hdd.setDeviceID(DeviceID);
            StringBuilder Buil = new StringBuilder();
            Buil.AppendLine("Caption: " + hdd.Caption);
            Buil.AppendLine("Model: " + hdd.Model);

        

        }

        private void comboBox1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string DeviceID = hdd.GetDeviceIdFromCaption(comboBox1.SelectedValue.ToString());
            hdd.setDeviceID(DeviceID);

            StringBuilder BStr = new StringBuilder();

            BStr.AppendLine("Caption: " + hdd.Caption);

            BStr.AppendLine("Model: " + hdd.Model);
            BStr.AppendLine("Revision: " + hdd.FirmwareRevision);
            BStr.AppendLine("InterfaceType: " + hdd.InterfaceType);
            BStr.AppendLine("Serial Number: " + hdd.SerialNumber);
            BStr.AppendLine("PNP Device ID: " + hdd.PNPDeviceID);
            BStr.AppendLine("Capacity: " + hdd.TotalSizeInBytes + " bytes");


            label3.Content = BStr.ToString();



        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            LD.setDeviceID(comboBox2.SelectedValue.ToString());
            StringBuilder str = new StringBuilder();
            str.AppendLine("Caption: " + LD.Caption);
            str.AppendLine("Drive Type: " + LD.DriveType);
            str.AppendLine("FileSystem: " + LD.FileSystem);
            str.AppendLine("Total Space: " + LD.TotalSize + " bytes");
            str.AppendLine("Free Space: " + LD.FreeSpace + " bytes");

            label4.Content = str;

        }

        private void comboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           Na.setDeviceID( Na.GetDeviceIdFromCaption(comboBox3.SelectedValue.ToString()));

            StringBuilder str = new StringBuilder();

            str.AppendLine("Caption: " + Na.Caption);
            str.AppendLine("Description: " + Na.Description);
            str.AppendLine("GUID: " + Na.GUID);
            str.AppendLine("MACAddress: " + Na.MACAddress);
            str.AppendLine("Manufacturer: " + Na.Manufacturer);
            str.AppendLine("PNP DeviceID: " + Na.PNPDeviceID);

            label5.Content = str;





        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SSE Support: " + cpu.IsSSESupported
                    + "\r\nMMX Support: " + cpu.IsMMXSupported
                    + "\r\nSSE2 Support: " + cpu.IsSSE2Supported
                    + "\r\nSSE3 Support: " + cpu.IsSSE3Supported
                
                );

        }

        private void comboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gpu.setDeviceID(gpu.GetDeviceIdFromCaption(comboBox4.SelectedValue.ToString()));

            StringBuilder GPU_Str = new StringBuilder();

            GPU_Str.AppendLine("Caption: " + gpu.Caption);
            GPU_Str.AppendLine("Driver Version: " + gpu.DriverVersion);
            GPU_Str.AppendLine("VideoDescription: " + gpu.VideoModeDescription);
            GPU_Str.AppendLine("VideoProcessor: " + gpu.VideoProcessor);

            GPU_Str.AppendLine("VideoArchitecture: " + gpu.VideoArchitecture);

            label6.Content = GPU_Str.ToString();


        }

      
 
    }
}
