using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core.BaseClasses;
using System.Collections.Specialized;

namespace HcpcsCodes
{
    public class CommunicatorConfiguration : CommunicatorConfigurationBase
    {
        public bool FileExists
        { 
            get
            {
                return File.Exists(this.Path);
            }
        }

        public CommunicatorConfiguration(string path)
        {
            this.Path = path;
        }

        public override NameValueCollection Read()
        {
            NameValueCollection collection = new NameValueCollection();
            string data = File.ReadAllText(this.Path);
            foreach (string pair in data.Split(';'))
            {
                string[] splitPair = pair.Split('=');
                collection.Add(splitPair[0], (splitPair[0].Length > 0) ? splitPair[1] : string.Empty);
            }

            return collection;
        }

        public override void Write(NameValueCollection collection)
        {
            string write = string.Empty;
            foreach(string key in collection.Keys)
           {
                write += key + "=" + collection[key] + ";";
            }

            File.WriteAllText(this.Path, write);
        }

        public void ClearConfiguration()
        {
            File.Delete(this.Path);
        }
    }
}
