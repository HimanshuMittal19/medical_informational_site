using System.ComponentModel.DataAnnotations;

namespace Medical_Rgistrations.ViewModels
{

    public class Menu
    {
        public Menu()
        {

        }

        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string? ParentMenuName { get; set; }
        public List<string>? ParentMenuNameList { get; set; }
        //public string? ControllerName { get; set; }
        public bool Active { get; set; }

    }
}
