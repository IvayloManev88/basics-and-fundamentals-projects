using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T _element;

        public T Element { get => _element; set => _element = value; }

        public override string ToString()
        {
            string result =Element.GetType()+ ": " + Element;
            return result;
        }
    }
}
