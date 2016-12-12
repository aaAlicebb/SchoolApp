
package com.example.Fragement;

import io.rong.imkit.fragment.ConversationListFragment;
import io.rong.imlib.model.Conversation;
import android.net.Uri;
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

public class MainMessageFragment extends BaseFragment {

	@ViewInject(R.id.sliding_tabs)
	SlidingTabLayout slidingTabLayout;
	@ViewInject(R.id.pager)
	ViewPager pager;
	ConversationListFragment mConversationFragment;
	Fragment mContactFragment;
	
	NavigationAdapter mAdapter;

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_main_message, null);
	}
	
	/**
	 * 刷新会话列表
	 */
	public void refreshConversationFrag(){
			ConversationListFragment listFrag = ConversationListFragment.getInstance();
			listFrag.setUri(uri);
			mConversationFragment = listFrag;
	}
	

	@Override
	protected void initData() {
		super.initData();
		uri= Uri.parse("rong://" + context.getApplicationInfo().packageName).buildUpon()
	             .appendPath("conversationlist")
	             .appendQueryParameter(Conversation.ConversationType.PRIVATE.getName(), "false") //设置私聊会话是否聚合显示
	             .appendQueryParameter(Conversation.ConversationType.GROUP.getName(), "false")
	             .appendQueryParameter(Conversation.ConversationType.DISCUSSION.getName(), "false") //设置私聊会话是否聚合显示
	             .appendQueryParameter(Conversation.ConversationType.SYSTEM.getName(), "false") //设置私聊会话是否聚合显示
	             .appendQueryParameter(Conversation.ConversationType.PUBLIC_SERVICE.getName(), "false")
	             .appendQueryParameter(Conversation.ConversationType.APP_PUBLIC_SERVICE.getName(), "false")
	             .build();
		mAdapter = new NavigationAdapter(getChildFragmentManager());
		pager.setAdapter(mAdapter);
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
	
	 Uri uri; 
	
	private static final String[] TITLES = new String[] { "消息", "通讯录"};

	private class NavigationAdapter extends
			CacheFragmentStatePagerAdapter {

		public NavigationAdapter(FragmentManager fm) {
			super(fm);
		}

		@Override
		protected Fragment createItem(int position) {
			 Fragment fragment = null;
	            switch (position) {
	                case 0:
	                    if (mConversationFragment == null) {
	                    	mConversationFragment = ConversationListFragment.getInstance();
	                    	if(uri != null)
	                    	mConversationFragment.setUri(uri);
//	                    	mConversationFragment = new BlankFragment();
	                    } 
	                        fragment = mConversationFragment;
	                    
	                    break;
	                case 1:
	                    if (mContactFragment == null) {
	                    	mContactFragment = new ContactFragment();
	                    }

	                    fragment = mContactFragment;

	                    break;
	            }
			return fragment;
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
