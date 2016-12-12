package com.example.newapp;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.View;

import com.example.app.GlobalContext;
import com.example.app.StuInfoBean;
import com.example.baserbean.UserInfoBean;
import com.lidroid.xutils.ViewUtils;
import com.readystatesoftware.systembartint.SystemBarTintManager;
import com.umeng.analytics.MobclickAgent;

public class BaseActivity extends ActionBarActivity {

	 //@ViewInject(R.id.loadingView)
	View loadingLayout;
	 public Context context;
	 protected UserInfoBean userInfo;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		ViewUtils.inject(this);
		context = this;
		loadingLayout = findViewById(R.id.loadingLayout);
		userInfo = GlobalContext.getInstance().getUserInfo();
//		loadingLayout = findViewById(R.id.loadingLayout);
//		 if (loadingLayout != null)
//		 loadingLayout.setVisibility(View.GONE);
		initView();
		// create our manager instance after the content view is set
		SystemBarTintManager tintManager = new SystemBarTintManager(this);
		// enable status bar tint
		tintManager.setStatusBarTintEnabled(true);
		// enable navigation bar tint
		tintManager.setNavigationBarTintEnabled(true);
		tintManager.setTintColor(getResources().getColor(
				R.color.colorPrimaryDark));
		initData();
		initListener();
	}

	protected void initView() {
	};

	protected void initData() {
	};

	protected void initListener() {
	};

	public void showLoadingView() {
		loadingLayout.setVisibility(View.VISIBLE);
	}

	public void hideLoadingView() {
		loadingLayout.setVisibility(View.GONE);
	}

	@Override
	protected void onResume() {
		super.onResume();
		MobclickAgent.onResume(this);
	}

	@Override
	protected void onPause() {
		super.onPause();
		MobclickAgent.onPause(this);
	}

}
