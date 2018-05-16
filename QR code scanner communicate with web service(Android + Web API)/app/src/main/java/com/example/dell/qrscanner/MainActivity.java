package com.example.dell.qrscanner;

import android.app.Activity;
import android.content.ActivityNotFoundException;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.StrictMode;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;


import com.google.zxing.Result;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

import org.apache.http.client.HttpClient;
import org.apache.http.client.ResponseHandler;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.BasicResponseHandler;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.lang.reflect.Type;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.Proxy;
import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;


public class MainActivity extends AppCompatActivity {
    EditText txtcontent;
    Button btnscan, btnClear, btnSearch;
    ArrayList<HashMap<String,String>> items;
    Item item;
    EditText txtRtype, txtDescription, txtAinfo;
    String test;
    String resourctype;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btnscan = (Button) findViewById(R.id.scanner);
        txtcontent = (EditText) findViewById(R.id.txtcontent);
        btnClear = (Button) findViewById(R.id.btnClear);
        txtRtype = (EditText) findViewById(R.id.txtRtype);
        txtDescription = (EditText) findViewById(R.id.txtRdescription);
        txtAinfo = (EditText) findViewById(R.id.txtAinfo);
        btnSearch= (Button) findViewById(R.id.btnSearch);
        btnSearch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String id=txtcontent.getText().toString();
                new  MyAsyncTask().execute("http://192.168.8.102:8080/api/item/"+id);

            }
        });

        final Activity acticity = this;

        if (Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);

        }
        btnscan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                IntentIntegrator integrator = new IntentIntegrator(acticity);
                integrator.setDesiredBarcodeFormats(IntentIntegrator.QR_CODE_TYPES);
                integrator.setPrompt("scan");
                integrator.setCameraId(0);
                integrator.setBeepEnabled(false);
                integrator.setBarcodeImageEnabled(false);
                integrator.initiateScan();
            }
        });
        btnClear.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                txtcontent.setText("");
                txtcontent.setHint("Content");
                txtRtype.setText("");
                txtRtype.setHint("Resource type");
                txtDescription.setText("");
                txtDescription.setHint("Resource description");
                txtAinfo.setText("");
                txtAinfo.setHint("Additional info");
            }
        });




    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        IntentResult result = IntentIntegrator.parseActivityResult(requestCode, resultCode, data);
        if (result != null) {
            if (result.getContents() == null) {
                Toast.makeText(this, "You cancelled the scanning", Toast.LENGTH_LONG).show();
            } else {
                txtcontent.setText(result.getContents());
            }
        } else {
            super.onActivityResult(requestCode, resultCode, data);
        }
    }

    @Override
    protected void onResume() {
        super.onResume();

    }
    class MyAsyncTask extends AsyncTask<String,Void,String>{
        String status=null;

        @Override
        protected void onPreExecute() {

        }

        @Override
        protected String doInBackground(String... conUrl) {
            HttpURLConnection conn=null;
            BufferedReader reader;

            try {
                final URL url=new URL(conUrl[0]);
                conn= (HttpURLConnection) url.openConnection();
                conn.addRequestProperty("Content-Type","application/json; charset=utf-8");
                conn.setRequestMethod("GET");
                int result=conn.getResponseCode();
                if(result==200){
                    InputStream in=new BufferedInputStream(conn.getInputStream());
                    reader=new BufferedReader(new InputStreamReader(in));
                    StringBuilder sb=new StringBuilder();
                    String line=null;

                    while((line=reader.readLine())!=null){
                        status=line;

                    }
                   // onPostExecute(status);
                }
            } catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }


            return status;
        }



        @Override
        protected void onPostExecute(String result) {
            test=result;
            super.onPostExecute(result);
            if(result!=null){
                try{
                    JSONObject object=new JSONObject(result);
                    resourctype=object.getString("ResourceType");
                    String resourcdescription=object.getString("ResourceDescription");
                    String additionalinfo=object.getString("AdditionalInfo");
                    item=new Item(resourctype,resourcdescription,additionalinfo);


                    txtRtype.setText(resourctype);
                    txtDescription.setText(item.getDescription());
                    txtAinfo.setText(item.getAdditionalinfo());
                }catch (Exception e){


                }

            }else {
                Toast.makeText(MainActivity.this,"could not get any data",Toast.LENGTH_LONG).show();
            }
        }
    }



}
