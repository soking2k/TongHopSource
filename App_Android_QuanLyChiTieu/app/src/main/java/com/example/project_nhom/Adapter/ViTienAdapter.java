package com.example.project_nhom.Adapter;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.project_nhom.Database.AppViewModel;
import com.example.project_nhom.Model.ViTien;
import com.example.project_nhom.R;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.List;
import java.util.Locale;

public class ViTienAdapter extends RecyclerView.Adapter<ViTienAdapter.ViTienHolder> {
    private Context context;
 //   private AdapterView.OnItemClickListener listener;
    private OnItemClickListener listener;

    private AppViewModel appViewModel;
    private List<ViTien> mlistUser;
    private IClickItemViTien iClickItemViTien;
    public interface IClickItemViTien
    {
        void UpdateViTien(ViTien vitien);
        void DeleteViTien(ViTien vitien);
    }
    public ViTienAdapter(Context context) {
        this.context = context;
    }
    public ViTienAdapter(IClickItemViTien iClickItemViTien) {
        this.iClickItemViTien = iClickItemViTien;
    }

    public void setData(List<ViTien>list){
        this.mlistUser = list;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public ViTienHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType){
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_user, parent, false);

        return new ViTienHolder(view);
    }


    public void onBindViewHolder(@NonNull ViTienHolder holder, int position)
    {
        final ViTien viTien = mlistUser.get(position);
        if(viTien == null){
            return;
        }
        holder.tvName.setText(viTien.getName());
        holder.tvMoney.setText(numberFormat(viTien.getMoney()));

        holder.btnUpdate1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                iClickItemViTien.UpdateViTien(viTien);

            }

        });
        holder.btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                iClickItemViTien.DeleteViTien(viTien);
            }
        });
    }
    public int getItemCount(){
        if(mlistUser != null)
        {
            return mlistUser.size();
        }
        return 0;
    }
    public class ViTienHolder extends RecyclerView.ViewHolder{
        private TextView tvName;
        private TextView tvMoney;
        private Button btnUpdate;
        private ImageButton btnUpdate1;
        private ImageButton btnDelete;


        public ViTienHolder(@NonNull View itemView){
            super(itemView);
            tvName = itemView.findViewById(R.id.tv_name);
            tvMoney = itemView.findViewById(R.id.tv_money);
            btnUpdate1 = itemView.findViewById(R.id.btn_update_tien);
            btnUpdate1
                    .animate()
                    .setDuration(150)
                    .alpha(0.0f)
                    .setListener(new AnimatorListenerAdapter() {
                        @Override
                        public void onAnimationEnd(Animator animation) {
                            super.onAnimationEnd(animation);
                            btnUpdate1.setVisibility(View.GONE);
                            // Hack: Remove the listener. So it won't be executed when
                            // any other animation on this view is executed
                            btnUpdate1.animate().setListener(null);
                        }
                    });
            btnDelete = itemView.findViewById(R.id.btn_delete);
            btnDelete
                    .animate()
                    .setDuration(150)
                    .alpha(0.0f)
                    .setListener(new AnimatorListenerAdapter() {
                        @Override
                        public void onAnimationEnd(Animator animation) {
                            super.onAnimationEnd(animation);
                            btnDelete.setVisibility(View.GONE);
                            // Hack: Remove the listener. So it won't be executed when
                            // any other animation on this view is executed
                            btnDelete.animate().setListener(null);
                        }
                    });
            itemView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    btnUpdate1.setVisibility(View.VISIBLE);
                    btnUpdate1.setAlpha(0.0f);
                    btnUpdate1
                            .animate()
                            .setDuration(150)
                            .alpha(1.0f)
                            .setListener(new AnimatorListenerAdapter() {
                                @Override
                                public void onAnimationEnd(Animator animation) {
                                    super.onAnimationEnd(animation);
                                    btnUpdate1.animate().setListener(null);
                                }
                            })
                    ;
                    btnDelete.setVisibility(View.VISIBLE);
                    btnDelete.setAlpha(0.0f);
                    btnDelete
                            .animate()
                            .setDuration(150)
                            .alpha(1.0f)
                            .setListener(new AnimatorListenerAdapter() {
                                @Override
                                public void onAnimationEnd(Animator animation) {
                                    super.onAnimationEnd(animation);
                                    btnDelete.animate().setListener(null);
                                }
                            })
                    ;
                    int position = getAdapterPosition();
                    if (listener != null && position != RecyclerView.NO_POSITION) {
                        btnUpdate1
                                .animate()
                                .setDuration(150)
                                .alpha(0.0f)
                                .setListener(new AnimatorListenerAdapter() {
                                    @Override
                                    public void onAnimationEnd(Animator animation) {
                                        super.onAnimationEnd(animation);
                                        btnUpdate1.setVisibility(View.GONE);
                                        // Hack: Remove the listener. So it won't be executed when
                                        // any other animation on this view is executed
                                        btnUpdate1.animate().setListener(null);
                                    }
                                });
                        btnDelete
                                .animate()
                                .setDuration(150)
                                .alpha(0.0f)
                                .setListener(new AnimatorListenerAdapter() {
                                    @Override
                                    public void onAnimationEnd(Animator animation) {
                                        super.onAnimationEnd(animation);
                                        btnDelete.setVisibility(View.GONE);
                                        // Hack: Remove the listener. So it won't be executed when
                                        // any other animation on this view is executed
                                        btnDelete.animate().setListener(null);
                                    }
                                });
                        listener.onItemClick(mlistUser.get(position));



                    }
                }
            });

        }
    }

    public interface OnItemClickListener {

        void onItemClick(ViTien viTien);

    }

    public void setOnItemClickListener(OnItemClickListener listener) {
        this.listener = listener;
    }
    private int getIdHinh(String name) {
        int drawableResourceId = context.getResources().getIdentifier(name, "drawable", context.getPackageName());
        return drawableResourceId;
    }


    public String numberFormat(String string) {
        Long number = Long.parseLong(string);
        DecimalFormat formatter = (DecimalFormat) NumberFormat.getInstance(Locale.US);
        formatter.applyPattern("#,###,###,### VND");
        String formattedString = formatter.format(number);
        return formattedString;
    }

}
