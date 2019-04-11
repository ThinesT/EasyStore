using System;
using System.Collections.Generic;
using EasyStore.Domain.Infrastructure;

namespace EasyStore.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Address_1 { get; private set; }
        public string Address_2 { get; private set; }
        public string City { get; private set; }
        public Email EmailAddress { get; set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        private Address() { }

        public Address(string address_1, string address_2, string city, string country, string zipCode)
        {
            Address_1 = address_1;
            Address_2 = address_2;
            City = city;
            Country = country;
            ZipCode = zipCode;

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address_1;
            yield return Address_2;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }
    }
}
