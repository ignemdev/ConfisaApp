using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfisaApp.Models
{
    public class DealerViewModel
    {
        public Dealer Dealer { get; set; }
        public SelectList Oficiales { get; set; }
    }
}
