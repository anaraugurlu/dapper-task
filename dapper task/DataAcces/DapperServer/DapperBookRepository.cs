using Dapper;
using dapper_task.Domain.Abstractions;
using dapper_task.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dapper_task.DataAcces.DapperServer
{
    public class DapperBookRepository : IBookRepository
    {
        public void AddData(Book book)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Books(Name,Price) VALUES(@ProductName,@ProductPrice)"
                    , new { ProductName = book.Name, ProductPrice = book.Price });

            }
        }

        public void CallSp()
        {
           
            
               using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
                {
                    DynamicParameters parameter = new DynamicParameters();

                    connection.Open();

                    parameter.Add("@P_Price", DbType.Decimal);
                    var data = connection.Query<Book>("ShowGreaterThan",
        parameter,
        commandType: CommandType.StoredProcedure);


                }
            
        }

        public void DeleteData(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Books WHERE Id=@PId", new { PId =id });
                MessageBox.Show("book Deleted Successfully");
            }
        }

        public List<Book> GetAllData()
        {
            List<Book> books = new List<Book>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                books = connection.Query<Book>("SELECT Id, Name, Price from Books").ToList();

            }
            return books;
        }

      

        public void UpdateData(Book data)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Books SET Name=@PName,Price=@PPrice WHERE Id=@PId",
                    new { PId = data.Id, PName = data.Name, PPrice = data.Price });
            }
        }
    }
}
