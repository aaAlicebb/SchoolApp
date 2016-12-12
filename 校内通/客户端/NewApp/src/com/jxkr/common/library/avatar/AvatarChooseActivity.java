package com.jxkr.common.library.avatar;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.provider.MediaStore;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.view.WindowManager;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.PopupWindow.OnDismissListener;
import android.widget.TextView;
import android.widget.Toast;

import com.example.newapp.R;
import com.jxkr.common.library.pickphoto.ImageLoader;
import com.jxkr.common.library.pickphoto.ImageLoader.Type;
import com.jxkr.common.library.pickphoto.ListImageDirPopupWindow;
import com.jxkr.common.library.pickphoto.ListImageDirPopupWindow.OnImageDirSelected;
import com.jxkr.common.library.pickphoto.PhotoAlbumLVItem;
import com.jxkr.common.library.pickphoto.PhotoScannerUtil;
import com.jxkr.common.library.pickphoto.PhotoWallActivity;
import com.jxkr.common.library.pickphoto.ScreenUtils;
import com.jxkr.common.library.pickphoto.Utility;

/**
 * 选择照片页面 Created by hanj on 14-10-15.
 */
public class AvatarChooseActivity extends Activity implements OnClickListener,
		OnImageDirSelected {

	private TextView titleTV;

	private ArrayList<String> list;
	private GridView mPhotoWall;
	private AvatarWallAdapter adapter;

	private Handler mHandler = new Handler() {
		public void handleMessage(android.os.Message msg) {
			mProgressDialog.dismiss();
			// 为View绑定数据
			data2View();
			// 初始化展示文件夹的popupWindw
			initListDirPopupWindw();
		}
	};

	/**
	 * 为View绑定数据
	 */
	private void data2View() {
		if (list == null) {
			Toast.makeText(getApplicationContext(), "一张图片都没扫描到",
					Toast.LENGTH_SHORT).show();
			return;
		}
		adapter = new AvatarWallAdapter(this, list);
		mPhotoWall.setAdapter(adapter);
		titleTV.setText(getString(R.string.latest_image));

	}

	Button btn_sure;
	String activityClass;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.avatar_wall);
		ScreenUtils.initScreen(this);
		File file = new File(PhotoWallActivity.PATH);
		if (!file.exists()) {
			file.mkdir();
		}
		activityClass = getIntent().getStringExtra("activityClass");
		titleTV = (TextView) findViewById(R.id.topbar_title_tv);
		titleTV.setText(R.string.latest_image);

		Button backBtn = (Button) findViewById(R.id.topbar_left_btn);
		btn_sure = (Button) findViewById(R.id.btn_sure);
		backBtn.setVisibility(View.VISIBLE);
		mPhotoWall = (GridView) findViewById(R.id.photo_wall_grid);
		list = new ArrayList<>();
		initImageDirList();

		// 点击返回，回到选择相册页面
		backBtn.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				backAction();
			}
		});
		titleTV.setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.topbar_title_tv: // 显示出popupwindow
			Drawable rightDrawable = getResources().getDrawable(
					R.drawable.pickphoto_arrow_up_black);
			rightDrawable.setBounds(0, 0, rightDrawable.getMinimumWidth(),
					rightDrawable.getMinimumHeight());
			titleTV.setCompoundDrawables(null, null, rightDrawable, null);
			mListImageDirPopupWindow.setAnimationStyle(R.style.anim_popup_dir);
			mListImageDirPopupWindow.showAsDropDown(titleTV, 0, 0);
			// 设置背景颜色变暗
			WindowManager.LayoutParams lp = getWindow().getAttributes();
			lp.alpha = .3f;
			getWindow().setAttributes(lp);
			break;
		}

	}

	public static final int OP_CODE_TAKE_PHOTO = 1;
	public static final int OP_CODE_PREVIEW_PHOTO = 2;

	private ListImageDirPopupWindow mListImageDirPopupWindow;

	/**
	 * 初始化展示文件夹的popupWindw
	 */
	private void initListDirPopupWindw() {

		mListImageDirPopupWindow = new ListImageDirPopupWindow(
				LayoutParams.MATCH_PARENT,
				(int) (ScreenUtils.getScreenH() * 0.7), albumList,
				LayoutInflater.from(getApplicationContext()).inflate(
						R.layout.photo_dir_list, null));

		mListImageDirPopupWindow.setOnDismissListener(new OnDismissListener() {

			@Override
			public void onDismiss() {
				Drawable rightDrawable = getResources().getDrawable(
						R.drawable.pickphoto_arrow_down_black);
				rightDrawable.setBounds(0, 0, rightDrawable.getMinimumWidth(),
						rightDrawable.getMinimumHeight());
				titleTV.setCompoundDrawables(null, null, rightDrawable, null);
				// 设置背景颜色变暗
				WindowManager.LayoutParams lp = getWindow().getAttributes();
				lp.alpha = 1.0f;
				getWindow().setAttributes(lp);
			}
		});
		// 设置选择文件夹的回调
		mListImageDirPopupWindow.setOnImageDirSelected(this);
	}

	/**
	 * 点击返回时，跳转至相册页面
	 */
	private void backAction() {
		finish();
	}

	@Override
	public void selected(int position, PhotoAlbumLVItem floder) {
		// 如果选的是最近照片
		if (position == 0) {
			list = lastestImagePathList;
		} else {
			list = PhotoScannerUtil.getAllImagePathsByFolder(floder
					.getPathName());
		}

		/**
		 * 可以看到文件夹的路径和图片的路径分开保存，极大的减少了内存的消耗；
		 */

		adapter = new AvatarWallAdapter(this, list);
		mPhotoWall.setAdapter(adapter);
		mListImageDirPopupWindow.dismiss();
		int lastSeparator = floder.getPathName().lastIndexOf(File.separator);
		titleTV.setText(floder.getPathName().substring(lastSeparator + 1));
	}

	private ArrayList<PhotoAlbumLVItem> albumList;
	private int lastestImageCount = 0;
	private String lastestFirstImagePath;
	private ProgressDialog mProgressDialog;
	private ArrayList<String> lastestImagePathList;

	/**
	 * 初始化图片文件夹list
	 */
	private void initImageDirList() {
		if (!Utility.isSDcardOK()) {
			Utility.showToast(this, "SD卡不可用。");
			return;
		}
		// 显示进度条a
		mProgressDialog = ProgressDialog.show(this, null, "正在加载...");
		new Thread(new Runnable() {

			@Override
			public void run() {
				list.clear();
				// 第二种方式：使用ContentProvider。（效率更高）
				lastestImagePathList = PhotoScannerUtil.getLatestImagePaths(
						AvatarChooseActivity.this, 100);
				lastestFirstImagePath = lastestImagePathList.get(0);
				lastestImageCount = lastestImagePathList.size();
				list.addAll(lastestImagePathList);
				albumList = new ArrayList<PhotoAlbumLVItem>();
				// “最近照片”
				albumList.add(new PhotoAlbumLVItem(getResources().getString(
						R.string.latest_image), lastestImageCount,
						lastestFirstImagePath));
				// 相册
				albumList.addAll(PhotoScannerUtil
						.getImagePathsByContentProvider(AvatarChooseActivity.this));
				// 通知Handler扫描图片完成
				mHandler.sendEmptyMessage(0x110);
			}

		}).start();

	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);
		if (resultCode != RESULT_OK)
			return;
		switch (requestCode) {
		case OP_CODE_TAKE_PHOTO:
			getContentResolver().insert(IMAGE_URI, contentValues);
			openCropActivity(photoFilePath);
			break;
		}
	}

	private String photoFilePath;
	private ContentValues contentValues;

	public static final Uri IMAGE_URI = MediaStore.Images.Media.EXTERNAL_CONTENT_URI;

	public void onPhotoButtonPressed() {
		Intent cameraintent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
		// 指定调用相机拍照后照片的储存路径
		// 系统时间
		long dateTaken = System.currentTimeMillis();
		// 图像名称
		String filename = DateFormat.format("yyyyMMddkkmmss", dateTaken)
				.toString() + ".jpg";
		photoFilePath = PhotoWallActivity.PATH + filename;
		contentValues = new ContentValues(7);
		contentValues.put(MediaStore.Images.Media.TITLE, filename);
		contentValues.put(MediaStore.Images.Media.DISPLAY_NAME, filename);
		contentValues.put(MediaStore.Images.Media.DATE_TAKEN, dateTaken);
		contentValues.put(MediaStore.Images.Media.MIME_TYPE, "image/jpeg");
		contentValues.put(MediaStore.Images.Media.DATA, photoFilePath);

		cameraintent.putExtra(MediaStore.EXTRA_OUTPUT,
				Uri.fromFile(new File(photoFilePath)));
		startActivityForResult(cameraintent, OP_CODE_TAKE_PHOTO);

	}

	/**
	 * 打开头像裁剪界面
	 * 
	 * @param item
	 *            选定的图片path
	 */
	protected void openCropActivity(String item) {
		Intent intent = new Intent(this, AvatarCropActivity.class);
		intent.putExtra("path", item);
		intent.putExtra("activityClass", activityClass);
		startActivity(intent);
	}

	private class AvatarWallAdapter extends BaseAdapter {

		private List<String> mDatas;

		public AvatarWallAdapter(Context context, List<String> mDatas) {
			this.mDatas = mDatas;
		}

		@Override
		public int getCount() {
			return mDatas.size() + 1;
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
		public View getView(final int position, View convertView,
				ViewGroup parent) {

			final ViewHolder holder;
			if (convertView == null) {
				convertView = LayoutInflater.from(AvatarChooseActivity.this)
						.inflate(R.layout.photo_wall_item, null);
				holder = new ViewHolder();

				holder.imageView = (ImageView) convertView
						.findViewById(R.id.photo_wall_item_photo);
				holder.checkBox = (ImageView) convertView
						.findViewById(R.id.photo_wall_item_cb);
				convertView.setTag(holder);
			} else {
				holder = (ViewHolder) convertView.getTag();
			}
			holder.checkBox.setVisibility(View.GONE);
			holder.imageView
			.setImageResource(R.drawable.pickphoto_empty_photo);
			if (position == 0) {
				holder.imageView
						.setImageResource(R.drawable.pickphoto_take_photo_icon);
			} else {
				final String filePath = mDatas.get(position - 1);
				ImageLoader.getInstance(3, Type.LIFO).loadImage(filePath,
						holder.imageView);
			}

			holder.imageView.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					if (position == 0) {
						onPhotoButtonPressed();
					} else {
						openCropActivity(mDatas.get(position - 1));
					}

				}
			});

			return convertView;
		}

	}

	private class ViewHolder {
		ImageView imageView;
		ImageView checkBox;
	}

}
