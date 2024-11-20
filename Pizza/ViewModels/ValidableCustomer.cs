using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.ViewModels
{
    internal class ValidableCustomer : ValidableBindableBase
    {
        private Guid _id;
        public Guid Id { get => _id; set => SetProperty(ref _id, value); }

        private string _firstName;
        [Required]
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value);}

        private string _lastName;
        [Required]
        public string LastName { get => _lastName; set => SetProperty(ref _lastName, value);}

        private string _phone;
        [Phone]
        public string Phone { get => _phone; set => SetProperty(ref _phone, value); }

        private string _email;
        [EmailAddress]
        public string Email { get => _email;set => SetProperty(ref _email, value);}
    }
}
