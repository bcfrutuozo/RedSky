using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class TaskDisplayViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string TaskTitle { get; set; }

        public IList<TaskCellDisplayViewModel> Cells { get; set; }
    }
}