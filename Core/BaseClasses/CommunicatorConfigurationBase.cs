using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseClasses
{
    public abstract class CommunicatorConfigurationBase
    {
        private List<string> requestParameterNames = new List<string>();

        public string Path { get; set; }
        public string Endpoint { get; set; }

        public abstract NameValueCollection Read();
        public abstract void Write(NameValueCollection collection);

        public void AddRequestParameter(string name)
        {
            requestParameterNames.Add(name);
        }

        public List<string> GetListOfRequestParameters()
        {
            return requestParameterNames;
        }
        
    }
}