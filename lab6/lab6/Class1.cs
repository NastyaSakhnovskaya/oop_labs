using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    abstract partial class Program : Software
    {
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Developer: {DeveloperName} ");
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }
            Program comparedObj = (Program)obj;
            if (comparedObj.DeveloperName == this.DeveloperName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"This is an object of {this.GetType()} type, with {this.GetHashCode()} hashcode.\nName of the program is {Name}\ndeveloper: {DeveloperName}";
        }
    }
}
