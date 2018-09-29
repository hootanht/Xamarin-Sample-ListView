using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleListApp
{
    [Activity(Label = "AddPageActivity")]
    public class AddPageActivity : Activity
    {
        private EditText etNames;
        private Button btnSave;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.add_page);
            etNames = FindViewById<EditText>(Resource.Id.etName);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MyListt.MyList.Contains(etNames.Text))
            {
                Toast.MakeText(this, "Data Founded", ToastLength.Long).Show();
            }
            else
            {
                MyListt.MyList.Add(etNames.Text);
                Finish();
            }
        }
    }
}