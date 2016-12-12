package com.example.util;


import java.util.Collections;
import java.util.LinkedList;
import java.util.List;

import android.content.Context;
import android.graphics.Bitmap;
import android.view.View;
import android.widget.ImageView;

import com.example.app.GlobalContext;
import com.example.newapp.R;
import com.nostra13.universalimageloader.cache.disc.naming.Md5FileNameGenerator;
import com.nostra13.universalimageloader.core.DisplayImageOptions;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;
import com.nostra13.universalimageloader.core.assist.QueueProcessingType;
import com.nostra13.universalimageloader.core.display.FadeInBitmapDisplayer;
import com.nostra13.universalimageloader.core.listener.ImageLoadingProgressListener;
import com.nostra13.universalimageloader.core.listener.SimpleImageLoadingListener;

public class ImageLoaderHelper {

	static {
		initImageLoader(GlobalContext.getInstance());
	}

//	/**
//	 * 加载头像的默认设置
//	 */
//	public static DisplayImageOptions avatarImageOptions = new DisplayImageOptions.Builder()
//			.showImageOnLoading(R.drawable.default_photo_grey)
//			.showImageForEmptyUri(R.drawable.default_photo_grey)
//			.showImageOnFail(R.drawable.default_photo_grey).cacheInMemory(true)
//			.cacheOnDisk(true).considerExifParams(true)
//			.bitmapConfig(Bitmap.Config.ARGB_8888).build();
//
//	/**
//	 * 去除缓存的图片加载设置
//	 */
//	public static DisplayImageOptions nocacheOptions = new DisplayImageOptions.Builder()
//			.cacheInMemory(false).cacheOnDisk(false).considerExifParams(false)
//			.bitmapConfig(Bitmap.Config.ARGB_8888).build();

	/**
	 * 初始化图片加载器
	 * 
	 * @param context
	 */
	private static void initImageLoader(Context context) {

//		DisplayImageOptions defaultDisplayImageOptions = new DisplayImageOptions.Builder()
//				// 设置载入图片过程中的提示图片image_loading，image_empty，image_error
//				.showImageOnLoading(R.drawable.gallery_pictemp)
//				.showImageForEmptyUri(R.drawable.nopic)
//				.showImageOnFail(R.drawable.nopic)
//				.cacheInMemory(true).cacheOnDisk(true).considerExifParams(true)
//				.bitmapConfig(Bitmap.Config.RGB_565).build();
		ImageLoaderConfiguration config = new ImageLoaderConfiguration.Builder(
				context).threadPriority(Thread.NORM_PRIORITY - 2)
				.denyCacheImageMultipleSizesInMemory()
				.diskCacheFileNameGenerator(new Md5FileNameGenerator())
				.diskCacheSize(50 * 1024 * 1024)
				.tasksProcessingOrder(QueueProcessingType.LIFO)
				// .writeDebugLogs() // Remove for release app
//				.defaultDisplayImageOptions(defaultDisplayImageOptions)
				.build();
		ImageLoader.getInstance().init(config);
	}

	private static AnimateFirstDisplayListener displayListener = new AnimateFirstDisplayListener();

	

	/**
	 * 图片加载时正在加载的图片类型
	 * 
	 * 
	 */
	public enum ImageLoadingType {
		NONE, AVATAR, SMALL, MEDIUM, LARGE,NOCACHE
	}

	static DisplayImageOptions.Builder defaultBuilder = new DisplayImageOptions.Builder()
			// 设置载入图片过程中的提示图片image_loading，image_empty，image_error
			.cacheInMemory(true).cacheOnDisk(true).considerExifParams(true)
			.showImageForEmptyUri(R.drawable.nopic)
			.showImageOnFail(R.drawable.nopic)
			.bitmapConfig(Bitmap.Config.RGB_565);
	
	/**
	 * 显示图片，默认带动画效果
	 * 
	 * @param uri
	 * @param imageView
	 */
	public static void displayImage(String uri, ImageView imageView) {
		displayImage(uri, imageView,ImageLoadingType.SMALL, null,null);
	}
	
	/**显示图片，提供图片正在加载时需要显示的图片
	 * @param uri
	 * @param imageView
	 * @param imageType
	 */
	public static void displayImage(String uri,ImageView imageView,ImageLoadingType imageType){
		displayImage(uri, imageView,imageType, null,null);
	}
	
	/**
	 * 显示图片，提供图片加载时的回调接口
	 * @param uri
	 * @param imageView
	 * @param imageType
	 * @param imageLoadingListener
	 */
	public static void displayImage(String uri,ImageView imageView,ImageLoadingType imageType,SimpleImageLoadingListener imageLoadingListener){
		displayImage(uri, imageView,imageType, imageLoadingListener,null);
	}

	/**显示图片，提供图片加载时的progress回调接口
	 * @param uri
	 * @param imageView
	 * @param imageType
	 * @param imageLoadingListener
	 * @param progressListener
	 */
	public static void displayImage(String uri, ImageView imageView,
			ImageLoadingType imageType,SimpleImageLoadingListener imageLoadingListener,ImageLoadingProgressListener progressListener) {
		int imageId = -1;
		defaultBuilder.showImageForEmptyUri(R.drawable.nopic);
		defaultBuilder.showImageOnFail(R.drawable.nopic);
		switch (imageType) {
		case NONE:
			imageId = R.drawable.transparent;
			break;
		case NOCACHE:
			imageId = R.drawable.gallery_pictemp;
			defaultBuilder.cacheInMemory(false).cacheOnDisk(false);
			break;
		case AVATAR:
			imageId = R.drawable.default_photo_grey;
			defaultBuilder.showImageForEmptyUri(imageId);
			defaultBuilder.showImageOnFail(imageId);
			break;
		case SMALL:
			imageId = R.drawable.gallery_pictemp;
			break;
		case MEDIUM:
			imageId = R.drawable.bg_color_grey;
			break;
		case LARGE:
			imageId = R.drawable.gallery_pictemp;
			break;
		default:
			imageId = R.drawable.bg_color_grey;
			break;
		}
		
		defaultBuilder.showImageOnLoading(imageId);
		if(imageLoadingListener==null){
			imageLoadingListener = displayListener;
		}
		ImageLoader.getInstance().displayImage(uri, imageView, defaultBuilder.build(), imageLoadingListener, progressListener);
	}

	private static class AnimateFirstDisplayListener extends
			SimpleImageLoadingListener {

		static final List<String> displayedImages = Collections
				.synchronizedList(new LinkedList<String>());

		@Override
		public void onLoadingComplete(String imageUri, View view,
				Bitmap loadedImage) {
			if (loadedImage != null) {
				ImageView imageView = (ImageView) view;
				// 保证只会在第一次加载的时候才会显示图片
				boolean firstDisplay = !displayedImages.contains(imageUri);
				if (firstDisplay) {
					FadeInBitmapDisplayer.animate(imageView, 500);
					displayedImages.add(imageUri);
				}
			}
		}
	}

}
