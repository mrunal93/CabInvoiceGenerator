using System;
using System.Runtime.Serialization;

namespace CabInvoiceGenerator
{
    public enum ExceptionType
    {
        NULL_EXCEPTION
    }
    public class CustomException : Exception
    {
        public string message;

        public CustomException(string Message)
        {
            this.message = Message;
        }
    }
}