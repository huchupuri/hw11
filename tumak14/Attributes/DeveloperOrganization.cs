using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    internal class DeveloperOrganizationAttribute : Attribute
    {
        public string DeveloperName { get; }
        public string OrganizationName { get; }

        public DeveloperOrganizationAttribute()
        {
            DeveloperName = new string("не указано");
            OrganizationName = new string("не указано");
        }
        public DeveloperOrganizationAttribute(string developerName)
        {
            DeveloperName = developerName;
            OrganizationName = new string("не указано");
        }

        public DeveloperOrganizationAttribute(string developerName, string organizationName)
        {
            DeveloperName = developerName;
            OrganizationName= organizationName;
        }
    }
}
