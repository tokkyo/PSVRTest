using System;
using System.Runtime.InteropServices;

namespace RawInputLib
{
    public class RawInput
    {
        public const int WM_INPUT = 0xFF;
        public enum RID : uint
        {
            /// <summary> Get header information. </summary>
            HEADER = 0x10000005,
            /// <summary> Get raw pData. </summary>
            INPUT = 0x10000003,
        }
        public enum RawInputType
        {
            Mouse = 0,
            Keyboard = 1,
            HID = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTDEVICELIST
        {
            public IntPtr hDevice;
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct RAWINPUT
        {
            [FieldOffset(0)]
            public RAWINPUTHEADER header;
            [FieldOffset(16)]
            public RAWMOUSE mouse;
            [FieldOffset(16)]
            public RAWKEYBOARD keyboard;
            [FieldOffset(16)]
            public RAWHID hid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTHEADER
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
            [MarshalAs(UnmanagedType.U4)]
            public int dwSize;
            public IntPtr hDevice;
            [MarshalAs(UnmanagedType.U4)]
            public int wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWHID
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwSizeHid;
            [MarshalAs(UnmanagedType.U4)]
            public int dwCount;
            //public IntPtr bRawData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BUTTONSSTR
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usButtonFlags;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usButtonData;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct RAWMOUSE
        {
            [MarshalAs(UnmanagedType.U2)]
            [FieldOffset(0)]
            public ushort usFlags;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(4)]
            public uint ulButtons;
            [FieldOffset(4)]
            public BUTTONSSTR buttonsStr;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(8)]
            public uint ulRawButtons;
            [FieldOffset(12)]
            public int lLastX;
            [FieldOffset(16)]
            public int lLastY;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(20)]
            public uint ulExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWKEYBOARD
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort MakeCode;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Flags;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Reserved;
            [MarshalAs(UnmanagedType.U2)]
            public ushort VKey;
            [MarshalAs(UnmanagedType.U4)]
            public uint Message;
            [MarshalAs(UnmanagedType.U4)]
            public uint ExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTDEVICE
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsagePage;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsage;
            [MarshalAs(UnmanagedType.U4)]
            public int dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct RID_DEVICE_INFO
        {
            [FieldOffset(0)]
            public int Size;
            [FieldOffset(4)]
            public int Type;

            [FieldOffset(8)]
            public RID_DEVICE_INFO_MOUSE MouseInfo;
            [FieldOffset(8)]
            public RID_DEVICE_INFO_KEYBOARD KeyboardInfo;
            [FieldOffset(8)]
            public RID_DEVICE_INFO_HID HIDInfo;
        }

        public struct RID_DEVICE_INFO_MOUSE
        {
            public uint ID;
            public uint NumberOfButtons;
            public uint SampleRate;
        }

        public struct RID_DEVICE_INFO_KEYBOARD
        {
            public uint Type;
            public uint SubType;
            public uint KeyboardMode;
            public uint NumberOfFunctionKeys;
            public uint NumberOfIndicators;
            public uint NumberOfKeysTotal;
        }

        public struct RID_DEVICE_INFO_HID
        {
            public uint VendorID;
            public uint ProductID;
            public uint VersionNumber;
            public ushort UsagePage;
            public ushort Usage;
        }

        public enum RIDI : uint
        {
            /// <summary> pData contains the device name. </summary>
            DEVICENAME = 0x20000007,
            /// <summary> pData contains the device info structure. </summary>
            DEVICEINFO = 0x2000000b,
            /// <summary> pData contains the previous parsed pData. </summary>
            PREPARSEDDATA = 0x20000005
        }

        public enum RIDEV : int
        {            
            APPKEYS      = 0x00000400,
            CAPTUREMOUSE = 0x00000200,
            DEVNOTIFY    = 0x00002000,
            EXCLUDE      = 0x00000010,
            EXINPUTSINK  = 0x00001000,
            INPUTSINK    = 0x00000100,
            NOHOTKEYS    = 0x00000200,
            NOLEGACY     = 0x00000030,
            PAGEONLY     = 0x00000020,
            REMOVE       = 0x00000001

        }

        [DllImport("User32.dll")]
        extern public static uint GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint uiNumDevices, uint cbSize);

        [DllImport("User32.dll")]
        extern public static uint GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);

        [DllImport("User32.dll")]
        extern public static bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevice, uint uiNumDevices, uint cbSize);

        [DllImport("User32.dll")]
        //extern public static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, out RAWINPUT pData, ref int pcbSize, int cbSizeHeader);
        extern public static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        public static RID_DEVICE_INFO GetDeviceInfo(IntPtr deviceHandle)
        {
            uint size = 0;
            GetRawInputDeviceInfo(deviceHandle, (uint)RIDI.DEVICEINFO, IntPtr.Zero, ref size);

            if (size > 0)
            {
                IntPtr data = Marshal.AllocHGlobal((int)size);
                try
                {
                    GetRawInputDeviceInfo(deviceHandle, (uint)RIDI.DEVICEINFO, data, ref size);
                    return (RID_DEVICE_INFO)Marshal.PtrToStructure(data, typeof(RID_DEVICE_INFO));
                }
                finally
                {
                    Marshal.FreeHGlobal(data);
                }
            }

            return new RID_DEVICE_INFO();
        }

        public static string GetDeviceName(IntPtr deviceHandle)
        {
            uint size = 0;
            GetRawInputDeviceInfo(deviceHandle, (uint)RIDI.DEVICENAME, IntPtr.Zero, ref size);

            if (size > 0)
            {
                IntPtr data = Marshal.AllocHGlobal((int)size);
                try
                {
                    GetRawInputDeviceInfo(deviceHandle, (uint)RIDI.DEVICENAME, data, ref size);
                    return (string)Marshal.PtrToStringAnsi(data);
                }
                finally
                {
                    Marshal.FreeHGlobal(data);
                }
            }
            return null;
        }

        public static RAWINPUTDEVICELIST[] GetInputDeviceList()
        {
            uint deviceCount = 0;
            int size = Marshal.SizeOf(typeof(RAWINPUTDEVICELIST));

            if (GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, (uint)size) != 0)
                throw new Exception("Failed to get raw input devices");

            RAWINPUTDEVICELIST[] rawInputDevices = new RAWINPUTDEVICELIST[deviceCount + 1];
            if (deviceCount > 0)
            {
                IntPtr data = Marshal.AllocHGlobal((int)(size * deviceCount));
                try
                {
                    GetRawInputDeviceList(data, ref deviceCount, (uint)size);
                    for (int i = 0; i < deviceCount; i++)
                    {
                        RAWINPUTDEVICELIST rid = (RAWINPUTDEVICELIST)Marshal.PtrToStructure(
                            new IntPtr((data.ToInt32() + (size * i))), typeof(RAWINPUTDEVICELIST));
                        rawInputDevices[i] = rid;
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(data);
                }
            }
            return rawInputDevices;
        }
    }


}
