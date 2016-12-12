package com.example.common.ui;

import java.util.List;

import android.content.Intent;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.animation.AlphaAnimation;
import android.view.animation.Animation;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.example.newapp.BaseActivity;
import com.example.newapp.R;
import com.example.util.ImageLoaderHelper;
import com.jxkr.common.library.pickphoto.ExtendedViewPager;
import com.jxkr.common.library.pickphoto.TouchImageView;
import com.lidroid.xutils.view.annotation.ContentView;
import com.lidroid.xutils.view.annotation.ViewInject;

@ContentView(R.layout.activity_photo_detail)
public class PhotoDetailActivity extends BaseActivity {

	@ViewInject(R.id.view_pager)
	ExtendedViewPager mViewPager;
	@ViewInject(R.id.ll_comm_topbar)
	View ll_comm_topbar;
	@ViewInject(R.id.topbar_left_btn)
	View cancelBtn;
	@ViewInject(R.id.tv_image_num)
	TextView tv_image_num;
	Animation alphaInAnimation = new AlphaAnimation(0f, 1f);
	Animation alphaOutAnimation = new AlphaAnimation(1f, 0f);

	private boolean isFullScreen = false;
	private List<String> allImagePaths;
	private TouchImageAdapter imageAdapter;

	@Override
	protected void initView() {
		super.initView();
		alphaInAnimation.setDuration(300);
		alphaOutAnimation.setDuration(300);
		Intent intent = getIntent();
		allImagePaths = intent.getStringArrayListExtra("allImagePaths");
		int position = intent.getIntExtra("position", 0);
		imageAdapter = new TouchImageAdapter();
		mViewPager.setAdapter(imageAdapter);
		mViewPager.setCurrentItem(position);
		tv_image_num.setText(mViewPager.getCurrentItem() + 1 + "/"
				+ allImagePaths.size());
	}

	@Override
	protected void initListener() {
		super.initListener();
		mViewPager.setOnPageChangeListener(new OnPageChangeListener() {

			@Override
			public void onPageSelected(int position) {
				tv_image_num.setText((position + 1) + "/"
						+ allImagePaths.size());
			}

			@Override
			public void onPageScrolled(int arg0, float arg1, int arg2) {

			}

			@Override
			public void onPageScrollStateChanged(int arg0) {

			}
		});
		cancelBtn.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				finish();
			}
		});
	}

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
			img.setTag(allImagePaths.get(position));
			ImageLoaderHelper.displayImage(allImagePaths.get(position), img);
			// ImageLoader.getInstance(3,Type.LIFO).loadImage(allImagePaths.get(position),
			// img);

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
				ll_comm_topbar.setVisibility(View.VISIBLE);
				ll_comm_topbar.startAnimation(alphaInAnimation);
			} else {
				ll_comm_topbar.setVisibility(View.GONE);
				ll_comm_topbar.startAnimation(alphaOutAnimation);
			}
			isFullScreen = !isFullScreen;
		}
	}

}
