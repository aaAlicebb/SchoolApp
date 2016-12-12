package com.example.util;

import com.lidroid.xutils.BitmapUtils;
import com.lidroid.xutils.bitmap.BitmapDisplayConfig;

public class ImageLoaderUtil {
	
	static BitmapUtils imageLoader;
	static BitmapDisplayConfig noCacheLoadConfig;
	static BitmapDisplayConfig defaultDisplayConfig = new BitmapDisplayConfig();
	
	static{
//		imageLoader = new BitmapUtils(GlobalContext.getInstance());
//		defaultDisplayConfig.setAnimation(AnimationUtils.loadAnimation(GlobalContext.getInstance(), R.anim.fade_in));
		//TODO 初始化图片加载器的配置
	}
	
	public enum ImageLoadType{
		small,middle,big,avatar
	}
	
	// 加载网络图片
//	bitmapUtils.display(testImageView, "http://bbs.lidroid.com/static/image/common/logo.png");
	// 加载本地图片(路径以/开头， 绝对路径)
//	bitmapUtils.display(testImageView, "/sdcard/test.jpg");
	// 加载assets中的图片(路径以assets开头)
//	bitmapUtils.display(testImageView, "assets/img/wallpaper.jpg");
	/**
	 * 加载网络图片，本地图片，asset图片
	 * @param imageView
	 * @param url
	 */
//	public static void displayImage(ImageView imageView,String uri,ImageLoadType type){
//		switch (type) {
//		case small:
//		case big:
//		case middle:
//			Drawable d = GlobalContext.getInstance().getResources().getDrawable(R.drawable.gallery_pictemp);
//			defaultDisplayConfig.setLoadingDrawable(d);
//			defaultDisplayConfig.setLoadFailedDrawable(d);
//			break;
//		case avatar:
//			Drawable d2 = GlobalContext.getInstance().getResources().getDrawable(R.drawable.default_photo_grey);
//			defaultDisplayConfig.setLoadingDrawable(d2);
//			defaultDisplayConfig.setLoadFailedDrawable(d2);
//			break;
//		default:
//			Drawable d3 = GlobalContext.getInstance().getResources().getDrawable(R.drawable.gallery_pictemp);
//			defaultDisplayConfig.setLoadingDrawable(d3);
//			defaultDisplayConfig.setLoadFailedDrawable(d3);
//			break;
//		}
		
//		imageLoader.display(imageView, uri,defaultDisplayConfig );
//	}
	
//	public static void displayImage(ImageView imageView,String uri){
//		displayImage(imageView, uri,ImageLoadType.small);
//	}
//	
//	public static void displayImage(ImageView imageView,String uri,BitmapLoadCallBack<ImageView> bitmapLoadCallBack){
//		imageLoader.display(imageView, uri, bitmapLoadCallBack);
//	}
	

}
