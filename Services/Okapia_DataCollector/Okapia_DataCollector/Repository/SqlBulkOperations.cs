using System;
using System.Data;
using System.Data.SqlClient;

namespace Okapia_DataCollector.Repository
{
    public class SqlBulkOperations
    {
        public void Insert(DataTable current)
        {
            try
            {
                using (var connection = new SqlConnection("Server=.;Database=Okapia;Trusted_Connection=True"))
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();

                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.BatchSize = 5000;
                        bulkCopy.DestinationTableName = "JobTransactions";
                        try
                        {
                            bulkCopy.WriteToServer(current);
                            transaction.Commit();
                        }
                        catch (Exception exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                            Console.WriteLine(exception.Message);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

    }
}
