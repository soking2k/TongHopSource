package com.example.project_nhom.Database;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import com.example.project_nhom.Model.ChiTieu;

import java.util.List;

@Dao
public interface ChiTieuDAO {
    @Insert
    void InserChiTieu(ChiTieu chiTieu);

    @Query("SELECT * FROM ChiTieu ORDER BY ChiTieu_date ASC")
    List<ChiTieu> getListChiTieu();

    @Query("SELECT * FROM ChiTieu WHERE ChiTieu_Name =:name")
    List<ChiTieu> CheckChiTieu(String name);

    @Update
    void updateChiTieu(ChiTieu chiTieu);

    @Delete
    void deleteChiTieu(ChiTieu chiTieu);

    @Query("DELETE FROM ChiTieu")
    void deleteAllChiTieu();

    @Query("SELECT * FROM ChiTieu ORDER BY ChiTieu_date ASC")
    List<ChiTieu> xuatChiTieu();

    @Query("SELECT * FROM ChiTieu ORDER BY ChiTieu_date ASC")
    LiveData<List<ChiTieu>> xuatChiTieuLive();

}
