using System;

namespace BigSchool.Models
{
    internal class stringLengthAttribute : Attribute
    {
        private int v;

        public stringLengthAttribute(int v)
        {
            this.v = v;
        }
    }
}