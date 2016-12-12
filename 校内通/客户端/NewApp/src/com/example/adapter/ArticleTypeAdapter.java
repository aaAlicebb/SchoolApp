package com.example.adapter;

import java.util.List;

import android.animation.ArgbEvaluator;
import android.animation.ObjectAnimator;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.support.v7.graphics.Palette;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.animation.AccelerateInterpolator;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.example.adapter.ArticleTypeAdapter.TypeViewHolder;
import com.example.bean.ArticleType;
import com.example.newapp.NormalArticleListActivity;
import com.example.newapp.R;
import com.example.util.ImageLoaderHelper;
import com.example.util.ImageLoaderHelper.ImageLoadingType;
import com.nostra13.universalimageloader.core.listener.SimpleImageLoadingListener;

public class ArticleTypeAdapter extends RecyclerView.Adapter<TypeViewHolder> {

	private final List<ArticleType> typeList;
	private Context context;
	private int defaultBackgroundcolor;
//	private int lastPosition = -1;
	private static final int SCALE_DELAY = 30;
	
	public ArticleTypeAdapter(List<ArticleType> typeList,Context context) {
		this.context = context;
		this.typeList = typeList;
		defaultBackgroundcolor = context.getResources().getColor(R.color.image_without_palette);
	}

	@Override
	public int getItemCount() {
		return typeList.size();
	}

	@Override
	public void onBindViewHolder(final TypeViewHolder viewHolder,
			final int position) {
		final ArticleType type = typeList.get(position);
		viewHolder.nameTextView.setText(type.getTypeName());
		viewHolder.countTextView.setText("话题：" + type.getArticleCount());
		viewHolder.descTextView.setText(type.getTypeDesc());
		viewHolder.typeImageView.setDrawingCacheEnabled(true);
		viewHolder.itemContainer.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				//跳转到帖子列表
//				if(type.getTypeId() == 1 || type.getTypeId()==2 || type.getTypeId()==3){//特殊类公告
//					//FIXME 特殊类公告跳转
//				}else{
					Intent intent = new Intent(context,NormalArticleListActivity.class);
					intent.putExtra("articleType", type);
					context.startActivity(intent);
//				}
				
				
			}
		});
		ImageLoaderHelper.displayImage(type.getPhotoUrl(), viewHolder.typeImageView,ImageLoadingType.AVATAR,new SimpleImageLoadingListener(){

			@Override
			public void onLoadingComplete(String imageUri, View view,
					Bitmap bitmap) {
				if (bitmap != null) {
//					imageView.setImageBitmap(bitmap);
					setCellColors(bitmap, viewHolder, position);
					amimateCell(viewHolder);
				}
				super.onLoadingComplete(imageUri, view, bitmap);
			}
			
		});

	}

	@SuppressLint("NewApi") private void amimateCell(TypeViewHolder booksViewHolder) {

		int cellPosition = booksViewHolder.getPosition();

		if (!booksViewHolder.animated) {

			booksViewHolder.animated = true;
			booksViewHolder.itemContainer.setScaleY(0);
			booksViewHolder.itemContainer.setScaleX(0);
			booksViewHolder.itemContainer.animate().scaleY(1).scaleX(1)
					.setDuration(200).setStartDelay(SCALE_DELAY * cellPosition)
					.start();
		}

	}

	public void setCellColors(Bitmap b, final TypeViewHolder viewHolder,
			final int position) {

		if (b != null) {
			Palette.generateAsync(b, new Palette.PaletteAsyncListener() {

				@Override
				public void onGenerated(Palette palette) {

					Palette.Swatch vibrantSwatch = palette.getVibrantSwatch();

					if (vibrantSwatch != null) {

						viewHolder.nameTextView.setTextColor(vibrantSwatch
								.getTitleTextColor());
						viewHolder.descTextView.setTextColor(vibrantSwatch.getBodyTextColor());
						viewHolder.countTextView.setTextColor(vibrantSwatch
								.getTitleTextColor());
						
						ObjectAnimator animator = ObjectAnimator.ofObject(
								viewHolder.textContainer, "backgroundColor",
								new ArgbEvaluator(), defaultBackgroundcolor,
								vibrantSwatch.getRgb());
						animator.setInterpolator(new AccelerateInterpolator(
								1.0f));
						animator.setDuration(3000);
						animator.start();

					} else {

						Log.e("[ERROR]",
								"BookAdapter onGenerated - The VibrantSwatch were null at: "
										+ position);
					}
				}
			});
		}
	}

	@Override
	public TypeViewHolder onCreateViewHolder(ViewGroup viewGroup, int arg1) {

		View rowView = LayoutInflater.from(viewGroup.getContext()).inflate(
				R.layout.item_bbs_type, viewGroup, false);

//		Context context = viewGroup.getContext();
//		defaultBackgroundcolor = context.getResources().getColor(
//				R.color.image_without_palette);

		return new TypeViewHolder(rowView);
	}

	class TypeViewHolder extends RecyclerView.ViewHolder
			 {

		protected LinearLayout itemContainer;
		protected RelativeLayout textContainer;
		protected ImageView typeImageView;
		protected TextView nameTextView;
		protected TextView countTextView;
		protected TextView descTextView;
		protected boolean animated = false;

		public TypeViewHolder(View itemView) {

			super(itemView);

			itemContainer = (LinearLayout) itemView
					.findViewById(R.id.itemContainer);
			textContainer = (RelativeLayout) itemView
					.findViewById(R.id.textContainer);
			typeImageView = (ImageView) itemView
					.findViewById(R.id.typeImageView);
			nameTextView = (TextView) itemView.findViewById(R.id.nameTextView);
			countTextView = (TextView) itemView
					.findViewById(R.id.countTextView);
			descTextView = (TextView) itemView.findViewById(R.id.descTextView);
			

		}

		

	}
}
