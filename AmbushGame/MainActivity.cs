using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace AmbushGame
{
    [Activity(Label = "AmbushGame", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button b1, b2, b3, retry, credit;
        TextView scoreview;
        static string ambush = new Random().Next(1, 4).ToString();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            int score = 0;

            b1 = FindViewById<Button>(Resource.Id.button1);
            b2 = FindViewById<Button>(Resource.Id.button2);
            b3 = FindViewById<Button>(Resource.Id.button3);
            retry = FindViewById<Button>(Resource.Id.buttonRetry);
            credit = FindViewById<Button>(Resource.Id.buttonCredit);
            scoreview = FindViewById<TextView>(Resource.Id.textViewScore);

            void GameOver()
            {
                b1.Enabled = false;
                b2.Enabled = false;
                b3.Enabled = false;
                retry.Visibility = Android.Views.ViewStates.Visible;
            }

            void ResetGame()
            {
                b1.Enabled = true;
                b2.Enabled = true;
                b3.Enabled = true;
                score = 0;
                ambush = new Random().Next(1, 4).ToString();
                scoreview.Text = score.ToString();
                retry.Visibility = Android.Views.ViewStates.Invisible;
            }

            b1.Click += AmbushEvent;
            b2.Click += AmbushEvent;
            b3.Click += AmbushEvent;

            retry.Visibility = Android.Views.ViewStates.Invisible;

            credit.Click += (o, e) =>
            {
                StartActivity(typeof(Credit));
            };

            retry.Click += (o, e) =>
            {
                ResetGame();
            };

            void AmbushEvent(object sender, EventArgs e)
            {
                Button b = sender as Button;

                if (b.Text == ambush)
                {
                    GameOver();
                    var gameOverDialog = new AlertDialog.Builder(this);
                    gameOverDialog.SetCancelable(false);
                    gameOverDialog.SetMessage("Här var det ett bakhåll.");
                    gameOverDialog.SetNegativeButton("Stäng dialog", delegate { });
                    gameOverDialog.SetTitle("Ajdå!");
                    gameOverDialog.Show();
                }
                else
                {
                    score++;
                    scoreview.Text = score.ToString();
                    ambush = new Random().Next(1, 4).ToString();
                }
            }
        }
    }
}

