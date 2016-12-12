package com.example.Fragement;

import org.apache.http.Header;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.app.Constant.URL;
import com.example.baserbean.UserActiveVerifyReqBean;
import com.example.baserbean.UserActiveVerifyResBean;
import com.example.newapp.ActiveActivity;
import com.example.newapp.LoginActivity;
import com.example.newapp.R;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.TipUtil;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.lidroid.xutils.view.annotation.event.OnClick;
import com.rengwuxian.materialedittext.MaterialEditText;
import com.rey.material.widget.Button;

public class ActiveValidationFragment extends BaseFragment {
	@ViewInject(R.id.phoneEditText)
	MaterialEditText phoneEditText;
	@ViewInject(R.id.codeEditText)
	MaterialEditText codeEditText;
	@ViewInject(R.id.validateBtn)
	Button validateBtn;
	@ViewInject(R.id.getCodeBtn)
	Button getCodeBtn;
	
	String StuNum;

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		
		return inflater.inflate(R.layout.fragment_active_validation, null);
	}
	
	/*@Override
	protected void initData() {
		telephone = getArguments().getString("telephone");
		if(!TextUtils.isEmpty(telephone)){
			phoneEditText.setText(telephone);
		}
	}
	*/
	@OnClick(R.id.getCodeBtn)
	public void getCode(Button v){
		v.setEnabled(false);
		v.setText("60s后重新获取");
	}
	
	@OnClick(R.id.validateBtn)
	public void validate(View v){
		UserActiveVerifyReqBean bean = new UserActiveVerifyReqBean();
		bean.setTelephone(phoneEditText.getText().toString());
		bean.setVerifyCode("123456");
		showLoadingView();
		HttpUtil.post(URL.ACTIVE_INFO, bean, new HttpBeanCallBack<UserActiveVerifyResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				hideLoadingView();
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					UserActiveVerifyResBean responseBean) {
				
				switch (responseBean.getResult()) {
//				case 0://帐号不存在
//					TipUtil.show("帐号不存在");
//					break;
				case 1://账号已经存在
					TipUtil.show("帐号已经存在，请直接登录");
					Intent intent = new Intent(context,LoginActivity.class);
					startActivity(intent);
					getActivity().finish();
					break;
				case 3://下一步
					
					ActiveActivity main = (ActiveActivity)context;
					main.go2WriteInfoFragment(phoneEditText
							.getText().toString());
					break;
				case 4://验证码不正确
					TipUtil.show("验证码不正确");
					break;
				}
				
				hideLoadingView();
				
			}
		});
	}
	
	

}
