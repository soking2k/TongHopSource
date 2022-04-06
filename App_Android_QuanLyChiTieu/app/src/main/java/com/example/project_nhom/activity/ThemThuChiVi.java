package com.example.project_nhom.activity;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.DatePicker;
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
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

public class ThemThuChiVi extends AppCompatActivity {

    private AppViewModel appViewModel;

    private EditText edtname;
    private EditText edtmoney;
    private EditText edtnamechi;
    private EditText edtmoneychi;
    private EditText edtloai;
    private TextView txtconlai;
    private TextView edtngay;
    private Button btn1;
    private Button btn2;
    private Button btn3;
    private Button btn4;
    private Button btn5;
    private Button btn6;
    private Date date;
    private Button btnUpdateViTien;
    private int thuchi;
    private ViTien svitien;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_themchi_vi);

        edtname = findViewById(R.id.edt_name);
        edtmoney = findViewById(R.id.edt_money);
        edtnamechi = findViewById(R.id.edt_name_chi);
        edtmoneychi = findViewById(R.id.edt_money_chi);
        edtngay = findViewById(R.id.edt_ngay);
        txtconlai = findViewById(R.id.txtconlai);
        edtloai = findViewById(R.id.edt_loai);
        btn1 = findViewById(R.id.btn1);
        btn2 = findViewById(R.id.btn2);
        btn3 = findViewById(R.id.btn3);
        btn4 = findViewById(R.id.btn4);
        btn5 = findViewById(R.id.btn5);
        btn6 = findViewById(R.id.btn6);
        appViewModel = new ViewModelProvider(this).get(AppViewModel.class);


        btnUpdateViTien = findViewById(R.id.btn_Update);
        edtmoneychi.addTextChangedListener(onTextChangedListener());
       // edtmoney.addTextChangedListener(onTextChangedListener());

        svitien = (ViTien) getIntent().getExtras().get("object_vitien");
        if(svitien != null){
            edtname.setText(svitien.getName());
            edtmoney.setText(svitien.getMoney());
            edtmoney.setText(numberFormat(svitien.getMoney()));
           // edtmoneychi.setText(null);
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


        edtngay.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

            }
        });

        SetLoai();

        btnUpdateViTien.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                addChiTieu();

            }
        });
    }
    private void chonNgay(final EditText chonNgay){
        final Calendar calendar = Calendar.getInstance();
        int ngay = calendar.get(Calendar.DATE);
        int thang = calendar.get(Calendar.MONTH);
        int nam = calendar.get(Calendar.YEAR);
        DatePickerDialog datePickerDialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                calendar.set(year,month,dayOfMonth);
                SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");
                chonNgay.setText(simpleDateFormat.format(calendar.getTime()));
            }
        },nam,thang,ngay);
        datePickerDialog.show();
    }
    private void addChiTieu(){
        String strName = edtnamechi.getText().toString().trim();
        String strLoai = edtloai.getText().toString().trim();
        String strMoney = edtmoneychi.getText().toString().replace(",", "").trim();
        String strNgay = edtngay.getText().toString().trim();

    /// COnvert string to time https://stackoverflow.com/questions/8573250/android-how-can-i-convert-string-to-date
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");
        try {
            Date date1 = simpleDateFormat.parse(strNgay);
       //     System.out.println(date);
        } catch (ParseException e) {
            e.printStackTrace();
        }

        if(TextUtils.isEmpty(strName) || TextUtils.isEmpty(strMoney)){
            return;
        }
        //  date = new Date(2021, 12, 12);
        Calendar cc = Calendar.getInstance();
        int year = cc.get(Calendar.YEAR);
        int month = cc.get(Calendar.MONTH);
        int mDay = cc.get(Calendar.DAY_OF_MONTH);

        date = new Date(year, month, mDay);


        ChiTieu chiTieu = new ChiTieu(strLoai,strName, strMoney,2,1,date);

        AppDatabase.getInstance(this).ChiTieuDAO().InserChiTieu(chiTieu);
        Toast.makeText(this,"Thêm Thành Công",Toast.LENGTH_SHORT).show();



        // Xử Lý + - Ví
        String strNameVi = edtname.getText().toString().trim();
        String strMoneyVi = edtmoney.getText().toString().replace(",", "").trim();

        if(TextUtils.isEmpty(strNameVi) || TextUtils.isEmpty(strMoneyVi)){
            return;
        }

        svitien.setName(strNameVi);
        svitien.setMoney(String.valueOf(Long.parseLong(svitien.getMoney()) - Long.parseLong(strMoney)));

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
                edtmoneychi.removeTextChangedListener(this);
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
                    edtmoneychi.setText(formattedString);
                    edtmoneychi.setSelection(edtmoneychi.getText().length());


                    //Cập nhật thông tin số tiền còn lại
                    String sotienconlai;
                    Character dauThuChi;
                        sotienconlai = numberFormat(String.valueOf(Long.parseLong(svitien.getMoney()) - Long.parseLong(formattedString.replace(",", ""))));
                    txtconlai.setText( "" + formattedString + " = " + sotienconlai  );

                } catch (NumberFormatException nfe) {
                    nfe.printStackTrace();
                }
                edtmoneychi.addTextChangedListener(this);
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