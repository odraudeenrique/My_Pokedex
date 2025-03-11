using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class Pokemon
    {
        private int id;
        private int number;
        private string name;
        private string description;
        private string url;
        private Element type;
        private Element weakness;
        //private int evolution;
        private bool active;
        public Pokemon()
        {
            Type=new Element();
            Weakness=new Element(); 
        }
        public Pokemon(int id, int number, string name, string description, string url, Element type,Element weakness, bool active)
        {
            Id = id;
            Number = number;
            Name = name;
            Description = description;
            Url = url;
            Type = type;
            Weakness = weakness;
            Active = active;
        }

        public int Id { get { return this.id; } set { this.id = value; } }
       
        public int Number { get { return this.number; } set { this.number = value; } }
        
        public string Name { get { return this.name; } set { this.name = value; } }
     
        public string Description { get { return this.description; } set { this.description = value; } }
        public string Url { get { return this.url; } set { this.url = value; } }
        public Element Type { get { return this.type; } set { this.type = value; } }
        public Element Weakness { get { return this.weakness; } set { this.weakness = value; } }
        public bool Active { get { return this.active; } set { this.active = value; } }



    }
}
