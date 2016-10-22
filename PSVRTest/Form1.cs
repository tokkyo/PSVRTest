using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RawInputLib;
using DS4Lib;
using PSVRLib;
using System.Diagnostics;

namespace PSVRTest
{
    public partial class Form1 : Form
    {
        PSVRState currentPSVR;
        DS4State currentDS4;
        private static bool ds4Mode = false;
        public Form1()
        {
            InitializeComponent();

        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            RegisterRawInputDevices();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            UnregisterRawInputDevices();
        }

        private void RegisterRawInputDevices()
        {

            int count = 1;
            int size = Marshal.SizeOf(typeof(RawInput.RAWINPUTDEVICE));

            RawInput.RAWINPUTDEVICE[] devices = new RawInput.RAWINPUTDEVICE[count];

            if (ds4Mode)
            {
                // for DS4
                devices[0].usUsagePage = 1;
                devices[0].usUsage = 5;//Game Pad
                devices[0].hwndTarget = this.Handle;
                devices[0].dwFlags = (int)RawInput.RIDEV.INPUTSINK;
            }
            else
            {
                // for PSVR
                devices[0].usUsagePage = 0xFF01;
                devices[0].usUsage = 0x01;//VS
                devices[0].hwndTarget = this.Handle;
                devices[0].dwFlags = (int)RawInput.RIDEV.INPUTSINK;
            }
            /*
                raw_input_device [0].usUsagePage = 0x0D; 
                // RIDEV_PAGEONLY specifies all devices whose top level collection is from the specified usUsagePage.
                // Note that usUsage must be zero.b
                raw_input_device [0].dwFlags = RIDEV_INPUTSINK | RIDEV_PAGEONLY;
                raw_input_device [0].usUsage = 0x00;
                // route the RAWINPUT messages to our window; this is required for the RIDEV_INPUTSINK option
                raw_input_device [0].hwndTarget = hwnd;
             */

            RawInput.RegisterRawInputDevices(devices, (uint)devices.Length, (uint)size);
        }


        private void UnregisterRawInputDevices()
        {
            int size = Marshal.SizeOf(typeof(RawInput.RAWINPUTDEVICE));

            RawInput.RAWINPUTDEVICE[] devices = new RawInput.RAWINPUTDEVICE[1];


            if (ds4Mode)
            {
                // for DS4
                devices[0].usUsagePage = 1;
                devices[0].usUsage = 5;//Game Pad
                devices[0].dwFlags = (int)RawInput.RIDEV.REMOVE;
            }
            else
            {
                // for PSVR
                devices[0].usUsagePage = 0xFF01; //Generic Desktop
                devices[0].usUsage = 0x01;//VS
                devices[0].dwFlags = (int)RawInput.RIDEV.REMOVE;
            }
            RawInput.RegisterRawInputDevices(devices, (uint)devices.Length, (uint)size);
        }

