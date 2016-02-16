using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp2.Models
{
    public class Pattern
    {

        public Color? Color { get; set; }
        public string ImageUrl { get; set; }

        public bool IsColorPattern
        {
            get { return String.IsNullOrWhiteSpace(ImageUrl) && Color != null; }
        }
    }
}
