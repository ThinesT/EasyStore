using System;
namespace EasyStore.Application.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogErro(string message, params object[] args);
        void LogWarning(string message, params object[] args);

    }
}
