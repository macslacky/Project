package com.example.gestionemenu;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.PopupMenu;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    ListView listView;
    String vociListView[] = {"Context Uno", "Context Due", "Context Tre", "Context Quattro", "Context Cinque"};
    Button btnPopUp;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        listView = (ListView)  findViewById(R.id.listView);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, vociListView);
        listView.setAdapter(adapter);

        registerForContextMenu(listView);

        btnPopUp = (Button) findViewById(R.id.button);
        // setOnClickListener activates a listener
        btnPopUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // creating the instance of popupmenu
                PopupMenu popupMenu = new PopupMenu(MainActivity.this, btnPopUp);
                // inflating the popup using xml file
                popupMenu.getMenuInflater().inflate(R.menu.popup_menu, popupMenu.getMenu());
                // registering popup with OnMenuItemClickListener
                popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener() {
                    @Override
                    public boolean onMenuItemClick(MenuItem menuItem) {
                        Toast.makeText(MainActivity.this, menuItem.getTitle(), Toast.LENGTH_LONG).show();
                        return false;
                    }
                });
                // showing popup menu
                popupMenu.show();
            }
        });
    }

    // link the menu to the activity
    public  boolean onCreateOptionsMenu(Menu menu) {
        // this adds items to the action bar
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return true;
    }

    // link the menu to the activity
    public void onCreateContextMenu(ContextMenu contextMenu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(contextMenu, v, menuInfo);
        // allows you to inflate the context menu from a menu resource
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.option_menu, contextMenu);
        contextMenu.setHeaderTitle("Select The Action");
    }
    // the system calls the method when the user selects a menu item
    public boolean onOptionsItemSelected(MenuItem item) {
        // identifies the item selected by the user
        int id = item.getItemId();

        switch (id) {
            case R.id.voce_1:
                Toast.makeText(getApplicationContext(), "Main Uno", Toast.LENGTH_LONG).show();
                break;
            case R.id.voce_2:
                Toast.makeText(getApplicationContext(), "Main Due", Toast.LENGTH_LONG).show();
                break;
            case R.id.voce_3:
                Toast.makeText(getApplicationContext(), "Main Tre", Toast.LENGTH_LONG).show();
                break;
        }
        return false;
    }

    // the system calls the method when the user selects a menu item
    public boolean onContextItemSelected(MenuItem item) {
        // identifies the item selected by the user
        int id = item.getItemId();

        switch (id) {
            case R.id.context_1:
                Toast.makeText(getApplicationContext(), "Context Uno", Toast.LENGTH_LONG).show();
                break;
            case R.id.context_2:
                Toast.makeText(getApplicationContext(), "Context Due", Toast.LENGTH_LONG).show();
                break;
            case R.id.context_3:
                Toast.makeText(getApplicationContext(), "Context Tre", Toast.LENGTH_LONG).show();
                break;
        }
        return false;
    }
}