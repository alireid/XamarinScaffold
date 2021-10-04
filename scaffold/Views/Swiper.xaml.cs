using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using scaffold.Helpers;
using MLToolkit.Forms.SwipeCardView.Core;

namespace scaffold.Views
{
    public partial class Swiper : ContentPage
    {

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Navigation.PushModalAsync(new Swiper());
        }

        public ObservableCollection<UserProfile> _Profile = new ObservableCollection<UserProfile>();
        public Swiper()
        {
            InitializeComponent();
            CardBinding(this.Retrieve());
            BindingContext = this;

            SwipeView1.Swiped += OnSwiped;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // move on a different tab to avoid infinite loop when back button is pressed
            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[0];
        }

        public void CardBinding(List<UserProfile> payload)
        {
            foreach(UserProfile p in payload)
            {
                _Profile.Add(new UserProfile() { Name = p.Name, Color = Color.FromHex(p.Hex), ImageSource = new Uri(p.Image), Image = p.Image });
            }
        }

        /// <summary>
        /// Make this a json reterival method
        /// </summary>
        /// <returns></returns>
        public List<UserProfile> Retrieve()
        {
            var items = new List<UserProfile>();

            items.Add(new UserProfile() { Hex = "FF0000", Image = "/temp/img/1.jpg", Name = "Jade" });
            items.Add(new UserProfile() { Hex = "0000FF", Image = "/temp/img/2.jpg", Name = "Gemma" });
            items.Add(new UserProfile() { Hex = "00FF00", Image = "/temp/img/3.jpg", Name = "Kelly" });

            return items;
        }

        private void OnSwiped(object sender, SwipedCardEventArgs e)
        {
            
            switch (e.Direction)
            {

                case SwipeCardDirection.Right:
                    var item = (UserProfile)e.Item;
                    DisplayAlert("Alert", string.Format("You liked {0}", item.Name), "OK");
                    break;
                case SwipeCardDirection.Left:
                    var item2 = (UserProfile)e.Item;
                    DisplayAlert("Alert", string.Format("You did NOT like {0}", item2.Name), "OK");
                    break;
            }
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
            public string Image { get; set; }
            public Color Color { get; set; }
            public ImageSource ImageSource { get; set; }
            public string Hex { get; set; }
        }
    }
}
