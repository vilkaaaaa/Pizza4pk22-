using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Models;
using Pizza.Services;

namespace Pizza.ViewModels
{
    class AddEditCustomerViewModel :BindableBase
    {
        private ICustomerRepository _repository;
        public AddEditCustomerViewModel()
        {
            _repository = new CustomerRepository();
        }
        private bool _isEditeMode;
        public bool IsEditeMode
        {
            get => _isEditeMode;
            set => SetProperty(ref _isEditeMode, value);
        }

        private Customer _editingCustomer = null;
        private ValidableCustomer _customer;
        public ValidableCustomer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyCustomer(Customer source, ValidableCustomer target)
        {
            target.Id = source.Id;
            if(IsEditeMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Email = source.Email;
                target.Phone = source.Phone;
            }
        }

        private void SetCustomer(Customer customer)
        {
            _editingCustomer = customer;
            if (Customer!= null)
                Customer.ErrorsChanged -= OnCanExecuteChanges;
            Customer = new ValidableCustomer();
            Customer.ErrorsChanged += OnCanExecuteChanges;
            CopyCustomer(customer, Customer);
        }

        private void OnCancel()
        {
            Done?.Invoke();
        }
        private bool CanSave() => !Customer.HasErrors;

        private void UpdateCustomer(ValidableCustomer source, Customer target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Email = source.Email;
            target.Phone = source.Phone;
        }
    }
}
