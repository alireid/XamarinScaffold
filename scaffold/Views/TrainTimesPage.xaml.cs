using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Newtonsoft.Json;
using Plugin.SimpleAudioPlayer;
using scaffold.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace scaffold.Views
{
    public partial class TrainTimesPage : ContentPage
    {
        public TrainTimesPage()
        {
            InitializeComponent();

            string payload = string.Empty;

            // Load JSON and breakdown into instructions, helper methods external static?
                //payload = Utility.DataRequest(Registry.DataUrl);
                payload = "{\"product\": null, \"version\": 0.0, \"releaseDate\": \"0001-01-01T00:00:00\", \"demo\": false, \"stations\": [{\"name\": \"abano\",\"time\": \"14:30\"},{ \"name\": \"padova\",\"time\": \"17:12\" }] }";

     

            this.jsonEditor.Text = payload;

        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            // Create list of media to play
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            List<string> mediaItems = new List<string>();
            mediaItems.Add("attention");

            string payload = this.jsonEditor.Text;

            // Convert payload to object
            scaffold.Models.StationEntity.StationPayload payloadObj = JsonConvert.DeserializeObject<scaffold.Models.StationEntity.StationPayload>(payload);

            foreach (scaffold.Models.StationEntity.Station s in payloadObj.stations)
            {
                // the station

                mediaItems.Add(textInfo.ToTitleCase(s.name));
                mediaItems.Add("arrive");

                // the time
                int mins = int.Parse(s.time.Substring(Math.Max(0, s.time.Length - 2)));
                int hrs = int.Parse(s.time.Substring(0, 2));

                string minsConverted = Utility.NiceNumbers(mins);
                string hoursConverted = Utility.NiceNumbers(hrs);

                mediaItems.Add(hoursConverted);
                mediaItems.Add(minsConverted);
            }




            foreach (string s in mediaItems)
            {
                ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(s + ".mp3");
                player.Play();



            }
            
        }


       


    }
}