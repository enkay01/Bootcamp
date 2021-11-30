using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    class Logger
    {
        private const string lFile = "log.txt";
        public Logger()
        {
            if (File.Exists(lFile))
            {
                File.Delete(lFile);
            }
        }
        public async Task writeToFile(string question, string result)
        {
            File.AppendAllText(lFile, string.Format("{0} = {1} {2}", question, result, Environment.NewLine));
        }
    }
}
