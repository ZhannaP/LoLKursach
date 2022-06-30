using System;
using System.Collections.Generic;
using System.Text;

namespace LOL.Core.Exeptions
{
    public class EntityWasCreatedException : Exception
    {
        public EntityWasCreatedException(int number) : base($"Entity was ID = {number} has already been created")
        { }
    }
}
