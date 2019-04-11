using System;
using System.Runtime.Serialization;
using EasyStore.Domain.Exceptions;

namespace EasyStore.Domain.ValueObjects
{

    internal class EmailNotFoundException : DomainException
    {
        internal EmailNotFoundException(string message) : base(message)
        {
        }
    }
}