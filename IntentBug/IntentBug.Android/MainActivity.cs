using System;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Nfc;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace IntentBug.Droid
{
    [Activity(Label = "IntentBug", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// NFC Adapter
        /// </summary>
        private NfcAdapter _nfcAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            _nfcAdapter = NfcAdapter.GetDefaultAdapter(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Called when the application is resumed
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            if (_nfcAdapter == null) {
                var alert = new AlertDialog.Builder(this).Create();
                alert.SetMessage("NFC is not supported on this device.");
                alert.SetTitle("NFC Unavailable");
                alert.Show();
            } else {
                var filters = new[] { new IntentFilter(NfcAdapter.ActionTagDiscovered) };
                var intent = new Intent(this, this.GetType()).AddFlags(ActivityFlags.SingleTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);

                _nfcAdapter.EnableForegroundDispatch(this, pendingIntent, filters, null);
            }
        }

        /// <summary>
        /// Intercepts intents from the Android OS
        /// </summary>
        /// <param name="intent"></param>
        protected override async void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            if (intent.Action == NfcAdapter.ActionTagDiscovered)
            {
                if (intent.GetParcelableExtra(NfcAdapter.ExtraTag) is Tag tag)
                {
                    var uid = ByteArrayToHexString(tag.GetId()).ToUpper();
                    string ndef = null;

                    // First get all the NdefMessage
                    var rawMessages = intent.GetParcelableArrayExtra(NfcAdapter.ExtraNdefMessages);
                    if (rawMessages != null)
                    {
                        var msg = (NdefMessage)rawMessages[0];

                        // Get NdefRecord which contains the actual data
                        var record = msg.GetRecords()[0];
                        if (record != null)
                        {
                            if (record.Tnf == NdefRecord.TnfWellKnown) // The data is defined by the Record Type Definition (RTD) specification available from http://members.nfc-forum.org/specs/spec_list/
                            {
                                // Get the transferred data
                                ndef = Encoding.UTF8.GetString(record.GetPayload());

                                if (ndef.Contains("en"))
                                {
                                    var parts = ndef.Split("en");

                                    if (parts.Length == 2)
                                    {
                                        ndef = parts[1];
                                    }
                                    else if (parts.Length > 2)
                                    {
                                        ndef = string.Join("", parts.Skip(1));
                                    }
                                }
                            }
                        }
                    }

                    //_messageBroker ??= DependencyInjection.Container.Resolve<IMessageBroker>();

                    //await _messageBroker.PostAsync(new NfcTagDiscovered(uid, ndef));
                }
            }
        }


        /// <summary>
        /// Converts Byte Array to Hex String
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        private static string ByteArrayToHexString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba) hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}