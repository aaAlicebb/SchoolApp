package com.example.util;

import java.text.SimpleDateFormat;
import java.util.Date;

import android.annotation.SuppressLint;


/**
 * 日期时间处理类
 * 
 * @author 汪俊
 * 
 */
public class DateUtil {

	private static SimpleDateFormat sdf;

	/**
	 * 得到简单的日期字符串 xx月xx日 HH:mm
	 * 
	 * @param mills
	 * @return
	 */
	@SuppressLint("SimpleDateFormat")
	public static String getSimpleDate(long mills) {
		return getSimpleDate(new Date(mills));
	}

	public static String getSimpleDate(Date date) {
		sdf = new SimpleDateFormat("MM月dd日 HH:mm");
		String datestr = sdf.format(date);
		return datestr;
	}

	/**
	 * 得到灵活的日期字符串
	 * 
	 * @param mills
	 * @return
	 */
	public static String getFlexibleDate(long mills) {
		long minus = System.currentTimeMillis() - mills;
		long delta = minus / 1000; // 得到秒数
		// 4.根据时间间隔算出合理的字符串
		if (delta < 60) { // 1分钟内
			return "刚刚";
		} else if (delta < 60 * 60) { // 1小时内
			return delta / 60 + "分钟前";
		} else if (delta < 60 * 60 * 24) { // 1天内
			sdf = new SimpleDateFormat("今天 HH时mm分");
			return sdf.format(new Date(mills));
		} else {
			sdf = new SimpleDateFormat("MM月dd日 HH:mm");
			return sdf.format(new Date(mills));
		}

	}

	/**
	 * 得到灵活的日期字符串
	 * 
	 * @param mills
	 * @return
	 */
	public static String getFlexibleDate(Date date) {
		return getFlexibleDate(date.getTime());
	}
	
	public static String getMMDDDateStr(Date date){
		sdf = new SimpleDateFormat("MM月dd日");
		String datestr = sdf.format(date);
		return datestr;
	}
	
	public static String getHHmmDateStr(Date date){
		sdf = new SimpleDateFormat("HH:mm");
		String datestr = sdf.format(date);
		return datestr;
	}


	/**
	 * 得到详细的时间格式 yyyy-MM-dd HH:mm:ss
	 * 
	 * @param date
	 * @return
	 */
	public static String getDetailDate(Date date) {
		sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		String datestr = sdf.format(date);
		return datestr;
	}

}
