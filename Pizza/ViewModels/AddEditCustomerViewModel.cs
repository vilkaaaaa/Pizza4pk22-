using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Models;

namespace Pizza.ViewModels
{
    class AddEditCustomerViewModel :BindableBase
    {
        private bool _isEditeMode;
        public bool IsEditeMode
        {
            get => _isEditeMode;
            set => SetProperty(ref _isEditeMode, value);
        }

        private Customer _customer;

        public void SetCustomer(Customer customer)=>
            _customer = customer;
    }
}
