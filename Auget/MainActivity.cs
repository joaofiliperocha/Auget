using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android;
using Android.Content.PM;
using System.Text;
using Java.Util;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Guardiola.Android;

namespace Auget
{
    [Activity(Label = "Auget", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        private const int RequestCameraPremissionID = 1001;
        private TextureView cameraView;
        private ACamera aCamera;
        private Button changeContrast;
        private Button changeZoom;

        private Handler handler;


    

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            cameraView = FindViewById<TextureView>(Resource.Id.Texture_View);
            changeContrast = FindViewById<Button>(Resource.Id.changeContrast);
            changeZoom = FindViewById<Button>(Resource.Id.changeZoom);
            handler = new Handler();

            changeContrast.Click += ChangeContrast_Click;
            changeZoom.Click += ChangeZoom_Click;

            aCamera = new ACamera(this, Android.Hardware.Camera2.LensFacing.Back, handler, cameraView);
           
        }

        private void ChangeZoom_Click(object sender, EventArgs e)
        {
            aCamera.Zoom +=10;
        }

        private void ChangeContrast_Click(object sender, EventArgs e)
        {
            aCamera.NextEffect();
        }
    }
}

