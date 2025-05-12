using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    internal class Customer
    {
        public int customerId { get; set; }
        public string userName { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public UserRole role { get; set; }
        public ushort prioritizeScore { get; set; }
        public UserStatus status { get; set; }
    }
}
