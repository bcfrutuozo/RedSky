using System;
using System.Collections.Generic;
using System.Globalization;
using RedSky.Domain.Entities;

namespace RedSky.Application.Interfaces
{
    public interface IProjetoApplicationService
    {
        IEnumerable<Projeto> GetListProjetoByIdEmpresa_INDEX(int idEmpresa);
        Projeto GetProjetoById(int id);
        IEnumerable<StatusProjeto> GetAllStatusProjeto_COMBOBOX();
        IEnumerable<TaskGroup> GetAllTaskGroup(int idEmpresa);
        IEnumerable<Label> GetListLabelByIdEmpresa(int idEmpresa);
        Task AddTask(Task newTask);
        Task GetTaskById(int idTask);
        Task DeleteTask(Task task);
        IEnumerable<TaskGroup> GetListTaskGroupByIdEmpresa(int idEmpresa);
        TaskGroup AddTaskGroup(TaskGroup taskGroup);
        TaskColumn AddTaskColumn(TaskColumn taskColumn);
        TaskColumn GetTaskColumnById(int idTaskColumn);
        TaskColumn DeleteTaskColumn(TaskColumn taskColumn);
        Task UpdateTaskName(Task task);
        TaskCell UpdateCellValue(TaskCell taskCell, CultureInfo culture);
        TaskColumn UpdateTaskColumn(TaskColumn taskColumn);
        Label AddLabel(Label label);
    }
}
