package com.example.project_nhom.Adapter;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.project_nhom.Database.AppViewModel;
import com.example.project_nhom.Model.ChiTieu;
import com.example.project_nhom.R;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class ChiTieudapter extends RecyclerView.Adapter<ChiTieudapter.ChiTieuHolder> {
    private Context context;
 //   private AdapterView.OnItemClickListener listener;
    private OnItemClickListener listener;

    private AppViewModel appViewModel;
    private List<ChiTieu> mlistUser1;
    private IClickItemChiTieu iClickItemChiTieu;
    public interface IClickItemChiTieu
    {
        void UpdateChiTieu(ChiTieu chiTieu);
        void DeleteChiTieu(ChiTieu chiTieu);
    }
    public ChiTieudapter(Context context) {
        this.context = context;
    }
    public ChiTieudapter(IClickItemChiTieu iClickItemChiTieu) {
        this.iClickItemChiTieu = iClickItemChiTieu;
    }

    public void setData(List<ChiTieu>list){
        this.mlistUser1 = list;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public ChiTieuHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType){
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_chitieu, parent, false);

        return new ChiTieuHolder(view);
    }


    public void onBindViewHolder(@NonNull ChiTieuHolder holder, int position)
    {
        final ChiTieu chiTieu = mlistUser1.get(position);


        holder.tvName.setText(chiTieu.getName());
        holder.tvLoai.setText(chiTieu.getLoai());
        //holder.tvMoney.setText(chiTieu.getMoney());
        holder.tvMoney.setText(numberFormat(chiTieu.getMoney()));

        if (chiTieu.getThuchi() == 1) {
            holder.tvMoney.setTextColor(Color.rgb(0,153,0));
            holder.imgUpDown.setImageResource(R.drawable.ic_up);
            holder.imgUpDown.setColorFilter(Color.rgb(0,153,0));


        } else {
            holder.tvMoney.setTextColor(Color.RED);
            holder.imgUpDown.setImageResource(R.drawable.ic_down);
            holder.imgUpDown.setColorFilter(Color.RED);


        }

        //  holder.tvMoney.setText(numberFormat(chiTieu.getMoney()));
       // holder.tvThuChi.setText(chiTieu.getThuchi());
       // holder.tvVi.setText(chiTieu.getVi());
        Date date = chiTieu.getDate();

        holder.tvDate.setText(+date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getYear());


        holder.btnUpdate1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                iClickItemChiTieu.UpdateChiTieu(chiTieu);

            }

        });
        holder.btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                iClickItemChiTieu.DeleteChiTieu(chiTieu);
            }
        });
    }
    public int getItemCount(){
        if(mlistUser1 != null)
        {
            return mlistUser1.size();
        }
        return 0;
    }
    public class ChiTieuHolder extends RecyclerView.ViewHolder{
        private TextView tvName;
        private TextView tvLoai;
        private TextView tvMoney;
        private TextView tvThuChi;
        private TextView tvVi;
        private TextView tvDate;
        private ImageView imgUpDown;


        private Button btnUpdate;
        private ImageButton btnUpdate1;
        private ImageButton btnDelete;


        public ChiTieuHolder(@NonNull View itemView){
            super(itemView);
            tvName = itemView.findViewById(R.id.tv_name);
            tvLoai = itemView.findViewById(R.id.tv_loai);
            tvMoney = itemView.findViewById(R.id.tv_money);
            tvDate = itemView.findViewById(R.id.tv_date);
            imgUpDown = itemView.findViewById(R.id.imgUpDown);
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
                        listener.onItemClick(mlistUser1.get(position));



                    }
                }
            });

        }
    }

    public interface OnItemClickListener {

        void onItemClick(ChiTieu chiTieu);

    }

    public void setOnItemClickListener(OnItemClickListener listener) {
        this.listener = listener;
    }
    private int getIdHinh(String name) {
        int drawableResourceId = context.getResources().getIdentifier(name, "drawable", context.getPackageName());
        return drawableResourceId;
    }

    //Định dạng số tiền
    public String numberFormat(String string) {
        Long number = Long.parseLong(string);
        DecimalFormat formatter = (DecimalFormat) NumberFormat.getInstance(Locale.US);
        formatter.applyPattern("#,###,###,### VND");
        String formattedString = formatter.format(number);
        return formattedString;
    }


}
