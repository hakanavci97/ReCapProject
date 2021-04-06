using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModul
    {
        void Load(IServiceCollection serviceCollection);

    }
}
