using System;
using System.Drawing.Printing;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SHDocVw;
using WebBrowser = System.Windows.Forms.WebBrowser;

namespace RedSky.Utilities.Controls
{
    public class RedSkyWebBrowser : WebBrowser
    {
        private const int MAX_PORTNAME_LEN = 64;
        private const int MAX_NETWORKNAME_LEN = 49;
        private const int MAX_SNMP_COMMUNITY_STR_LEN = 33;
        private const int MAX_QUEUENAME_LEN = 33;
        private const int MAX_IPADDR_STR_LEN = 16;
        private const int RESERVED_BYTE_ARRAY_SIZE = 540;
        private InternetExplorer axIWebBrowser2 => (InternetExplorer) ActiveXInstance;

        public void PrintHtmlToPDF(string output)
        {
            axIWebBrowser2.Silent = true;
            var ps = new PrinterSettings
            {
                PrinterName = "Microsoft Print to PDF",
                PrintFileName = output,
                PrintToFile = true
            };

            var pd = new PrintDialog
            {
                PrintToFile = true,
                AllowPrintToFile = true,
                PrinterSettings = ps
            };

            SetAsDefaultPrinter(pd.PrinterSettings.PrinterName);
            Print();
            //SetPrinterPort(ps.PrinterName, output);
            //this.axIWebBrowser2.ExecWB(OLECMDID.OLECMDID_PRINT, OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, null, IntPtr.Zero);
        }

        private static int SetAsDefaultPrinter(string printerDevice)
        {
            int ret;

            var path = "win32_printer.DeviceId='" + printerDevice + "'";

            using (var printer = new ManagementObject(path))
            {
                var outParams =
                    printer.InvokeMethod("SetDefaultPrinter", null, null);
                ret = (int) (uint) outParams.Properties["ReturnValue"].Value;
            }

            return ret;
        }

        public static void SetPrinterPort(string printerName, string portName)
        {
            var oManagementScope = new ManagementScope(ManagementPath.DefaultPath);
            oManagementScope.Connect();

            var oSelectQuery = new SelectQuery();
            oSelectQuery.QueryString = @"SELECT * FROM Win32_Printer 
            WHERE Name = '" + printerName.Replace("\\", "\\\\") + "'";

            var oObjectSearcher =
                new ManagementObjectSearcher(oManagementScope, oSelectQuery);
            var oObjectCollection = oObjectSearcher.Get();

            foreach (ManagementObject oItem in oObjectCollection)
            {
                oItem.Properties["PortName"].Value = portName;
                oItem.Put();
            }
        }
        //And here are the declarations of the Windows API functions that we'll need:

        [DllImport("winspool.drv")]
        private static extern bool OpenPrinter(string printerName, out IntPtr phPrinter,
            ref PrinterDefaults printerDefaults);

        [DllImport("winspool.drv")]
        private static extern bool ClosePrinter(IntPtr phPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode)]
        private static extern bool XcvDataW(IntPtr hXcv, string pszDataName, IntPtr pInputData, uint cbInputData,
            out IntPtr pOutputData, uint cbOutputData, out uint pcbOutputNeeded, out uint pdwStatus);

        //And here is the function which adds the monitor port:

        /**
         * <summary>Adds a monitor printer port with the given name and type.</summary>
         * <param name="portName">The name of the new port (must end with ':').</param>
         * <param name="portType">The type of the new port (ex. "Redirected Port").</param>
         */
        public static void AddMonitorPrinterPort(string portName, string portType)
        {
            IntPtr printerHandle;
            var defaults = new PrinterDefaults {DesiredAccess = PrinterAccess.ServerAdmin};
            if (!OpenPrinter(",XcvMonitor " + portType, out printerHandle, ref defaults))
                throw new Exception("Could not open printer for the monitor port " + portType + "!");
            try
            {
                var portData = new PortData
                {
                    dwVersion = 1,
                    dwProtocol = 1, // 1 = RAW, 2 = LPR
                    dwPortNumber = 9100, // 9100 = default port for RAW, 515 for LPR
                    dwReserved = 0,
                    sztPortName = portName,
                    sztIPAddress = "172.30.164.15",
                    sztSNMPCommunity = "public",
                    dwSNMPEnabled = 1,
                    dwSNMPDevIndex = 1
                };
                var size = (uint) Marshal.SizeOf(portData);
                portData.cbSize = size;
                var pointer = Marshal.AllocHGlobal((int) size);
                Marshal.StructureToPtr(portData, pointer, true);
                IntPtr outputData;
                uint outputNeeded, status;
                try
                {
                    if (!XcvDataW(printerHandle, "AddPort", pointer, size, out outputData, 0, out outputNeeded,
                        out status))
                        throw new ApplicationException("Could not add port (error code " + status + ")!");
                }
                finally
                {
                    Marshal.FreeHGlobal(pointer);
                }
            }
            finally
            {
                ClosePrinter(printerHandle);
            }
        }

