using CustomerWebApplication.Context;
using CustomerWebApplication.Interfaces;
using CustomerWebApplication.Models;

namespace CustomerWebApplication.Services
{
    public class WorkersRepo : IWorkersData
    {
        private DBContext _workerContext;

        public WorkersRepo(DBContext workerContext)
        {
            _workerContext = workerContext;
        }

        Workers IWorkersData.AddWorker(Workers workers)
        {
            workers.WorkerId = Guid.NewGuid();
            workers.UpdatedAt = DateTime.Now;
            workers.CreatedAt = DateTime.Now;
            _workerContext.Workers.Add(workers);
            _workerContext.SaveChanges();
            return workers;
        }

        public void DeleteWorker(Workers workers)
        {
            throw new NotImplementedException();
        }

        List<Workers> IWorkersData.GetWorkers()
        {
            return _workerContext.Workers.ToList();
        }

        Workers IWorkersData.GetWorkers(Guid Id)
        {
            throw new NotImplementedException();
        }

        Workers IWorkersData.EditWorker(Workers workers)
        {
            throw new NotImplementedException();
        }
    }
}
