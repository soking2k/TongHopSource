package com.example.project_nhom.Fragment;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

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
import com.example.project_nhom.Database.AppDatabase;
import com.example.project_nhom.Database.AppViewModel;
import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.Model.ViTien;
import com.example.project_nhom.R;
import com.example.project_nhom.activity.ChiTieuActivity;
import com.example.project_nhom.activity.ViTienActivity;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

public class HomeFragment extends Fragment {

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

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_home,container,false);
        //btnViTien = view.findViewById(R.id.btnvitien);
        addDatabase();

        rcvViTien = view.findViewById(R.id.rvViTien);
        rcvThuNhap = view.findViewById(R.id.rvThuNhap);

        loadData();
  ;
        //buttonViTien();



        return view;

    }




    private void loadData()
    {
        rcvViTien.setLayoutManager(new LinearLayoutManager(getContext()));
        viTienAdapter = new ViTienAdapter(getContext());
        rcvViTien.setAdapter(viTienAdapter);
        viTienLiveData = appViewModel.tatCaViTien();
        viTienLiveData.observe(getViewLifecycleOwner(), new Observer<List<ViTien>>() {
            @Override
            public void onChanged(List<ViTien> viTienList) {
                viTienAdapter.setData(viTienList);
                

            }
        });
        viTienAdapter.setOnItemClickListener(new ViTienAdapter.OnItemClickListener() {
            @Override
            public void onItemClick(ViTien viTien) {
                startActivity(new Intent(getActivity(), ViTienActivity.class));
            }
        });
        // Thu Nhập
        Calendar calendar = Calendar.getInstance();
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int day = calendar.get(Calendar.DAY_OF_MONTH);
        date = new Date(year, month, day);
        rcvThuNhap.setLayoutManager(new LinearLayoutManager(getContext()));
        chiTieudapter = new ChiTieudapter(getContext());
        rcvThuNhap.setAdapter(chiTieudapter);
        ThuNhapLiveData = appViewModel.tatCaChiTieu();
        ThuNhapLiveData.observe(getViewLifecycleOwner(), new Observer<List<ChiTieu>>() {
            @Override
            public void onChanged(List<ChiTieu> chiTieuList) {
                List<ChiTieu> chiTieuHomNay = new ArrayList<>();
                for (int i = 0; i < chiTieuList.size(); i++) {
                    ChiTieu chiTieu = chiTieuList.get(i);
                    if (chiTieu.getDate().equals(date)){
                        chiTieuHomNay.add(chiTieu);
                    }
                }
                chiTieudapter.setData(chiTieuHomNay);

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
