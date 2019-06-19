using System;
using System.Collections.Generic;
using System.Data;
using Okapia_DataCollector.Model;

namespace Okapia_DataCollector.Tools
{
    public class Convertor
    {
        public DataTable ListToDataTable(List<JobTransaction> transactions)
        {
            var dtb = GetDataTableStructure();
            foreach (var transaction in transactions)
            {
                var row = dtb.NewRow();
                row["Id"] = transaction.Id;
                row["Amount"] = transaction.Ammount;
                row["PanTrunc"] = transaction.PanTrunc;
                row["Rrn"] = transaction.Rrn;
                row["LocalDateTime"] = transaction.LocalDateTime;
                row["TrAmmount"] = transaction.TrAmmount;
                dtb.Rows.Add(row);
            }

            return dtb;
        }

        private static DataTable GetDataTableStructure()
        {
            var dtb = new DataTable("JobTransactions");
            var dc = new DataColumn("Id", typeof(long));
            dtb.Columns.Add(dc);
            dc = new DataColumn("Amount", typeof(long));
            dtb.Columns.Add(dc);
            dc = new DataColumn("PanTrunc", typeof(string));
            dtb.Columns.Add(dc);
            dc = new DataColumn("Rrn", typeof(long));
            dtb.Columns.Add(dc);
            dc = new DataColumn("LocalDateTime", typeof(DateTime));
            dtb.Columns.Add(dc);
            dc = new DataColumn("TrAmmount", typeof(long));
            dtb.Columns.Add(dc);

            return dtb;
        }
    }
}