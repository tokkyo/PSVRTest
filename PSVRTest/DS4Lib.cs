using System;


namespace DS4Lib
{
    public struct DS4Buttons
    {
        public byte  L2, R2;
        public bool Square, Triangle, Circle, Cross, Share, Options, TouchButton, L1, R1, L3, R3, PS;
        public bool DPadUp, DPadRight, DPadDown, DPadLeft;
    }

    public struct DS4Stick
    {
        public int X;
        public int Y;
    }

    public struct DS4Sticks
    {
        public DS4Stick L;
        public DS4Stick R;
    }
    public struct DS4Sensor
    {
        public int MotionX;
        public int MotionY;
        public int MotionZ;

        public int GyloYaw;
        public int GyloPitch;
        public int GyloRoll;

    }



    public struct DS4Touch
    {
        public int X;
        public int Y;
        public bool isActive;
        public int touchID;
    }

    public struct DS4TouchPad {
        public DS4Touch Touch1;
        public DS4Touch Touch2;
    }

    public struct DS4State {
        public DS4Buttons buttons;
        public DS4TouchPad touchPad;
        public DS4Sticks sticks;
        public DS4Sensor sensor;
        public int battery;
    }


    
    class DS4
    {
        private static int TOUCHPAD_DATA_OFFSET = 35;

        public static DS4State parse(byte[] data) {
            DS4State state = new DS4State();
            state.buttons = parseButtons(data);
            state.touchPad = parseTouchPad(data);
            state.sticks = parseSticks(data);
            state.sensor = parseSensor(data);
            state.battery = parseBattery(data);
            return state;
        }

        public static DS4TouchPad parseTouchPad(byte[] data)
        {

            bool isActive1 = (data[0 + TOUCHPAD_DATA_OFFSET] >> 7) != 0 ? false : true; // >= 1 touch detected
            bool isActive2 = (data[4 + TOUCHPAD_DATA_OFFSET] >> 7) != 0 ? false : true; // > 1 touch detected
            byte touchID1 = (byte)(data[0 + TOUCHPAD_DATA_OFFSET] & 0x7F);
            byte touchID2 = (byte)(data[4 + TOUCHPAD_DATA_OFFSET] & 0x7F);
            int currentX1 = data[1 + TOUCHPAD_DATA_OFFSET] + ((data[2 + TOUCHPAD_DATA_OFFSET] & 0xF) * 255);
            int currentY1 = ((data[2 + TOUCHPAD_DATA_OFFSET] & 0xF0) >> 4) + (data[3 + TOUCHPAD_DATA_OFFSET] * 16);
            //add secondary touch data
            int currentX2 = data[5 + TOUCHPAD_DATA_OFFSET] + ((data[6 + TOUCHPAD_DATA_OFFSET] & 0xF) * 255);
            int currentY2 = ((data[6 + TOUCHPAD_DATA_OFFSET] & 0xF0) >> 4) + (data[7 + TOUCHPAD_DATA_OFFSET] * 16);

            DS4TouchPad pad = new DS4TouchPad();
            pad.Touch1.isActive = isActive1;
            pad.Touch1.X = currentX1;
            pad.Touch1.Y = currentY1;
            pad.Touch1.touchID = touchID1;

            pad.Touch2.isActive = isActive2;
            pad.Touch2.X = currentX2;
            pad.Touch2.Y = currentY2;
            pad.Touch2.touchID = touchID2;            
            return pad;
        }

