using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true) ]
    internal class DeveloperInfoAttribute: Attribute
    {
        public string DeveloperName { get; }
        public DateTime DevelopmentDate { get; }

        public DeveloperInfoAttribute()
        {
            DeveloperName = new string("не указано");
            DevelopmentDate = DateTime.Now;
        }
        public DeveloperInfoAttribute(string developerName)
        {
            DeveloperName = developerName;
            DevelopmentDate = DateTime.Now;
        }

        public DeveloperInfoAttribute(string developerName, string developmentDate)
        {
            DeveloperName = developerName;
            DevelopmentDate = DateTime.Parse(developmentDate); 
        }
        
    }
}
