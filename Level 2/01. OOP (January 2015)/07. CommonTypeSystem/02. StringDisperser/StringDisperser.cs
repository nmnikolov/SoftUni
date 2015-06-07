namespace StringDisperser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class StringDisperser
        : IComparable<StringDisperser>, IEnumerable, ICloneable
    {
        private readonly IList<string> strings = new List<string>();

        public StringDisperser(params string[] strings)
        {
            this.Strings = strings;
        }

        public IList<string> Strings
        {
            get
            {
                return this.strings;
            }

            set
            {
                foreach (var str in value)
                {
                    this.strings.Add(str);
                }
            }
        }

        public static bool operator ==(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return object.Equals(firstDisperser, secondDisperser);
        }

        public static bool operator !=(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return !object.Equals(firstDisperser, secondDisperser);
        }

        public int CompareTo(StringDisperser other)
        {
            string thisString = string.Join(string.Empty, this.Strings);
            string otherString = string.Join(string.Empty, other.Strings);

            return string.Compare(thisString, otherString, StringComparison.InvariantCulture);
        }

        public object Clone()
        {
            StringDisperser clone = new StringDisperser();

            foreach (var str in this.Strings)
            {
                clone.Strings.Add(str);
            }

            return clone;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            string str = string.Join(string.Empty, this.Strings);

            return str.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return this.Strings.GetHashCode();
        }

        public override bool Equals(object disperserToCompare)
        {
            StringDisperser disperser = disperserToCompare as StringDisperser;

            if (disperser == null || !object.Equals(this.Strings, disperser.Strings) || this.Strings != disperser.Strings)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Strings:\n");
            foreach (var str in this.Strings)
            {
                result.AppendFormat("{0}\n", str);
            }

            return result.ToString();
        }
    }
}