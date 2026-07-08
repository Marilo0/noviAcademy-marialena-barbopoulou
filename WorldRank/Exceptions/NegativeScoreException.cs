using System;
using System.Collections.Generic;
using System.Text;

namespace WorldRank.Exceptions
{
    public class NegativeScoreException : Exception
    {

        public NegativeScoreException() : base("Score cannot be negative.")
        {
        }

        public NegativeScoreException(string message)
            : base(message)
        {
        }
    }
}
