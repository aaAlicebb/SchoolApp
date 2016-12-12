package com.example.common.utils;

import com.qiniu.util.Auth;
import com.qiniu.util.StringMap;

public class QiniuUtil {
	
	private static final String ACCESS_KEY = "KgutHnD2PBxGNxS7_LiXXEI72X8yEwaNoTpZ0lmx";
	private static final String SECRET_KEY = "jn7NlUJftyP2Gce3uL0mMWHHQ6pYX08l8Zq4rczI";
	private static final String BUCKET = "mypicturs";
	
	private static Auth auth = Auth.create(ACCESS_KEY, SECRET_KEY);
	
	// �?��上传，使用默认策�?
	public static String getUpToken(){
	    return auth.uploadToken(BUCKET);
	}

	// 覆盖上传
	private static String getUpToken1(){
	    return auth.uploadToken(BUCKET, "key");
	}

	// 设置指定上传策略
	private static String getUpToken2(){
	    return auth.uploadToken(BUCKET, null, 3600, new StringMap()
	         .put("callbackUrl", "call back url").putNotEmpty("callbackHost", "")
	         .put("callbackBody", "key=$(key)&hash=$(etag)"));
	}

	// 设置预处理�?去除非限定的策略字段
	private static String getUpToken3(){
	    return auth.uploadToken("bucket", null, 3600, new StringMap()
	            .putNotEmpty("persistentOps", "").putNotEmpty("persistentNotifyUrl", "")
	            .putNotEmpty("persistentPipeline", ""), true);
	}
	
	/**
	* 生成上传token
	*
	* @param bucket  空间�?
	* @param key     key，可�?null
	* @param expires 有效时长，单位秒。默�?600s
	* @param policy  上传策略的其它参数，�?new StringMap().put("endUser", "uid").putNotEmpty("returnBody", "")�?
	*        scope通过 bucket、key间接设置，deadline 通过 expires 间接设置
	* @param strict  是否去除非限定的策略字段，默认true
	* @return 生成的上传token
	*/
//	public String uploadToken(String bucket, String key, long expires, StringMap policy, boolean strict)

}
