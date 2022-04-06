package com.example.project_nhom.Model;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import java.io.Serializable;

@Entity(tableName = "ViTien")
public class ViTien implements Serializable {
    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "ViTien_id")
    private int id;

    @ColumnInfo(name = "ViTien_img")
    private String img;
    @ColumnInfo(name = "ViTien_name")
    private String name;

    @ColumnInfo(name = "ViTien_money")
    private String money;

    public ViTien() {
    }

    public ViTien(String img, String name, String money) {
        this.img = img;
        this.name = name;
        this.money = money;
    }

    public ViTien(int id, String img, String name, String money) {
        this.id = id;
        this.img = img;
        this.name = name;
        this.money = money;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getImg() {
        return img;
    }

    public void setImg(String img) {
        this.img = img;
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
}
