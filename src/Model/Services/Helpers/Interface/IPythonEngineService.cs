using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.Services.Helpers.Interface
{
    public interface IPythonEngineService
    {
        ScriptEngine GetEngine();
    }
}
