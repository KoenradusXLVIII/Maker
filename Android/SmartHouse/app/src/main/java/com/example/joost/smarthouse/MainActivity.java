package com.example.joost.smarthouse;

import android.app.Activity;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.TextView;
import android.widget.ToggleButton;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

public class MainActivity extends AppCompatActivity {

    private ToggleButton button_light_gardenhouse;
    private ToggleButton button_water_gardenhouse;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //attach a listener to the light button
        button_light_gardenhouse = (ToggleButton) findViewById(R.id.lightButton);
        button_light_gardenhouse.setOnCheckedChangeListener(new OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                String site;
                if (isChecked) {
                    site = "http://192.168.1.112/light_mode/auto";
                } else {
                    site = "http://192.168.1.112/light_mode/manual";
                }

                GetRESTTask REST = new GetRESTTask();
                REST.execute(site);
            }
        });

        //attach a listener to the water button
        button_water_gardenhouse = (ToggleButton) findViewById(R.id.waterButton);
        button_water_gardenhouse.setOnCheckedChangeListener(new OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                String site;
                if (isChecked) {
                    site = "http://192.168.1.112/water_mode/auto";
                } else {
                    site = "http://192.168.1.112/water_mode/manual";
                }

                GetRESTTask REST = new GetRESTTask();
                REST.execute(site);
            }
        });
    }

    private class GetRESTTask extends AsyncTask<String, Void, String> {
        @Override
        protected String doInBackground(String... urls) {
            // Initialize variables
            HttpURLConnection urlConnection = null;
            URL url = null;

            // Parse URL
            try {
                url = new URL(urls[0]);
            } catch (MalformedURLException e) {
                Log.e("SmartHouse", "MalformedURLException", e);
            }

            // If URL parses correctly open connection
            try {
                urlConnection = (HttpURLConnection) url.openConnection();
            } catch (IOException e) {
                Log.e("SmartHouse", "IOException", e);
            }
            
            String HTTPResponse = null;
            try {
                HTTPResponse = urlConnection.getResponseMessage();
                Log.d("SmartHouse", HTTPResponse);
            } catch (IOException e) {
                Log.e("SmartHouse", "IOException", e);
            }

            urlConnection.disconnect();
            return HTTPResponse;
        }
    }
}

