using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class DeleteTaskViewModel
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string TaskTitle { get; set; }
    }
}