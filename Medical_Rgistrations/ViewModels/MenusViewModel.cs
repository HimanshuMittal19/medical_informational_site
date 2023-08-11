using System.ComponentModel.DataAnnotations;

namespace Medical_Rgistrations.ViewModels
{

    public class MenusViewModel
    {
        public MenusViewModel()
        {
        }

        public string MenuName { get; set; }
        public string ParentMenuName { get; set; }
        public bool Active { get; set; }

    }
    public class MenuVM
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public object MenuVMs { get; set; }
    }

    public class MenuApiVM
    {
        //public MenuApiVM()
        //{
        //    this.MenuVMs = new List<MenuVM>();
        //}
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<MenuVM> MenuVMs { get; set; }
    }
    public class MenuApisVM
    {
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public string? ParentMenuName { get; set; }
        public Guid? ParentMenuId { get; set; }
        public bool Active { get; set; }
        public List<string> MenuList { get; set; }
    }
}
