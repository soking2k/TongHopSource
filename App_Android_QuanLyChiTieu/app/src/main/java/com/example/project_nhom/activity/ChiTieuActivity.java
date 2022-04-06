package com.example.project_nhom.activity;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.project_nhom.Adapter.ChiTieudapter;
import com.example.project_nhom.Database.AppDatabase;
import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.R;

import java.util.ArrayList;
import java.util.List;

public class ChiTieuActivity extends AppCompatActivity {

    private static final int MY_REQUEST_CODEZ = 11;
    private EditText edtname;
    private EditText edtmoney;
    private Button btnAddChiTieu;
    private Button btnAddThuNhap;
    private RecyclerView rcvChiTieu;
    private TextView tvDeleteAll;
    private Button btnback;
  //  private ThemChiTieu themChiTieu;

    private ChiTieudapter ChiTieudapter;
    private List<ChiTieu> mListChiTieu;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chitien);

        InitUI();
        ChiTieudapter = new ChiTieudapter(new ChiTieudapter.IClickItemChiTieu() {
            @Override
            public void UpdateChiTieu(ChiTieu chiTieu) {
                clickupdatechitieu(chiTieu);

            }

            @Override
            public void DeleteChiTieu(ChiTieu chiTieu) {
                clickDeleteChiTieu(chiTieu);
            }
        });
        mListChiTieu = new ArrayList<>();
        ChiTieudapter.setData(mListChiTieu);

        LinearLayoutManager LinearLayoutManager = new LinearLayoutManager(this);
        rcvChiTieu.setLayoutManager(LinearLayoutManager);
        rcvChiTieu.setAdapter(ChiTieudapter);


        buttonChiTieu();
        buttonback();
        hideKeyboard();
        loadData();

    }
    private void buttonChiTieu() {
        btnAddChiTieu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(),ThuChiActivity.class));


            }
        });

    }
    private void buttonback() {
        btnback.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(),MainActivity.class));

            }
        });
    }
    private void InitUI(){
        edtname = findViewById(R.id.edt_name);
        edtmoney =   findViewById(R.id.edt_money);
        btnAddChiTieu = findViewById(R.id.btn_add);
        btnback = findViewById(R.id.btn_back);
        rcvChiTieu = findViewById(R.id.rcv_chitien);
        //tvDeleteAll = findViewById(R.id.tv_delete_all);


    }


    public void hideKeyboard() {
        // Check if no view has focus:
        View view = this.getCurrentFocus();
        if (view != null) {
            InputMethodManager inputManager = (InputMethodManager) this.getSystemService(Context.INPUT_METHOD_SERVICE);
            inputManager.hideSoftInputFromWindow(view.getWindowToken(), InputMethodManager.HIDE_NOT_ALWAYS);
        }
    }
    private void loadData()
    {
        mListChiTieu = AppDatabase.getInstance(this).ChiTieuDAO().getListChiTieu();
        ChiTieudapter.setData(mListChiTieu);
    }

    private void clickupdatechitieu(ChiTieu chiTieu)
    {
        Intent intent = new Intent(ChiTieuActivity.this,UpdateChiTieu.class);
        Bundle bundle = new Bundle();
        bundle.putSerializable("object_chitieu",chiTieu);
        intent.putExtras(bundle);
        startActivityForResult(intent,MY_REQUEST_CODEZ);
    }


    private void clickDeleteChiTieu(final ChiTieu chiTieu)
    {
        new AlertDialog.Builder(this)
                .setTitle("Xac Nhan Xoa")
                .setMessage("Ban chac chan muon xoa")
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        AppDatabase.getInstance(ChiTieuActivity.this).ChiTieuDAO().deleteChiTieu(chiTieu);
                        Toast.makeText(ChiTieuActivity.this,"Da Xoa Thanh Cong",Toast.LENGTH_SHORT).show();
                        loadData();
                    }
                })
                .setNegativeButton("No",null)
                .show();
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(requestCode == MY_REQUEST_CODEZ && resultCode == Activity.RESULT_OK){
            loadData();
        }
    }

}