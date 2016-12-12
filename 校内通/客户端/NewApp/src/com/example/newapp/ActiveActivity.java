package com.example.newapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;

import com.example.Fragement.ActiveValidationFragment;
import com.example.Fragement.ActiveWriteInfoFragment;
import com.example.baserbean.UserActiveVerifyResBean;
import com.lidroid.xutils.view.annotation.ContentView;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.rey.material.app.ToolbarManager;

@ContentView(R.layout.activity_active)
public class ActiveActivity extends BaseActivity {

	@ViewInject(R.id.mainToolbar)
	Toolbar mainToolbar;

	private ToolbarManager mToolbarManager;
	
	public UserActiveVerifyResBean activeResBean;
	

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		mToolbarManager = new ToolbarManager(this, mainToolbar, 0,
				R.style.ToolbarRippleStyle, R.anim.abc_fade_in,
				R.anim.abc_fade_out);
		mainToolbar.setTitle("立即注册");
		setSupportActionBar(mainToolbar);
		// mainToolbar.setl
		// mainToolbar.setna
		
		FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
		ActiveValidationFragment validate = new ActiveValidationFragment();
//		Bundle b = new Bundle();
//		b.putString("StuNum", getIntent().getStringExtra("StuNum"));
//		validate.setArguments(b);
		ft.replace(R.id.content, validate);
		ft.commit();

	}


//	public void go2ConfirmFragment() {
//		FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
//		ActiveConfirmFragment confirm = new ActiveConfirmFragment();
//		ft.replace(R.id.content, confirm);
//		ft.addToBackStack(null);
//		ft.commit();
//	}
//	
	ActiveWriteInfoFragment writeInfoFragment;
	
	public void go2WriteInfoFragment(String telephone) {
		FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
		writeInfoFragment = new ActiveWriteInfoFragment();
		Bundle b = new Bundle();
		b.putString("telephone", telephone);
		writeInfoFragment.setArguments(b);
		ft.replace(R.id.content, writeInfoFragment);
		ft.addToBackStack(null);
		ft.commit();
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case android.R.id.home:
			if (getSupportFragmentManager().getBackStackEntryCount()==0) {
				finish();
			}else{
				getSupportFragmentManager().popBackStackImmediate();
			}
			break;

		default:
			break;
		}
		return super.onOptionsItemSelected(item);
	}
	
	public String avatarPath;
	
	@Override
	protected void onNewIntent(Intent intent) {
		super.onNewIntent(intent);
		avatarPath = intent.getStringExtra("avatarPath");
		writeInfoFragment.displayPhoto();
	}

}
