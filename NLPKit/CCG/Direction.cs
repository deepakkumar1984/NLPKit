using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NLPKit.CCG
{
    public class Direction
    {
        public string Dir { get; set; }

        public string[] Restrictions { get; set; }

        public int ComparisonKey { get; set; }

        public Direction(string dir, string[] restrictions)
        {
            Dir = dir;
            Restrictions = restrictions;
            ComparisonKey = dir.Length + restrictions.Length;
        }

        public bool IsForward()
        {
            return Dir == "/";
        }

        public bool IsBackward()
        {
            return Dir == "\\";
        }

        public bool IsVariable()
        {
            return Restrictions.Contains("_");
        }

        public Dictionary<string, string[]> CanUnify(Direction other)
        {
            if (other.IsVariable())
                return new Dictionary<string, string[]>() { { "_", Restrictions } };
            else if (IsVariable())
                return new Dictionary<string, string[]>() { { "_", other.Restrictions } };
            else
                if (other.Restrictions == this.Restrictions)
                    return null;

            return null;
        }

        public Direction Substitute(Dictionary<string, string[]> subs)
        {
            if (!IsVariable())
                return this;

            foreach (var item in subs)
            {
                if(item.Key == "_")
                {
                    return new Direction(Dir, item.Value);
                }
            }

            return this;
        }

        public bool CanCompose()
        {
            return !Restrictions.Contains(",");
        }

        public bool CanCross()
        {
            return !Restrictions.Contains(".");
        }

        public static bool operator ==(Direction a, Direction b)
        {
            return a.ComparisonKey == b.ComparisonKey;
        }

        public static bool operator !=(Direction a, Direction b)
        {
            return a.ComparisonKey != b.ComparisonKey;
        }

        public static bool operator <(Direction a, Direction b)
        {
            return a.ComparisonKey < b.ComparisonKey;
        }

        public static bool operator >(Direction a, Direction b)
        {
            return a.ComparisonKey > b.ComparisonKey;
        }
    }
}