        private void ProcessRawInput(ref Message m)
        {

            uint dwSize = 0;
            RawInput.GetRawInputData(m.LParam, (uint)RawInput.RID.INPUT, IntPtr.Zero, ref dwSize, (uint)Marshal.SizeOf(typeof(RawInput.RAWINPUTHEADER)));

            IntPtr buffer = Marshal.AllocHGlobal((int)dwSize);
            try
            {
                if (buffer == IntPtr.Zero)
                    return;

                if (
                  RawInput.GetRawInputData(m.LParam, (uint)RawInput.RID.INPUT, buffer, ref dwSize,
                                           (uint)Marshal.SizeOf(typeof(RawInput.RAWINPUTHEADER))) != dwSize)
                    return;
            }
            catch (Exception ex)
            {
            }
            RawInput.RAWINPUT raw = (RawInput.RAWINPUT)Marshal.PtrToStructure(buffer, typeof(RawInput.RAWINPUT));

            int offset = 0;
            byte[] bRawData;
            byte[] newArray;
            string RawCode;
            switch (raw.header.dwType)
            {
                case (int)RawInput.RawInputType.HID:
                    RawInput.RAWHID hid = raw.hid;
                    offset = Marshal.SizeOf(typeof(RawInput.RAWINPUTHEADER)) + Marshal.SizeOf(typeof(RawInput.RAWHID));

                    bRawData = new byte[offset + raw.hid.dwSizeHid];
                    Marshal.Copy(buffer, bRawData, 0, bRawData.Length);

                    newArray = new byte[raw.hid.dwSizeHid];
                    Array.Copy(bRawData, offset, newArray, 0, newArray.Length);

                    RawCode = BitConverter.ToString(newArray);


                    if (false)
                    {
                        //this blocks UI...
                        if (listBox1.Items.Count > 30) listBox1.Items.RemoveAt(30);
                        listBox1.Items.Insert(0, string.Format("{0}\r\n", RawCode));
                    }
                    else
                    {
                        Debug.WriteLine(RawCode);
                    }
                    //TODO: check VID/PID or HID Usage
                    if (ds4Mode)
                    {
                        currentDS4 = DS4.parse(newArray);
                    }
                    else
                    {
                        currentPSVR = PSVR.parse(newArray);
                    }
                    break;
                case (int)RawInput.RawInputType.Mouse:
                    RawInput.RAWMOUSE mouse = raw.mouse;
                    offset = Marshal.SizeOf(typeof(RawInput.RAWINPUTHEADER)) + Marshal.SizeOf(typeof(RawInput.RAWMOUSE));

                    bRawData = new byte[offset + Marshal.SizeOf(typeof(RawInput.RAWMOUSE))];
                    Marshal.Copy(buffer, bRawData, 0, bRawData.Length);

                    newArray = new byte[Marshal.SizeOf(typeof(RawInput.RAWMOUSE))];
                    Array.Copy(bRawData, offset, newArray, 0, newArray.Length);

                    RawCode = BitConverter.ToString(newArray);
                    //textBox1.AppendText(string.Format("RAW HID DATA: {0}\r\n", RawCode));
                    if (listBox1.Items.Count > 30) listBox1.Items.RemoveAt(30);
                    listBox1.Items.Insert(0, string.Format("{0}\r\n", RawCode));

                    break;
                case (int)RawInput.RawInputType.Keyboard:
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == RawInput.WM_INPUT)
            {
                this.ProcessRawInput(ref m);
            }
            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ds4Mode)
            {
                showDS4State(currentDS4);
            }
            else
            {
                showPSVRState(currentPSVR);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterRawInputDevices();
        }

        private void showPSVRState(PSVRState state)
        {
            string str = "";

            str += string.Format("Motion X1: {0,6}\r\n", state.sensor.MotionX1);
            str += string.Format("Motion Y1: {0,6}\r\n", state.sensor.MotionY1);
            str += string.Format("Motion Z1: {0,6}\r\n", state.sensor.MotionZ1);

            str += string.Format("Motion X2: {0,6}\r\n", state.sensor.MotionX2);
            str += string.Format("Motion Y2: {0,6}\r\n", state.sensor.MotionY2);
            str += string.Format("Motion Z2: {0,6}\r\n", state.sensor.MotionZ2);


            str += string.Format("Gyro Yaw1:    {0,6}\r\n", state.sensor.GyroYaw1);
            str += string.Format("Gyro Pitch1:  {0,6}\r\n", state.sensor.GyroPitch1);
            str += string.Format("Gyro Roll1:   {0,6}\r\n", state.sensor.GyroRoll1);

            str += string.Format("Gyro Yaw2:    {0,6}\r\n", state.sensor.GyroYaw2);
            str += string.Format("Gyro Pitch2:  {0,6}\r\n", state.sensor.GyroPitch2);
            str += string.Format("Gyro Roll2:   {0,6}\r\n", state.sensor.GyroRoll2);


            str += string.Format("Volume: {0}\r\n", state.sensor.volume);
            str += string.Format("Worn: {0}\r\n", state.sensor.isWorn);
            str += string.Format("Display: {0}\r\n", state.sensor.isDisplayActive);
            str += string.Format("Mute: {0}\r\n", state.sensor.isMute);
            str += string.Format("Earphone: {0}\r\n", state.sensor.isEarphoneConnected);


            trackBar1.Value = state.sensor.A;
            trackBar2.Value = state.sensor.B;
            trackBar3.Value = state.sensor.C;

            trackBar4.Value = state.sensor.D;
            trackBar5.Value = state.sensor.E;
            trackBar6.Value = state.sensor.F;

            trackBar7.Value = state.sensor.G;
            //trackBar8.Value = state.sensor.H;
            trackBar9.Value = state.sensor.I;

            trackBar10.Value = state.sensor.J;
            trackBar11.Value = state.sensor.K;
            trackBar12.Value = state.sensor.L;

            trackBar13.Value = state.sensor.M;
            trackBar14.Value = state.sensor.N;
            trackBar15.Value = state.sensor.O;


            //trackBar16.Value = state.sensor.MotionX1 - state.sensor.MotionX2;
            //trackBar17.Value = state.sensor.MotionY1 - state.sensor.MotionY2;
            //trackBar18.Value = state.sensor.MotionZ1 - state.sensor.MotionZ2;

            trackBar16.Value = state.sensor.GyroYaw1 - state.sensor.GyroYaw2;
            trackBar17.Value = state.sensor.GyroPitch1 - state.sensor.GyroPitch2;
            trackBar18.Value = state.sensor.GyroRoll1 - state.sensor.GyroRoll2;
            stateTextBox.Text = str;
        }

