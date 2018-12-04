using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketManage
{
    class CommondMethod
    {
        /// <summary>
        /// 字符串转16进制数组，字符串以空格分割
        /// </summary>
        /// <param name="strHexValue"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string strHexValue)
        {
            string[] strAryHex = strHexValue.Split(' ');
            byte[] btAryHex = new byte[strAryHex.Length];

            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch (Exception ex)
            {
            	
            }

            return btAryHex;
        }

        /// <summary>
        /// 字符数组转为16进制数组
        /// </summary>
        /// <param name="strAryHex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static byte[] StringArrayToByteArray(string[] strAryHex, int nLen)
        {
            if (strAryHex.Length < nLen)
            {
                nLen = strAryHex.Length;
            }

            byte[] btAryHex = new byte[nLen];

            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch (Exception ex)
            {
            	
            }

            return btAryHex;
        }

        /// <summary>
        /// 16进制字符数组转成字符串
        /// </summary>
        /// <param name="btAryHex"></param>
        /// <param name="nIndex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] btAryHex, int nIndex, int nLen)
        {
            if (nIndex + nLen > btAryHex.Length)
            {
                nLen = btAryHex.Length - nIndex;
            }

            string strResult = string.Empty;

            for (int nloop = nIndex; nloop < nIndex + nLen; nloop++ )
            {
                string strTemp = string.Format(" {0:X2}", btAryHex[nloop]);

                strResult += strTemp;
            }

            return strResult;
        }

        /// <summary>
        /// 将字符串按照指定长度截取并转存为字符数组，空格忽略
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string[] StringToStringArray(string strValue, int nLength)
        {
            string[] strAryResult = null;

            if (!string.IsNullOrEmpty(strValue))
            {
                System.Collections.ArrayList strListResult = new System.Collections.ArrayList();
                string strTemp = string.Empty;
                int nTemp = 0;

                for (int nloop = 0; nloop < strValue.Length; nloop++ )
                {
                    if (strValue[nloop] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        nTemp++;

                        //校验截取的字符是否在A~F、0~9区间，不在则直接退出
                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(([A-F])*(\d)*)$");
                        if (!reg.IsMatch(strValue.Substring(nloop, 1)))
                        {
                            return strAryResult;
                        }

                        strTemp += strValue.Substring(nloop, 1);

                        //判断是否到达截取长度
                        if ((nTemp == nLength) || (nloop == strValue.Length - 1 && !string.IsNullOrEmpty(strTemp)))
                        {
                            strListResult.Add(strTemp);
                            nTemp = 0;
                            strTemp = string.Empty;
                        }
                    }
                }

                if (strListResult.Count > 0)
                {
                    strAryResult = new string[strListResult.Count];
                    strListResult.CopyTo(strAryResult);
                }
            }

            return strAryResult;
        }

        public static string FormatErrorCode(byte btErrorCode)
        {
            string strErrorCode = "";
            switch (btErrorCode)
            {
                case 0x10:
                    strErrorCode = "命令已执行";
                    break;
                case 0x11:
                    strErrorCode = "命令执行失败";
                    break;
                case 0x20:
                    strErrorCode = "CPU 复位错误";
                    break;
                case 0x21:
                    strErrorCode = "打开CW 错误";
                    break;
                case 0x22:
                    strErrorCode = "天线未连接";
                    break;
                case 0x23:
                    strErrorCode = "写Flash 错误";
                    break;
                case 0x24:
                    strErrorCode = "读Flash 错误";
                    break;
                case 0x25:
                    strErrorCode = "设置发射功率错误";
                    break;
                case 0x31:
                    strErrorCode = "盘存标签错误";
                    break;
                case 0x32:
                    strErrorCode = "读标签错误";
                    break;
                case 0x33:
                    strErrorCode = "写标签错误";
                    break;
                case 0x34:
                    strErrorCode = "锁定标签错误";
                    break;
                case 0x35:
                    strErrorCode = "灭活标签错误";
                    break;
                case 0x36:
                    strErrorCode = "无可操作标签错误";
                    break;
                case 0x37:
                    strErrorCode = "成功盘存但访问失败";
                    break;
                case 0x38:
                    strErrorCode = "缓存为空";
                    break;
                case 0x40:
                    strErrorCode = "访问标签错误或访问密码错误";
                    break;
                case 0x41:
                    strErrorCode = "无效的参数";
                    break;
                case 0x42:
                    strErrorCode = "wordCnt 参数超过规定长度";
                    break;
                case 0x43:
                    strErrorCode = "MemBank 参数超出范围";
                    break;
                case 0x44:
                    strErrorCode = "Lock 数据区参数超出范围";
                    break;
                case 0x45:
                    strErrorCode = "LockType 参数超出范围";
                    break;
                case 0x46:
                    strErrorCode = "读卡器地址无效";
                    break;
                case 0x47:
                    strErrorCode = "Antenna_id 超出范围";
                    break;
                case 0x48:
                    strErrorCode = "输出功率参数超出范围";
                    break;
                case 0x49:
                    strErrorCode = "射频规范区域参数超出范围";
                    break;
                case 0x4A:
                    strErrorCode = "波特率参数超过范围";
                    break;
                case 0x4B:
                    strErrorCode = "蜂鸣器设置参数超出范围";
                    break;
                case 0x4C:
                    strErrorCode = "EPC 匹配长度越界";
                    break;
                case 0x4D:
                    strErrorCode = "EPC 匹配长度错误";
                    break;
                case 0x4E:
                    strErrorCode = "EPC 匹配参数超出范围";
                    break;
                case 0x4F:
                    strErrorCode = "频率范围设置参数错误";
                    break;
                case 0x50:
                    strErrorCode = "无法接收标签的RN16";
                    break;
                case 0x51:
                    strErrorCode = "DRM 设置参数错误";
                    break;
                case 0x52:
                    strErrorCode = "PLL 不能锁定";
                    break;
                case 0x53:
                    strErrorCode = "射频芯片无响应";
                    break;
                case 0x54:
                    strErrorCode = "输出达不到指定的输出功率";
                    break;
                case 0x55:
                    strErrorCode = "版权认证未通过";
                    break;
                case 0x56:
                    strErrorCode = "频谱规范设置错误";
                    break;
                case 0x57:
                    strErrorCode = "输出功率过低";
                    break;
                case 0xFF:
                    strErrorCode = "未知错误";
                    break;

                default:
                    break;
            }

            return strErrorCode;
        }
    }    
}
