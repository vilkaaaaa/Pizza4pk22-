using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Models;
using Pizza.ViewModels;

namespace Pizza
{
    class MainWindowViewModel : BindableBase
    {
        private AddEditCustomerViewModel _addEditCustomerVewModel = new();
        private CustomerListViewModel _customerListViewModel = new();
        private OrderPerpViewModel _orderPrepViewModel = new();
        private OrderViewModer _orderViewModel = new();

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public RelayCommand<string> NavigationCommand { get; private set; }

        //открывать список клиентов
        private void OnNavigation(string dest)
        {
            switch (dest)
            {
                case "orderPrep":
                    CurrentViewModel = _orderPrepViewModel; break;
                case "customers":
                default:
                       CurrentViewModel = _customerListViewModel; break;
            }
        }
        //открывать окно для редактирования клиента
        private void NavigationToEditCustomer(Customer customer)
        {
            _addEditCustomerVewModel.IsEditeMode = true; 
            _addEditCustomerVewModel.SetCustomer(customer);
            CurrentViewModel = _customerListViewModel;
        }

        //открывать окно для добавления клиента
        private void NavigationToAddCustomer(Customer customer)
        {
            _addEditCustomerVewModel.IsEditeMode = false;
            _addEditCustomerVewModel.SetCustomer(customer);
            CurrentViewModel = _customerListViewModel;
        }

        //окно для оформления заказа
        private void NavigateToOrder(Customer customer)
        {
            _orderViewModel.Id = customer.Id;
            CurrentViewModel = _orderViewModel;
        }
    }
}
