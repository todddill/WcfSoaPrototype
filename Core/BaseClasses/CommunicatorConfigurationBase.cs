using System.Collections.Generic;

namespace Core.BaseClasses
{
    public abstract class CommunicatorConfigurationBase
    {
        public string Endpoint { get; set; }
        public List<string> RequestParameters { get; set; }

        public abstract void Read();
        public abstract void Write(string path);

    }
}