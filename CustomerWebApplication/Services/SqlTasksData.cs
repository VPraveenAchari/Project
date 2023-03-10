using CustomerWebApplication.Interfaces;
using CustomerWebApplication.Models.UtilityModels;
using CustomerWebApplication.Models;
using CustomerWebApplication.Context;

namespace CustomerWebApplication.Services
{
    public class SqlTasksData : ITasksData
    {
        private DBContext _taskContext;
        private DBContext _workerContext;

        public SqlTasksData(DBContext taskContext, DBContext workerContext)
        {
            _taskContext = taskContext;
            _workerContext = workerContext;
        }

        public void AssignedTaskTo(AssignedTo value)
        {
            var task = _taskContext.ToDoTasks.Find(value.TaskId);
            var worker = _workerContext.Workers.Find(value.WorkerId);
            if (task != null)
            {
                task.WorkerId = value.WorkerId;
                task.UpdatedAt = DateTime.Now;
                _taskContext.Entry(task)
               .Property(x => x.Id).IsModified = false;
                _taskContext.SaveChanges();
            }

            if (worker != null)
            {
                worker.TaskId = value.TaskId;
                worker.UpdatedAt = DateTime.Now;
                _workerContext.Entry(worker)
               .Property(x => x.Id).IsModified = false;
                _workerContext.SaveChanges();
            }
        }

        Tasks ITasksData.AddTask(Tasks task)
        {
            task.TaskId = Guid.NewGuid();
            task.UpdatedAt = DateTime.Now;
            task.CreatedAt = DateTime.Now;
            _taskContext.ToDoTasks.Add(task);
            _taskContext.SaveChanges();
            return task;
        }

        void ITasksData.DeleteTask(Tasks task)
        {
            if (task != null)
            {
                _taskContext.Remove(task);
                _taskContext.SaveChanges();
            }
        }

        Tasks ITasksData.EditTask(Tasks tasks)
        {
            var existingTask = _taskContext.ToDoTasks.Find(tasks.TaskId);
            if (existingTask != null)
            {

                existingTask.UpdatedAt = DateTime.Now;
                existingTask.TaskName = tasks.TaskName;
                existingTask.DueDate = tasks.DueDate;
                existingTask.Status = tasks.Status;

            }
            _taskContext.ToDoTasks.Update(existingTask);
            _taskContext.Entry(existingTask)
                .Property(x => x.Id).IsModified = false; // To Prevent Idenity column update issue
            _taskContext.SaveChanges();
            return tasks;

        }

        List<Tasks> ITasksData.GetTasks()
        {
            return _taskContext.ToDoTasks.ToList();
        }

        Tasks ITasksData.GetTasks(Guid Id)
        {
            var task = _taskContext.ToDoTasks.Find(Id);

            return task;

        }
    }
}
