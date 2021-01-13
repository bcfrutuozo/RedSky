using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RedSky.Utilities;

namespace RedSky.Presentation.Web.ViewModels
{
    public class TaskViewModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        [MaxLength(64)]
        public string TaskTitle { get; set; }

        public List<UsuarioViewModel> Users { get; set; }

        public int IdStatusTask { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime InitialDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndingDate { get; set; }

        [DecimalPrecision(15,4)]
        public Decimal Number { get; set; }

        public string Text { get; set; }

    }
}