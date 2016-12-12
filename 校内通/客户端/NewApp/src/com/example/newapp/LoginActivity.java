package com.example.newapp;

import org.apache.http.Header;

import android.content.Intent;
import android.view.View;

import com.daimajia.androidanimations.library.Techniques;
import com.daimajia.androidanimations.library.YoYo;
import com.example.app.Constant.URL;
import com.example.app.GlobalContext;
import com.example.baserbean.GradeBean;
import com.example.baserbean.UserInfoBean;
import com.example.baserbean.UserInfoResBean;
import com.example.baserbean.UserLoginReqBean;
import com.example.bean.CommonResultResBean;
import com.example.util.ConfigUtil;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.MD5Util;
import com.example.util.TipUtil;
import com.lidroid.xutils.view.annotation.ContentView;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.lidroid.xutils.view.annotation.event.OnClick;
import com.rengwuxian.materialedittext.MaterialEditText;
import com.rengwuxian.materialedittext.validation.RegexpValidator;
import com.rey.material.widget.Button;

@ContentView(R.layout.activity_login)
public class LoginActivity extends BaseActivity {

	@ViewInject(R.id.phoneEditText)
	MaterialEditText phoneEditText;
	@ViewInject(R.id.RegistTxt)
	MaterialEditText registText;
	@ViewInject(R.id.pwdEditText)
	MaterialEditText pwdEditText;
	@ViewInject(R.id.loginBtn)
	Button loginBtn;

	@Override
	protected void onResume() {
		super.onResume();
		if (GlobalContext.getInstance().getUserInfo() != null) {
			phoneEditText.setText(GlobalContext.getInstance().getUserInfo()
					.getTelephone());
			pwdEditText.requestFocus();
		}
	}

	@OnClick(R.id.loginBtn)
	void login(View v) {

		final UserLoginReqBean bean = new UserLoginReqBean();
		boolean isPhone = phoneEditText.validateWith(new RegexpValidator(
				"请输入正确格式的电话号码", "\\d{11}"));
		if (!isPhone) {
			YoYo.with(Techniques.Shake).playOn(phoneEditText);
			return;
		}

		showLoadingView();

		bean.setTelephone(phoneEditText.getText().toString());
		String pwd = pwdEditText.getText().toString();
		bean.setPassword(MD5Util.MD5(pwd));
		HttpUtil.post(URL.LOGIN, bean,
				new HttpBeanCallBack<CommonResultResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {
						hideLoadingView();
					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							CommonResultResBean responseBean) {

						switch (responseBean.getResult()) {
						case 0:// 用户名不存在
							phoneEditText.setError("账号不存在");
							hideLoadingView();
							break;
						case 1:// 密码错误
							pwdEditText.setError("密码错误");
							hideLoadingView();
							break;
						case 3:// 登录成功
							getUserInfo(bean);
							break;
						default:
							TipUtil.show("连接服务器失败，请重试");
							hideLoadingView();
							break;
						}
					}

				});

	}
/**
 * 注册
 */
	@OnClick(R.id.RegistTxt)
	void regist(View v){
		Intent intent = new Intent(LoginActivity.this,
				ActiveActivity.class);
		startActivity(intent);
		
	}
	/**
	 * 去服务器获取用户信息
	 */
	protected void getUserInfo(final UserLoginReqBean bean) {
		HttpUtil.post(URL.USER_INFO, bean,
				new HttpBeanCallBack<UserInfoResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {
						hideLoadingView();

					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							UserInfoResBean responseBean) {
						hideLoadingView();
						// 直接获取用户数据
						TipUtil.show("登录成功");
						GradeBean grade=new GradeBean();
						grade.setGradeId(responseBean.getGrade().getGradeId());
						TipUtil.show(responseBean.getGrade().getGradeId().toString());
						grade.setGradeName(responseBean.getGrade().getGradeName());
						TipUtil.show(responseBean.getGrade().getGradeName().toString());
						UserInfoBean info = new UserInfoBean(responseBean.getUserId(),
								responseBean.getName(), responseBean.getGender(), responseBean.getAge(), 
								responseBean.getBirthday(), responseBean.getAddress(), responseBean.getTelephone(),
								responseBean.getPhotoUrl(),bean.getPassword(),grade);
						info.setToken(responseBean.getToken());
						
						GlobalContext.getInstance().setUserInfo(info);
						ConfigUtil.setLoginSuccess(true);
						// 跳转到主页面
						GlobalContext.getInstance().openIMService();
						Intent intent = new Intent(context, MainActivity.class);
						startActivity(intent);
						finish();

					}
				});

	}

}
