package com.example.project_nhom.Database;

import android.app.Application;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;

import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.Model.ViTien;

import org.jetbrains.annotations.NotNull;

import java.util.List;

public class AppViewModel extends AndroidViewModel {
    private AppRepository repository;
    private AppDatabase appDatabase;


    //Vi Tiền
    private ViTien viTien;
    private List<ViTien> xuatViTien;
    private LiveData<List<ViTien>> tatCaViTien;

    //Chi Tiêu
    private ChiTieu chiTieu;
    private List<ChiTieu> xuatChiTieu;
    private LiveData<List<ChiTieu>> tatCaChiTieu;


    public AppViewModel(@NonNull @NotNull Application application) {
        super(application);
        repository = new AppRepository(application);


        //Ví Tiền
        xuatViTien = repository.xuatViTien();
        tatCaViTien = repository.xuatViTienLive();

        //Chi Tiêu
        xuatChiTieu = repository.xuatChiTieu();
        tatCaChiTieu = repository.xuatChiTieuLive();

    }
    // Ví Tiền
    public List<ViTien> xuatViTien() {
        return xuatViTien;
    }
    public LiveData<List<ViTien>> tatCaViTien() {
        return tatCaViTien;
    }

    // Chi Tiêu
    public List<ChiTieu> xuatChiTieu() {
        return xuatChiTieu;
    }
    public LiveData<List<ChiTieu>> tatCaChiTieu() {
        return tatCaChiTieu;
    }



}