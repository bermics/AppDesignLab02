using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetHub.Domain.Entities;

namespace GadgetHub.WebUI.Models
{
    public class GadgetListViewModel
    {
        public IEnumerable<Gadget> Gadgets { get; set; }
        public PageProperties PageProperties{ get; set; }
    }
}