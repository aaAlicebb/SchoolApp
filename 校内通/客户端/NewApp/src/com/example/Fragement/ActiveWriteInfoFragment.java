package com.example.Fragement;

import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.http.Header;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.example.app.Constant.URL;
import com.example.app.GlobalContext;
import com.example.app.StuInfoBean;
import com.example.baserbean.UserActiveReqBean;
import com.example.baserbean.UserInfoBean;
import com.example.bean.CommonResultResBean;
import com.example.bean.UpTokenResBean;
import com.example.newapp.ActiveActivity;
import com.example.newapp.LoginActivity;
import com.example.newapp.R;
import com.example.util.FileLoadCallBack;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.ImageUtil;
import com.example.util.MD5Util;
import com.example.util.QiniuUtil;
import com.example.util.TipUtil;
import com.example.util.UUIDUtil;
import com.jxkr.common.library.avatar.AvatarChooseActivity;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.lidroid.xutils.view.annotation.event.OnClick;
import com.rengwuxian.materialedittext.MaterialEditText;
import com.rey.material.app.DatePickerDialog;
import com.rey.material.app.Dialog;
import com.rey.material.app.DialogFragment;

public class ActiveWriteInfoFragment extends BaseFragment {
	
	@ViewInject(R.id.photoImageView)
	ImageView photoImageView;
	@ViewInject(R.id.pwdEditText)
	MaterialEditText pwdEditText;
	@ViewInject(R.id.birthDayEditText)
	MaterialEditText birthDayEditText;
	@ViewInject(R.id.addrEditText)
	MaterialEditText addrEditText;
	@ViewInject(R.id.repwdEditText)
	MaterialEditText repwdEditText;
	@ViewInject(R.id.nickEditText)
	MaterialEditText nickEditText;
	
	Date birthDay;
	String photoUrl;
	
	ActiveActivity main; 

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_active_write_info, null);
	}
	
	@Override
	protected void initData() {
		main = (ActiveActivity) context;
	}
	
	
	@OnClick(R.id.photoImageView)
	void chooseAvatar(View v){
		Intent intent2 = new Intent(context, AvatarChooseActivity.class);
		intent2.putExtra("activityClass", getActivity().getClass().getName());
		startActivity(intent2);
	}
	
	public void displayPhoto(){
		Bitmap bitmap = ImageUtil.readBitMap(main.avatarPath);
		photoImageView.setImageBitmap(bitmap);
		//FIXME 用circleImageView会报错
//		photoImageView.setImageURI(Uri.fromFile(new File()));
//		ImageLoaderUtil.displayImage(photoImageView, main.avatarPath);
	}
	

	@OnClick(R.id.chooseDateBtn)
	void chooseBirthDay(View v) {
		Dialog.Builder builder = new DatePickerDialog.Builder() {
			@Override
			public void onPositiveActionClicked(DialogFragment fragment) {
				DatePickerDialog dialog = (DatePickerDialog) fragment
						.getDialog();
				birthDay = new Date(dialog.getDate());
				String date = dialog.getFormattedDate(SimpleDateFormat
						.getDateInstance());
				birthDayEditText.setText(date);
//				Toast.makeText(fragment.getDialog().getContext(),
//						"Date is " + date, Toast.LENGTH_SHORT).show();
				super.onPositiveActionClicked(fragment);
			}

			@Override
			public void onNegativeActionClicked(DialogFragment fragment) {
//				Toast.makeText(fragment.getDialog().getContext(), "Cancelled",
//						Toast.LENGTH_SHORT).show();
				super.onNegativeActionClicked(fragment);
			}
		}.positiveAction("确定").negativeAction("取消");
		DialogFragment fragment = DialogFragment.newInstance(builder);
        fragment.show(getFragmentManager(), null);

	}

	@OnClick(R.id.submitBtn)
	void submitData(View v) {
		String pwd = pwdEditText.getText().toString();
		String pwd2 = repwdEditText.getText().toString();
		if(!pwd2.equals(pwd)){
			repwdEditText.setError("两次密码输入不相同");
			return;
		}
		
		ActiveActivity main = (ActiveActivity) context;
		showLoadingView();
		//先上传图片
		if(!TextUtils.isEmpty(main.avatarPath)){
			getUpToken();
		}else{
			submitData();
		}
		
		
		
		
	}
	
	String upToken;
	
	private void getUpToken(){
		HttpUtil.post(URL.GET_UP_TOKEN, null, new HttpBeanCallBack<UpTokenResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				hideLoadingView();
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					UpTokenResBean responseBean) {
				upToken = responseBean.getUpToken();
				uploadAvatar();
			}
		});
	}
	
	private void uploadAvatar() {
		QiniuUtil.put(main.avatarPath, UUIDUtil.getUUID(), upToken, new FileLoadCallBack() {
			
			@Override
			public void onSuccess(String key) {
				photoUrl = URL.QINIU + key;
				submitData();
			}
			
			@Override
			public void onFailure(String errorMsg) {
				hideLoadingView();
				TipUtil.show(errorMsg);
			}
		});
		
	}


	private void submitData() {
		final String pwd = pwdEditText.getText().toString();
		
		UserActiveReqBean bean = new UserActiveReqBean();
		bean.setAddress(addrEditText.getText().toString());
		bean.setBirthday(birthDay);
		bean.setPassword(MD5Util.MD5(pwd));
		bean.setPhotoUrl(photoUrl);
		bean.setName(nickEditText.getText().toString());
		bean.setTelephone(getArguments().getString("telephone"));
		HttpUtil.post(URL.ACTIVE, bean, new HttpBeanCallBack<CommonResultResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				hideLoadingView();
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					CommonResultResBean responseBean) {
				hideLoadingView();
				if(responseBean.getResult() == 0){
					TipUtil.show("注册失败");
				}else{
				 UserInfoBean bean = new UserInfoBean();
				 bean.setAddress(addrEditText.getText().toString());
					bean.setBirthday(birthDay);
					//bean.setUserId(main.activeResBean.getUserId());
					bean.setPassword(MD5Util.MD5(pwd));
					bean.setPhotoUrl(photoUrl);
					bean.setName(nickEditText.getText().toString());
					bean.setTelephone(getArguments().getString("telephone"));
				//	bean.setGradeBean(gradeBean)
					GlobalContext.getInstance().setUserInfo(bean);
					TipUtil.show("注册成功，请登录");
					Intent intent2 = new Intent(getActivity(),
							LoginActivity.class);
					startActivity(intent2);
					getActivity().finish();
				}
				
			}
		});
	}


	

}
