using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidX.AppCompat.App;
using Java.IO;

namespace GestioneMenuX.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/menu_logo", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView listView;
        String[] vociListView = new string[] { "Context Uno", "Context Due", "Context Tre" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            listView = (ListView) FindViewById<ListView>(Resource.Id.listView);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, vociListView);
            listView.Adapter = adapter;
            RegisterForContextMenu(listView);

            Button btnPopUp = FindViewById<Button>(Resource.Id.popupButton);
            // setOnClickListener activates a listener
            btnPopUp.Click += (s, arg) =>
            {
                // creating the instance of popupmenu
                PopupMenu popupMenu = new PopupMenu(this, btnPopUp);
                // inflating the popup using xml file
                popupMenu.Inflate(Resource.Menu.popup_menu);
                // registering popup with OnMenuItemClickListener
                popupMenu.MenuItemClick += (s1, arg1) =>
                {
                    Toast.MakeText(this, arg1.Item.TitleFormatted, ToastLength.Long).Show();
                };
                // showing popup menu
                popupMenu.Show();
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        // link the menu to the activity
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // this adds items to the action bar
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        // the system calls the method when the user selects a menu item
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // identifies the item selected by the user
            int id = item.ItemId;
            switch (id)
            {
                case Resource.Id.voce_1:
                    Toast.MakeText(this, "Voce Uno", ToastLength.Long).Show();
                    break;
                case Resource.Id.voce_2:
                    Toast.MakeText(this, "Voce Due", ToastLength.Long).Show();
                    break;
                case Resource.Id.voce_3:
                    Toast.MakeText(this, "Voce Tre", ToastLength.Long).Show();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        // link the menu to the activity
        public override void OnCreateContextMenu(IContextMenu contextMenu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            base.OnCreateContextMenu(contextMenu, v, menuInfo);
            // allows you to inflate the context menu from a menu resource
            MenuInflater.Inflate(Resource.Menu.option_menu, contextMenu);
            contextMenu.SetHeaderTitle("Seleziona l'Azione");
        }

        // the system calls the method when the user selects a menu item
        public override bool OnContextItemSelected(IMenuItem item)
        {
            // identifies the item selected by the user
            int id = item.ItemId;
            switch(id)
            {
                case Resource.Id.context_1:
                    Toast.MakeText(this, "Context Uno", ToastLength.Long).Show();
                    break;
                case Resource.Id.context_2:
                    Toast.MakeText(this, "Context Due", ToastLength.Long).Show();
                    break;
                case Resource.Id.context_3:
                    Toast.MakeText(this, "Context Tre", ToastLength.Long).Show();
                    break;
            }
            return base.OnContextItemSelected(item);
        }
    }
}