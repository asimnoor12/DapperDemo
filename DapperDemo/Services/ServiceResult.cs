using DapperDemo.Models;

namespace DapperDemo.Services
{
    internal class ServiceResult<T> : Product
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}