package com.example.common.utils;

import io.rong.ApiHttpClient;
import io.rong.models.FormatType;
import io.rong.models.SdkHttpResult;

import java.util.List;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;

public class RongyunUtil {
	
	private static final String APP_KEY = "bmdehs6pdcf5s";
	private static final String APP_SECRET = "8amlPMjfipQFKp";
	
	
	/**
	 * 鑾峰彇铻嶄簯鍞竴token锛岀敤浜庤瘑鍒敤鎴?
	 * @param telephone  锛堟湰鏉ュ簲璇ユ槸userId锛夛紝鐢变簬鏈郴缁焨serid瀵规墍鏈夋垚鍛樹笉鍞竴锛屾晠鏀圭敤telephone鍞竴璇嗗埆鎴愬憳
	 * 涓嶈?铏戜竴涓垚鍛樺張鏄?甯堝張鏄闀跨殑鎯呭喌
	 * @param username  鐢ㄦ埛鍚嶏紝鍙?
	 * @param portraitUri  澶村儚uri锛屽彲閫?
	 */
	public static String  getToken(String telephone,String username,String portraitUri){
		String token =null;
		try {
			SdkHttpResult result =  ApiHttpClient.getToken(APP_KEY, APP_SECRET, telephone, username, portraitUri, FormatType.json);
			if(result.getHttpCode() == 200){
				JSONObject json = JSON.parseObject(result.getResult());
				//json = {"code":200,"userId":"13300000000",
				//	"token":"7GTrKucjM5CUCBwqElOTqKaNpMYvuhjheujpINLfy/KRo3rtufpiQVskvLYV6+QtbT79ECkP6BMlL12mdWES9qNyMV/KQK31"}
				return json.getString("token");
			}
		} catch (Exception e) {
			e.printStackTrace();
			return token;
		}
		return token;
	}
	
	/**
	 *灏唘serId鐨勭敤鎴峰姞鍏ョ兢缁?
	 * @param userId
	 * @param groupId
	 * @param groupName
	 * @return
	 */
	public static boolean joinGroup(String userId,String groupId,String groupName){
		SdkHttpResult result = null;
		try {
			result = ApiHttpClient.joinGroup(APP_KEY, APP_SECRET,userId, groupId,
					groupName, FormatType.json);
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
		System.out.println("joinGroup=" + result);
		return result.getHttpCode() == 200;
		
	}
	
	/**
	 * 灏嗙敤鎴锋壒閲忓姞鍏ョ兢缁?
	 * @param userIds
	 * @param groupId
	 * @param groupName
	 * @return
	 */
	public static boolean joinGroupBatch(List<String> userIds,String groupId,String groupName){
		SdkHttpResult result = null;
		try {
			result = ApiHttpClient.joinGroupBatch(APP_KEY, APP_SECRET, userIds, "id1",
					"name1", FormatType.json);
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
		System.out.println("joinGroupBatch=" + result);
		return result.getHttpCode() == 200;
	}

}
