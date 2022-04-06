package com.example.project_nhom.Fragment;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.project_nhom.Adapter.ChiTieudapter;
import com.example.project_nhom.Adapter.ViTienAdapter;
import com.example.project_nhom.Adapter.spAdapter;
import com.example.project_nhom.Database.AppDatabase;
import com.example.project_nhom.Database.AppViewModel;
import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.Model.ThangNam;
import com.example.project_nhom.Model.ViTien;
import com.example.project_nhom.R;
import com.example.project_nhom.activity.ChiTieuActivity;
import com.example.project_nhom.activity.ViTienActivity;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class SettingFragment extends Fragment {

    private AppViewModel appViewModel;
    private AppDatabase appDatabase;
    private ViTienActivity viTienActivity;
    //Ví tiền
    private RecyclerView rvViTien;
    private ViTienAdapter viTienAdapter;
    private LiveData<List<ViTien>> viTienLiveData;
    private View view;
    private Button btnViTien;
    private RecyclerView rcvViTien;
    private RecyclerView rcvThuNhap;
    private List<ViTien> mListViTien;
    private Date date;

    // Thu Nhập
    private ChiTieudapter chiTieudapter;
    private LiveData<List<ChiTieu>> ThuNhapLiveData;
    private List<ViTien> mListThuNhap;

    // Hiệu Thu Chi
    private TextView txtTongThuTrongThang;
    private TextView txtTongChiTrongThang;
    private TextView txtHieuThuChi;
    private long tongThu;
    private long tongChi;
    private List<ChiTieu> chiTieus;

    //Load Thang
    Spinner spThang;
    Spinner spNgay;
    Spinner spNam;
    ArrayList<ThangNam> thangArrayList;
    ArrayList<ThangNam> ngayArrayList;
    ArrayList<ThangNam> NamArrayList;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_setting,container,false);
        //btnViTien = view.findViewById(R.id.btnvitien);
        addDatabase();

        rcvThuNhap = view.findViewById(R.id.rvThuNhap);
        txtTongThuTrongThang = view.findViewById(R.id.txtTongThuTrongThangy);
        txtTongChiTrongThang = view.findViewById(R.id.txtTongChiTrongThang);
        txtHieuThuChi = view.findViewById(R.id.txtHieuThuChi);

        Calendar calendar = Calendar.getInstance();
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int day = calendar.get(Calendar.DAY_OF_MONTH);
        date = new Date(year, month,day);
        // Tháng
        thangArrayList = new ArrayList<>();
        spThang = view.findViewById(R.id.spChonThang);
        thangArrayList.add(new ThangNam(0,"Chọn tháng Để xem Chi Tiết Thống Kê "));
        for (int i = 1; i < 13; i++){
            thangArrayList.add(new ThangNam(i,"Xem Chi Tiết Thống Kê Của Tháng " + i));
        }
        spAdapter adapter = new spAdapter(getContext(), thangArrayList);
        spThang.setAdapter(adapter);




        spThang.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                ThangNam thangNam = thangArrayList.get(i);


                if (thangNam.getId() == 0){

                    loadData(month);
                }else {

                    loadData(i-1);

                }
                //loadData(check[0],check[1],check[2]);

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });





        return view;

    }


    private void xuLyThongKeSoLieuThuChi(int thang) {
        tongChi = 0;
        tongThu = 0;
        Calendar calendar = Calendar.getInstance();
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int day = calendar.get(Calendar.DAY_OF_MONTH);
        date = new Date(year, month,day);
        for (int i = 0; i < chiTieus.size(); i++) {
            ChiTieu chiTieu = chiTieus.get(i);
            if (chiTieu.getThuchi() == 2 && chiTieu.getDate().getMonth() == thang && chiTieu.getDate().getYear() == year) {
                tongChi += Long.parseLong(chiTieu.getMoney());
            } else if (chiTieu.getThuchi() == 1 && chiTieu.getDate().getMonth() == thang && chiTieu.getDate().getYear() == year) {
                tongThu += Long.parseLong(chiTieu.getMoney());
            }
        }
        txtTongChiTrongThang.setText(numberFormat(String.valueOf(tongChi)));
        txtTongThuTrongThang.setText(numberFormat(String.valueOf(tongThu)));
        txtHieuThuChi.setText(numberFormat(String.valueOf(tongThu - tongChi)) + " " + "VND");
    }
    //Định dạng số tiền
    public String numberFormat(String string) {
        Long number = Long.parseLong(string);
        DecimalFormat formatter = (DecimalFormat) NumberFormat.getInstance(Locale.US);
        formatter.applyPattern("#,###,###,###");
        String formattedString = formatter.format(number);
        return formattedString;
    }
    private void loadData(int thang)
    {

        // Thu Nhập
        Calendar calendar = Calendar.getInstance();
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int day = calendar.get(Calendar.DAY_OF_MONTH);
        date = new Date(year, month,day);
        rcvThuNhap.setLayoutManager(new LinearLayoutManager(getContext()));
        chiTieudapter = new ChiTieudapter(getContext());
        rcvThuNhap.setAdapter(chiTieudapter);
        ThuNhapLiveData = appViewModel.tatCaChiTieu();
        ThuNhapLiveData.observe(getViewLifecycleOwner(), new Observer<List<ChiTieu>>() {
            @Override
            public void onChanged(List<ChiTieu> chiTieuList) {
                List<ChiTieu> chiTieuThangNay = new ArrayList<>();
                for (int i = 0; i < chiTieuList.size(); i++) {
                    ChiTieu chiTieu = chiTieuList.get(i);
                    if ( chiTieu.getDate().getMonth() == thang && chiTieu.getDate().getYear() == year){
                        chiTieuThangNay.add(chiTieu);
                    }
                }
                chiTieuList = chiTieuThangNay;
                chiTieudapter.setData(chiTieuList);
                chiTieus = chiTieuList;
                xuLyThongKeSoLieuThuChi(thang);

                //chiTieudapter.setData(chiTieuList);


            }
        });
        chiTieudapter.setOnItemClickListener(new ChiTieudapter.OnItemClickListener() {
            @Override
            public void onItemClick(ChiTieu chiTieu) {
                startActivity(new Intent(getActivity(), ChiTieuActivity.class));
            }
        });
    }
    private void addDatabase() {
        appViewModel = new ViewModelProvider(this).get(AppViewModel.class);
    }


    private void buttonViTien() {
        btnViTien.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getActivity(), ViTienActivity.class);
                startActivity(intent);
            }
        });
    }


}
