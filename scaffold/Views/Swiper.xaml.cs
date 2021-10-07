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
using System.Windows.Input;
using scaffold.Models;

namespace scaffold.Views
{
    public partial class Swiper : ContentPage
    {
        public ObservableCollection<UserProfile> _Profile = new ObservableCollection<UserProfile>();
        public UserProfileList _Users = new UserProfileList();
        public List<UserProfile> _LikedList = new List<UserProfile>();

        public Swiper()
        {
            InitializeComponent();
            SwipeView1.Swiped += OnSwiped;
            SwipeView1.Dragging += OnDragged;
        }

        /// <summary>
        /// On appearing
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            new Swiper();
            await CardBindingAsync();
            _LikedList.Clear();
            BindingContext = this;
        }


        /// <summary>
        /// On disappearing
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        /// <summary>
        /// Binding of users to profile
        /// </summary>
        public async Task CardBindingAsync()
        {
            _Users = await Services.GetUsersService.GetUsers();

            foreach (UserProfile p in _Users.Users)
            {
                _Profile.Add(new UserProfile() { Name = p.Name, Color = Color.FromHex(p.Hex), ImageSource = new Uri(p.Image), Image = p.Image, UserId = p.UserId });
            }
        }

        /// <summary>
        /// On swipe command add user to liked list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSwiped(object sender, SwipedCardEventArgs e)
        {  
            switch (e.Direction)
            {
                case SwipeCardDirection.Right:
                    _LikedList.Add((UserProfile)e.Item);
                    break;
                case SwipeCardDirection.Left:
                    // action tbd
                    break;
            }
        }

        /// <summary>
        /// On drag command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragged(object sender, DraggingCardEventArgs e)
        {
            switch (e.Position)
            {
                case DraggingCardPosition.FinishedOverThreshold:
                    this.EndOfStack((UserProfile)e.Item);
                    break;
            }
        }

        /// <summary>
        /// Once reached end of stack altert
        /// </summary>
        /// <param name="e"></param>
        private void EndOfStack(UserProfile e)
        {
            // Last item in stack alert
            if (e.UserId == _Users.Users.Last().UserId)
            {
                string likedPeople = String.Empty;

                foreach(UserProfile p in _LikedList)
                {
                    likedPeople += Environment.NewLine + p.Name;
                }

                DisplayAlert("Alert", string.Format("End of stack, you liked: {0}", likedPeople), "OK");
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
    }
}
