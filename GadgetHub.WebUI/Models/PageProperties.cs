using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GadgetHub.WebUI.Models
{
    public class PageProperties
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        public string PageUrl(int page) => $"/Gadget/List?page={page}";
    }
}