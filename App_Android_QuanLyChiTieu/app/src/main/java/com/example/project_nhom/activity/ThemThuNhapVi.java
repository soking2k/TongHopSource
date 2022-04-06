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
import androidx.lifecycle.ViewModelProvider;

import com.example.project_nhom.Database.AppDatabase;
import com.example.project_nhom.Database.AppViewModel;
import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.Model.ViTien;
import com.example.project_nhom.R;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

public class ThemThuNhapVi extends AppCompatActivity {

    private AppViewModel appViewModel;

    private EditText edtname;
    private EditText edtmoney;
    private EditText edtnamethu;
    private EditText edtmoneythu;
    private EditText edtngay;
    private EditText edtloai;
    private Date date;
    private TextView txtconlai;

    private Button btnUpdateViTien;
    private int thuchi;
    private ViTien svitien;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_themthu_vi);

        edtname = findViewById(R.id.edt_name);
        edtmoney = findViewById(R.id.edt_money);
        edtnamethu = findViewById(R.id.edt_name_thu);
        edtmoneythu = findViewById(R.id.edt_money_thu);
        edtngay = findViewById(R.id.edt_ngay);
        edtloai = findViewById(R.id.edt_loai);
        txtconlai = findViewById(R.id.txtconlai);

        appViewModel = new ViewModelProvider(this).get(AppViewModel.class);


        btnUpdateViTien = findViewById(R.id.btn_Update);
        edtmoneythu.addTextChangedListener(onTextChangedListener());
      //  edtmoney.addTextChangedListener(onTextChangedListener());

        svitien = (ViTien) getIntent().getExtras().get("object_vitien");
        if(svitien != null){
            edtname.setText(svitien.getName());
            edtmoney.setText(numberFormat(svitien.getMoney()));
            edtmoneythu.setText(null);
            edtname.setEnabled(false);
            edtmoney.setEnabled(false);
            edtngay.setEnabled(false);
        }


        //Ngày date picker
        Calendar cc = Calendar.getInstance();
        int year = cc.get(Calendar.YEAR);
        int month = cc.get(Calendar.MONTH);
        int mDay = cc.get(Calendar.DAY_OF_MONTH);

        date = new Date(year, month, mDay);
        edtngay.setText(mDay + "/" + (month+1) + "/" + year);


        btnUpdateViTien.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                addChiTieu();

            }
        });
    }
    private void addChiTieu(){
        String strName = edtnamethu.getText().toString().trim();
        String strLoai = edtloai.getText().toString().trim();
        String strMoney = edtmoneythu.getText().toString().replace(",", "").trim();


        if(TextUtils.isEmpty(strName) || TextUtils.isEmpty(strMoney)){
            return;
        }
        //  date = new Date(2021, 12, 12);
        Calendar cc = Calendar.getInstance();
        int year = cc.get(Calendar.YEAR);
        int month = cc.get(Calendar.MONTH);
        int mDay = cc.get(Calendar.DAY_OF_MONTH);

        date = new Date(year, month, mDay);


        ChiTieu chiTieu = new ChiTieu(strLoai,strName, strMoney,1,1,date);

        AppDatabase.getInstance(this).ChiTieuDAO().InserChiTieu(chiTieu);
        Toast.makeText(this,"Thêm Thành Công",Toast.LENGTH_SHORT).show();



        // Xử Lý + - Ví
        String strNameVi = edtname.getText().toString().trim();
        String strMoneyVi = edtmoney.getText().toString().replace(",", "").trim();

        if(TextUtils.isEmpty(strNameVi) || TextUtils.isEmpty(strMoneyVi)){
            return;
        }

        svitien.setName(strNameVi);
        svitien.setMoney(String.valueOf(Long.parseLong(svitien.getMoney()) + Long.parseLong(strMoney)));

        AppDatabase.getInstance(this).ViTienDAO().updateViTien(svitien);
        Toast.makeText(this,"Update thanh cong",Toast.LENGTH_SHORT).show();

        Intent intenResult = new Intent();
        setResult(Activity.RESULT_OK,intenResult);
       // finish();
        edtname.setText("");
        edtmoney.setText("");
        hideKeyboard();
        startActivity(new Intent(getApplicationContext(),ChiTieuActivity.class));

    }
    public void hideKeyboard() {
        // Check if no view has focus:
        View view = this.getCurrentFocus();
        if (view != null) {
            InputMethodManager inputManager = (InputMethodManager) this.getSystemService(Context.INPUT_METHOD_SERVICE);
            inputManager.hideSoftInputFromWindow(view.getWindowToken(), InputMethodManager.HIDE_NOT_ALWAYS);
        }
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
                edtmoneythu.removeTextChangedListener(this);
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
                    edtmoneythu.setText(formattedString);
                    edtmoneythu.setSelection(edtmoneythu.getText().length());


                    //Cập nhật thông tin số tiền còn lại
                    String sotienconlai;
                    Character dauThuChi;
                        sotienconlai = numberFormat(String.valueOf(Long.parseLong(svitien.getMoney()) + Long.parseLong(formattedString.replace(",", ""))));
                    txtconlai.setText( "" + formattedString + " = " + sotienconlai  );

                } catch (NumberFormatException nfe) {
                    nfe.printStackTrace();
                }
                edtmoneythu.addTextChangedListener(this);
            }
        };

    }

    public String numberFormat(String string) {
        Long number = Long.parseLong(string);
        DecimalFormat formatter = (DecimalFormat) NumberFormat.getInstance(Locale.US);
        formatter.applyPattern("#,###,###,###");
        String formattedString = formatter.format(number);
        return formattedString;
    }

    private void updateViTien() {
        String strNameVi = edtname.getText().toString().trim();
        String strMoneyVi = edtmoney.getText().toString().replace(",", "").trim();

        if(TextUtils.isEmpty(strNameVi) || TextUtils.isEmpty(strMoneyVi)){
            return;
        }

        svitien.setName(strNameVi);
        svitien.setMoney(strMoneyVi);

       AppDatabase.getInstance(this).ViTienDAO().updateViTien(svitien);
        Toast.makeText(this,"Update thanh cong",Toast.LENGTH_SHORT).show();

        Intent intenResult = new Intent();
        setResult(Activity.RESULT_OK,intenResult);
        finish();
    }
}