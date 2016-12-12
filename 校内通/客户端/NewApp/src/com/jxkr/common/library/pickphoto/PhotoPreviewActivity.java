package com.jxkr.common.library.pickphoto;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.animation.AlphaAnimation;
import android.view.animation.Animation;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.example.newapp.R;
import com.jxkr.common.library.pickphoto.ImageLoader.Type;

public class PhotoPreviewActivity extends Activity implements OnClickListener {

	ExtendedViewPager mViewPager;
	View ll_comm_topbar;
	View ll_comm_bottombar;
	View cancelBtn;
	Button sureBtn;
	TextView tv_image_num;
	ImageView select_cb;
	Animation alphaInAnimation = new AlphaAnimation(0f, 1f);
	Animation alphaOutAnimation = new AlphaAnimation(1f, 0f);

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.photo_preview);
		alphaInAnimation.setDuration(400);
		alphaOutAnimation.setDuration(400);
		initViews();
		initEvents();
		initData();
	}

	private List<String> allImagePaths;
	private ArrayList<String> newImagePaths = new ArrayList<String>();;
	private TouchImageAdapter imageAdapter;
	private int maxSelectImageNum;
	private boolean isFullScreen = false;
	private int mOpenType;
	public static final int OPEN_TYPE_ONE_PHOTO = 1;
	public static final int OPEN_TYPE_MENY_PHOTO = 2;
	public static final int OPEN_TYPE_PREVIEW_SELECTED_PHOTO = 3;
	String activityClass;

	private void initData() {
		Intent intent = getIntent();
		mOpenType = intent.getIntExtra("openType", 2);
		newImagePaths = intent.getStringArrayListExtra("selectedImagePaths");
		if (newImagePaths == null) {
			newImagePaths = new ArrayList<>(4);
		}
		allImagePaths = intent.getStringArrayListExtra("allImagePaths");
		maxSelectImageNum = intent.getIntExtra("maxSelectImageNum", 1000);
		activityClass = intent.getStringExtra("activityClass");
		int position = intent.getIntExtra("position", 0);
		imageAdapter = new TouchImageAdapter();
		mViewPager.setAdapter(imageAdapter);
		mViewPager.setCurrentItem(position);
		updateSureBtn();
		select_cb.setSelected(newImagePaths.contains(allImagePaths
				.get(position)));
		tv_image_num.setText(mViewPager.getCurrentItem() + 1 + "/"
				+ allImagePaths.size());
	}

	private void initEvents() {
		mViewPager.setOnPageChangeListener(new OnPageChangeListener() {

			@Override
			public void onPageSelected(int position) {
				tv_image_num.setText((position + 1) + "/"
						+ allImagePaths.size());
				select_cb.setSelected(newImagePaths.contains(allImagePaths
						.get(position)));
			}

			@Override
			public void onPageScrolled(int arg0, float arg1, int arg2) {

			}

			@Override
			public void onPageScrollStateChanged(int arg0) {

			}
		});

		select_cb.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				int position = mViewPager.getCurrentItem();
				String imagePath = allImagePaths.get(position);
				boolean flag = newImagePaths.contains(imagePath);
				if (!flag && !isSelectPhotoFull()) {
					newImagePaths.add(imagePath);
					select_cb.setSelected(true);
				} else if (flag) {
					newImagePaths.remove(imagePath);
					select_cb.setSelected(false);
				}
				updateSureBtn();
			}
		});

		cancelBtn.setOnClickListener(this);
		sureBtn.setOnClickListener(this);
	}

	protected void updateSureBtn() {
		sureBtn.setText("确定(" + newImagePaths.size() + "/" + maxSelectImageNum
				+ ")");
	}

	/**
	 * 是否可选择的图片已满
	 * 
	 * @return
	 */
	protected boolean isSelectPhotoFull() {
		if (newImagePaths.size() == maxSelectImageNum) {
			Toast.makeText(this, "可选择图片数量不能超过" + maxSelectImageNum + "张",
					Toast.LENGTH_SHORT).show();
			return true;
		}
		return false;
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.topbar_left_btn:
			onBackAction();
			break;
		case R.id.topbar_right_btn:
			Intent intent;
			try {
				intent = new Intent(this, Class.forName(activityClass));
				intent.putStringArrayListExtra("selectedImagePaths", newImagePaths);
				intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP
						| Intent.FLAG_ACTIVITY_SINGLE_TOP);
				startActivity(intent);
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
			
			break;
		default:
			break;
		}

	}

	private void onBackAction() {
		Intent intent = new Intent();
		intent.putExtra("type", mOpenType);
		intent.putStringArrayListExtra("selectedImagePaths", newImagePaths);
		setResult(RESULT_OK, intent);
		finish();
	}

	@Override
	public void onBackPressed() {
		onBackAction();
	}

	private void initViews() {
		mViewPager = (ExtendedViewPager) findViewById(R.id.view_pager);
		ll_comm_topbar = findViewById(R.id.ll_comm_topbar);
		ll_comm_bottombar = findViewById(R.id.ll_comm_bottombar);
		cancelBtn = findViewById(R.id.topbar_left_btn);
		sureBtn = (Button) findViewById(R.id.topbar_right_btn);
		tv_image_num = (TextView) findViewById(R.id.tv_image_num);
		select_cb = (ImageView) findViewById(R.id.select_cb);

	}

//	SDCardImageLoader loader = new SDCardImageLoader(ScreenUtils.getScreenW(),
//			ScreenUtils.getScreenH());

	private class TouchImageAdapter extends PagerAdapter {

		ImageClickListener mClickListener = new ImageClickListener();

		@Override
		public int getCount() {
			return allImagePaths.size();
		}

		@Override
		public View instantiateItem(ViewGroup container, int position) {
			TouchImageView img = new TouchImageView(container.getContext());
			img.setOnClickListener(mClickListener);
			// img.setImageResource(images[position]);
			img.setTag(allImagePaths.get(position));
//			loader.loadImage(1, allImagePaths.get(position), img);
			 ImageLoader.getInstance(3,Type.LIFO).loadImage(allImagePaths.get(position),
			 img);

			container.addView(img, LinearLayout.LayoutParams.MATCH_PARENT,
					LinearLayout.LayoutParams.MATCH_PARENT);
			return img;
		}

		@Override
		public void destroyItem(ViewGroup container, int position, Object object) {
			container.removeView((View) object);
		}

		@Override
		public boolean isViewFromObject(View view, Object object) {
			return view == object;
		}

	}

	private class ImageClickListener implements OnClickListener {

		@Override
		public void onClick(View v) {
			if (isFullScreen) {// 显示操作栏
				ll_comm_bottombar.setVisibility(View.VISIBLE);
				ll_comm_topbar.setVisibility(View.VISIBLE);
				ll_comm_bottombar.startAnimation(alphaInAnimation);
				ll_comm_topbar.startAnimation(alphaInAnimation);
			} else {
				ll_comm_bottombar.setVisibility(View.GONE);
				ll_comm_topbar.setVisibility(View.GONE);
				ll_comm_bottombar.startAnimation(alphaOutAnimation);
				ll_comm_topbar.startAnimation(alphaOutAnimation);
			}
			isFullScreen = !isFullScreen;
		}
	}

}
