package com.example.util;

/**
 * 所有设置的存取的工具类 将sharedprefrence里的所有配置信息都用getter和setter形式来封装提供给其他类的使用
 * 虽然这样做会使得这个类编写的很繁琐 不过这样做会很规范，统一管理配置信息
 * 
 * 
 */
public class ConfigUtil {

	public static int getVersionCode() {
		return SPUtil.getInt("version_code", -1);
	}

	public static void setVersionCode(int versionCode) {
		SPUtil.saveInt("version_code", versionCode);
	}

	// public static String getDeviceToken(){
	// return SPUtil.getString("device_token");
	// }
	//
	// public static void setDeviceToken(String token){
	// SPUtil.saveString("device_token", token);
	// }

	/**
	 * app是否是第一次打开
	 * 
	 * @return
	 */
	public static boolean isFirstStart() {
		boolean flag = SPUtil.getBoolean("first_start", true);
		if (flag)
			SPUtil.saveBoolean("first_start", false);
		return flag;

	}

	public static boolean isLoginSuccess() {
		return SPUtil.getBoolean("login_success", false);
	}

	public static void setLoginSuccess(boolean success) {
		SPUtil.saveBoolean("login_success", success);
	}

	public static String getUserInfo() {
		return SPUtil.getString("user_info");
	}

	public static void setUserInfo(String info) {
		SPUtil.saveString("user_info", info);
	}

	public static String getChildInfo() {
		return SPUtil.getString("child_info");
	}

	public static void setChildInfo(String info) {
		SPUtil.saveString("child_info", info);
	}

	public static void setContactInfos(String infos) {
		SPUtil.saveString("contact_infos", infos);
	}

	public static String getContactInfos() {
		return SPUtil.getString("contact_infos");
	}
	
	public static String getRootUrl(){
		return SPUtil.getString("rootUrl");
	}
	
	public static void setRootUrl(String url){
		 SPUtil.saveString("rootUrl", url);
	}
}
