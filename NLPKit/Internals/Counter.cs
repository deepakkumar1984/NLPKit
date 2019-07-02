using System;
using System.Collections.Generic;
using System.Text;

namespace NLPKit.Internals
{
    public class Counter
    {
        private int value = 0;

        public Counter(int initial_value = 0)
        {
            value = initial_value;
        }

        public int Get()
        {
            value += 1;
            return value;
        }
    }
}
