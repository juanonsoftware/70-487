using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityConnection con=new EntityConnection();
            

            SampleModel1Container c=new SampleModel1Container();
            c.Database.Connection.BeginTransaction();

            EntityCommand ec = new EntityCommand();
            ec.ExecuteScalarAsync();

            SqlCommand sc = new SqlCommand();
            sc.ExecuteReaderAsync();
          
            

            System.Data.OleDb.OleDbCommand oc=new OleDbCommand();
            oc.ExecuteReaderAsync();
        }
    }
}
