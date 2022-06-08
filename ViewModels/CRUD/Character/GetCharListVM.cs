using System.ComponentModel.DataAnnotations;

namespace AppDisney.ViewModels
{
    public class GetCharListVM
    {
        [Display(Name = "Character name")]        
        public string Name { get; set; }

        [Display(Name = "URL Image")]       
        public string Image { get; set; }
    }
}
