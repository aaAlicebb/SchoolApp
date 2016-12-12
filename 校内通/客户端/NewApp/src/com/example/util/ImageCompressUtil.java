package com.example.util;

import java.io.ByteArrayOutputStream;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

public class ImageCompressUtil {

	//TODO 这个不应该定死，是根据不同图片计算得到的
	public static int SCALE_TO_WIDTH = 540;
	public static int SCALE_TO_HEIGHT = 960;

	/**
	 * 计算图片缩放比例
	 * 
	 * @param newOpts
	 * @param newWidth
	 * @param newHeight
	 * @return
	 */
	public static int getImageSampleSize(BitmapFactory.Options newOpts) {
		int w = newOpts.outWidth;
		int h = newOpts.outHeight;
		// 缩放比。由于是固定比例缩放，只用高或者宽其中一个数据进行计算即可
		int be = 1;// be=1表示不缩放

		// if (w > h && w > ww) {//如果宽度大的话根据宽度固定大小缩放
		// be = (int) (newOpts.outWidth / ww);
		// } else if (w < h && h > hh) {//如果高度高的话根据宽度固定大小缩放
		// be = (int) (newOpts.outHeight / hh);
		// }
		be = (int) ((w / SCALE_TO_WIDTH + h / SCALE_TO_HEIGHT) / 2);

		if (be <= 0)
			be = 1;
		return be;// 设置缩放比例
	}

	/**
	 * 压缩图片——宽高压缩方法
	 * 
	 * @param srcPath
	 *            图片路径
	 * @param width
	 *            压缩到的宽度
	 * @param height
	 *            压缩到的高度
	 * @return
	 */
	public static Bitmap compressImageSize(String srcPath) {
		BitmapFactory.Options newOpts = new BitmapFactory.Options();
		// 开始读入图片，此时把options.inJustDecodeBounds 设回true了
		newOpts.inJustDecodeBounds = true;
		Bitmap bitmap = BitmapFactory.decodeFile(srcPath, newOpts);// 此时返回bm为空
		int w = newOpts.outWidth;
		int h = newOpts.outHeight;
		// 缩放比。由于是固定比例缩放，只用高或者宽其中一个数据进行计算即可
		int inSampleSize = 1;// be=1表示不缩放
		inSampleSize = (int) ((w / SCALE_TO_WIDTH + h / SCALE_TO_HEIGHT) / 2);
		if (inSampleSize <= 0)
			inSampleSize = 1;
		newOpts.inSampleSize = inSampleSize;
		newOpts.inJustDecodeBounds = false;
		newOpts.inPreferredConfig = Bitmap.Config.RGB_565;
		// 重新读入图片，注意此时已经把options.inJustDecodeBounds 设回false了
		bitmap = BitmapFactory.decodeFile(srcPath, newOpts);
		return bitmap;//
	}

	/**
	 * 将srcPath的图片压缩到capacity左右的大小，并且存储到desPath
	 * @param srcPath
	 * @param desPath
	 * @param capacity
	 * @return
	 */
	public static boolean compressImage2Small(String srcPath, String desPath,
			int capacity) {
		BitmapFactory.Options newOpts = new BitmapFactory.Options();
		// 开始读入图片，此时把options.inJustDecodeBounds 设回true了
		newOpts.inJustDecodeBounds = true;
		Bitmap bitmap = BitmapFactory.decodeFile(srcPath, newOpts);// 此时返回bm为空
		int w = newOpts.outWidth;
		int h = newOpts.outHeight;
		// 缩放比。由于是固定比例缩放，只用高或者宽其中一个数据进行计算即可
		int inSampleSize = 1;// be=1表示不缩放
		inSampleSize = (int) ((w / SCALE_TO_WIDTH + h / SCALE_TO_HEIGHT) / 2);
		if (inSampleSize <= 0)
			inSampleSize = 1;
		newOpts.inSampleSize = inSampleSize;
		newOpts.inJustDecodeBounds = false;
		newOpts.inPreferredConfig = Bitmap.Config.RGB_565;
		bitmap = BitmapFactory.decodeFile(srcPath, newOpts);//这是为了不OOM
		bitmap = ImageUtil.scaleBitmap(bitmap, SCALE_TO_WIDTH);//上面的bitmap的像素可能还是很大，再放缩一次
		int options = getBestCompressOptions(bitmap, capacity);
		return ImageUtil.saveBitmap(bitmap,options,desPath);
	}

	/**
	 * 得到最合适的压缩参数options
	 * 
	 * @param bitmap
	 * @param capacity
	 * @return
	 */
	private static int getBestCompressOptions(Bitmap bitmap, int capacity) {
		// 开始压缩quality
		ByteArrayOutputStream baos = new ByteArrayOutputStream();
		//TODO png,hpg两个参数要区别对待
		bitmap.compress(Bitmap.CompressFormat.JPEG, 100, baos);
		// if(baos.toByteArray().length/1024 <= 200)
		int options = 110;//90,70,50,30,10
		while (baos.toByteArray().length / 1024 > capacity && options >= 10) { // 循环判断如果压缩后图片是否大于capacitykb,大于继续压缩
			options -= 20;// 每次都减少20
			baos.reset();// 重置baos即清空baos
			bitmap.compress(Bitmap.CompressFormat.JPEG, options, baos);// 这里压缩options%，把压缩后的数据存放到baos中
			
		}
		if(options==110){
			options=100;
		}
		return options;
	}
}
