using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NLPKit.CCG
{
    public class PrimitiveCategory : CCGCategory
    {
        public string Categ { get; set; }

        public string[] Restrictions { get; set; }

        public PrimitiveCategory(string categ, string[] restrictions)
        {
            Categ = categ;
            Restrictions = restrictions;
            ComparisonKey = categ.Length + restrictions.Length;
        }

        public override Dictionary<object, CCGCategory> CanUnify(CCGCategory other)
        {
            PrimitiveCategory primitiveCategory = (PrimitiveCategory)other;
            if (!other.IsPrimitive())
                return null;

            if (other.IsVar())
                return new Dictionary<object, CCGCategory>() { { other, this } };

            if(primitiveCategory.Categ == Categ)
            {
                foreach (var item in Restrictions)
                {
                    if(!primitiveCategory.Restrictions.Contains(item))
                    {
                        return null;
                    }
                }

                return new Dictionary<object, CCGCategory>();
            }

            return null;
        }

        public override bool IsFunction()
        {
            return false;
        }

        public override bool IsPrimitive()
        {
            return true;
        }

        public override bool IsVar()
        {
            return false;
        }

        public override CCGCategory Substitute(Dictionary<object, CCGCategory> substitutions)
        {
            return this;
        }
    }
}
