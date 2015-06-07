namespace Customer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Customer
        : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string address;
        private string mobilePhone;
        private string email;

        public Customer(string firstName, string middleName, string lastName, string id, string address, string mobilePhone, string email, IList<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public Customer(string firstName, string middleName, string lastName, string id, string address, string mobilePhone, string email, Payment payment, CustomerType customerType)
            : this(firstName, middleName, lastName, id, address, mobilePhone, email, new List<Payment>() { payment }, customerType)
        {
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validation.IsValidName(value, "First name");
                this.firstName = value;
            } 
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                Validation.IsValidName(value, "Middle name");
                this.middleName = value;
            } 
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validation.IsValidName(value, "Last name");
                this.lastName = value;
            } 
        }

        public string Id 
        {
            get
            {
                return this.id;
            }

            set
            {
                Validation.IsValidId(value);
                this.id = value;
            }
        }

        public string Address 
        {
            get
            {
                return this.address;
            }

            set
            {
                Validation.IsValidName(value, "Address");
                this.address = value;
            } 
        }
        
        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                Validation.IsValidPhone(value);
                this.mobilePhone = value;
            }
        }

        public string Email 
        {
            get
            {
                return this.email;
            }

            set
            {
                Validation.IsValidEmail(value);
                this.email = value;
            }
        }

        public IList<Payment> Payments { get; private set; } 

        public CustomerType CustomerType { get; private set; }

        public static bool operator ==(Customer firstCustomer, Customer secondCustomer)
        {
            return object.Equals(firstCustomer, secondCustomer);
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            return !object.Equals(firstCustomer, secondCustomer);
        }

        public void AddPayment(Payment payment)
        {
            this.Payments.Add(payment);
        }
        
        public object Clone()
        {
            Customer clone = new Customer(this.FirstName, this.MiddleName, this.LastName, this.Id, this.Address, this.MobilePhone, this.Email, new List<Payment>(), this.CustomerType);

            foreach (var payment in this.Payments)
            {
                clone.Payments.Add(new Payment(payment.ProductName, payment.Price));
            }

            return clone;
        }

        public int CompareTo(Customer other)
        {
            string fullName = string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            string otherFullname = string.Format("{0} {1} {2}", other.FirstName, other.MiddleName, other.LastName);

            if (string.Compare(fullName, otherFullname, StringComparison.InvariantCulture) == 0)
            {
                return string.Compare(this.id, other.id, StringComparison.InvariantCulture);
            }

            return string.Compare(fullName, otherFullname, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode();
        }

        public override bool Equals(object customerToCompare)
        {
            Customer customer = customerToCompare as Customer;

            if (customer == null || !object.Equals(this.FirstName, customer.FirstName) || this.FirstName != customer.FirstName)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name: {0} {1} {2}\n", this.FirstName, this.MiddleName, this.LastName);
            result.AppendFormat("Id: {0}\n", this.Id);
            result.AppendFormat("Address: {0}\n", this.Address);
            result.AppendFormat("Mobile phone: {0}\n", this.MobilePhone);
            result.AppendFormat("Email: {0}\n", this.Email);
            result.AppendFormat("Payments: {0}\n", this.Payments.Count);
            result.AppendFormat("Customer type: {0}\n", this.CustomerType);

           return result.ToString();
        }
    }
}