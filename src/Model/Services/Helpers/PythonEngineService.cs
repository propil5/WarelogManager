using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Services.Helpers.Interface;

namespace WarelogManager.Model.Services.Helpers
{
    public class PythonEngineService : IPythonEngineService
    {
        public ScriptEngine GetEngine()
        {
            var engine = Python.CreateEngine();
            var Paths = SetPaths(engine);
            engine.SetSearchPaths(Paths);
            return engine;
        }

        private static ICollection<string> SetPaths(ScriptEngine engine)
        {
            var Paths = engine.GetSearchPaths();
            Paths.Add(@"C:\Users\piotr");
            return Paths;
        }
    }
}
