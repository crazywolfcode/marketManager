using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MarketManage
{
    class InventoryBuffer
    {
        /// <summary>
        /// 盘存次数
        /// </summary>
        public byte btRepeat;
        /// <summary>
        /// sessionid
        /// </summary>
        public byte btSession;
        /// <summary>
        /// 盘存标记
        /// </summary>
        public byte btTarget;
        /// <summary>
        /// 存储天线列表
        /// </summary>
        public List<byte> lAntenna;
        /// <summary>
        /// 判断是否循环发送命令，为false时循环，true则停止
        /// </summary>
        public bool bLoopInventory;
        public int nIndexAntenna;
        public int nCommond;
        public bool bLoopInventoryReal;
        /// <summary>
        /// 是否自定义session参数
        /// </summary>
        public bool bLoopCustomizedSession;
        
        public int nTagCount;
        public int nDataCount; //执行一次命令所返回的标签记录条数
        public int nCommandDuration;
        public int nReadRate;
        public int nCurrentAnt;
        public List<int> lTotalRead;
        public DateTime dtStartInventory;
        public DateTime dtEndInventory;
        public int nMaxRSSI;
        public int nMinRSSI;
        public DataTable dtTagTable;
        public DataTable dtTagDetailTable;

        public InventoryBuffer()
        {
            btRepeat = 0x00;
            lAntenna = new List<byte>();
            bLoopInventory = false;
            nIndexAntenna = 0;
            nCommond = 0;
            bLoopInventoryReal = false;

            nTagCount = 0;
            nReadRate = 0;
            lTotalRead = new List<int>();
            dtStartInventory = DateTime.Now;
            dtEndInventory = DateTime.Now;
            nMaxRSSI = 0;
            nMinRSSI = 0;

            dtTagTable = new DataTable();
            dtTagTable.Columns.Add("COLPC", typeof(string));
            dtTagTable.Columns.Add("COLCRC", typeof(string));
            dtTagTable.Columns.Add("COLEPC", typeof(string));
            dtTagTable.Columns.Add("COLANT", typeof(string));
            dtTagTable.Columns.Add("COLRSSI", typeof(string));
            dtTagTable.Columns.Add("COLINVCNT", typeof(string));
            dtTagTable.Columns.Add("COLFREQ", typeof(string));
            dtTagTable.Columns.Add("COLANT1", typeof(string));
            dtTagTable.Columns.Add("COLANT2", typeof(string));
            dtTagTable.Columns.Add("COLANT3", typeof(string));
            dtTagTable.Columns.Add("COLANT4", typeof(string));

            dtTagDetailTable = new DataTable();
            dtTagDetailTable.Columns.Add("COLEPC", typeof(string));
            dtTagDetailTable.Columns.Add("COLRSSI", typeof(string));
            dtTagDetailTable.Columns.Add("COLANT", typeof(string));
            dtTagDetailTable.Columns.Add("COLFRE", typeof(string));
        }

        public void ClearInventoryPar()
        {
            btRepeat = 0x00;
            lAntenna.Clear();
            //bLoopInventory = false;
            nIndexAntenna = 0;
            nCommond = 0;
            bLoopInventoryReal = false;
        }

        public void ClearInventoryResult()
        {
            nTagCount = 0;
            nReadRate = 0;
            lTotalRead.Clear();
            dtStartInventory = DateTime.Now;
            dtEndInventory = DateTime.Now;
            nMaxRSSI = 0;
            nMinRSSI = 0;
            dtTagTable.Rows.Clear();
        }

        public void ClearInventoryRealResult()
        {
            nTagCount = 0;
            nReadRate = 0;
            lTotalRead.Clear();
            dtStartInventory = DateTime.Now;
            dtEndInventory = DateTime.Now;
            nMaxRSSI = 0;
            nMinRSSI = 0;
            dtTagTable.Rows.Clear();
            dtTagDetailTable.Clear();
        }
    }
}
