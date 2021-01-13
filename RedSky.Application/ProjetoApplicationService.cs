using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RedSky.Application.Interfaces;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Application
{
    public class ProjetoApplicationService : IProjetoApplicationService
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly ILabelService _labelService;
        private readonly IProjetoService _projetoService;
        private readonly ITaskService _taskService;
        private readonly ITaskCellService _taskCellService;
        private readonly ITaskColumnService _taskColumnService;
        private readonly ITaskGroupService _taskGroupService;
        private readonly IStatusProjetoService _statusProjetoService;

        public ProjetoApplicationService(
            IDataTypeService dataTypeService,
            ILabelService labelService,
            IProjetoService projetoService,
            ITaskService taskService,
            ITaskCellService taskCellService,
            ITaskColumnService taskColumnService,
            ITaskGroupService taskGroupService,
            IStatusProjetoService statusProjetoService)

        {
            _dataTypeService = dataTypeService;
            _labelService = labelService;
            _projetoService = projetoService;
            _statusProjetoService = statusProjetoService;
            _taskService = taskService;
            _taskCellService = taskCellService;
            _taskColumnService = taskColumnService;
            _taskGroupService = taskGroupService;
        }

        #region Label

        public Label AddLabel(Label label)
        {
            return _labelService.Add(label).FirstOrDefault();
        }

        public IEnumerable<Label> GetListLabelByIdEmpresa(int idEmpresa)
        {
            return _labelService.GetList(st => st.IdEmpresa == idEmpresa || !st.IdEmpresa.HasValue, st => st.Color);
        }

        #endregion

        #region Projeto

        public IEnumerable<Projeto> GetListProjetoByIdEmpresa_INDEX(Int32 idEmpresa)
        {
            return _projetoService.GetListProjetoByIdEmpresa_INDEX(idEmpresa);
        }

        public Projeto GetProjetoById(Int32 id)
        {
            return _projetoService.GetProjetoById(id);
        }

        #endregion

        #region StatusProjeto

        public IEnumerable<StatusProjeto> GetAllStatusProjeto_COMBOBOX()
        {
            return _statusProjetoService.GetAllStatusProjeto_COMBOBOX();
        }

        #endregion

        #region Task

        public Task AddTask(Task newTask)
        {
            var task = _taskService.Add(newTask).FirstOrDefault();
            
            var taskGroup = _taskGroupService.GetWithColumnsById(task.IdTaskGroup);

            List<TaskCell> lstCells = taskGroup.Columns.Select(column => new TaskCell() {IdTask = task.Id, IdTaskColumn = column.Id, Value = null }).ToList();

            _taskCellService.Add(lstCells.ToArray());

            return task;
        }

        public Task GetTaskById(int idTask)
        {
            return _taskService.GetById(idTask);
        }

        public Task UpdateTaskName(Task task)
        {
            var objTask = _taskService.GetById(task.Id);
            objTask.TaskTitle = task.TaskTitle;
            return _taskService.Update(objTask).FirstOrDefault();
        }

        public Task DeleteTask(Task task)
        {
            var objTask = _taskService.GetWithCellsById(task.Id);

            _taskCellService.Delete(objTask.TaskCells.Select(cell => new TaskCell
                {
                    Id = cell.Id, IdTask = cell.IdTask, IdTaskColumn = cell.IdTaskColumn, Value = cell.Value,
                })
                .ToArray());

            return _taskService.Delete(task).FirstOrDefault();
        }

        #endregion

        #region TaskCell

        public TaskCell UpdateCellValue(TaskCell taskCell, CultureInfo culture)
        {
            var objTaskCell = _taskCellService.GetWithColumnAndDataTypeById(taskCell.Id);

            switch (objTaskCell.TaskColumn.DataType.Type)
            {
                 case "System.Int32":
                     objTaskCell.Value = taskCell.Value;
                     break;
                 case "System.Decimal":
                     //objTaskCell.Value = Decimal.Parse(taskCell.Value, NumberStyles.Any, culture).ToString("D2");
                     objTaskCell.Value = Convert.ToString(Convert.ToDecimal(taskCell.Value, culture), new CultureInfo("en-US"));
                     break;
                 case "System.String":
                     objTaskCell.Value = taskCell.Value;
                     break;
                 case "System.DateTime":
                     objTaskCell.Value =
                         Convert.ToString(DateTime.Parse(taskCell.Value, culture), new CultureInfo("en-US"));
                     break;
                 case "IEnumerable<RedSky.Domain.Entities.Usuario>":
                     break;
                 case "RedSky.Domain.Entities.StatusTask":
                     objTaskCell.Value = taskCell.Value;
                     break;
            }

            // Remove eager loading for saving
            objTaskCell.TaskColumn = null;
            return _taskCellService.Update(objTaskCell).FirstOrDefault();
        }

        #endregion

        #region TaskColumn

        public TaskColumn AddTaskColumn(TaskColumn taskColumn)
        {
            var coluna = _taskColumnService.Add(taskColumn).FirstOrDefault();
            
            var taskGroup = _taskGroupService.GetWithTaskById(coluna.IdTaskGroup);

            List<TaskCell> lstCells = taskGroup.Tasks.Select(tarefa => new TaskCell
                {IdTask = tarefa.Id, IdTaskColumn = coluna.Id, Value = null}).ToList();

            _taskCellService.Add(lstCells.ToArray());

            return coluna;
        }

        public TaskColumn GetTaskColumnById(int idTaskColumn)
        {
            return _taskColumnService.GetById(idTaskColumn);
        }

        public TaskColumn UpdateTaskColumn(TaskColumn taskColumn)
        {
            var objTaskColumn = _taskColumnService.GetById(taskColumn.Id);
            
            // Pega o tipo de dado atual da coluna, proibindo a alteração de seu valor para o usuário.
            taskColumn.IdDataType = objTaskColumn.IdDataType;
            taskColumn.IdTaskGroup = objTaskColumn.IdTaskGroup;
            
            return _taskColumnService.Update(taskColumn).First();
        }

        public TaskColumn DeleteTaskColumn(TaskColumn taskColumn)
        {
            var objColumn = _taskColumnService.GetWithCellsById(taskColumn.Id);

            _taskCellService.Delete(objColumn.TaskCells.Select(cell => new TaskCell
                {
                    Id = cell.Id, IdTask = cell.IdTask, IdTaskColumn = cell.IdTaskColumn, Value = cell.Value,
                })
                .ToArray());

            return _taskColumnService.Delete(taskColumn).FirstOrDefault();
        }

        #endregion

        #region TaskGroup

        public TaskGroup AddTaskGroup(TaskGroup taskGroup)
        {
            return _taskGroupService.Add(taskGroup).FirstOrDefault();
        }

        public IEnumerable<TaskGroup> GetAllTaskGroup(int idEmpresa)
        {
            return _taskGroupService.GetListTaskGroupByIdEmpresa(idEmpresa);
        }

        public IEnumerable<TaskGroup> GetListTaskGroupByIdEmpresa(int idEmpresa)
        {
            return _taskGroupService.GetListTaskGroupByIdEmpresa(idEmpresa);
        }

        #endregion
    }
}
