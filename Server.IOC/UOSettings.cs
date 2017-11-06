using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.IOC
{
    public interface IUOSettings
    {
        bool Profiling { get; set; }
        string FindDataFile( string path )
    }
    public class UOSettings : IUOSettings
    {
        public bool Profiling { get; set; }
        public string FindDataFile(string path)
        {
            return string.Empty;
        }
    }
}
