package com.example.Fragement;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.app.GlobalContext;
import com.example.app.StuInfoBean;
import com.example.baserbean.UserInfoBean;
import com.example.newapp.R;
import com.lidroid.xutils.ViewUtils;

public abstract class BaseFragment extends Fragment {

	View loadingLayout;
	UserInfoBean userInfo;
	public Context context;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View view = initView(inflater, container, savedInstanceState);
		ViewUtils.inject(this, view); // 注入view和事件
		userInfo = GlobalContext.getInstance().getUserInfo();
		context = this.getActivity();
		if (view != null)
			loadingLayout = view.findViewById(R.id.loadingLayout);
		initData();
		initListener();
		return view;
	}

	public abstract View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState);

	protected void initData() {
	};

	protected void initListener() {
	};

	@Override
	public void onPause() {
		super.onPause();
	}

	public void showLoadingView() {
		loadingLayout.setVisibility(View.VISIBLE);
	}

	public void hideLoadingView() {
		loadingLayout.setVisibility(View.GONE);
	}

}
