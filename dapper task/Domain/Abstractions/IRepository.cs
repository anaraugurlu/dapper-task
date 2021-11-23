using dapper_task.Mapping;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapper_task.Domain.Abstractions
{
    public interface IRepository<T>
    {
        void CallSp();
        List<Book> GetAllData();
        void AddData(Book book);
        void UpdateData(T data);
        void DeleteData(int id);
   
    }
}
