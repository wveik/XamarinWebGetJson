using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamarinWebGetJson.Domain;
using Newtonsoft.Json;

namespace XamarinWebGetJson {
    [Activity(Label = "XamarinWebGetJson", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {

        private Button button;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += GetJsonFromWeb;
        }

        private void GetJsonFromWeb(object sender, EventArgs e) {
            using (var webClient = new System.Net.WebClient()) {
                var json = webClient.DownloadString("http://iis8.ntk-intourist.ru//Home/CheckBooking?DG_CODE=AVBX0411A0&FIO=%D0%92%D0%BE%D1%80%D0%BE%D0%BD%D0%B8%D0%BD%D0%B0%20%D0%951%D0%BB%D0%B5%D0%BD%D0%B0");

                Console.WriteLine(json);
                //JsonConvert - взято с Json.NET NuGet
                var test = JsonConvert.DeserializeObject<CheckAndSessionId>(json);
                button.Text = test.SessionId.ToString();
                Console.WriteLine(test.SessionId);
            }
        }
    }
}

