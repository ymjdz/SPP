using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinglePointPositioning
{
    class SPP
    {
        //Read_N_File
        public N_FlieHead n_FileHead = new N_FlieHead();
        public N_FileData n_FileData = new N_FileData();
        //Read_O_File
        public O_FileHead o_FileHead = new O_FileHead();
        public O_FileDataHead o_FileDataHead = new O_FileDataHead();
        public O_FileDataObs o_FileDataObs = new O_FileDataObs();
        public O_FileData o_FileData = new O_FileData();

        public ReceiverPosition receiverPosition = new ReceiverPosition();
        //public double LastEpochX;
        //public double LastEpochY;
        //public double LastEpochZ;



        /// <summary>
        /// 读取N文件
        /// </summary>
        public bool Read_N_File()
        {
            string path;//打开文件路径
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择导航电文文件";
            ofd.Filter = "N文件|*.*n|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return false;
            }
            //清除
            N_FileSum.n_FileHeadSum = null;
            N_FileSum.n_FileDataSum.Clear();


            StreamReader n_FileReader = new StreamReader(path);
            string n_FileLine;//储存读到的每一行
            n_FileLine = n_FileReader.ReadLine();
            while (n_FileLine != null)
            {
                /**************************************读取头文件********************************************/
                while (n_FileLine.Trim() != "END OF HEADER")
                {
                    string tempStr = n_FileLine.Substring(60, n_FileLine.Length - 60);//用于判断内容的部分
                    switch (tempStr.Trim())
                    {
                        case "ION ALPHA":
                            n_FileHead.Ion_Alpha = new double[4];
                            n_FileHead.Ion_Alpha[0] = double.Parse(n_FileLine.Substring(2, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(11, 3)));
                            n_FileHead.Ion_Alpha[1] = double.Parse(n_FileLine.Substring(14, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(23, 3)));
                            n_FileHead.Ion_Alpha[2] = double.Parse(n_FileLine.Substring(26, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(35, 3)));
                            n_FileHead.Ion_Alpha[3] = double.Parse(n_FileLine.Substring(38, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(47, 3)));
                            break;
                        case "ION BETA":
                            n_FileHead.Ion_Beta = new double[4];
                            n_FileHead.Ion_Beta[0] = double.Parse(n_FileLine.Substring(2, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(11, 3)));
                            n_FileHead.Ion_Beta[1] = double.Parse(n_FileLine.Substring(14, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(23, 3)));
                            n_FileHead.Ion_Beta[2] = double.Parse(n_FileLine.Substring(26, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(35, 3)));
                            n_FileHead.Ion_Beta[3] = double.Parse(n_FileLine.Substring(38, 8)) * Math.Pow(10, double.Parse(n_FileLine.Substring(47, 3)));
                            break;
                        case "DELTA-UTC: A0,A1,T,W":
                            n_FileHead.A0 = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            n_FileHead.A1 = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileHead.T = int.Parse(n_FileLine.Substring(41, 9));
                            n_FileHead.W = int.Parse(n_FileLine.Substring(50, 9));
                            break;
                        case "LEAP SECONDS":
                            n_FileHead.Leap_Seconds = int.Parse(n_FileLine.Substring(0, 6));
                            break;
                    }//swich
                    n_FileLine = n_FileReader.ReadLine();
                } //while (n_FileLine != "END OF HEADER")
                N_FileSum.n_FileHeadSum = n_FileHead;//读出的值存入N_FileSum

                /**************************************读取数据文件********************************************/
                n_FileLine = n_FileReader.ReadLine();
                int i = 0;
                while (n_FileLine != null)
                {
                    switch (i)
                    {
                        case 0:
                            n_FileData.PRN = int.Parse(n_FileLine.Substring(0, 2).Trim());
                            n_FileData.TOC.Year = int.Parse(n_FileLine.Substring(3, 2)) + 2000;
                            n_FileData.TOC.Month = int.Parse(n_FileLine.Substring(5, 3));
                            n_FileData.TOC.Day = int.Parse(n_FileLine.Substring(8, 3));
                            n_FileData.TOC.Hour = int.Parse(n_FileLine.Substring(11, 3));
                            n_FileData.TOC.Minute = int.Parse(n_FileLine.Substring(14, 3));
                            n_FileData.TOC.Second = double.Parse(n_FileLine.Substring(17, 5));
                            n_FileData.ClkBias = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileData.ClkDrift = double.Parse(n_FileLine.Substring(41, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(57, 3)));
                            n_FileData.ClkDriftRate = double.Parse(n_FileLine.Substring(60, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(76, 3)));
                            break;
                        case 1:
                            n_FileData.IODE = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            n_FileData.Crs = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileData.DetlaN = double.Parse(n_FileLine.Substring(41, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(57, 3)));
                            n_FileData.M0 = double.Parse(n_FileLine.Substring(60, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(76, 3)));
                            break;
                        case 2:
                            n_FileData.Cuc = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            n_FileData.E = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileData.Cus = double.Parse(n_FileLine.Substring(41, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(57, 3)));
                            n_FileData.SqrtA = double.Parse(n_FileLine.Substring(60, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(76, 3)));
                            break;
                        case 3:
                            n_FileData.TOE = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            n_FileData.Cic = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileData.Omega = double.Parse(n_FileLine.Substring(41, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(57, 3)));
                            n_FileData.Cis = double.Parse(n_FileLine.Substring(60, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(76, 3)));
                            break;
                        case 4:
                            n_FileData.I0 = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            n_FileData.Crc = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileData.OmegaLow = double.Parse(n_FileLine.Substring(41, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(57, 3)));
                            n_FileData.OmegaDot = double.Parse(n_FileLine.Substring(60, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(76, 3)));
                            break;
                        case 5:
                            n_FileData.IDot = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            n_FileData.CodesOnL2Channel = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileData.GPSWeek = double.Parse(n_FileLine.Substring(41, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(57, 3)));
                            n_FileData.L2PDataFlag = double.Parse(n_FileLine.Substring(60, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(76, 3)));
                            break;
                        case 6:
                            n_FileData.SVAccuracy = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            n_FileData.SVHealth = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));
                            n_FileData.TGD = double.Parse(n_FileLine.Substring(41, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(57, 3)));
                            n_FileData.IODC = double.Parse(n_FileLine.Substring(60, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(76, 3)));
                            break;
                        case 7:
                            n_FileData.TransTimeOfMsg = double.Parse(n_FileLine.Substring(3, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(19, 3)));
                            //n_FileData.Spare1 = double.Parse(n_FileLine.Substring(22, 15)) * Math.Pow(10, double.Parse(n_FileLine.Substring(38, 3)));//有的文件没有这个数据，会报错。
                            break;
                    }//switch (i)
                    i = i + 1;
                    i = i % 8;
                    if (i == 0)
                    {
                        N_FileSum.n_FileDataSum.Add(n_FileData);//读出的值存入N_FileSum
                        n_FileData = new N_FileData();
                    }
                    n_FileLine = n_FileReader.ReadLine();
                }//while (n_FileLine != null)
            }//while (n_FileLine != null)
            return true;
        }

        /// <summary>
        /// 读取O文件
        /// </summary>
        public bool Read_O_File()
        {
            string path;//打开文件路径
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择观测数据文件";
            ofd.Filter = "O文件|*.*o|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return false;
            }
            //清除
            O_FlieSum.o_FileHeadSum = null;
            O_FlieSum.o_FileDataSum.Clear();

            StreamReader o_FileReader = new StreamReader(path);
            string o_FileLine;//储存读到的每一行
            string o_FileLineJumpLine;//用于观测值类型多于5个时跳过一行
            o_FileLine = o_FileReader.ReadLine();
            /**************************************读取头文件********************************************/
            while (o_FileLine.Trim() != "END OF HEADER")
            {
                string tempStr = o_FileLine.Substring(60, o_FileLine.Length - 60);
                switch (tempStr.Trim())
                {
                    case "APPROX POSITION XYZ":
                        o_FileHead.Approx_Position.XX = double.Parse(o_FileLine.Substring(0, 14));
                        o_FileHead.Approx_Position.YY = double.Parse(o_FileLine.Substring(14, 14));
                        o_FileHead.Approx_Position.ZZ = double.Parse(o_FileLine.Substring(28, 14));
                        break;
                    case "ANTENNA: DELTA H/E/N":
                        o_FileHead.AntennaDeltaH = double.Parse(o_FileLine.Substring(0, 14));
                        o_FileHead.AntennaDeltaE = double.Parse(o_FileLine.Substring(14, 14));
                        o_FileHead.AntennaDeltaN = double.Parse(o_FileLine.Substring(28, 14));
                        break;
                    case "WAVELENGTH FACT L1/2":
                        o_FileHead.L1WaveLength = int.Parse(o_FileLine.Substring(0, 6));
                        o_FileHead.L2WaveLength = int.Parse(o_FileLine.Substring(6, 6));
                        break;
                    case "# / TYPES OF OBSERV":
                        o_FileHead.ObservDataTypeSum = int.Parse(o_FileLine.Substring(0, 6));
                        o_FileHead.TypeOfObserv = new string[o_FileHead.ObservDataTypeSum];
                        for (int i = 0; i < o_FileHead.ObservDataTypeSum; i++)
                        {
                            o_FileHead.TypeOfObserv[i] = o_FileLine.Substring(10 + i * 6, 2);
                        }//for
                        break;
                    case "INTERVAL":
                        o_FileHead.Interval = double.Parse(o_FileLine.Substring(0, 10));
                        break;
                    case "TIME OF FIRST OBS":
                        o_FileHead.TimeOfFirstObs.Year = int.Parse(o_FileLine.Substring(0, 6));
                        o_FileHead.TimeOfFirstObs.Month = int.Parse(o_FileLine.Substring(6, 6));
                        o_FileHead.TimeOfFirstObs.Day = int.Parse(o_FileLine.Substring(12, 6));
                        o_FileHead.TimeOfFirstObs.Hour = int.Parse(o_FileLine.Substring(18, 6));
                        o_FileHead.TimeOfFirstObs.Minute = int.Parse(o_FileLine.Substring(24, 6));
                        o_FileHead.TimeOfFirstObs.Second = double.Parse(o_FileLine.Substring(30, 13));
                        break;
                    case "TIME OF LAST OBS":
                        o_FileHead.TimeOfLastObs.Year = int.Parse(o_FileLine.Substring(0, 6));
                        o_FileHead.TimeOfLastObs.Month = int.Parse(o_FileLine.Substring(6, 6));
                        o_FileHead.TimeOfLastObs.Day = int.Parse(o_FileLine.Substring(12, 6));
                        o_FileHead.TimeOfLastObs.Hour = int.Parse(o_FileLine.Substring(18, 6));
                        o_FileHead.TimeOfLastObs.Minute = int.Parse(o_FileLine.Substring(24, 6));
                        o_FileHead.TimeOfLastObs.Second = double.Parse(o_FileLine.Substring(30, 13));
                        break;
                }//switch (tempStr)
                o_FileLine = o_FileReader.ReadLine();
            }//while (o_FileLine.Trim()!= "END OF HEADER")
            O_FlieSum.o_FileHeadSum = o_FileHead;//读出的值存入O_FileSum

            /**************************************读取数据文件********************************************/
            o_FileLine = o_FileReader.ReadLine();
            while (o_FileLine != null)
            {
                //数据第一行
                o_FileDataHead.Epoch.Year = int.Parse(o_FileLine.Substring(1, 2)) + 2000;
                o_FileDataHead.Epoch.Month = int.Parse(o_FileLine.Substring(3, 3));
                o_FileDataHead.Epoch.Day = int.Parse(o_FileLine.Substring(6, 3));
                o_FileDataHead.Epoch.Hour = int.Parse(o_FileLine.Substring(9, 3));
                o_FileDataHead.Epoch.Minute = int.Parse(o_FileLine.Substring(12, 3));
                o_FileDataHead.Epoch.Second = double.Parse(o_FileLine.Substring(15, 11));
                o_FileDataHead.Epoch_Flag = int.Parse(o_FileLine.Substring(26, 3));
                o_FileDataHead.Sat_Num = int.Parse(o_FileLine.Substring(29, 3));
                o_FileDataHead.Sat_PRN = new int[o_FileDataHead.Sat_Num];
                for (int i = 0; i < o_FileDataHead.Sat_Num; i++)
                {
                    o_FileDataHead.Sat_PRN[i] = int.Parse(o_FileLine.Substring(33 + i * 3, 2));
                }
                o_FileData.o_FileDataHead = o_FileDataHead;//读出的值存入O_FileData

                //各颗卫星的数据
                o_FileData.o_FileDataObs = new O_FileDataObs[o_FileDataHead.Sat_Num];
                for (int i = 0; i < o_FileDataHead.Sat_Num; i++)
                {
                    o_FileDataObs.PRN = o_FileDataHead.Sat_PRN[i];
                    o_FileLine = o_FileReader.ReadLine();
                    if (o_FileHead.ObservDataTypeSum > 5)
                    {
                        o_FileLineJumpLine = o_FileReader.ReadLine();
                    }//观测值类型多于5个时，跳过一行
                    for (int j = 0; j < o_FileHead.ObservDataTypeSum; j++)
                    {
                        if (o_FileHead.TypeOfObserv[j] == "C1")
                        {
                            o_FileDataObs.C1 = double.Parse(o_FileLine.Substring(16 * j, 14));
                        }
                    }//for j
                    o_FileData.o_FileDataObs[i] = o_FileDataObs;//读出的值存入O_FileData
                    o_FileDataObs = new O_FileDataObs();
                }//for i
                O_FlieSum.o_FileDataSum.Add(o_FileData);//全部读出的值存入O_FileSum
                o_FileDataHead = new O_FileDataHead();
                o_FileData = new O_FileData();
                o_FileLine = o_FileReader.ReadLine();
            }//while (o_FileLine != null)
            return true;
        }

        /// <summary>
        /// 通用时转换为GPS时
        /// </summary>
        /// <param name="time">通用时</param>
        /// <returns>GPS时</returns>
        public GPSTime TimeToGPSTime(Time time)
        {
            GPSTime gpsTime = new GPSTime();
            double JD, UT;
            int y, m;
            UT = time.Hour + (time.Minute / 60.0) + (time.Second / 3600.0);
            if (time.Month <= 2)
            {
                y = time.Year - 1;
                m = time.Month + 12;
            }
            else
            {
                y = time.Year;
                m = time.Month;
            }
            JD = (int)(365.25 * y) + (int)(30.6001 * (m + 1)) + time.Day + (UT / 24) + 1720981.5;
            gpsTime.GPSWeek = (int)((JD - 2444244.5) / 7);
            gpsTime.GPSSecond = (JD - 2444244.5) * 3600 * 24 - gpsTime.GPSWeek * 3600 * 24 * 7;
            return gpsTime;
        }

        /// <summary>
        /// 根据O_FileDataHead中的卫星PRN和TOC找出N_FileData中对应的星历序号
        /// </summary>
        /// <param name="sat_PRN">O_FileDataHead中的卫星PRN</param>
        /// <param name="epoch">O_FileDataHead中的TOC</param>
        /// <returns>N_FileData中对应的星历序号</returns>
        public int FindBestEph(int sat_PRN, Time epoch)
        {
            GPSTime oTime = TimeToGPSTime(epoch);
            for (int i = 0; i < N_FileSum.n_FileDataSum.Count; i++)
            {
                if (sat_PRN == N_FileSum.n_FileDataSum[i].PRN)
                {
                    GPSTime nTime = TimeToGPSTime(N_FileSum.n_FileDataSum[i].TOC);
                    if (Math.Abs(oTime.GPSSecond - nTime.GPSSecond) < 3600.0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 计算卫星在信号发射时的位置
        /// </summary>
        /// <param name="n_FileData">星历数据</param>
        /// <param name="satSendTime">卫星信号发射的时间</param>
        /// <returns>卫星在地心坐标系中的空间直角坐标</returns>
        public Position SatellitePosition(N_FileData n_FileData, GPSTime satSendTime)
        {
            Position satPosition = new Position();
            double A, n0, tk, n, Mk, Ek, E0, f, uu, omega_uk, omega_rk, omega_ik, uk, rk, ik, xk, yk, Lk;

            A = Math.Pow(n_FileData.SqrtA, 2);//轨道长半轴
            n0 = Math.Sqrt((Constant.GM / Math.Pow(A, 3)));
            tk = satSendTime.GPSWeek * 604800 + satSendTime.GPSSecond - n_FileData.GPSWeek * 604800 - n_FileData.TOE;
            if (tk > 302400)
            {
                tk = tk - 604800;
            }
            else if (tk < -302400)
            {
                tk = tk + 604800;
            }
            n = n0 + n_FileData.DetlaN;
            Mk = n_FileData.M0 + n * tk;
            E0 = Mk;
            Ek = Mk + n_FileData.E * Math.Sin(E0);
            while (Math.Abs(Ek - E0) > Math.Pow(10, -12))
            {
                E0 = Ek;
                Ek = Mk + n_FileData.E * Math.Sin(E0);
            }
            f = Math.Atan2((Math.Sqrt(1 - Math.Pow(n_FileData.E, 2))) * Math.Sin(Ek), Math.Cos(Ek) - n_FileData.E);
            uu = f + n_FileData.OmegaLow;
            omega_uk = n_FileData.Cus * Math.Sin(2 * uu) + n_FileData.Cuc * Math.Cos(2 * uu);
            omega_rk = n_FileData.Crs * Math.Sin(2 * uu) + n_FileData.Crc * Math.Cos(2 * uu);
            omega_ik = n_FileData.Cis * Math.Sin(2 * uu) + n_FileData.Cic * Math.Cos(2 * uu);
            uk = uu + omega_uk;
            rk = A * (1 - n_FileData.E * Math.Cos(Ek)) + omega_rk;
            ik = n_FileData.I0 + omega_ik + n_FileData.IDot * tk;
            xk = rk * Math.Cos(uk);
            yk = rk * Math.Sin(uk);
            Lk = n_FileData.Omega + (n_FileData.OmegaDot - Constant.OmegaDotE) * tk - Constant.OmegaDotE * n_FileData.TOE;
            satPosition.XX = xk * Math.Cos(Lk) - yk * Math.Cos(ik) * Math.Sin(Lk);
            satPosition.YY = xk * Math.Sin(Lk) + yk * Math.Cos(ik) * Math.Cos(Lk);
            satPosition.ZZ = yk * Math.Sin(ik);
            return satPosition;
        }

        /// <summary>
        /// 地球自转改正
        /// </summary>
        /// <param name="deltaT">信号传播时间</param>
        /// <param name="satPosition">卫星在信号发射时刻的位置</param>
        /// <returns>改正后的卫星位置</returns>
        public Position EarthRotationCorrection(double deltaT, Position satPosition)
        {
            double[,] R = new double[3, 3];
            double[] XYZ = new double[3];
            double[] XXYYZZ = new double[3];
            Position satPosCorrection = new Position();
            R[0, 0] = Math.Cos(Constant.OmegaDotE * deltaT);
            R[0, 1] = Math.Sin(Constant.OmegaDotE * deltaT);
            R[0, 2] = 0.0;
            R[1, 0] = -Math.Sin(Constant.OmegaDotE * deltaT);
            R[1, 1] = Math.Cos(Constant.OmegaDotE * deltaT);
            R[1, 2] = 0.0;
            R[2, 0] = 0.0;
            R[2, 1] = 0.0;
            R[2, 2] = 1.0;
            XYZ[0] = satPosition.XX;
            XYZ[1] = satPosition.YY;
            XYZ[2] = satPosition.ZZ;
            for (int i = 0; i < 3; i++)
            {
                XXYYZZ[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    XXYYZZ[i] = XXYYZZ[i] + R[i, j] * XYZ[j];
                }
            }
            satPosCorrection.XX = XXYYZZ[0];
            satPosCorrection.YY = XXYYZZ[1];
            satPosCorrection.ZZ = XXYYZZ[2];
            return satPosCorrection;
        }

        public bool Positioning()
        {
            ReceiverPositionSum.receiverPositionSum.Clear();

            OneEpochData oneEpochData = new OneEpochData();
            List<OneEpochData> oneEpochDataSum = new List<OneEpochData>();

            GPSTime TR = new GPSTime();//历元时刻
            double x, y, z, cdtr;//测站位置和钟差
            double xx = 0;
            double yy = 0;
            double zz = 0;//用于储存每个历元的定位结果，用于赋值给下一历元的初值
            double deltaT0Si;//卫星信号传播时间
            double dtSi;//卫星钟差
            double deltaT1Si;
            double rho;//伪距
            GPSTime TSi = new GPSTime();//卫星信号发射概略时刻
            Position XSi = new Position();//卫星在TSi时刻的位置
            Position XSiW = new Position();//卫星自转改正后的位置
            GPSTime T1Si = new GPSTime();//卫星信号发射时刻
            double RSi;//测站和卫星的几何距离

            double b0Si, b1Si, b2Si, b3Si;//卫星方向余弦
            double ISi;//卫星在观测方程中的余数项

            double[,] A;
            double[,] AT;
            double[,] ATA = new double[4, 4];
            double[,] revATA = new double[4, 4];
            double[,] L;
            double[,] ATL = new double[4, 1];
            double[,] xi;

            double sumX = 0;
            double sumY = 0;
            double sumZ = 0;

            if (O_FlieSum.o_FileDataSum.Count == 0)
            {
                MessageBox.Show("没有打开观测数据文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (N_FileSum.n_FileDataSum.Count == 0)
            {
                MessageBox.Show("没有打开导航电文文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            for (int i = 0; i < O_FlieSum.o_FileDataSum.Count; i++)//循环全部历元
            {
                x = xx;
                y = yy;
                z = zz;//每个历元初值等于上个历元的定位结果，第一个历元为0
                cdtr = 0;//第一次循环为0
                xi = new double[4, 1];

                do//解算一个历元
                {
                    //************************有改动，X+
                    x = x + xi[0, 0];//第一次改正数为0，以后每次循环将改正数累加。
                    y = y + xi[1, 0];
                    z = z + xi[2, 0];
                    cdtr = cdtr + xi[3, 0];

                    for (int j = 0; j < O_FlieSum.o_FileDataSum[i].o_FileDataHead.Sat_Num; j++)//循环一个历元中的全部卫星
                    {
                        TR = TimeToGPSTime(O_FlieSum.o_FileDataSum[i].o_FileDataHead.Epoch);//O-FileDataHead中的历元时刻转换为GPS时

                        int prnNum = FindBestEph(O_FlieSum.o_FileDataSum[i].o_FileDataHead.Sat_PRN[j], O_FlieSum.o_FileDataSum[i].o_FileDataHead.Epoch);
                        if (prnNum == -1)
                        {
                            MessageBox.Show("卫星{0}没有对应的星历文件", O_FlieSum.o_FileDataSum[i].o_FileDataHead.Sat_PRN[j].ToString());
                        }

                        rho = O_FlieSum.o_FileDataSum[i].o_FileDataObs[j].C1;

                        //************有改动，-cdtr/Constant.SpeedOfLight
                        GPSTime gpsTimeTOC = TimeToGPSTime(N_FileSum.n_FileDataSum[prnNum].TOC);
                        dtSi = N_FileSum.n_FileDataSum[prnNum].ClkBias + N_FileSum.n_FileDataSum[prnNum].ClkDrift * (TR.GPSSecond - gpsTimeTOC.GPSSecond) + N_FileSum.n_FileDataSum[prnNum].ClkDriftRate * Math.Pow((TR.GPSSecond - gpsTimeTOC.GPSSecond), 2);
                        deltaT1Si = (rho / Constant.SpeedOfLight) + N_FileSum.n_FileDataSum[prnNum].ClkBias + N_FileSum.n_FileDataSum[prnNum].ClkDrift * (TR.GPSSecond - gpsTimeTOC.GPSSecond) + N_FileSum.n_FileDataSum[prnNum].ClkDriftRate * Math.Pow((TR.GPSSecond - gpsTimeTOC.GPSSecond), 2) - cdtr / Constant.SpeedOfLight;
                        do
                        {

                            deltaT0Si = deltaT1Si;
                            TSi.GPSSecond = TR.GPSSecond - deltaT0Si;
                            TSi.GPSWeek = TR.GPSWeek;
                            XSi = SatellitePosition(N_FileSum.n_FileDataSum[prnNum], TSi);
                            XSiW = EarthRotationCorrection(deltaT0Si, XSi);
                            //******************有改动，O_FlieSum.o_FileHeadSum.Approx_Position.XX.YY.ZZ   XYZ
                            RSi = Math.Sqrt(Math.Pow(XSiW.XX - (O_FlieSum.o_FileHeadSum.Approx_Position.XX + x), 2) + Math.Pow(XSiW.YY - (O_FlieSum.o_FileHeadSum.Approx_Position.YY + y), 2) + Math.Pow(XSiW.ZZ - (O_FlieSum.o_FileHeadSum.Approx_Position.ZZ + z), 2));
                            deltaT1Si = RSi / Constant.SpeedOfLight;
                        } while (Math.Abs(deltaT1Si - deltaT0Si) > Math.Pow(10, -7));
                        T1Si.GPSSecond = TR.GPSSecond - deltaT1Si;
                        T1Si.GPSWeek = TR.GPSWeek;
                        //*********************有改动O_FlieSum.o_FileHeadSum.Approx_Position.XX + X，以及/RSi
                        b0Si = (O_FlieSum.o_FileHeadSum.Approx_Position.XX + x - XSiW.XX) / rho;
                        b1Si = (O_FlieSum.o_FileHeadSum.Approx_Position.YY + y - XSiW.YY) / rho;
                        b2Si = (O_FlieSum.o_FileHeadSum.Approx_Position.ZZ + z - XSiW.ZZ) / rho;
                        b3Si = 1.0;
                        //****************************有改动
                        ISi = rho - RSi + dtSi * Constant.SpeedOfLight - cdtr;

                        oneEpochData.b0S = b0Si;
                        oneEpochData.b1S = b1Si;
                        oneEpochData.b2S = b2Si;
                        oneEpochData.b3S = b3Si;
                        oneEpochData.IS = ISi;
                        oneEpochDataSum.Add(oneEpochData);
                        oneEpochData = new OneEpochData();
                    }//for j

                    A = new double[oneEpochDataSum.Count, 4];
                    L = new double[oneEpochDataSum.Count, 1];
                    AT = new double[4, oneEpochDataSum.Count];
                    for (int k = 0; k < oneEpochDataSum.Count; k++)
                    {
                        A[k, 0] = oneEpochDataSum[k].b0S;
                        A[k, 1] = oneEpochDataSum[k].b1S;
                        A[k, 2] = oneEpochDataSum[k].b2S;
                        A[k, 3] = oneEpochDataSum[k].b3S;
                        L[k, 0] = oneEpochDataSum[k].IS;
                    }
                    AT = Matrix.Transfer(A, oneEpochDataSum.Count, 4);
                    ATA = Matrix.Multiply(AT, A, 4, oneEpochDataSum.Count, 4);
                    revATA = Matrix.MatrixOpp(ATA);
                    ATL = Matrix.Multiply(AT, L, 4, oneEpochDataSum.Count, 1);
                    xi = Matrix.Multiply(revATA, ATL, 4, 4, 1);
                    //*************有改动，添加
                    oneEpochDataSum.Clear();
                } while (Math.Abs(xi[0, 0]) > 0.001 && Math.Abs(xi[1, 0]) > 0.001 && Math.Abs(xi[2, 0]) > 0.001);//循环条件是否应该直接判断每次计算的坐标增量
                xx = x + xi[0, 0];//之前全部的改正加最后一次循环的改正数，这个历元的最终结果
                yy = y + xi[1, 0];
                zz = z + xi[2, 0];
                receiverPosition.X = O_FlieSum.o_FileHeadSum.Approx_Position.XX + xx;
                receiverPosition.Y = O_FlieSum.o_FileHeadSum.Approx_Position.YY + yy;
                receiverPosition.Z = O_FlieSum.o_FileHeadSum.Approx_Position.ZZ + zz;
                receiverPosition.Cdtr = (cdtr + xi[3, 0]) / Constant.SpeedOfLight;//是否是除以光速之后才能得出
                receiverPosition.RPTime.GPSWeek = TR.GPSWeek;
                receiverPosition.RPTime.GPSSecond = TR.GPSSecond;
                ReceiverPositionSum.receiverPositionSum.Add(receiverPosition);
                receiverPosition = new ReceiverPosition();
                oneEpochDataSum.Clear();
            }//for i

            for (int i = 0; i < ReceiverPositionSum.receiverPositionSum.Count; i++)
            {
                sumX = sumX + ReceiverPositionSum.receiverPositionSum[i].X;
                sumY = sumY + ReceiverPositionSum.receiverPositionSum[i].Y;
                sumZ = sumZ + ReceiverPositionSum.receiverPositionSum[i].Z;
            }
            Result.X = sumX / ReceiverPositionSum.receiverPositionSum.Count;
            Result.Y = sumY / ReceiverPositionSum.receiverPositionSum.Count;
            Result.Z = sumZ / ReceiverPositionSum.receiverPositionSum.Count;


            //Result.X = ReceiverPositionSum.receiverPositionSum[ReceiverPositionSum.receiverPositionSum.Count - 1].X;
            //Result.Y = ReceiverPositionSum.receiverPositionSum[ReceiverPositionSum.receiverPositionSum.Count - 1].Y;
            //Result.Z = ReceiverPositionSum.receiverPositionSum[ReceiverPositionSum.receiverPositionSum.Count - 1].Z;


            return true;
        }

    }
}
