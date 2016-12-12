package com.example.common.utils;

import com.alibaba.fastjson.JSON;

/**
 * 封装了关于JSON转换的一些工具类
 * @author WangJun
 *
 */
public class JsonUtil {
	
	/**
	 * 将json字符串转换成对象
	 * @param jsonString
	 * @param objectClass
	 * @return
	 */
	public static <T> T parseObject(String jsonString,Class<T> objectClass){
		return JSON.parseObject(jsonString, objectClass);
	}
	
	/**
	 * 将对象转换成json字符�?
	 * @param object
	 * @return
	 */
	public static String toJsonString(Object object){
		return JSON.toJSONString(object);
	}
	
	
}
