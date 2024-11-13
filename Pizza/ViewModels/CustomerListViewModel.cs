using Pizza.Models;
using Pizza.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.ViewModels
{
    internal class CustomerListViewModel : BindableBase
    {
        #region nocommand
        private ICustomerRepository _repository;
        public CustomerListViewModel(ICustomerRepository repository)
        {
            _repository = repository;
            //TODO command
        }
        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        private List<Customer> _customersList;
        public async void LoadCustomers()
        {
            _customersList = await _repository.GetCustomersAsync();
            Customers = new ObservableCollection<Customer>();
        }
        #endregion

        #region filterCustomers
        private string _searchInput;
        public string SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterCustomersByName(_searchInput);
            }
        }

        public void FilterCustomersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Customers = new ObservableCollection<Customer>(_customersList);
                return;
            }
            else
            {
                Customers = new ObservableCollection<Customer>(
                    _customersList.Where(c => c.FirstName.ToLower().Contains(name.ToLower())));
            }
        }
        #endregion


        #region commmands
        //событие добавления нового клиента
        public event Action<Customer> AddCustomerEvent;
        //сделать заказ для клиента
        public event Action<Guid> AddOrderForCustomerEvent;
        //изменить данные клиента
        public event Action<Customer> UpdateCustomerEvent;

        //команды:

        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> AddOrderForCustomerCommand { get; private set; }
        public RelayCommand<Customer> UpdateCustomerCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        void OnAddCustomer()
        {
            AddCustomerEvent(new Customer
            { Id = new Guid() });
        }

        void OnAddOrderForCustomer(Customer customer)
        {
            AddOrderForCustomerEvent(customer.Id);
        }

        void OnUpdateCustomer(Customer customer) 
        {
            UpdateCustomerEvent(customer);
        }

        void OnClearSearch()
        {
            SearchInput = null;
        }
        #endregion
    }
}
