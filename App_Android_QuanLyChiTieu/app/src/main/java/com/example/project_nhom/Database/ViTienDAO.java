package com.example.project_nhom.Database;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import com.example.project_nhom.Model.ViTien;

import java.util.List;

@Dao
public interface ViTienDAO {
    @Insert
    void insertViTien(ViTien vitien);

    @Query("SELECT * FROM ViTien")
    List<ViTien> getListViTien();

    @Query("SELECT * FROM ViTien WHERE ViTien_name =:name")
    List<ViTien> checkVi(String name);

    @Update
    void updateViTien(ViTien viTien);

    @Delete
    void deleteViTien(ViTien viTien);

    @Query("DELETE FROM vitien")
    void deleteAllViTien();

    @Query("SELECT * FROM ViTien")
    List<ViTien> xuatViTien();

    @Query("SELECT * FROM ViTien")
    LiveData<List<ViTien>> xuatViTienLive();

}