        private enum PrinterAccess
        {
            ServerAdmin = 0x01,
            ServerEnum = 0x02,
            PrinterAdmin = 0x04,
            PrinterUse = 0x08,
            JobAdmin = 0x10,
            JobRead = 0x20,
            StandardRightsRequired = 0x000f0000,
            PrinterAllAccess = StandardRightsRequired | PrinterAdmin | PrinterUse
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PrinterDefaults
        {
            public readonly IntPtr pDataType;
            public readonly IntPtr pDevMode;
            public PrinterAccess DesiredAccess;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct PortData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PORTNAME_LEN)]
            public string sztPortName;

            public uint dwVersion;
            public uint dwProtocol;
            public uint cbSize;
            public uint dwReserved;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NETWORKNAME_LEN)]
            public readonly string sztHostAddress;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SNMP_COMMUNITY_STR_LEN)]
            public string sztSNMPCommunity;

            public readonly uint dwDoubleSpool;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_QUEUENAME_LEN)]
            public readonly string sztQueue;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_IPADDR_STR_LEN)]
            public string sztIPAddress;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RESERVED_BYTE_ARRAY_SIZE)]
            public readonly byte[] Reserved;

            public uint dwPortNumber;
            public uint dwSNMPEnabled;
            public uint dwSNMPDevIndex;
        }

        public static class Winspool
        {
            [DllImport("winspool.drv", EntryPoint = "XcvDataW", SetLastError = true)]
            private static extern bool XcvData(
                IntPtr hXcv,
                [MarshalAs(UnmanagedType.LPWStr)] string pszDataName,
                IntPtr pInputData,
                uint cbInputData,
                IntPtr pOutputData,
                uint cbOutputData,
                out uint pcbOutputNeeded,
                out uint pwdStatus);

            [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
            private static extern int OpenPrinter(
                string pPrinterName,
                ref IntPtr phPrinter,
                PRINTER_DEFAULTS pDefault);

            [DllImport("winspool.drv", EntryPoint = "ClosePrinter")]
            private static extern int ClosePrinter(IntPtr hPrinter);

            public static int AddLocalPort(string portName)
            {
                var def = new PRINTER_DEFAULTS();

                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = 1; //Server Access Administer

                var hPrinter = IntPtr.Zero;

                var n = OpenPrinter(",XcvMonitor Local Port", ref hPrinter, def);
                if (n == 0)
                    return Marshal.GetLastWin32Error();

                if (!portName.EndsWith("\0"))
                    portName += "\0"; // Must be a null terminated string

                // Must get the size in bytes. Rememeber .NET strings are formed by 2-byte characters
                var size = (uint) (portName.Length * 2);

                // Alloc memory in HGlobal to set the portName
                var portPtr = Marshal.AllocHGlobal((int) size);
                Marshal.Copy(portName.ToCharArray(), 0, portPtr, portName.Length);

                uint needed; // Not that needed in fact...
                uint xcvResult; // Will receive de result here

                XcvData(hPrinter, "AddPort", portPtr, size, IntPtr.Zero, 0, out needed, out xcvResult);

                ClosePrinter(hPrinter);
                Marshal.FreeHGlobal(portPtr);

                return (int) xcvResult;
            }

            [StructLayout(LayoutKind.Sequential)]
            private class PRINTER_DEFAULTS
            {
                public int DesiredAccess;
                public string pDatatype;
                public IntPtr pDevMode;
            }
        }
    }
}