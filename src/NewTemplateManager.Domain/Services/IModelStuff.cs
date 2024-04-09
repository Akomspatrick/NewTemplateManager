using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTemplateManager.Domain.Services
{
    public interface IModelStuff
    {
        List<string> GetModels(string modelName);
    }
}