        public static DS4Buttons parseButtons(byte[] data)
        {

            DS4Buttons buttons = new DS4Buttons();
            if (data == null)
            {
                return buttons;
            }


            buttons.Triangle = ((byte)data[5] & (1 << 7)) != 0;
            buttons.Circle = ((byte)data[5] & (1 << 6)) != 0;
            buttons.Cross = ((byte)data[5] & (1 << 5)) != 0;
            buttons.Square = ((byte)data[5] & (1 << 4)) != 0;
            buttons.DPadUp = ((byte)data[5] & (1 << 3)) != 0;
            buttons.DPadDown = ((byte)data[5] & (1 << 2)) != 0;
            buttons.DPadLeft = ((byte)data[5] & (1 << 1)) != 0;
            buttons.DPadRight = ((byte)data[5] & (1 << 0)) != 0;

            //Convert dpad into individual On/Off bits instead of a clock representation
            bool[] dpad = { buttons.DPadRight, buttons.DPadLeft, buttons.DPadDown, buttons.DPadUp };
            byte c = 0;
            for (int i = 0; i < 4; ++i)
            {
                if (dpad[i])
                {
                    c |= (byte)(1 << i);
                }
            }

            int dpad_state = c;
            switch (dpad_state)
            {
                case 0: buttons.DPadUp = true; buttons.DPadDown = false; buttons.DPadLeft = false; buttons.DPadRight = false; break;
                case 1: buttons.DPadUp = true; buttons.DPadDown = false; buttons.DPadLeft = false; buttons.DPadRight = true; break;
                case 2: buttons.DPadUp = false; buttons.DPadDown = false; buttons.DPadLeft = false; buttons.DPadRight = true; break;
                case 3: buttons.DPadUp = false; buttons.DPadDown = true; buttons.DPadLeft = false; buttons.DPadRight = true; break;
                case 4: buttons.DPadUp = false; buttons.DPadDown = true; buttons.DPadLeft = false; buttons.DPadRight = false; break;
                case 5: buttons.DPadUp = false; buttons.DPadDown = true; buttons.DPadLeft = true; buttons.DPadRight = false; break;
                case 6: buttons.DPadUp = false; buttons.DPadDown = false; buttons.DPadLeft = true; buttons.DPadRight = false; break;
                case 7: buttons.DPadUp = true; buttons.DPadDown = false; buttons.DPadLeft = true; buttons.DPadRight = false; break;
                case 8: buttons.DPadUp = false; buttons.DPadDown = false; buttons.DPadLeft = false; buttons.DPadRight = false; break;
            }

            buttons.R3 = ((byte)data[6] & (1 << 7)) != 0;
            buttons.L3 = ((byte)data[6] & (1 << 6)) != 0;
            buttons.Options = ((byte)data[6] & (1 << 5)) != 0;
            buttons.Share = ((byte)data[6] & (1 << 4)) != 0;
            buttons.R1 = ((byte)data[6] & (1 << 1)) != 0;
            buttons.L1 = ((byte)data[6] & (1 << 0)) != 0;

            buttons.L2 = data[8];
            buttons.R2 = data[9];

            buttons.PS = ((byte)data[7] & (1 << 0)) != 0;
            buttons.TouchButton = (data[7] & (1 << 2 - 1)) != 0 ? true : false;


            return buttons;


        }
        public static DS4Sticks parseSticks(byte[] data)
        {

            DS4Sticks sticks = new DS4Sticks();
            if (data == null)
            {
                return sticks;
            }

            sticks.L.X = data[1];
            sticks.L.Y = data[2];
            sticks.R.X = data[3];
            sticks.R.Y = data[4];

            return sticks;
        }

        public static int parseBattery(byte[] data)
        {

            if (data == null)
            {
                return 0;
            }

            return data[12];

        }
        public static DS4Sensor parseSensor(byte[] data)
        {

            DS4Sensor sensor = new DS4Sensor();
            if (data == null)
            {
                return sensor;
            }

            sensor.MotionX = convert(data[13], data[14]);
            sensor.MotionY = convert(data[15], data[16]);
            sensor.MotionZ = convert(data[17], data[18]);
            sensor.GyloRoll = -convert(data[19], data[20]);
            sensor.GyloYaw = convert(data[21], data[22]);
            sensor.GyloPitch = convert(data[23], data[24]);
            return sensor;

        }
        private static int convert(byte byte1, byte byte2) {
            byte[] tmp = new byte[2];

            tmp[0] = byte1;
            tmp[1] = byte2;

            return BitConverter.ToInt16(tmp, 0);
        }
    }
}

