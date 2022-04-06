package com.example.project_nhom.Model;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import java.io.Serializable;
import java.util.Date;

@Entity(tableName = "ChiTieu")
public class ChiTieu implements Serializable {
    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "ChiTieu_id")
    private int id;

    @ColumnInfo(name = "ChiTieu_loai")
    private String loai;
    @ColumnInfo(name = "ChiTieu_Name")
    private String name;

    @ColumnInfo(name = "ChiTieu_money")
    private String money;

    @ColumnInfo(name = "ChiTieu_thuchi")
    private int thuchi;

    @ColumnInfo(name = "ChiTieu_vi")
    private int vi;

    @ColumnInfo(name = "ChiTieu_date")
    private Date date;

    public ChiTieu() {
    }

    public ChiTieu(String loai, String name, String money, int thuchi, int vi, Date date) {
        this.loai = loai;
        this.name = name;
        this.money = money;
        this.thuchi = thuchi;
        this.vi = vi;
        this.date = date;

    }

    public ChiTieu(int id, String loai, String name, String money, int thuchi, int vi, Date date) {
        this.id = id;
        this.loai = loai;
        this.name = name;
        this.money = money;
        this.thuchi = thuchi;
        this.vi = vi;
        this.date = date;

    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getLoai() {
        return loai;
    }

    public void setLoai(String loai) {
        this.loai = loai;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getMoney() {
        return money;
    }
    public void setMoney(String money) {
        this.money = money;
    }
    public int getThuchi() {
        return thuchi;
    }

    public void setThuchi(int thuchi) {
        this.thuchi = thuchi;
    }

    public int getVi() {
        return vi;
    }


    public void setVi(int vi) {
        this.vi = vi;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}