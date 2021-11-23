using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapper_task.Mapping
{
  public  class Book
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Authorname { get; set; }
        public string Name { get; set; }
    }
}
