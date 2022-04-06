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
import com.example.project_nhom.Model.ViTien;
import com.example.project_nhom.R;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Locale;

public class UpdateViTien extends AppCompatActivity {
    private EditText edtname;
    private EditText edtmoney;
    private Button btnUpdateViTien;

    private ViTien svitien;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_vi_tien);

        edtname = findViewById(R.id.edt_name);
        edtmoney = findViewById(R.id.edt_money);
        btnUpdateViTien = findViewById(R.id.btn_Update);
        edtmoney.addTextChangedListener(onTextChangedListener());

        svitien = (ViTien) getIntent().getExtras().get("object_vitien");
        if(svitien != null){
            edtname.setText(svitien.getName());
            edtmoney.setText(svitien.getMoney());
        }
        btnUpdateViTien.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                updateViTien();
            }


        });
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
    private void updateViTien() {
        String strName = edtname.getText().toString().trim();
        String strMoney = edtmoney.getText().toString().replace(",", "").trim();

        if(TextUtils.isEmpty(strName) || TextUtils.isEmpty(strMoney)){
            return;
        }

        svitien.setName(strName);
        svitien.setMoney(strMoney);

       AppDatabase.getInstance(this).ViTienDAO().updateViTien(svitien);
        Toast.makeText(this,"Update thanh cong",Toast.LENGTH_SHORT).show();

        Intent intenResult = new Intent();
        setResult(Activity.RESULT_OK,intenResult);
        finish();
    }
}