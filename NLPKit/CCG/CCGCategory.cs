using System;
using System.Collections.Generic;
using System.Text;

namespace NLPKit.CCG
{
    public abstract class CCGCategory
    {
        public int ComparisonKey { get; set; }

        public abstract bool IsPrimitive();

        public abstract bool IsFunction();

        public abstract bool IsVar();

        public abstract CCGCategory Substitute(Dictionary<object, CCGCategory> substitutions);

        public abstract Dictionary<object, CCGCategory> CanUnify(CCGCategory other);

        public static bool operator ==(CCGCategory a, CCGCategory b)
        {
            return a.ComparisonKey == b.ComparisonKey;
        }

        public static bool operator !=(CCGCategory a, CCGCategory b)
        {
            return a.ComparisonKey != b.ComparisonKey;
        }

        public static bool operator <(CCGCategory a, CCGCategory b)
        {
            return a.ComparisonKey < b.ComparisonKey;
        }

        public static bool operator >(CCGCategory a, CCGCategory b)
        {
            return a.ComparisonKey > b.ComparisonKey;
        }
    }
}
