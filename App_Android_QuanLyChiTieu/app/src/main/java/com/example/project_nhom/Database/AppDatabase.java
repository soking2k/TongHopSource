package com.example.project_nhom.Database;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;
import androidx.room.TypeConverters;

import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.Model.ViTien;

@Database(entities = {ViTien.class, ChiTieu.class}, version = 3)
@TypeConverters(Converter.class)

public abstract class AppDatabase extends RoomDatabase{

    private static final String DATABASE_NAME ="sinhvien2.db";
    private static AppDatabase instance;

    public static synchronized AppDatabase getInstance(Context context) {
        if (instance == null) {
            instance = Room.databaseBuilder(context.getApplicationContext(), AppDatabase.class, DATABASE_NAME)
                    .allowMainThreadQueries()
                    .build();
        }
        return instance;
    }

    public abstract ChiTieuDAO ChiTieuDAO();


    public abstract ViTienDAO ViTienDAO();




}

