using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace scaffold.Views
{
    public partial class Swiper : ContentPage
    {
        public ObservableCollection<UserProfile> _Profile = new ObservableCollection<UserProfile>();
        public Swiper()
        {
            InitializeComponent();
            CardBinding();
            BindingContext = this;
        }

        public void CardBinding()
        {
            _Profile.Add(new UserProfile() { Name = "1", Color = Color.Green, Image = "1.jpg" });
            _Profile.Add(new UserProfile() { Name = "2", Color = Color.Yellow, Image = "2.jpg" });
            _Profile.Add(new UserProfile() { Name = "3", Color = Color.Orange, Image = "3.jpg" });
            _Profile.Add(new UserProfile() { Name = "4", Color = Color.Blue, Image = "4.jpg" });
            _Profile.Add(new UserProfile() { Name = "5", Color = Color.Black, Image = "5.jpg" });
        }

        public ObservableCollection<UserProfile> Profile
        {
            get => _Profile;
            set
            {
                _Profile = value;
            }
        }

        public class UserProfile
        {
            public string Name { get; set; }
            public string Colour { get; set; }
            public string Image { get; set; }
            public Color Color { get; set; }
        }
    }
}
