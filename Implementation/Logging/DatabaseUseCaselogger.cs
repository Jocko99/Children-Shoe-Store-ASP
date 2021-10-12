using Application;
using Domain.Entites;
using EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class DatabaseUseCaselogger : IUseCaseLogger
    {
        private readonly ShoeStoreContext _context;

        public DatabaseUseCaselogger(ShoeStoreContext context)
        {
            _context = context;
        }

        public void Log(IUseCase userCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                UseCaseName = userCase.Name,
                Date = DateTime.UtcNow
            });
            _context.SaveChanges();
        }

        public void Log(IUseCase userCase, IApplicationActor actor, object firstUseCaseData, object secondUseCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(firstUseCaseData) + " " + JsonConvert.SerializeObject(secondUseCaseData),
                UseCaseName = userCase.Name
            });
            _context.SaveChanges();
        }
    }
}
