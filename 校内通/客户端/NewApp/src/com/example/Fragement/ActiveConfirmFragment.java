//package com.example.Fragement;
//
//import java.util.ArrayList;
//import java.util.List;
//
//import Studentbean.StuActiveVerifyResBean;
//import android.os.Bundle;
//import android.view.LayoutInflater;
//import android.view.View;
//import android.view.ViewGroup;
//
//import com.example.adapter.CommonAdapter;
//import com.example.adapter.ViewHolder;
//import com.example.common.view.NoScrollListView;
//import com.example.newapp.ActiveActivity;
//import com.example.newapp.R;
//import com.lidroid.xutils.view.annotation.ViewInject;
//import com.lidroid.xutils.view.annotation.event.OnClick;
//import com.rey.material.widget.Button;
//import com.rey.material.widget.TextView;
//
//public class ActiveConfirmFragment extends BaseFragment{
//	
//	@ViewInject(R.id.nameTextView)
//	TextView nameTextView;
//	@ViewInject(R.id.phTextView)
//	TextView phoneTextView;
//	@ViewInject(R.id.schoolTextView)
//	TextView schoolTextView;
//	@ViewInject(R.id.childListView)
//	NoScrollListView childListView;
//	@ViewInject(R.id.confirmBtn)
//	Button confirmBtn;
//	StuActiveVerifyResBean activeResBean ;
//
//	@Override
//	public View initView(LayoutInflater inflater, ViewGroup container,
//			Bundle savedInstanceState) {
//		return inflater.inflate(R.layout.fragment_active_confirm, null);
//	}
//	
//	@OnClick(R.id.confirmBtn)
//	void active(View v){
//		main.go2WriteInfoFragment();
//	}
//	
//	ActiveActivity main;
//	
//	@Override
//	protected void initData() {
//		 main = (ActiveActivity) context;
//		activeResBean = main.activeResBean;
//		nameTextView.setText(activeResBean.getName());
//		phoneTextView.setText(activeResBean.getStuNum());
//		schoolTextView.setText(activeResBean.getSchool());
//	}
//
//}
