package com.jxkr.common.library.pickphoto;

import java.io.File;
import java.util.List;

import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.BaseAdapter;
import android.widget.ListView;

import com.example.adapter.CommonAdapter;
import com.example.adapter.ViewHolder;
import com.example.newapp.R;


public class ListImageDirPopupWindow extends
		BasePopupWindowForListView<PhotoAlbumLVItem> {
	private ListView mListDir;

	public ListImageDirPopupWindow(int width, int height,
			List<PhotoAlbumLVItem> datas, View convertView) {
		super(convertView, width, height, true, datas);
	}

	@Override
	public void initViews() {
		mListDir = (ListView) findViewById(R.id.id_list_dir);
		mListDir.setAdapter(new CommonAdapter<PhotoAlbumLVItem>(context,
				mDatas, R.layout.photo_dir_list_item) {
			@Override
			public void convert(int position, ViewHolder helper,
					PhotoAlbumLVItem item) {
				View id_dir_item_choose = helper
						.getView(R.id.id_dir_item_choose);
				if (position == selectedPosition) {
					id_dir_item_choose.setVisibility(View.VISIBLE);
				} else {
					id_dir_item_choose.setVisibility(View.GONE);
				}

				int lastSeparator = item.getPathName().lastIndexOf(
						File.separator);
				helper.setText(R.id.id_dir_item_name, item.getPathName()
						.substring(lastSeparator + 1));
//				ImageLoaderHelper.displayImage("file://"+item.getFirstImagePath(), (ImageView)helper.getView(R.id.id_dir_item_image));
				helper.setImageByUrl(R.id.id_dir_item_image,
						item.getFirstImagePath());
				helper.setText(R.id.id_dir_item_count, item.getFileCount()
						+ "张");
			}
		});
	}

	public interface OnImageDirSelected {
		void selected(int position,PhotoAlbumLVItem floder);
	}

	private OnImageDirSelected mImageDirSelected;

	public void setOnImageDirSelected(OnImageDirSelected mImageDirSelected) {
		this.mImageDirSelected = mImageDirSelected;
	}

	private int selectedPosition;

	@Override
	public void initEvents() {
		mListDir.setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {
				if (selectedPosition == position)
					return;

				if (mImageDirSelected != null) {
					selectedPosition = position;
					mImageDirSelected.selected(position,mDatas.get(position));
					((BaseAdapter) mListDir.getAdapter())
							.notifyDataSetChanged();
				}
			}
		});
	}

	@Override
	public void init() {

	}

	@Override
	protected void beforeInitWeNeedSomeParams(Object... params) {
	}

}
