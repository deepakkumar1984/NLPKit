using System;
using System.Collections.Generic;
using System.Text;

namespace NLPKit.CCG
{
    public class CCGVar : CCGCategory
    {
        private int maxID = 0;

        public bool PrimOnly { get; set; }

        public int ID { get; set; }

        public CCGVar(bool prim_only = false)
        {
            PrimOnly = prim_only;
        }

        public int NewID()
        {
            maxID = maxID + 1;
            return maxID - 1;
        }

        public void ResetID()
        {
            maxID = 0;
        }

        public override Dictionary<object, CCGCategory> CanUnify(CCGCategory other)
        {
            if(other.IsPrimitive() || !PrimOnly)
            {
                return new Dictionary<object, CCGCategory>() { { this, other } };
            }

            return null;
        }

        public override bool IsFunction()
        {
            return false;
        }

        public override bool IsPrimitive()
        {
            return false;
        }

        public override bool IsVar()
        {
            return true;
        }

        public override CCGCategory Substitute(Dictionary<object, CCGCategory> substitutions)
        {
            foreach (var item in substitutions)
            {
                if(item.GetType() == GetType())
                {
                    return item.Value;
                }
            }

            return this;
        }
    }
}
