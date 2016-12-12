package com.example.Fragement;


import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import org.apache.http.Header;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;

import com.example.adapter.ContactAdapter;
import com.example.app.Constant.URL;
import com.example.bean.im.ContactBean;
import com.example.bean.im.ContactListReqBean;
import com.example.bean.im.ContactListResBean;
import com.example.common.im.IMDataCache;
import com.example.common.view.SideBar;
import com.example.common.view.SideBar.OnTouchingLetterChangedListener;
import com.example.newapp.R;
import com.example.util.CharacterParser;
import com.example.util.ConfigUtil;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.JsonUtil;
import com.example.util.TipUtil;
import com.lidroid.xutils.view.annotation.ViewInject;

public class ContactFragment extends BaseFragment {

	@ViewInject(R.id.tipTextView)
	TextView tipTextView;
	@ViewInject(R.id.sideBar)
	SideBar sideBar;
	@ViewInject(R.id.listView)
	ListView listView;

	/**
	 * 汉字转换成拼音的类
	 */
	private CharacterParser characterParser;
	private List<ContactBean> mDatas;
	private ContactAdapter mAdapter;

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_contact, null);
	}

	@Override
	protected void initData() {
		super.initData();
		// 实例化汉字转拼音类
		characterParser = CharacterParser.getInstance();
		sideBar.setTextView(tipTextView);
		// 设置右侧触摸监听
		sideBar.setOnTouchingLetterChangedListener(new OnTouchingLetterChangedListener() {

			@SuppressLint("NewApi")
			@Override
			public void onTouchingLetterChanged(String s) {
				// 该字母首次出现的位置
				int position = mAdapter.getPositionForSection(s.charAt(0));
				if (position != -1) {
					listView.setSelection(position);
				}
			}
		});
		loadContact();

	}
	
	

	private void loadContact() {
		showLoadingView();
		ContactListReqBean bean = new ContactListReqBean();
		bean.setPersonId(userInfo.getUserId());
		TipUtil.show(userInfo.getUserId().toString());
		bean.setPersonType(2);
		bean.setTelephone(userInfo.getTelephone());
		HttpUtil.post(URL.GROUP_CONTACT_LIST, bean, new HttpBeanCallBack<ContactListResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				hideLoadingView();
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					ContactListResBean responseBean) {
				hideLoadingView();
				mDatas = responseBean.getContactBeans();
				fillLetters(mDatas);
				// 根据a-z进行排序源数据
				Collections.sort(mDatas, new PinyinComparator());
				IMDataCache.getInstance().setUserInfos(mDatas);
				String infos = JsonUtil.toJsonString(mDatas);
				ConfigUtil.setContactInfos(infos);
				((MainMessageFragment)getParentFragment()).refreshConversationFrag();
				mAdapter = new ContactAdapter(context, mDatas);
				listView.setAdapter(mAdapter);
			}
		});
		
	}



	protected void fillLetters(List<ContactBean> data) {
		for (int i = 0; i < data.size(); i++) {
			ContactBean bean = data.get(i);
			if(bean.getType() == 0){//如果是群组
				bean.setSortLetters("群");
				continue;
			}
			// 汉字转换成拼音
			String pinyin = characterParser.getSelling(bean.getName());
			String sortString = pinyin.substring(0, 1).toUpperCase();

			// 正则表达式，判断首字母是否是英文字母
			if (sortString.matches("[A-Z]")) {
				bean.setSortLetters(sortString.toUpperCase());
			} else {
				bean.setSortLetters("#");
			}
		}
	}



	class PinyinComparator implements Comparator<ContactBean> {

		public int compare(ContactBean o1, ContactBean o2) {
			if (o1.getSortLetters().equals("群")
					|| o2.getSortLetters().equals("#")) {
				return -1;
			} else if (o1.getSortLetters().equals("#")
					|| o2.getSortLetters().equals("群")) {
				return 1;
			} else {
				return o1.getSortLetters().compareTo(o2.getSortLetters());
			}
		}

	}

}
