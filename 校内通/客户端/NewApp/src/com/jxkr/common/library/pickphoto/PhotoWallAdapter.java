package com.jxkr.common.library.pickphoto;

import java.util.ArrayList;
import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.Toast;

import com.example.newapp.R;
import com.jxkr.common.library.pickphoto.ImageLoader.Type;


/**
 * PhotoWall中GridView的适配器
 * 
 * @author hanj
 */

public class PhotoWallAdapter extends BaseAdapter {
	private Context context;
	private ArrayList<String> imagePathList = null;
	private List<String> selectedImagePathList = null;
	private int maxSelectPhotoNum;
//	private SDCardImageLoader loader;

	private boolean isRecentImages;

	public void setSelectedImagePathList(List<String> list) {
		this.selectedImagePathList = list;
		this.notifyDataSetChanged();
	}

	public PhotoWallAdapter(Context context, ArrayList<String> imagePathList,
			List<String> selectedImagePathList,int maxSelectPhotoNum, boolean isRecentImages) {
		this.context = context;
		this.imagePathList = imagePathList;
		this.selectedImagePathList = selectedImagePathList;
		this.maxSelectPhotoNum = maxSelectPhotoNum;
		this.isRecentImages = isRecentImages;
//		loader = new SDCardImageLoader(ScreenUtils.getScreenW(),
//				ScreenUtils.getScreenH());
	}

	@Override
	public int getCount() {
//		if (isRecentImages)
			return imagePathList.size() + 1;
//		else
//			return imagePathList.size();
	}

	@Override
	public Object getItem(int position) {
		return position;
	}

	@Override
	public long getItemId(int position) {
		return 0;
	}
	

	@Override
	public View getView(final int position, View convertView, ViewGroup parent) {

		final ViewHolder holder;
		if (convertView == null) {
			convertView = LayoutInflater.from(context).inflate(
					R.layout.photo_wall_item, null);
			holder = new ViewHolder();

			holder.imageView = (ImageView) convertView
					.findViewById(R.id.photo_wall_item_photo);
			holder.checkBox = (ImageView) convertView
					.findViewById(R.id.photo_wall_item_cb);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		
		if (position == 0) {
			holder.checkBox.setVisibility(View.GONE);
			holder.imageView.setImageResource(R.drawable.pickphoto_take_photo_icon);
			holder.imageView.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					mOnTakePhotoListener.onPhotoButtonPressed();
				}
			});
		} else {
			holder.imageView.setImageResource(R.drawable.pickphoto_empty_photo);
//			if (isRecentImages)
				final String filePath = imagePathList.get(position - 1);
//			else
//				filePath = imagePathList.get(position);
			holder.checkBox.setVisibility(View.VISIBLE);
			holder.imageView.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
//					if(isRecentImages)
//					if(isSelectPhotoFull()){
//						return;
//					}
					mOnTakePhotoListener.onImageClicked(position - 1);
//					else mOnTakePhotoListener.onImageClicked(position);
				}
			});

			holder.checkBox.setOnClickListener(new OnClickListener() {
				
				@Override
				public void onClick(View v) {
					boolean flag = selectedImagePathList
							.contains(filePath);
					if (!flag && !isSelectPhotoFull()) {
						selectedImagePathList.add(filePath);
						holder.imageView.setColorFilter(context
								.getResources().getColor(
										R.color.image_checked_bg));
						holder.checkBox.setSelected(true);
					} else if (flag) {
						selectedImagePathList.remove(filePath);
						holder.imageView.setColorFilter(null);
						holder.checkBox.setSelected(false);
					}
					mOnTakePhotoListener.onImageCheckedChanged();
				}
			});
			
			if (selectedImagePathList.contains(filePath)) {
				holder.checkBox.setSelected(true);
				holder.imageView.setColorFilter(context.getResources()
						.getColor(R.color.image_checked_bg));

			} else {
				holder.checkBox.setSelected(false);
				holder.imageView.setColorFilter(null);
			}

			holder.imageView.setTag(filePath);
			 ImageLoader.getInstance(3, Type.LIFO).loadImage(filePath,
			 holder.imageView);
//			 ImageLoaderHelper.displayImage("file://"+filePath, holder.imageView);
		}

		return convertView;
	}

	/**是否可选择的图片已满
	 * @return
	 */
	protected boolean isSelectPhotoFull() {
		if( selectedImagePathList.size() == maxSelectPhotoNum){
			Toast.makeText(context, "可选择图片数量不能超过"+maxSelectPhotoNum+"张", Toast.LENGTH_SHORT).show();
			return true;
		}
		return false;
	}

	public interface OnTakePhotoListener {
		void onPhotoButtonPressed();

		void onImageClicked(int position);

		void onImageCheckedChanged();
	}

	private OnTakePhotoListener mOnTakePhotoListener;

	public void setOnImageCheckedChangeListener(OnTakePhotoListener l) {
		mOnTakePhotoListener = l;
	}

	private class ViewHolder {
		ImageView imageView;
		ImageView checkBox;
	}

}
