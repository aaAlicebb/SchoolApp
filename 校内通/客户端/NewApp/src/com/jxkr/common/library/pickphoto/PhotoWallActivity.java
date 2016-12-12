package com.jxkr.common.library.pickphoto;

import java.io.File;
import java.util.ArrayList;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.ContentValues;
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
import android.view.ViewGroup.LayoutParams;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.GridView;
import android.widget.PopupWindow.OnDismissListener;
import android.widget.TextView;
import android.widget.Toast;

import com.example.newapp.R;
import com.example.util.SdCardUtil;
import com.jxkr.common.library.pickphoto.ListImageDirPopupWindow.OnImageDirSelected;
import com.jxkr.common.library.pickphoto.PhotoWallAdapter.OnTakePhotoListener;

/**
 * 选择照片页面 Created by hanj on 14-10-15.
 */
public class PhotoWallActivity extends Activity implements OnClickListener,
		OnImageDirSelected, OnTakePhotoListener {

	public static final String PATH = SdCardUtil.getAppDirectory()+"/photo/";// 拍照完后图片保存目录

	private TextView titleTV;

	private ArrayList<String> list;
	private GridView mPhotoWall;
	private PhotoWallAdapter adapter;

	private ArrayList<String> selectedImagePaths;

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
		adapter = new PhotoWallAdapter(this, list, selectedImagePaths,
				maxSelectedPhotoNum, true);
		adapter.setOnImageCheckedChangeListener(this);
		mPhotoWall.setAdapter(adapter);
		titleTV.setText(getString(R.string.latest_image));

	}

	private int maxSelectedPhotoNum;
	Button btn_sure;
	Button btn_preview;
	String activityClass;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.photo_wall);
		ScreenUtils.initScreen(this);
		File file = new File(PATH);
		if (!file.exists()) {
			file.mkdir();
		}
		selectedImagePaths = getIntent().getStringArrayListExtra(
				"selectedImagePaths");
		if (selectedImagePaths == null)
			selectedImagePaths = new ArrayList<>(
					PhotoMainAdapter.MAX_SELECT_PHOTO_NUM);
		maxSelectedPhotoNum = getIntent().getIntExtra("maxSelectImageNum", -1);
		activityClass = getIntent().getStringExtra("activityClass");
		titleTV = (TextView) findViewById(R.id.topbar_title_tv);
		titleTV.setText(R.string.latest_image);

		Button backBtn = (Button) findViewById(R.id.topbar_left_btn);
		btn_sure = (Button) findViewById(R.id.btn_sure);
		btn_preview = (Button) findViewById(R.id.btn_preview);
		Button confirmBtn = (Button) findViewById(R.id.topbar_right_btn);
		// backBtn.setText(R.string.photo_album);
		backBtn.setVisibility(View.VISIBLE);
		// confirmBtn.setText(R.string.main_confirm);
		// confirmBtn.setVisibility(View.VISIBLE);
		updateBtnDisplay();
		btn_sure.setText("确定(0/" + PhotoMainAdapter.MAX_SELECT_PHOTO_NUM + ")");
		btn_sure.setOnClickListener(this);
		btn_preview.setOnClickListener(this);
		mPhotoWall = (GridView) findViewById(R.id.photo_wall_grid);
		list = new ArrayList<>();
		initImageDirList();

		// 选择照片完成
		confirmBtn.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				// ArrayList<String> paths = getSelectImagePaths();

				Intent intent;
				try {
					intent = new Intent(PhotoWallActivity.this, Class
							.forName(activityClass));
					intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					// intent.putExtra("code", paths != null ? 100 : 101);
					// intent.putStringArrayListExtra("paths", paths);
					startActivity(intent);
				} catch (ClassNotFoundException e) {
					e.printStackTrace();
				}

			}
		});

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
		case R.id.btn_sure:
			// Intent intent = new Intent(PhotoWallActivity.this,
			// MainActivity.class);
			// intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			// // intent.putExtra("code", paths != null ? 100 : 101);
			// intent.putStringArrayListExtra("paths",
			// (ArrayList<String>) selectedImagePaths);
			// startActivity(intent);
			Intent intent = getIntent();
			intent.putStringArrayListExtra("selectedImagePaths",
					(ArrayList<String>) selectedImagePaths);
			setResult(RESULT_OK, intent);
			finish();
			break;
		case R.id.btn_preview:
			openPreviewActivity(OP_CODE_PREVIEW_PHOTO, 0, selectedImagePaths);
			break;
		default:
			break;
		}

	}

	/**
	 * 打开大图预览界面
	 * 
	 * @param position
	 *            预览的首先位置
	 * @param list
	 *            预览的数据集
	 */
	private void openPreviewActivity(int openType, int position,
			ArrayList<String> list) {
		Intent pIntent = new Intent(PhotoWallActivity.this,
				PhotoPreviewActivity.class);
		pIntent.putExtra("openType", openType);
		pIntent.putExtra("activityClass", activityClass);
		pIntent.putStringArrayListExtra("selectedImagePaths",
				selectedImagePaths);
		pIntent.putStringArrayListExtra("allImagePaths", list);
		pIntent.putExtra("position", position);
		pIntent.putExtra("maxSelectImageNum", maxSelectedPhotoNum);
		startActivityForResult(pIntent, OP_CODE_PREVIEW_PHOTO);
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

	private int lastestImageCount = 0;

	

	@Override
	public void selected(int position, PhotoAlbumLVItem floder) {
		// 如果选的是最近照片
		if (position == 0) {
			list = lastestImagePathList;
		} else {
			list = PhotoScannerUtil.getAllImagePathsByFolder(floder.getPathName());
		}

		/**
		 * 可以看到文件夹的路径和图片的路径分开保存，极大的减少了内存的消耗；
		 */

		adapter = new PhotoWallAdapter(this, list, selectedImagePaths,
				maxSelectedPhotoNum, position == 0);
		adapter.setOnImageCheckedChangeListener(this);
		mPhotoWall.setAdapter(adapter);
		// mAdapter.notifyDataSetChanged();
		mListImageDirPopupWindow.dismiss();
		int lastSeparator = floder.getPathName().lastIndexOf(File.separator);
		titleTV.setText(floder.getPathName().substring(lastSeparator + 1));
	}

	private ArrayList<PhotoAlbumLVItem> albumList;

	private ProgressDialog mProgressDialog;

	private ArrayList<String> lastestImagePathList;

	/**
	 * 初始化图片文件夹list
	 */
	private void initImageDirList() {
		if (!Utility.isSDcardOK()) {
			Utility.showToast(PhotoWallActivity.this, "SD卡不可用。");
			return;
		}
		// 显示进度条
		mProgressDialog = ProgressDialog.show(PhotoWallActivity.this, null,
				"正在加载...");
		new Thread(new Runnable() {

			@Override
			public void run() {
				list.clear();
				// 第二种方式：使用ContentProvider。（效率更高）
				lastestImagePathList = PhotoScannerUtil.getLatestImagePaths(PhotoWallActivity.this,100);
				lastestFirstImagePath = lastestImagePathList.get(0);
				lastestImageCount = lastestImagePathList.size();
				list.addAll(lastestImagePathList);
				albumList = new ArrayList<PhotoAlbumLVItem>();
				// “最近照片”
				albumList.add(new PhotoAlbumLVItem(getResources().getString(
						R.string.latest_image), lastestImageCount,
						lastestFirstImagePath));
				// 相册
				albumList.addAll(PhotoScannerUtil.getImagePathsByContentProvider(PhotoWallActivity.this));
				// 通知Handler扫描图片完成
				mHandler.sendEmptyMessage(0x110);
			}

		}).start();

	}

	

	private String lastestFirstImagePath;

	
	

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);
		if (resultCode != RESULT_OK)
			return;
		switch (requestCode) {
		case OP_CODE_PREVIEW_PHOTO:
			int type = data.getIntExtra("type", -1);
			if (type == 1) {// 拍照预览后返回处理
				selectedImagePaths = data
						.getStringArrayListExtra("selectedImagePaths");
				initImageDirList();// 重新加载图片
			} else if (type == 2) {// 图片集预览后处理
				// 只需要更新选中集合
				selectedImagePaths = data
						.getStringArrayListExtra("selectedImagePaths");
				adapter.setSelectedImagePathList(selectedImagePaths);
			}
			break;
		case OP_CODE_TAKE_PHOTO:
			// Uri uri =null;
			// if(data.getData()!=null){
			// uri = data.getData();
			// }else{
			// uri = Uri.fromFile(new File(photoFilePath));
			// }
			if (selectedImagePaths == null) {
				selectedImagePaths = new ArrayList<>();
			}
			selectedImagePaths.add(photoFilePath);
			getContentResolver().insert(IMAGE_URI, contentValues);
			openPreviewActivity(OP_CODE_TAKE_PHOTO, 0, selectedImagePaths);

			break;
		default:
			break;
		}
	}

	private String photoFilePath;
	private ContentValues contentValues;

	public static final Uri IMAGE_URI = MediaStore.Images.Media.EXTERNAL_CONTENT_URI;

	@Override
	public void onPhotoButtonPressed() {
		Intent cameraintent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
		// 指定调用相机拍照后照片的储存路径
		// 系统时间
		long dateTaken = System.currentTimeMillis();
		// 图像名称
		String filename = DateFormat.format("yyyyMMddkkmmss", dateTaken)
				.toString() + ".jpg";
		photoFilePath = PATH + filename;
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

	@Override
	public void onImageCheckedChanged() {
		updateBtnDisplay();
	}

	private void updateBtnDisplay() {
		// 单选按钮发生变化，改变确定按钮的数字显示
		if (selectedImagePaths.size() == 0) {
			btn_sure.setEnabled(false);
			btn_preview.setEnabled(false);
			// btn_sure.setText("确定");
		} else {
			btn_preview.setEnabled(true);
			btn_sure.setEnabled(true);
			btn_sure.setText("确定(" + selectedImagePaths.size() + "/"
					+ PhotoMainAdapter.MAX_SELECT_PHOTO_NUM + ")");
		}
	}

	@Override
	public void onImageClicked(int position) {
		openPreviewActivity(OP_CODE_PREVIEW_PHOTO, position, list);
	}

}
