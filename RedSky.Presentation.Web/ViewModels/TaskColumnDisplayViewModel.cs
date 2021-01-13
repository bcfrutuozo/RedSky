using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class TaskColumnDisplayViewModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }

        [Display(Name = "Header")]
        [MinLength(4, ErrorMessage = "Mínimo de {1} caracteres")]
        [MaxLength(32, ErrorMessage = "Tamanho máximo permitido de {1} caracteres")]
        public string Header { get; set; }
        
        public DataTypeDisplayViewModel DataType { get; set; }
        
        public IList<TaskCellDisplayViewModel> Cells { get; set; }
    }
}