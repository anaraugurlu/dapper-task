using dapper_task.Commands;
using Stripe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapper_task.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand SelectBookCommand { get; set; }
        public MainViewModel()
        {
            AllBooks = App.DB.BookRepository.GetAllData();

            SelectBookCommand = new RelayCommand((sender) =>
            {
                AllOrders = new ObservableCollection<Order>(SelectedBook.Books);
            });
        }

        private ObservableCollection<Customer> allCustomers;

        public ObservableCollection<Customer> AllCustomers
        {
            get { return allCustomers; }
            set { allCustomers = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Order> allOrders;

        public ObservableCollection<Order> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; OnPropertyChanged(); }
        }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set { selectedCustomer = value; OnPropertyChanged(); }
        }


    }
}
