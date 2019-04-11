using System.Collections.Generic;
using EasyStore.Domain.Infrastructure;

namespace EasyStore.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmailNotFoundException("Email address should not be empty!");
            }

            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}