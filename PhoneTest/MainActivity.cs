using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace PhoneTest
{
    [Activity(Label = "Phone Word", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText phoneNumberText;
        Button translateButton;
        Button callButton;
        string translatedNumber = string.Empty;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            phoneNumberText = FindViewById<EditText>(Resource.Id.phoneNumberText);
            translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            callButton = FindViewById<Button>(Resource.Id.callButton);

            translateButton.Click += TranslateButton_Click;
            callButton.Click += CallButton_Click;
            callButton.Enabled = false;

            
        }

        private void TranslateButton_Click(object sender, EventArgs e)
        {
            translatedNumber = PhoneTranslator.ToNumber(phoneNumberText.Text);
            if (string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.Text = "CALL";
                callButton.Enabled = false;
            }
            else
            {
                callButton.Text = "CALL " + translatedNumber;
                callButton.Enabled = true;
            }
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            var callDialog = new AlertDialog.Builder(this);
            callDialog.SetTitle("Dialog");
            callDialog.SetMessage("call " + translatedNumber + "?");

           
            callDialog.SetNegativeButton("Cancel", delegate { });
            callDialog.SetPositiveButton("Call", delegate
            {
                var callClient = new Intent(Intent.ActionCall);
                callClient.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                StartActivity(callClient);


            });
            callDialog.Show();
        }
    }
}

