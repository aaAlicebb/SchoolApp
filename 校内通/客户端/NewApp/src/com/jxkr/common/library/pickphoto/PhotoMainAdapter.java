package com.jxkr.common.library.pickphoto;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;

import com.example.newapp.R;

/**
 * 主页面中GridView的适配器
 * 
 * @author hanj
 */

public class PhotoMainAdapter extends BaseAdapter {
	private Context context;
	private ArrayList<String> imagePathList = null;

	public static final int MAX_SELECT_PHOTO_NUM = 12;

	public PhotoMainAdapter(Context context, ArrayList<String> imagePathList) {
		this.context = context;
		this.imagePathList = imagePathList;

	}

	@Override
	public int getCount() {
		if (imagePathList.size() == MAX_SELECT_PHOTO_NUM)
			return imagePathList.size();
		else
			return imagePathList.size() + 1;
	}

	@Override
	public Object getItem(int position) {
		return null;
	}

	@Override
	public long getItemId(int position) {
		return 0;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		final ViewHolder holder;
		if (convertView == null) {
			convertView = LayoutInflater.from(context).inflate(
					R.layout.photo_main_gridview_item, null);
		}
		holder = new ViewHolder();
		holder.imageView = (ImageView) convertView
				.findViewById(R.id.main_gridView_item_photo);
		holder.sinkingView = (SinkingView) convertView
				.findViewById(R.id.sinking);
		convertView.setTag(holder);

		if (imagePathList.size() != MAX_SELECT_PHOTO_NUM
				&& position == getCount() - 1) {
			holder.imageView
					.setImageResource(R.drawable.pickphoto_add_photo_icon);
		} else {
			String filePath = imagePathList.get(position);
			ImageLoader.getInstance().loadImage(filePath, holder.imageView);
			// ImageLoaderHelper.displayImage("file://"+filePath,
			// holder.imageView);
		}

		return convertView;
	}

	public class ViewHolder {
		ImageView imageView;
		public SinkingView sinkingView;
	}

}
