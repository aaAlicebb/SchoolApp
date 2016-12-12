package com.example.newapp;

import java.util.ArrayList;
import java.util.List;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.view.View;

import com.example.Fragement.MainBBSFragment;
import com.example.Fragement.MainCenterFragment;
import com.example.Fragement.MainHomeFragment;
import com.example.Fragement.MainMessageFragment;
import com.lidroid.xutils.view.annotation.ContentView;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.lidroid.xutils.view.annotation.event.OnClick;
import com.readystatesoftware.systembartint.SystemBarTintManager;

@ContentView(R.layout.activity_main)
public class MainActivity extends BaseActivity {
	
//	@ViewInject(R.id.mainToolbar)
//	Toolbar mainToolBar;
	@ViewInject(R.id.pager)
	ViewPager pager;
	@ViewInject(R.id.homeTab)
	View homeTab;
	@ViewInject(R.id.bbsTab)
	View bbsTab;
	@ViewInject(R.id.msgTab)
	View msgTab;
	@ViewInject(R.id.centerTab)
	View centerTab;
	
//	List<Fragment> fragments = new ArrayList<Fragment>(4);
	List<View> tabs = new ArrayList<View>(4);
	View selectedTab;
	
	MainHomeFragment homeFrag; 
	MainBBSFragment bbsFrag; 
	MainMessageFragment msgFrag; 
	MainCenterFragment centerFrag; 
	
	public void refreshHomeFragment(){
		//homeFrag.refreshData();
		tabSelect(0);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		 // 创建状态栏的管理实例  
	    SystemBarTintManager tintManager = new SystemBarTintManager(this);  
	    // 激活状态栏设置  
	    tintManager.setStatusBarTintEnabled(true);  
	    // 激活导航栏设置  
	    tintManager.setNavigationBarTintEnabled(true);  
	 // 设置一个颜色给系统栏  
	    tintManager.setTintColor(getResources().getColor(R.color.colorPrimaryDark));  
	    // 设置一个样式背景给导航栏  
//	    tintManager.setNavigationBarTintResource(R.drawable.my_tint);  
	    // 设置一个状态栏资源  
//	    tintManager.setStatusBarTintDrawable(MyDrawable);
//		fragments.add(new MainHomeFragment());
//		fragments.add(new MainBBSFragment());
//		fragments.add(new MainMessageFragment());
//		fragments.add(new MainCenterFragment());
		tabs.add(homeTab);
		tabs.add(bbsTab);
		tabs.add(msgTab);
		tabs.add(centerTab);
		
		pager.setAdapter(new ViewPagerAdapter(this.getSupportFragmentManager()));
		pager.setOffscreenPageLimit(4);
		selectedTab = homeTab;
		tabSelect(0);
		
		
	}
	
	@Override
	protected void initListener() {
		super.initListener();
		pager.setOnPageChangeListener(new OnPageChangeListener() {
			
			@Override
			public void onPageSelected(int index) {
				selectedTab.setSelected(false);
				tabs.get(index).setSelected(true);
				selectedTab = tabs.get(index);
			}
			
			@Override
			public void onPageScrolled(int arg0, float arg1, int arg2) {
			}
			
			@Override
			public void onPageScrollStateChanged(int arg0) {
			}
		});
	}
	
	@OnClick(R.id.homeTab)
	void homeTabClick(View v){
		tabSelect(0);
	}
	@OnClick(R.id.bbsTab)
	void bbsTabClick(View v){
		tabSelect(1);
	}
	@OnClick(R.id.msgTab)
	void msgTabClick(View v){
		tabSelect(2);
	}
	@OnClick(R.id.centerTab)
	void centerTabClick(View v){
		tabSelect(3);
	}
	
	void tabSelect(int index){
		selectedTab.setSelected(false);
		tabs.get(index).setSelected(true);
		selectedTab = tabs.get(index);
		pager.setCurrentItem(index, true);
	}
	
	private class ViewPagerAdapter extends FragmentPagerAdapter {

		public ViewPagerAdapter(FragmentManager fm) {
			super(fm);
			
		}
		

		@Override
		public Fragment getItem(int position) {
			Fragment f = null;
			switch (position) {
			case 0:
				if(homeFrag==null)
					homeFrag = new MainHomeFragment();
				f = homeFrag;
				break;
			case 1:
				if(bbsFrag==null)
					bbsFrag = new MainBBSFragment();
				f = bbsFrag;
				break;
			case 2:
				if(msgFrag==null)
					msgFrag = new MainMessageFragment();
				f = msgFrag;
				break;
			case 3:
				if(centerFrag==null)
					centerFrag = new MainCenterFragment();
				f = centerFrag;
				break;

			}
			return f;
		}

		@Override
		public int getCount() {
			return 4;
		}

		@Override
		public CharSequence getPageTitle(int position) {
			return null;
		}
	}
	
	
}
