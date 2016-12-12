package com.example.util;

import java.util.UUID;

public class UUIDUtil {
	
	 /** 
     * 获得一个UUID 32位
     * 550E8400 E29B 11D4 A716 446655440000 
     * @return String UUID 
     */ 
    public static String getUUID(){ 
        String s = UUID.randomUUID().toString(); 
        //去掉“-”符号 
        return s.substring(0,8)+s.substring(9,13)+s.substring(14,18)+s.substring(19,23)+s.substring(24); 
    } 

}
