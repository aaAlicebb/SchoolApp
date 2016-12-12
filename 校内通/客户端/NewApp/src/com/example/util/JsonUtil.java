package com.example.util;

import java.util.List;

import com.alibaba.fastjson.JSON;

/**
 * 封装了关于JSON转换的一些工具类
 * 
 * @author WangJun
 *
 */
public class JsonUtil {

	/**
	 * 将json字符串转换成对象
	 * 
	 * @param jsonString
	 * @param objectClass
	 * @return
	 */
	public static <T> T parseObject(String jsonString, Class<T> objectClass) {
		if (jsonString == null || jsonString.isEmpty())
			return null;
		return JSON.parseObject(jsonString, objectClass);
	}
	
	/**
	 * 将json字符串转换成对象集合
	 * @param <T>
	 * 
	 * @param jsonString
	 * @param objectClass
	 * @return
	 */
	public static <T> List<T>  parseObjectList(String jsonString, Class<T> objectClass) {
		if (jsonString == null || jsonString.isEmpty())
			return null;
		return JSON.parseArray(jsonString, objectClass);
	}

	/**
	 * 将对象转换成json字符串
	 * 
	 * @param object
	 * @return
	 */
	public static String toJsonString(Object object) {
		return JSON.toJSONString(object);
	}

}
