using System;
using System.Drawing;
using Xamarin.Forms;

namespace scaffold.Models
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Xamarin.Forms.Color Color { get; set; }
        public ImageSource ImageSource { get; set; }
        public string Hex { get; set; }
        public int UserId { get; set; }
    }
}