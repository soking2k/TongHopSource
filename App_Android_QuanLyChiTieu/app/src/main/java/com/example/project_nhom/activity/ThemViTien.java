package com.example.project_nhom.activity;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import com.example.project_nhom.Database.AppDatabase;
import com.example.project_nhom.Model.ViTien;
import com.example.project_nhom.R;

import org.jetbrains.annotations.NotNull;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.List;
import java.util.Locale;

public class ThemViTien extends AppCompatActivity {
    private EditText edtname;
    private EditText edtmoney;
    private Button btnAddViTien;
    private RecyclerView rcvViTien;
    private TextView tvDeleteAll;

    private List<ViTien> mListViTien;
    private ViTien svitien;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.acitivity_themvi);

        InitUI();
        edtmoney.addTextChangedListener(onTextChangedListener());
        btnAddViTien.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                addViTien();

            }
        });

    }
    private void loadData()
    {
        mListViTien = AppDatabase.getInstance(this).ViTienDAO().getListViTien();
    }
    private void addViTien(){
        String strName = edtname.getText().toString().trim();
        String strMoney = edtmoney.getText().toString().replace(",", "").trim();

        if(TextUtils.isEmpty(strName) || TextUtils.isEmpty(strMoney)){
            return;
        }
        ViTien vitien = new ViTien("x",strName, strMoney);
        if(isVitTienExits(vitien)){
            Toast.makeText(this,"Ví đã tồn tại",Toast.LENGTH_SHORT).show();
            return;
        }
        AppDatabase.getInstance(this).ViTienDAO().insertViTien(vitien);
        Toast.makeText(this,"Thêm Thành Công",Toast.LENGTH_SHORT).show();

        edtname.setText("");
        edtmoney.setText("");
        hideKeyboard();
        startActivity(new Intent(getApplicationContext(),ViTienActivity.class));

    }
    private TextWatcher onTextChangedListener() {
        return new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
            }

            @Override
            public void afterTextChanged(Editable s) {
                edtmoney.removeTextChangedListener(this);
                try {
                    String originalString = s.toString();

                    Long longval;
                    if (originalString.contains(",")) {
                        originalString = originalString.replaceAll(",", "");
                    }
                    longval = Long.parseLong(originalString);

                    DecimalFormat formatter = (DecimalFormat) NumberFormat.getInstance(Locale.US);
                    formatter.applyPattern("#,###,###,###");
                    String formattedString = formatter.format(longval);

                    //setting text after format to EditText
                    edtmoney.setText(formattedString);
                    edtmoney.setSelection(edtmoney.getText().length());

                    //Cập nhật thông tin số tiền còn lại

                } catch (NumberFormatException nfe) {
                    nfe.printStackTrace();
                }
                edtmoney.addTextChangedListener(this);
            }
        };
    }

    private void InitUI(){
        edtname = findViewById(R.id.edt_name);
        edtmoney =   findViewById(R.id.edt_money);
        btnAddViTien = findViewById(R.id.btn_add);


    }
    public void hideKeyboard() {
        // Check if no view has focus:
        View view = this.getCurrentFocus();
        if (view != null) {
            InputMethodManager inputManager = (InputMethodManager) this.getSystemService(Context.INPUT_METHOD_SERVICE);
            inputManager.hideSoftInputFromWindow(view.getWindowToken(), InputMethodManager.HIDE_NOT_ALWAYS);
        }
    }
    private boolean isVitTienExits(@NotNull ViTien viTien){
        List<ViTien> list = AppDatabase.getInstance(this).ViTienDAO().checkVi(viTien.getName());
        return list != null && !list.isEmpty();
    }
    private void updateViTien() {
        String strName = edtname.getText().toString().trim();
        String strMoney = edtmoney.getText().toString().trim();

        if(TextUtils.isEmpty(strName) || TextUtils.isEmpty(strMoney)){
            return;
        }

        svitien.setName(strName);
        svitien.setMoney(strMoney);

        //    AppDatabase.getInstance(this).ViTienDAO().updateViTien(svitien);
        Toast.makeText(this,"Update thanh cong",Toast.LENGTH_SHORT).show();

        Intent intenResult = new Intent();
        setResult(Activity.RESULT_OK,intenResult);
        finish();
    }
}