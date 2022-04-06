package com.example.project_nhom.activity;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentStatePagerAdapter;
import androidx.viewpager.widget.ViewPager;

import com.example.project_nhom.R;
import com.google.android.material.bottomnavigation.BottomNavigationView;

public class MainActivity extends AppCompatActivity {

    private BottomNavigationView mNavigationView;
    private ViewPager mViewPager;
    private TextView txtTBTitle;
    private ImageButton btnthem;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtTBTitle = findViewById(R.id.txtTBTitle);
        mNavigationView = findViewById(R.id.bottom_nav);
        btnthem = findViewById(R.id.btn_them);
        mViewPager = findViewById(R.id.viewr_pager);
        txtTBTitle.setText("Báo cáo");

        buttonViTien();
        setUpViewPager();




        //Khi Click chuột
        mNavigationView.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                switch (item.getItemId()){
                    case R.id.action_home:
                        mViewPager.setCurrentItem(0);
                        txtTBTitle.setText("Tổng Quan");
                        showButtonThemThuChi();

                        break;

                    case R.id.action_money:
                        mViewPager.setCurrentItem(1);
                        txtTBTitle.setText("Tất Cả Thu Chi");
                        showButtonThemThuChi();

                        break;

                    case R.id.action_setting:
                        mViewPager.setCurrentItem(2);
                        txtTBTitle.setText("Thống Kê");
                        hideButtonThemThuChi();
                        break;
                }
                return true;
            }
        });
    }
    private void showButtonThemThuChi() {
        // Precondition
        if (btnthem.getVisibility() == View.VISIBLE) {
            return;
        }

        // Animate the hidden linear layout as visible and set
        // the alpha as 0.0. Otherwise the animation won't be shown
        btnthem.setVisibility(View.VISIBLE);
        btnthem.setAlpha(0.0f);
        btnthem
                .animate()
                .setDuration(150)
                .alpha(1.0f)
                .setListener(new AnimatorListenerAdapter() {
                    @Override
                    public void onAnimationEnd(Animator animation) {
                        super.onAnimationEnd(animation);
                        btnthem.animate().setListener(null);
                    }
                })
        ;
    }
    private void hideButtonThemThuChi() {
        // Precondition
        if (btnthem.getVisibility() != View.VISIBLE) {
            return;
        }

        // Animate the hidden linear layout as visible and set
        btnthem
                .animate()
                .setDuration(150)
                .alpha(0.0f)
                .setListener(new AnimatorListenerAdapter() {
                    @Override
                    public void onAnimationEnd(Animator animation) {
                        super.onAnimationEnd(animation);
                        btnthem.setVisibility(View.GONE);
                        // Hack: Remove the listener. So it won't be executed when
                        // any other animation on this view is executed
                        btnthem.animate().setListener(null);
                    }
                })
        ;
    }

    private void buttonViTien() {
        btnthem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(),ViTienActivity.class));
            }
        });
    }
    private void buttonViTien1() {
        btnthem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(),ChiTieuActivity.class));
            }
        });
    }
    // Khi Vuốt Màn HÌnh
    private void setUpViewPager(){
        ViewPagerAdapter viewPagerAdapter = new ViewPagerAdapter(getSupportFragmentManager(), FragmentStatePagerAdapter.BEHAVIOR_RESUME_ONLY_CURRENT_FRAGMENT);
        mViewPager.setAdapter(viewPagerAdapter);

        mViewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

            }

            @Override
            public void onPageSelected(int position) {

                switch (position){
                    case 0:
                        mNavigationView.getMenu().findItem(R.id.action_home).setChecked(true);
                        txtTBTitle.setText("Tổng Quan");
                        buttonViTien();
                        showButtonThemThuChi();

                        break;
                    case 1:
                        txtTBTitle.setText("Tất Cả Thu Chi");
                        mNavigationView.getMenu().findItem(R.id.action_money).setChecked(true);
                        buttonViTien1();
                        showButtonThemThuChi();

                        break;
                    case 2:
                        txtTBTitle.setText("Thống Kê Tháng");
                        mNavigationView.getMenu().findItem(R.id.action_setting).setChecked(true);
                        hideButtonThemThuChi();
                        break;
                }
            }

            @Override
            public void onPageScrollStateChanged(int state) {

            }
        });



    }
}