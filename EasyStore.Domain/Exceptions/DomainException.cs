using System;
namespace EasyStore.Domain.Exceptions
{
    public class DomainException : Exception
    {
        internal DomainException(string message): base(message)
        { 
        }
    }
}
