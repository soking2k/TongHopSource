package com.example.project_nhom.Database;

import android.app.Application;

import androidx.lifecycle.LiveData;

import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.Model.ViTien;

import java.util.List;

public class AppRepository {

    //Ví Tiền
    private ViTienDAO viTienDao;
    private List<ViTien> xuatViTien;
    private LiveData<List<ViTien>> xuatViTienLive;

    //Chi Tieu
    private ChiTieuDAO chiTieuDAO;
    private List<ChiTieu> xuatChiTieu;
    private LiveData<List<ChiTieu>> xuatChiTieuLive;


    public AppRepository(Application application) {
        AppDatabase appDatabase = AppDatabase.getInstance(application);


        //Ví Tiền
        viTienDao = appDatabase.ViTienDAO();
        xuatViTien = viTienDao.xuatViTien();
        xuatViTienLive = viTienDao.xuatViTienLive();

        //Chi Tiêun
        chiTieuDAO = appDatabase.ChiTieuDAO();
        xuatChiTieu = chiTieuDAO.xuatChiTieu();
        xuatChiTieuLive = chiTieuDAO.xuatChiTieuLive();

    }
    // Ví Tiền
    public List<ViTien> xuatViTien() {
        return xuatViTien;
    }
    public LiveData<List<ViTien>> xuatViTienLive() {
        return xuatViTienLive;
    }
    // Chi Tiêu
    public List<ChiTieu> xuatChiTieu() {
        return xuatChiTieu;
    }

    public LiveData<List<ChiTieu>> xuatChiTieuLive() {
        return xuatChiTieuLive;
    }


}
