package com.example.util;

import android.content.SharedPreferences;
import android.preference.PreferenceManager;

import com.example.app.GlobalContext;

/**
 * sharedpreference工具类
 * s
 * 
 */
public class SPUtil {

	private static SharedPreferences mPref = PreferenceManager
			.getDefaultSharedPreferences(GlobalContext.getInstance());


	public static void saveString(SharedPreferences pref, String key,
			String value) {
		SharedPreferences.Editor edit = pref.edit();
		edit.putString(key, value);
		edit.commit();
	}

	public static void saveString(String key, String value) {
		saveString(mPref, key, value);
	}

	public static String getString(String key) {
		return getString(mPref, key, null);
	}

	public static String getString(String key, String strDefault) {
		return getString(mPref, key, strDefault);
	}

	public static String getString(SharedPreferences pref, String key,
			String strDefault) {
		return pref.getString(key, strDefault);
	}

	public static void saveBoolean(SharedPreferences pref, String key,
			boolean value) {
		SharedPreferences.Editor edit = mPref.edit();
		edit.putBoolean(key, value);
		edit.commit();
	}

	public static void saveBoolean(String key, boolean value) {
		saveBoolean(mPref, key, value);
	}

	public static boolean getBoolean(String key) {
		return getBoolean(mPref, key, false);
	}

	public static boolean getBoolean(String key, boolean strDefault) {
		return getBoolean(mPref, key, strDefault);
	}

	public static boolean getBoolean(SharedPreferences pref, String key,
			boolean strDefault) {
		return pref.getBoolean(key, strDefault);
	}

	public static void saveInt(SharedPreferences pref, String key, int value) {
		SharedPreferences.Editor edit = mPref.edit();
		edit.putInt(key, value);
		edit.commit();
	}

	public static void saveInt(String key, int value) {
		saveInt(mPref, key, value);
	}

	public static int getInt(String key) {
		return getInt(mPref, key, -1);
	}

	public static int getInt(String key, int strDefault) {
		return getInt(mPref, key, strDefault);
	}

	public static int getInt(SharedPreferences pref, String key, int strDefault) {
		return pref.getInt(key, strDefault);
	}

	public static long getLong(String key, long mills) {
		return mPref.getLong(key, mills);
	}

	public static void saveLong(String key, long value) {
		SharedPreferences.Editor edit = mPref.edit();
		edit.putLong(key, value);
		edit.commit();
	}

}
