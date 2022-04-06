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

import com.example.project_nhom.Adapter.ViTienAdapter;
import com.example.project_nhom.Database.AppDatabase;
import com.example.project_nhom.Model.ViTien;
import com.example.project_nhom.R;

import org.jetbrains.annotations.NotNull;

import java.util.ArrayList;
import java.util.List;

public class ViTienActivity extends AppCompatActivity {

    private static final int MY_REQUEST_CODE = 10;
    private EditText edtname;
    private EditText edtmoney;
    private Button btnAddViTien;
    private RecyclerView rcvViTien;
    private TextView tvDeleteAll;
    private Button btnback;

    private ViTienAdapter ViTienAdapter;
    private List<ViTien> mListViTien;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_vitien);

        InitUI();
        ViTienAdapter = new ViTienAdapter(new ViTienAdapter.IClickItemViTien() {
            @Override
            public void UpdateViTien(ViTien viTien) {
                clickupdatevitien(viTien);
            }

            @Override
            public void DeleteViTien(ViTien vitien) {
                clickDeleteViTien(vitien);
            }
        });

        mListViTien = new ArrayList<>();
        ViTienAdapter.setData(mListViTien);

        LinearLayoutManager LinearLayoutManager = new LinearLayoutManager(this);
        rcvViTien.setLayoutManager(LinearLayoutManager);
        rcvViTien.setAdapter(ViTienAdapter);

/*        tvDeleteAll.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clickDeleteAllViTien();
            }
        });*/
        buttonViTien();
        buttonback();
        hideKeyboard();
        loadData();

    }
    private void buttonViTien() {
        btnAddViTien.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(),ThemViTien.class));

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
        btnAddViTien = findViewById(R.id.btn_add);
        btnback = findViewById(R.id.btn_back);

        rcvViTien = findViewById(R.id.rcv_vitien);
        //tvDeleteAll = findViewById(R.id.tv_delete_all);


    }

    private void addViTien(){
        startActivity(new Intent(getApplicationContext(),ThemViTien.class));

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
        mListViTien = AppDatabase.getInstance(this).ViTienDAO().getListViTien();

        ViTienAdapter.setData(mListViTien);
    }
    private boolean isVitTienExits(@NotNull ViTien viTien){
        List<ViTien> list = AppDatabase.getInstance(this).ViTienDAO().checkVi(viTien.getName());
        return list != null && !list.isEmpty();
    }
    private void clickupdatevitien(ViTien viTien)
    {
        Intent intent = new Intent(ViTienActivity.this,UpdateViTien.class);
        Bundle bundle = new Bundle();
        bundle.putSerializable("object_vitien",viTien);
        intent.putExtras(bundle);
        startActivityForResult(intent,MY_REQUEST_CODE);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(requestCode == MY_REQUEST_CODE && resultCode == Activity.RESULT_OK){
            loadData();
        }
    }
    private void clickDeleteViTien(final ViTien viTien)
    {
        new AlertDialog.Builder(this)
                .setTitle("Xac Nhan Xoa Vi")
                .setMessage("Ban chac chan muon xoa vi")
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        AppDatabase.getInstance(ViTienActivity.this).ViTienDAO().deleteViTien(viTien);
                        Toast.makeText(ViTienActivity.this,"Xoa Vi Tien Thanh Cong",Toast.LENGTH_SHORT).show();
                        loadData();
                    }
                })
                .setNegativeButton("No",null)
                .show();
    }
    private void clickDeleteAllViTien()
    {
        new AlertDialog.Builder(this)
                .setTitle("Xac Nhan Xoa Toan Bo Vi")
                .setMessage("Ban chac chan muon xoa toan bo vi")
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        AppDatabase.getInstance(ViTienActivity.this).ViTienDAO().deleteAllViTien();
                        Toast.makeText(ViTienActivity.this,"Xoa Toan Bo Vi Tien Thanh Cong",Toast.LENGTH_SHORT).show();
                        loadData();
                    }
                })
                .setNegativeButton("No",null)
                .show();
    }
}