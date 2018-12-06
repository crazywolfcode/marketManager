using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManage
{
    public class TagInfoObj
    {
        /// <summary>
        /// data总长度
        /// </summary>
        public int nLen { get; set; }
        /// <summary>
        /// Read 操作的数据长度。单位是字节
        /// </summary>
        public int nDataLen { get; set; }
        /// <summary>
        /// //所操作标签的有效数据长度(AryData[2])   Epc的长度=有效数据长度-PC-CRC-读取的标签数据   pc和crc各占两字节
        /// </summary>
        public int nEpcLen { get; set; }
        /// <summary>
        /// 从数组3开始获取两字节的pc
        /// </summary>
        public String PC { get; set; }

        public String EPC { get; set; }

        public String CRC { get; set; }

        public String Data { get; set; }
        /// <summary>
        /// 当前工作的天线
        /// </summary>
        public String AntId { get; set; }
        /// <summary>
        /// 读取数
        /// </summary>
        public String ReadCount { get; set; }


        public TagInfoObj() { }


        public TagInfoObj(byte[] AryData)
        {

            //读取规则可查看r2000通讯协议用户手册_V2.38   
            //data总长度
            nLen = AryData.Length;
            //Read 操作的数据长度。单位是字节 
            nDataLen = Convert.ToInt32(AryData[nLen - 3]);
            //所操作标签的有效数据长度(AryData[2])   Epc的长度=有效数据长度-PC-CRC-读取的标签数据   pc和crc各占两字节
            nEpcLen = Convert.ToInt32(AryData[2]) - nDataLen - 4;
            //从数组3开始获取两字节的pc
            PC = CommonFunction.ByteArrayToString(AryData, 3, 2);
            EPC = CommonFunction.ByteArrayToString(AryData, 5, nEpcLen);
            CRC = CommonFunction.ByteArrayToString(AryData, 5 + nEpcLen, 2);
            Data = CommonFunction.ByteArrayToString(AryData, 7 + nEpcLen, nDataLen);

            byte byTemp = AryData[nLen - 2];
            byte byAntId = (byte)((byTemp & 0x03) + 1);
            //读取当前工作的天线   
            AntId = byAntId.ToString();
            //读取数
            string strReadCount = AryData[nLen - 1].ToString();
        }


        public String  ShowInfo() {
            return "data总长度： "+nLen+" 操作的数据长度： "+nDataLen+" 所操作标签的有效数据长度： "+nEpcLen+" PC： "+PC+" EPC： "+EPC+" CRC： "+CRC+" Data 天线： "+AntId+" 读取数： "+ReadCount;
        }
    }
}
