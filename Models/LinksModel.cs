using System;
using System.Collections.Generic;

namespace asp_net_mvc_core_link_generation.Models
{
    public class Link {
        public string Text { get; set; }
        public string URL { get; set; }
    }

    public class LinksModel
    {
        public IEnumerable<Link> Links { get; set; }
    }
}
