package com.example.util;

import android.content.res.Resources;
import android.util.DisplayMetrics;
import android.util.TypedValue;
import android.view.View;
import android.view.ViewGroup.LayoutParams;

import com.example.app.GlobalContext;

/**
 * 距离单位工具类
 * 
 * 
 */
public class DimenUtil {

	/**
	 * 将dp转换成px单位
	 * 
	 * @param res
	 * @param dp
	 * @return
	 */
	public static int dpToPx(Resources res, int dp) {
		return (int) TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, dp,
				res.getDisplayMetrics());
	}

	/**
	 * 将dp转换成px单位
	 * 
	 * @param dp
	 * @return
	 */
	public static int dpToPx(int dp) {

		return (int) TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, dp,
				GlobalContext.getInstance().getResources().getDisplayMetrics());
	}

	/**
	 * 将px转换成dp单位
	 * 
	 * @param px
	 * @return
	 */
	public static float pxToDp(float px) {
		return px
				/ GlobalContext.getInstance().getResources()
						.getDisplayMetrics().density;
	}

	/**
	 * 获取屏幕的长宽
	 * 
	 * @param activity
	 * @return
	 */
	public static int[] getScreenSize() {
		DisplayMetrics dm = GlobalContext.getInstance().getResources()
				.getDisplayMetrics();
		return new int[] { dm.widthPixels, dm.heightPixels };
	}

	/**
	 * 获取屏幕的密度
	 * 
	 * @param activity
	 * @return
	 */
	public static float getScreenDensity() {
		DisplayMetrics dm = GlobalContext.getInstance().getResources()
				.getDisplayMetrics();
		return dm.density;
	}

	/**
	 * 得到你控件的宽高
	 * 
	 * @param v
	 * @return
	 */
	public static int[] getViewSize(View v) {
		LayoutParams lp = v.getLayoutParams();
		return new int[] { lp.width, lp.height };
	}

	/**
	 * 向服务器请求缩略图
	 * 
	 * @param v
	 * @return
	 */
	public static String getSmallImageStr(View v) {
		int width = getViewSize(v)[0];
		if (width <= 0)
			width = 200;
		return "?imageView2/0/w/" + width;
	}

	/**
	 * 向服务器请求缩略图
	 * 
	 * @param width
	 * @return
	 */
	public static String getSmallImageStr(int width) {
		if (width <= 0)
			width = 200;
		return "?imageView2/0/w/" + width;
	}
}
