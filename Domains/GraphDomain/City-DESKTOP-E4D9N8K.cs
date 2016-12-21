using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDomain
{
    [Serializable]
    public class City
    {
        public string id { get; set; }

        public string name { get ; set; }

        public City()
        {
            if(name == String.Empty)
                name = id;
        }

        public override string ToString()
        {
            return String.Format("id: {0}",id); 
        }

        public override bool Equals(Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            City p = obj as City;
            if ((Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return p.id == this.id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
