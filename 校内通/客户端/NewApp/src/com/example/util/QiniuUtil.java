package com.example.util;

import org.json.JSONObject;

import com.lidroid.xutils.util.LogUtils;
import com.qiniu.android.http.ResponseInfo;
import com.qiniu.android.storage.UpCompletionHandler;
import com.qiniu.android.storage.UpProgressHandler;
import com.qiniu.android.storage.UploadManager;
import com.qiniu.android.storage.UploadOptions;

public class QiniuUtil {
	
	 static UploadManager uploadManager = new UploadManager();
	 
	 /**
	  * 上传文件到七牛云存储上
	 * @param filePath
	 * @param key
	 * @param token
	 * @param callback
	 */
	public static void put(String filePath, String key, String token,final FileLoadCallBack callback){
		 uploadManager.put(filePath, key, token, new UpCompletionHandler() {
			
			@Override
			public void complete(String key, ResponseInfo info, JSONObject response) {
				if(info.isOK()){
					String fileKey = response.optString("key", "");
					callback.onSuccess(fileKey);
				}else{
					callback.onFailure(info.toString());
					LogUtils.e(info.toString());
					TipUtil.show("上传失败...");
				}
				
			}
		}, new UploadOptions(null, null, false, new UpProgressHandler() {
			
			@Override
			public void progress(String key, double percent) {
				callback.onProcess(key, percent);
			}
		}, null));
	 }
	 
}	 
//	 
//	 public static void getUpToken(){
//		 
//	 }

