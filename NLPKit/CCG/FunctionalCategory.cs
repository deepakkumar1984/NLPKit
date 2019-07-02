using System;
using System.Collections.Generic;
using System.Text;

namespace NLPKit.CCG
{
    public class FunctionalCategory : CCGCategory
    {
        public CCGCategory Result { get; set; }
        public CCGCategory Arg { get; set; }
        public CCGCategory Dir { get; set; }

        public FunctionalCategory(CCGCategory result, CCGCategory arg, CCGCategory dir )
        {
            Result = result;
            Arg = arg;
            Dir = dir;
        }

        public override Dictionary<object, CCGCategory> CanUnify(CCGCategory other)
        {
            if (other.IsVar())
                return new Dictionary<object, CCGCategory>() { { other, this } };

            FunctionalCategory functionalCategory = (FunctionalCategory)other;
            if (other.IsFunction())
            {
                var sa = Result.CanUnify(functionalCategory.Result);
                var sd = Dir.CanUnify(functionalCategory.Dir);

                if(sa != null && sd != null)
                {
                    var sb = Arg.Substitute(sa).CanUnify(functionalCategory.Arg.Substitute(sa));
                    if (sb != null)
                    {
                        foreach (var item in sb)
                        {
                            sa.Add(item.Key, item.Value);
                        }
                    }
                }
            }

            return null;
        }

        public override bool IsFunction()
        {
            return true;
        }

        public override bool IsPrimitive()
        {
            return false;
        }

        public override bool IsVar()
        {
            return false;
        }

        public override CCGCategory Substitute(Dictionary<object, CCGCategory> substitutions)
        {
            return new FunctionalCategory(Result.Substitute(substitutions), Arg.Substitute(substitutions), Dir.Substitute(substitutions));
        }
    }
}