        private void showDS4State(DS4State state)
        {
            string str = "";

            str += string.Format("DPad Up: {0}\r\n", state.buttons.DPadUp);
            str += string.Format("DPad Down: {0}\r\n", state.buttons.DPadDown);
            str += string.Format("DPad Left: {0}\r\n", state.buttons.DPadLeft);
            str += string.Format("DPad Right: {0}\r\n", state.buttons.DPadRight);


            str += string.Format("○: {0}\r\n", state.buttons.Circle);
            str += string.Format("△: {0}\r\n", state.buttons.Triangle);
            str += string.Format("□: {0}\r\n", state.buttons.Square);
            str += string.Format("☓: {0}\r\n", state.buttons.Cross);

            str += string.Format("L1: {0}\r\n", state.buttons.L1);
            str += string.Format("L2: {0}\r\n", state.buttons.L2);
            str += string.Format("L3: {0}\r\n", state.buttons.L3);

            str += string.Format("R1: {0}\r\n", state.buttons.R1);
            str += string.Format("R2: {0}\r\n", state.buttons.R2);
            str += string.Format("R3: {0}\r\n", state.buttons.R3);

            str += string.Format("PS: {0}\r\n", state.buttons.PS);
            str += string.Format("SHARE: {0}\r\n", state.buttons.Share);
            str += string.Format("OPTIONS: {0}\r\n", state.buttons.Options);

            str += string.Format("TouchPad Button: {0}\r\n", state.buttons.TouchButton);
            str += string.Format("Battery Level: {0}\r\n", state.battery);

            str += string.Format("Motion X: {0}\r\n", state.sensor.MotionX);
            str += string.Format("Motion Y: {0}\r\n", state.sensor.MotionY);
            str += string.Format("Motion Z: {0}\r\n", state.sensor.MotionZ);

            str += string.Format("Gyro Yaw: {0}\r\n", state.sensor.GyroYaw);
            str += string.Format("Gyro Pitch: {0}\r\n", state.sensor.GyroPitch);
            str += string.Format("Gyro Roll: {0}\r\n", state.sensor.GyroRoll);

            trackBar1.Value = state.sensor.MotionX;//左方向+ (横方向にX軸)
            trackBar2.Value = state.sensor.MotionY;//下方向+ (縦方向にY軸)
            trackBar3.Value = state.sensor.MotionZ;//前方向+ (前後方向にZ軸)
            trackBar4.Value = state.sensor.GyroYaw;
            trackBar5.Value = state.sensor.GyroPitch;
            trackBar6.Value = state.sensor.GyroRoll;



            str += string.Format("StickL X: {0}\r\n", state.sticks.L.X);
            str += string.Format("StickL Y: {0}\r\n", state.sticks.L.Y);

            str += string.Format("StickR X: {0}\r\n", state.sticks.R.X);
            str += string.Format("StickR Y: {0}\r\n", state.sticks.R.Y);

            if (state.touchPad.Touch1.isActive)
            {
                str += string.Format("Touch1 X: {0}\r\n", state.touchPad.Touch1.X);
                str += string.Format("Touch1 Y: {0}\r\n", state.touchPad.Touch1.Y);
            }
            else
            {
                str += string.Format("Touch1 X: {0}\r\n", "not detected");
                str += string.Format("Touch1 Y: {0}\r\n", "not detected");
            }

            if (state.touchPad.Touch2.isActive)
            {
                str += string.Format("Touch2 X: {0}\r\n", state.touchPad.Touch2.X);
                str += string.Format("Touch2 Y: {0}\r\n", state.touchPad.Touch2.Y);
            }
            else
            {
                str += string.Format("Touch2 X: {0}\r\n", "not detected");
                str += string.Format("Touch2 Y: {0}\r\n", "not detected");
            }

            stateTextBox.Text = str;
        }


    }
}
