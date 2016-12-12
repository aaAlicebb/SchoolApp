package com.example.app;

import io.rong.imkit.RongContext;
import io.rong.imkit.RongIM;
import io.rong.imlib.RongIMClient;
import io.rong.imlib.ipc.RongExceptionHandler;
import io.rong.message.RichContentMessage;
import android.app.ActivityManager;
import android.app.Application;
import android.content.Context;
import android.util.Log;

import com.example.baserbean.UserInfoBean;
import com.example.common.im.RongCloudEvent;
import com.example.util.ConfigUtil;
import com.example.util.JsonUtil;
import com.example.util.TipUtil;
import com.lidroid.xutils.DbUtils;

public class GlobalContext extends Application {

	private static GlobalContext instance;

	private UserInfoBean userInfo;


	private DbUtils dbUtils;
	
	public static GlobalContext getInstance() {
		return instance;
	}

	@Override
	public void onCreate() {
		super.onCreate();
		instance = this;
		dbUtils = (DbUtils.create(this));
		userInfo = JsonUtil.parseObject(ConfigUtil.getUserInfo(),
				UserInfoBean.class);
		 /**
         * 注意：
         *
         * IMKit SDK调用第一步 初始化
         *
         * context上下文
         *
         * 只有两个进程需要初始化，主进程和 push 进程
         */
            /**c
             * 融云SDK事件监听处理
             *
             * 注册相关代码，只需要在主进程里做。
             */
            if (getApplicationInfo().packageName.equals(getCurProcessName(getApplicationContext()))) {

            	if (getApplicationInfo().packageName.equals(getCurProcessName(getApplicationContext())) ||
                        "io.rong.push".equals(getCurProcessName(getApplicationContext()))) {

                    /**
                     * IMKit SDK调用第一步 初始化
                     */
                    RongIM.init(this);
                    RongCloudEvent.init(this);
                
                }
    
            }
        }
	public boolean IMServiceOpened = false;

	public void openIMService() {
		if (getApplicationInfo().packageName.equals(GlobalContext.getCurProcessName(getApplicationContext()))) {

		if (userInfo.getToken() != null) {
			TipUtil.show(userInfo.getToken().toString());
			/**
			 * IMKit SDK调用第二步，建立与服务器的连接
			 */
			if (!IMServiceOpened) {
				RongIM.connect(userInfo.getToken(),
						new RongIMClient.ConnectCallback() {

							@Override
							public void onSuccess(String userId) {
								// Connect 成功
								TipUtil.show("即时通讯服务开启成功--userid--" + userId);
								IMServiceOpened = true;
							}

							@Override
							public void onError(RongIMClient.ErrorCode error) {
								// Connect 失败
								TipUtil.show("即时通讯服务开启失败--" + error);
								IMServiceOpened = false;
							}

							@Override
							public void onTokenIncorrect() {
								// TODO Auto-generated method stub
								 Log.d("LoginActivity", "--onTokenIncorrect");
							}
						});
			}

		}
		}
	}
	public static String getCurProcessName(Context context) {
        int pid = android.os.Process.myPid();
        ActivityManager activityManager = (ActivityManager) context
                .getSystemService(Context.ACTIVITY_SERVICE);
        for (ActivityManager.RunningAppProcessInfo appProcess : activityManager
                .getRunningAppProcesses()) {
            if (appProcess.pid == pid) {
                return appProcess.processName;
            }
        }
        return null;
    }


	public UserInfoBean getUserInfo() {
		return userInfo;
	}

	public void setUserInfo(UserInfoBean userInfo) {
		this.userInfo = userInfo;
		ConfigUtil.setUserInfo(JsonUtil.toJsonString(userInfo));
	}

	public DbUtils getDbUtils() {
		return dbUtils;
	}


}
