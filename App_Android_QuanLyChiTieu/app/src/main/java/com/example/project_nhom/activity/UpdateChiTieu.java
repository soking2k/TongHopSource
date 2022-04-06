package com.example.project_nhom.activity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.project_nhom.Database.AppDatabase;
import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.R;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Locale;

public class UpdateChiTieu extends AppCompatActivity {
    private EditText edtname;
    private EditText edtloai;
    private EditText edtmoney;
    private Button btnUpdateChiTieu;
    private Button btn1;
    private Button btn2;
    private Button btn3;
    private Button btn4;
    private Button btn5;
    private Button btn6;

    private ChiTieu schitieu;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_chi_tieu);

        InitUI();
        edtmoney.addTextChangedListener(onTextChangedListener());
        SetLoai();
        schitieu = (ChiTieu) getIntent().getExtras().get("object_chitieu");
        if(schitieu != null){
            edtname.setText(schitieu.getName());
            edtloai.setText(schitieu.getLoai());
            edtmoney.setText(schitieu.getMoney());
        }
        btnUpdateChiTieu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                UpdateChiTieu();
            }


        });
    }
    private void InitUI()
    {
        edtname = findViewById(R.id.edt_name);
        edtloai = findViewById(R.id.edt_loai);
        edtmoney = findViewById(R.id.edt_money);
        btnUpdateChiTieu = findViewById(R.id.btn_Update);
        btn1 = findViewById(R.id.btn1);
        btn2 = findViewById(R.id.btn2);
        btn3 = findViewById(R.id.btn3);
        btn4 = findViewById(R.id.btn4);
        btn5 = findViewById(R.id.btn5);
        btn6 = findViewById(R.id.btn6);
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
    private void SetLoai() {
        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                edtloai.setText("Chi Tiêu Cần Thiết");

            }
        });
        btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                edtloai.setText("Tiết Kiệm Dài Hạn" );

            }
        });
        btn3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                edtloai.setText("Quỹ Giáo Dục");

            }
        });
        btn4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                edtloai.setText("Hưởng Thụ");

            }
        });
        btn5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                edtloai.setText("Quỹ Tự Do Tài Chính");

            }
        });
        btn6.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                edtloai.setText("Quỹ Từ Thiện");

            }
        });
    }
    private void UpdateChiTieu() {
        String strName = edtname.getText().toString().trim();
        String strLoai = edtloai.getText().toString().trim();
        String strMoney = edtmoney.getText().toString().replace(",", "").trim();

        if(TextUtils.isEmpty(strName) || TextUtils.isEmpty(strMoney)){
            return;
        }

        schitieu.setName(strName);
        schitieu.setLoai(strLoai);
        schitieu.setMoney(strMoney);

       AppDatabase.getInstance(this).ChiTieuDAO().updateChiTieu(schitieu);
        Toast.makeText(this,"Update thanh cong",Toast.LENGTH_SHORT).show();

        Intent intenResult = new Intent();
        setResult(Activity.RESULT_OK,intenResult);
        finish();
    }
}