package info.ribosoft.splashscreen;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class SplashScreen extends AppCompatActivity {
    int SPLAH_TIME_OUT = 3000;

    @Override
    // create the first activity
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash_screen);
        /* create a new handler to the message queue
           to be run after the specified ammount of time elapses */
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                // start a new activity
                startActivity(new Intent(SplashScreen.this, MainActivity.class));
                finish();
            }
        }, SPLAH_TIME_OUT);
    }
}