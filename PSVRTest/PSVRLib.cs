using System;

namespace PSVRLib
{

    public struct PSVRSensor
    {
        //To be analyzed...

        public int volume;
        public bool isWorn;
        public bool isDisplayActive;
        public bool isMute;
        public bool isEarphoneConnected;

        public int MotionX1;
        public int MotionY1;
        public int MotionZ1;

        public int MotionX2;
        public int MotionY2;
        public int MotionZ2;


        public int GyroYaw1;
        public int GyroPitch1;
        public int GyroRoll1;

        public int GyroYaw2;
        public int GyroPitch2;
        public int GyroRoll2;

        //DEBUG
        public int A;
        public int B;
        public int C;
        public int D;
        public int E;
        public int F;
        public int G;
        public int H;
        public int I;
        public int J;
        public int K;
        public int L;
        public int M;
        public int N;
        public int O;


    }

    public struct PSVRState
    {
        public PSVRSensor sensor;
    }

    class PSVR {

        public static PSVRState parse(byte[] data)
        {
            PSVRState state = new PSVRState();
            state.sensor = parseSensor(data);
            return state;
        }

        public static PSVRSensor parseSensor(byte[] data)
        {

            PSVRSensor sensor = new PSVRSensor();
            if (data == null)
            {
                return sensor;
            }


            /*
             * sample data
                00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64

                00-00-00-19-00-0A-04-20-00-06-1D-01-FF-7F-00-00-42-AB-D7-69-00-FE-FF-F4-FF-16-00-E1-CF-1F-E0-E1-E9-9F-D9-69-00-FC-FF-EF-FF-24-00-C1-CF-1F-E0-B1-E9-1D-01-00-00-00-03-FF-82-00-00-00-00-00-BC-01-6D
                00-00-00-19-00-0A-04-20-00-06-1D-01-FF-7F-00-00-42-93-DB-69-00-FF-FF-FA-FF-13-00-D1-CF-2F-E0-81-E9-88-DD-69-00-FC-FF-0A-00-FC-FF-11-D0-FF-DF-D1-E9-1D-01-00-00-00-03-FF-82-00-00-00-00-00-7D-01-6E
                00-00-00-19-00-0A-04-20-00-06-1D-01-FF-7F-00-00-42-7B-DF-69-00-08-00-0E-00-EE-FF-F1-CF-EF-DF-01-EA-70-E1-69-00-04-00-09-00-F9-FF-E1-CF-1F-E0-B1-E9-1D-01-00-00-00-03-FF-82-00-00-00-00-00-84-01-6F
            
                [byte 3]
                Volume (0～50)

                [byte 9]
                0000 0001 Worn (Mounted on Player)
                0000 0010 Display is On
                0000 0100 ??
                0000 1000 Mute
                0001 0000 Earphone
                0010 0000
                0100 0000
                1000 0000

                reference:
                https://github.com/hrl7/node-psvr/blob/master/lib/psvr.js
             */


            sensor.volume = data[3];

            sensor.isWorn               = (data[9] & 0x1) == 0x1 ? true : false;//confirmed
            sensor.isDisplayActive      = (data[9] & 0x2) == 0x2 ? false : true;
            sensor.isMute               = (data[9] & 0x8) == 0x8 ? true : false;//confirmed

            sensor.isEarphoneConnected  = (data[9] & 0x10) == 0x10 ? true : false;//confirmed


            sensor.MotionX1 = getIntFromInt16(data, 27);
            sensor.MotionY1 = getIntFromInt16(data, 29);
            sensor.MotionZ1 = getIntFromInt16(data, 31);

            sensor.MotionX2 = getIntFromInt16(data, 43);
            sensor.MotionY2 = getIntFromInt16(data, 45);
            sensor.MotionZ2 = getIntFromInt16(data, 47);

            sensor.GyroYaw1      = getIntFromInt16(data, 21);
            sensor.GyroPitch1    = getIntFromInt16(data, 23);
            sensor.GyroRoll1     = getIntFromInt16(data, 25);

            sensor.GyroYaw2      = getIntFromInt16(data, 37);
            sensor.GyroPitch2    = getIntFromInt16(data, 39);
            sensor.GyroRoll2     = getIntFromInt16(data, 41);


            sensor.A = convert(data[19], data[20]);
            sensor.B = convert(data[21], data[22]);
            sensor.C = convert(data[23], data[24]);

            sensor.D = convert(data[25], data[26]);
            sensor.E = convert(data[27], data[28]);//下方向加速度
            sensor.F = convert(data[29], data[30]);//左方向加速度

            sensor.G = convert(data[31], data[32]);//後ろ方向加速度
            sensor.H = convert(data[33], data[34]);
            sensor.I = convert(data[35], data[36]);

            sensor.J = convert(data[37], data[38]);
            sensor.K = convert(data[39], data[40]);
            sensor.L = convert(data[41], data[42]);

            sensor.M = convert(data[43], data[44]);//下方向加速度
            sensor.N = convert(data[45], data[46]);//左方向加速度
            sensor.O = convert(data[47], data[48]);//後ろ方向加速度


            return sensor;

        }

        private static int convert(byte byte1, byte byte2)
        {
            byte[] tmp = new byte[2];

            tmp[0] = byte1;
            tmp[1] = byte2;

            return BitConverter.ToInt16(tmp, 0);
        }

        private static int getIntFromInt16(byte[] data, byte offset)
        {
            byte[] tmp = new byte[2];

            tmp[0] = data[offset];
            tmp[1] = (byte)(data[offset + 1]);

            return BitConverter.ToInt16(tmp, 0);
        }

    }
}
