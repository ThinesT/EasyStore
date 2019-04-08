using System;
using System.Collections.Generic;
using EasyStore.Domain.Infrastructure;

namespace EasyStore.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }

        public Money(decimal value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
