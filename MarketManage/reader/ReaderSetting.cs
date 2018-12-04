using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo
{
    class ReaderSetting
    {
        /// <summary>
        /// 十进制255
        /// </summary>
        public byte btReadId;
        public byte btMajor;
        public byte btMinor;
        public byte btIndexBaudrate;
        public byte btPlusMinus;
        public byte btTemperature;
        public byte btOutputPower;
        /// <summary>
        /// current antena
        /// </summary>
        public byte btWorkAntenna;
        public byte btDrmMode;
        public byte btRegion;
        public byte btFrequencyStart;
        public byte btFrequencyEnd;
        public byte btBeeperMode;
        public byte btGpio1Value;
        public byte btGpio2Value;
        public byte btGpio3Value;
        public byte btGpio4Value;
        /// <summary>
        /// Detector 检测器
        /// </summary>
        public byte btAntDetector;
        public byte btMonzaStatus;
        public string btReaderIdentifier;
        public byte btAntImpedance;
        /// <summary>
        /// 自定义开始 频率
        /// </summary>
        public int nUserDefineStartFrequency;
        /// <summary>
        /// 自定义开始 频率间隔
        /// </summary>
        public byte btUserDefineFrequencyInterval;
        public byte btUserDefineChannelQuantity;
        /// <summary>
        /// 连接信息
        /// </summary>
        public byte btLinkProfile;

        public ReaderSetting()
        {
            btReadId = 0xFF;
            btMajor = 0x00;
            btMinor = 0x00;
            btIndexBaudrate = 0x00;
            btPlusMinus = 0x00;
            btTemperature = 0x00;
            btOutputPower = 0x00;
            btWorkAntenna = 0x00;
            btDrmMode = 0x00;
            btRegion = 0x00;
            btFrequencyStart = 0x00;
            btFrequencyEnd = 0x00;
            btBeeperMode = 0x00;
            btGpio1Value = 0x00;
            btGpio2Value = 0x00;
            btGpio3Value = 0x00;
            btGpio4Value = 0x00;
            btAntDetector = 0x00;
        }
    }
}
