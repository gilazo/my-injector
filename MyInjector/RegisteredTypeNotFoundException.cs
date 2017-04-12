using System;

namespace MyInjector
{
    public class RegisteredTypeNotFoundException : Exception
    {
        public RegisteredTypeNotFoundException(string message)
            : base(message)
        {
        }
    }
}
