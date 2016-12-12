package com.example.util;

import java.io.File;
import java.lang.reflect.InvocationTargetException;

import android.content.Context;
import android.os.Environment;
import android.os.storage.StorageManager;

import com.example.app.GlobalContext;

public class SdCardUtil {
	
	
	/**得到本应用用到的sdcard的路径
	 * @return
	 */
	public static String getAppDirectory(){
		String path = getStorageDirectory() + "/kindergarten";
		File file = new File(path);
		if(!file.exists()){
			file.mkdirs();
		}
		
		return path;
	}

	/**得到所有sdcard的根路径
	 * @return
	 */
	public static String[] getSdcardPaths() {
		String paths[] = null;
		StorageManager sm = (StorageManager) GlobalContext.getInstance()
				.getSystemService(Context.STORAGE_SERVICE);
		try {
			paths = (String[]) sm.getClass().getMethod("getVolumePaths", null)
					.invoke(sm, null);
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		} catch (InvocationTargetException e) {
			e.printStackTrace();
		} catch (NoSuchMethodException e) {
			e.printStackTrace();
		}
		return paths;
	}

	/**得到当前可用的sd卡根路径
	 * @return
	 */
	public static String getMountedStorageDirectory() {
		String paths[] = getSdcardPaths();
		for (int i = 0; i < paths.length; i++) {
			String p = paths[i] + "/_file111111111111111";
			try {
				File f = new File(p);
				if (!f.exists()) {
					if (f.mkdirs()) {
						f.delete();
						return paths[i];
					}
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return null;
	}

	/**
	 * 无论sdcard是否拔出，都返回可用的存储路径
	 * @return
	 */
	public static String getStorageDirectory() {
		if (Environment.getExternalStorageState().equals(
				Environment.MEDIA_MOUNTED)) {
			return Environment.getExternalStorageDirectory().toString();
		} else {
			return getMountedStorageDirectory();
		}
	}
}