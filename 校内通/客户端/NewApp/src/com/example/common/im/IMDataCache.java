package com.example.common.im;

import java.util.List;

import android.content.Context;
import android.text.TextUtils;

import com.example.bean.im.ContactBean;
import com.example.util.ConfigUtil;
import com.example.util.JsonUtil;

public class IMDataCache {

	private static IMDataCache mInstance;

	private Context mContext;

	private List<ContactBean> mUserInfos;
	private List<ContactBean> mFriendInfos;

	public static IMDataCache getInstance() {

		if (mInstance == null) {

			synchronized (IMDataCache.class) {

				if (mInstance == null) {
					mInstance = new IMDataCache();
				}
			}
		}
		return mInstance;
	}

	private IMDataCache() {
		String infos = ConfigUtil.getContactInfos();
		mUserInfos = JsonUtil.parseObjectList(infos, ContactBean.class);
	}

	public List<ContactBean> getUserInfos() {
		return mUserInfos;
	}

	public void setUserInfos(List<ContactBean> userInfos) {
		mUserInfos = userInfos;
	}

	/**
	 * 临时存放用户数据
	 *
	 * @param userInfos
	 */
	public void setFriends(List<ContactBean> userInfos) {

		this.mFriendInfos = userInfos;
	}

	public List<ContactBean> getFriends() {
		return mFriendInfos;
	}

	/**
	 * 获取用户信息
	 *
	 * @param userId
	 * @return
	 */
	public ContactBean getUserInfoById(String userId) {

		ContactBean userInfoReturn = null;

		if (!TextUtils.isEmpty(userId) && mUserInfos != null) {
			for (ContactBean userInfo : mUserInfos) {

				if (userInfo.getType() == 1 && userId.equals(userInfo.getId())) {
					userInfoReturn = userInfo;
					break;
				}

			}
		}
		return userInfoReturn;
	}

	/**
	 * 获取群组信息
	 *
	 * @param userId
	 * @return
	 */
	public ContactBean getGroupInfoById(String groupId) {

		ContactBean userInfoReturn = null;

		if (!TextUtils.isEmpty(groupId) && mUserInfos != null) {
			for (ContactBean userInfo : mUserInfos) {
				if (userInfo.getType() == 0 && groupId.equals(userInfo.getId())) {
					userInfoReturn = userInfo;
					break;
				}

			}
		}
		return userInfoReturn;
	}

}
