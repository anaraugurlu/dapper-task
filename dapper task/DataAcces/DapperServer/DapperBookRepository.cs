using dapper_task.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapper_task.DataAcces.DapperServer
{
    public class DapperBookRepository : IBookRepository
    {
        public void AddData(Book data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Book data)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ObservableCollection<Book> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Book GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Book data)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Products SET Name=@PName,Price=@PPrice WHERE Id=@PId",
                    new { PId = data.Id, PName = data.Name, PPrice = data.Price });
            }
        }
}
