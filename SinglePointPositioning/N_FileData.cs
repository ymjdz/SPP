using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePointPositioning
{
    class N_FileData
    {
        //PRN号/历元/卫星钟
        public int PRN
        {
            get;
            set;
        }//卫星的PRN号
        public Time TOC = new Time();//历元。卫星钟的参考时刻
        public double ClkBias
        {
            get;
            set;
        }//卫星钟的偏差
        public double ClkDrift
        {
            get;
            set;
        }//卫星钟的漂移
        public double ClkDriftRate
        {
            get;
            set;
        }//卫星钟的漂移速度
        //广播轨道-1
        public double IODE
        {
            get;
            set;
        }//数据、星历发布的时间
        public double Crs
        {
            get;
            set;
        }//轨道半径的正弦调和项改正的振幅
        public double DetlaN
        {
            get;
            set;
        }//平均运行角速度差
        public double M0
        {
            get;
            set;
        }//参考时刻TOE的平近点角
        //广播轨道-2
        public double Cuc
        {
            get;
            set;
        }//纬度幅角的余弦调和项改正的振幅
        public double E
        {
            get;
            set;
        }//轨道偏心率
        public double Cus
        {
            get;
            set;
        }//纬度幅角的正弦调和项改正的振幅
        public double SqrtA
        {
            get;
            set;
        }//轨道长半轴的平方根
        //广播轨道-3
        public double TOE
        {
            get;
            set;
        }//星历的参考时刻
        public double Cic
        {
            get;
            set;
        }//轨道倾角的余弦调和项改正的振幅
        public double Omega
        {
            get;
            set;
        }//参考时刻TOE的升交点赤径
        public double Cis
        {
            get;
            set;
        }//轨道倾角的正弦调和项改正的振幅
        //广播轨道-4
        public double I0
        {
            get;
            set;
        }//参考时刻TOE的轨道倾角
        public double Crc
        {
            get;
            set;
        }//轨道半径的余弦调和项改正的振幅
        public double OmegaLow
        {
            get;
            set;
        }//近地点角距
        public double OmegaDot
        {
            get;
            set;
        }//升交点赤经变化率
        //广播轨道-5
        public double IDot
        {
            get;
            set;
        }//轨道倾角变化率
        public double CodesOnL2Channel
        {
            get;
            set;
        }//L2上的码
        public double GPSWeek
        {
            get;
            set;
        }//GPS周数（与TOE一同表示时间）
        public double L2PDataFlag
        {
            get;
            set;
        }//P码数据标记
        //广播轨道-6
        public double SVAccuracy
        {
            get;
            set;
        }//卫星精度
        public double SVHealth
        {
            get;
            set;
        }//卫星健康状态
        public double TGD
        {
            get;
            set;
        }//载波L1,L2电离层延迟差
        public double IODC
        {
            get;
            set;
        }//卫星钟的数据龄期
        //广播轨道-7
        public double TransTimeOfMsg
        {
            get;
            set;
        }//电文发送时刻
        public double Spare1
        {
            get;
            set;
        }//拟合区间
        public double Spare2
        {
            get;
            set;
        }//备用
        public double Spare3
        {
            get;
            set;
        }//备用

    }
}
