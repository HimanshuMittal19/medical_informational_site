using Medical_Rgistrations.APIModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Medical_Rgistrations.ViewModels
{
    public class MyHtmlContent
    {

        public MyHtmlContent()
        {
            this.PagesGroup = new List<string>();
            this.DownloadLinks = new List<AncorLink>();
            this.ImportentNotification = new List<AncorLink>();
        }
        public Guid Id { get; set; }
        public string HtmlData { get; set; }
        public string Page { get; set; }
        public bool Active { get; set; }
        public string TemplateName { get; set; }
        public List<string> PagesGroup { get; set; }
        public string? GallaryGroup { get; set; }
        public Gallary? imgages { get; set; }
        public List<AncorLink>? DownloadLinks { get; set; }
        public List<AncorLink>? ImportentNotification { get; set; }
        public List<AncorLink>? QuickLinks { get; set; }
        public List<AncorLink>? ImportantLinks { get; set; }
        public ContactFormVM ContactFormVM { get; set; }
    }


    public class AncorLink
    {
        public string Name { get; set; }
        public string link { get; set; }
    }
    public class ContactFormVM
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Message is required")]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
