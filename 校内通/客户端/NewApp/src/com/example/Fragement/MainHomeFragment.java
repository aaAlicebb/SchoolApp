
package com.example.Fragement;

import java.util.ArrayList;
import java.util.List;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.common.view.SlidingTabLayout;
import com.example.newapp.R;
import com.github.ksoichiro.android.observablescrollview.CacheFragmentStatePagerAdapter;
import com.lidroid.xutils.view.annotation.ViewInject;

public class MainHomeFragment extends BaseFragment {

	@ViewInject(R.id.sliding_tabs)
	SlidingTabLayout slidingTabLayout;
	@ViewInject(R.id.pager)
	ViewPager pager;
	//SchoolNoticeFragment mConversationFragment;
	//SchoolNoticeFragment mContactFragment;
private NavigationAdapter mPagerAdapter;
	
	public static MainHomeFragment instance; 

	private List<Fragment> fragments = new ArrayList<>(3);
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		instance = this;
	}

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_main_home, null);
	}
	
	
	

	@Override
	protected void initData() {
		super.initData();
		mPagerAdapter = new NavigationAdapter(getChildFragmentManager());
		pager.setAdapter(mPagerAdapter);
		initIndicator();
	}

	private void initIndicator() {
		slidingTabLayout.setCustomTabView(R.layout.tab_indicator,
				android.R.id.text1);
		slidingTabLayout.setSelectedIndicatorColors(getResources().getColor(
				R.color.colorAccent));
		slidingTabLayout.setDistributeEvenly(true);
		slidingTabLayout.setViewPager(pager);

	}
	
	 private Fragment getCurrentFragment() {
	        return mPagerAdapter.getItemAt(pager.getCurrentItem());
	    }

	private static class NavigationAdapter extends
			CacheFragmentStatePagerAdapter {

		private static final String[] TITLES = new String[] { "通知公告", "班级通知",
				"课程表" };

		public NavigationAdapter(FragmentManager fm) {
			super(fm);
		}

		@Override
		protected Fragment createItem(int position) {
			Fragment f = null;
			switch (position) {
			case 0:
				f = new SchoolNoticeFragment();
				break;
			case 1:
				f = new SchoolNoticeFragment();
				break;
			case 2:
				f = new CourseFragment();
				break;
			}
			return f;
		}

		@Override
		public int getCount() {
			return TITLES.length;
		}

		@Override
		public CharSequence getPageTitle(int position) {
			return TITLES[position];
		}
	}

}
