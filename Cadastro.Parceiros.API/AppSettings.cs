using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cadastro.Parceiros.API
{
    public class AppSettings
    {
        public static AppSettings Settings { get; set; }
        public string UseDatabase { get; set; }
        public string MigrationAssembly { get; set; }
        public Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

        public AppSettings()
        {
            Settings = this;
        }
    }
}