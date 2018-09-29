using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;

namespace SampleListApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ListView lvNames;
        private TextView tvMyList;
        private EditText etSearch;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            lvNames = FindViewById<ListView>(Resource.Id.listView1);
            tvMyList = FindViewById<TextView>(Resource.Id.tvMyList);
            etSearch = FindViewById<EditText>(Resource.Id.etSearch);
            tvMyList.Click += TvMyList_Click;
            etSearch.TextChanged += EtSearch_TextChanged;
            UpdateList();
        }

        private void EtSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<string> lstSearch = new List<string>();
            if (!string.IsNullOrEmpty(etSearch.Text))
            {
                foreach (var item in MyListt.MyList)
                {
                    if (item.StartsWith(etSearch.Text))
                    {
                        lstSearch.Add(item);
                    }
                }
                ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, lstSearch);
                lvNames.Adapter = adapter;
            }
            else
            {
                UpdateList();
            }

        }

        private void TvMyList_Click(object sender, System.EventArgs e)
        {
            UpdateList();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MyMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.add)
            {
                StartActivity(typeof(AddPageActivity));
            }
            return base.OnOptionsItemSelected(item);
        }
        private void UpdateList()
        {
            //List<string> sampleList = new List<string>()
            //{
            //    "ali", "hesam","hootan"
            //};
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, MyListt.MyList);
            lvNames.Adapter = adapter;
        }
        protected override void OnResume()
        {
            UpdateList();
            base.OnResume();
        }
    }
}