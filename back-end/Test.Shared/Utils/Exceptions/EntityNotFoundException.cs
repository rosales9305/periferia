using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Shared.Utils.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }

        public EntityNotFoundException(string message) : base(message)
        {

        }

    }
}
