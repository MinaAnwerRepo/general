//-----------------------------------in main  activity ----------------------------------------------------------------- 
   ImageView myimgview;
        public static readonly int PickImageId = 1000;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
             myimgview = FindViewById<ImageView>(Resource.Id.imgview1);
            Button btnImg = FindViewById < Button>(Resource.Id.btnPic);
            btnImg.Click += BtnImg_Click;

        }
        private void BtnImg_Click(object sender, System.EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                myimgview.SetImageURI(data.Data);
            }
        }	
//--------------------------------------------------------------------------------------------------------------------------		