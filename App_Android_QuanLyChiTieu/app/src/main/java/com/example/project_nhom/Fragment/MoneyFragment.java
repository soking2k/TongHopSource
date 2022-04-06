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
import com.example.project_nhom.R;
import com.example.project_nhom.activity.ChiTieuActivity;

import java.util.List;

public class MoneyFragment extends Fragment {

    private AppViewModel appViewModel;
    private AppDatabase appDatabase;
    //Ví tiền
    private RecyclerView rvViTien;
    private ChiTieudapter chiTieudapter;
    private LiveData<List<ChiTieu>> ChiTieuLiveData;
    private View view;
    private Button btnViTien;
    private RecyclerView rcChiTieu;
    private ViTienAdapter ViTienAdapter;
    private List<ChiTieu> mListChiTIeu;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_money,container,false);
        //btnViTien = view.findViewById(R.id.btnvitien);
        addDatabase();

        rcChiTieu = view.findViewById(R.id.rvChiTieu);
        loadData();
      //  Intent intent = new Intent(getActivity(), ThemThuNhap.class);
      //  startActivity(intent);
        return view;

    }




    private void loadData()
    {
        rcChiTieu.setLayoutManager(new LinearLayoutManager(getContext()));
        chiTieudapter = new ChiTieudapter(getContext());
        rcChiTieu.setAdapter(chiTieudapter);
        ChiTieuLiveData = appViewModel.tatCaChiTieu();
        ChiTieuLiveData.observe(getViewLifecycleOwner(), new Observer<List<ChiTieu>>() {
            @Override
            public void onChanged(List<ChiTieu> chiTieuList) {
                chiTieudapter.setData(chiTieuList);

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
//                Intent intent = new Intent(getActivity(), ThemThuNhap.class);
              //  startActivity(intent);
            }
        });
    }


}
