package com.example.Fragement;

import java.text.SimpleDateFormat;
import java.util.Date;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.newapp.LoginActivity;
import com.example.newapp.R;
import com.example.util.ImageLoaderHelper;
import com.example.util.ImageLoaderHelper.ImageLoadingType;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.lidroid.xutils.view.annotation.event.OnClick;
import com.makeramen.roundedimageview.RoundedImageView;

public class MainCenterFragment extends BaseFragment {
	
	@ViewInject(R.id.avatarImageView)
	RoundedImageView avatarImageView;
	@ViewInject(R.id.nameTextView)
	TextView nameTextView;
	@ViewInject(R.id.birthdayTxt)
	TextView birthdayTextView;
	@ViewInject(R.id.addressTxt)
	TextView addressTextView;


	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_main_center, null);
	}
	
	@Override
	protected void initListener() {
		super.initListener();
	}
	@OnClick(R.id.logoutBtn)
	void logout(View v){
		Intent intent = new Intent(context,LoginActivity.class);
		intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK|Intent.FLAG_ACTIVITY_SINGLE_TOP);
		startActivity(intent);
		getActivity().finish();
	}
	
	@Override
	protected void initData() {
		super.initData();
		ImageLoaderHelper.displayImage(userInfo.getPhotoUrl(), avatarImageView,
				ImageLoadingType.AVATAR);
		nameTextView.setText(userInfo.getName());
		Date date = new Date();
		String dateStr = new SimpleDateFormat("yyyy-MM-dd").format(userInfo.getBirthday());
		birthdayTextView.setText("生日："+dateStr);
		addressTextView.setText("地址："+userInfo.getAddress());
		
	}
	

}
