using CustomerWebApplication.Models;
using System.Collections.Generic;

namespace CustomerWebApplication.Interfaces
{
    public interface IWorkersData
    {
        List<Workers> GetWorkers();

        Workers GetWorkers(Guid Id);

        Workers AddWorker(Workers workers);

        Workers EditWorker(Workers workers);

        void DeleteWorker(Workers workers);
    }
}
