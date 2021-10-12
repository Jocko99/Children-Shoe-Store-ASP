using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase userCase, IApplicationActor actor, object useCaseData);
        void Log(IUseCase userCase, IApplicationActor actor, object firstUseCaseData, object secondUseCaseData);
    }
}
