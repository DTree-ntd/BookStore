using System.Runtime.CompilerServices;
using log4net;

namespace BookStore.Common
{
    public class LogAction
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }
    }
}
