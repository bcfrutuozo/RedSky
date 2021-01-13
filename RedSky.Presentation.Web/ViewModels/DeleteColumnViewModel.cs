using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class DeleteColumnViewModel
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public string Header { get; set; }
    }
}