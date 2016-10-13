using System;

namespace PSVRLib
{

    public struct PSVRSensor
    {
        //To be analyzed...
        public int MotionX;
        public int MotionY;
        public int MotionZ;

        public int GyloYaw;
        public int GyloPitch;
        public int GyloRoll;

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

            //sensor.MotionX = convert(data[25], data[26]);
            //sensor.MotionY = convert(data[27], data[28]);
            //sensor.MotionZ = convert(data[29], data[30]);


            //sensor.GyloRoll = -convert(data[19], data[20]);
            //sensor.GyloYaw =   convert(data[21], data[22]);
            //sensor.GyloPitch = convert(data[23], data[24]);

            /*
             * sample data
                00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64

                00-00-00-19-00-0A-04-20-00-06-1D-01-FF-7F-00-00-42-AB-D7-69-00-FE-FF-F4-FF-16-00-E1-CF-1F-E0-E1-E9-9F-D9-69-00-FC-FF-EF-FF-24-00-C1-CF-1F-E0-B1-E9-1D-01-00-00-00-03-FF-82-00-00-00-00-00-BC-01-6D
                00-00-00-19-00-0A-04-20-00-06-1D-01-FF-7F-00-00-42-93-DB-69-00-FF-FF-FA-FF-13-00-D1-CF-2F-E0-81-E9-88-DD-69-00-FC-FF-0A-00-FC-FF-11-D0-FF-DF-D1-E9-1D-01-00-00-00-03-FF-82-00-00-00-00-00-7D-01-6E
                00-00-00-19-00-0A-04-20-00-06-1D-01-FF-7F-00-00-42-7B-DF-69-00-08-00-0E-00-EE-FF-F1-CF-EF-DF-01-EA-70-E1-69-00-04-00-09-00-F9-FF-E1-CF-1F-E0-B1-E9-1D-01-00-00-00-03-FF-82-00-00-00-00-00-84-01-6F
            */

            sensor.A = convert(data[19], data[20]);
            sensor.B = convert(data[21], data[22]);
            sensor.C = convert(data[23], data[24]);

            sensor.D = convert(data[25], data[26]);
            sensor.E = convert(data[27], data[28]);
            sensor.F = convert(data[29], data[30]);

            sensor.G = convert(data[31], data[32]);
            sensor.H = convert(data[33], data[34]);
            sensor.I = convert(data[35], data[36]);

            sensor.J = convert(data[37], data[38]);
            sensor.K = convert(data[39], data[40]);
            sensor.L = convert(data[41], data[42]);

            sensor.M = convert(data[43], data[44]);
            sensor.N = convert(data[45], data[46]);
            sensor.O = convert(data[47], data[48]);


            return sensor;

        }
        private static int convert(byte byte1, byte byte2)
        {
            byte[] tmp = new byte[2];

            tmp[0] = byte1;
            tmp[1] = byte2;

            return BitConverter.ToInt16(tmp, 0);
        }
    }
}
