using CustomerWebApplication.Models.UtilityModels;
using CustomerWebApplication.Models;
using System.Collections.Generic;

namespace CustomerWebApplication.Interfaces
{
    public interface ITasksData
    {
        List<Tasks> GetTasks();

        Tasks GetTasks(Guid Id);

        Tasks AddTask(Tasks tasks);

        Tasks EditTask(Tasks tasks);

        void DeleteTask(Tasks tasks);

        void AssignedTaskTo(AssignedTo value);
    }
}
