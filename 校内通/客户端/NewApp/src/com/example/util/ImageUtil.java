package com.example.util;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;

import android.app.Activity;
import android.content.Context;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.Bitmap.CompressFormat;
import android.graphics.Bitmap.Config;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.PorterDuff.Mode;
import android.graphics.PorterDuffXfermode;
import android.graphics.Rect;
import android.graphics.RectF;
import android.media.ExifInterface;
import android.net.Uri;
import android.provider.MediaStore;
import android.util.DisplayMetrics;

public class ImageUtil {
	

	/**
	 * ��ͼƬת��Բ��
	 * 
	 * @param bitmap
	 * @param angle
	 *            ͼ�ǽǶ� ����0~90
	 * @return
	 */
	public static Bitmap getRoundedCornerBitmap(Bitmap bitmap, float angle) {
		Bitmap output = Bitmap.createBitmap(bitmap.getWidth(),
				bitmap.getHeight(), Config.ARGB_8888);
		Canvas canvas = new Canvas(output);
		final int color = 0xff424242;
		final Paint paint = new Paint();
		final Rect rect = new Rect(0, 0, bitmap.getWidth(), bitmap.getHeight());
		final RectF rectF = new RectF(rect);
		// final float roundPx = 90;
		paint.setAntiAlias(true);
		canvas.drawARGB(0, 0, 0, 0);
		paint.setColor(color);
		canvas.drawRoundRect(rectF, angle, angle, paint);
		paint.setXfermode(new PorterDuffXfermode(Mode.SRC_IN));
		canvas.drawBitmap(bitmap, rect, rect, paint);
		return output;
	}
	
	/**
	 * ��sd����ȡͼƬ
	 * 
	 * @param path
	 * @return
	 */
	public static Bitmap readBitMap(String path) {
		BitmapFactory.Options options = new BitmapFactory.Options();
		options.inPreferredConfig = Config.ARGB_8888;
		Bitmap bm = BitmapFactory.decodeFile(path, options);
		return bm;
	}
	
	/**
	 * ��bitmap�洢��SD��
	 * @param path
	 * @return �Ƿ�ɹ�
	 */
	public static boolean saveBitmap(Bitmap bitmap,int options,String path){
		FileOutputStream fos = null;
		boolean flag = false;
		try {
			fos = new FileOutputStream(path);
			//TODO �ǵ��޸� png or jpg
			flag= bitmap.compress(CompressFormat.JPEG, options, fos);
			fos.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return flag;
		
	}

	/**
	 * ����ͼƬ �Ŵ���С������λ��
	 * 
	 * @param newWidth
	 * @param newHeight
	 * @param bitmap
	 * @return
	 */
	public static Bitmap resizeBitmap(float newWidth, float newHeight,
			Bitmap bitmap) {
		Matrix matrix = new Matrix();
		matrix.postScale(newWidth / bitmap.getWidth(),
				newHeight / bitmap.getHeight());
		Bitmap newBitmap = Bitmap.createBitmap(bitmap, 0, 0, bitmap.getWidth(),
				bitmap.getHeight(), matrix, true);
		return newBitmap;
	}

	/**
	 * ��תͼƬ
	 * 
	 * @param source
	 * @return
	 * 
	 * @version:v1.0
	 * @author:lanyj
	 * @date:2014-7-8 ����11:58:22
	 */
	public static Bitmap changeRoate(Bitmap source, boolean isHeadCamera) {
		int orientation = 90;
		Bitmap bMapRotate = null;
		if (source.getHeight() < source.getWidth()) {
			orientation = 90;
			if (isHeadCamera)
				orientation = -90;
		} else {
			orientation = 0;
		}
		if (orientation != 0) {
			Matrix matrix = new Matrix();
			matrix.postRotate(orientation);
			bMapRotate = Bitmap.createBitmap(source, 0, 0, source.getWidth(),
					source.getHeight(), matrix, true);
		} else {
			return source;
		}
		return bMapRotate;
	}

	/**
	 * ��ȡͼƬ·��
	 */
	public static String getPicPathFromUri(Uri uri, Activity activity) {
		String value = uri.getPath();

		if (value.startsWith("/external")) {
			String[] proj = { MediaStore.Images.Media.DATA };
			Cursor cursor = activity.managedQuery(uri, proj, null, null, null);
			int column_index = cursor
					.getColumnIndexOrThrow(MediaStore.Images.Media.DATA);
			cursor.moveToFirst();
			return cursor.getString(column_index);
		} else {
			return value;
		}
	}

	/**
	 * ��ȡ���ص�ͼƬ�õ�����ͼ����ͼƬ��Ҫ��ת����ת��
	 * 
	 * @param path
	 * @param width
	 * @param height
	 * @return
	 */
	public static Bitmap getLocalThumbImg(String path, float width,
			float height, String imageType) {
		BitmapFactory.Options newOpts = new BitmapFactory.Options();
		// ��ʼ����ͼƬ����ʱ��options.inJustDecodeBounds ���true��
		newOpts.inJustDecodeBounds = true;
		Bitmap bitmap = BitmapFactory.decodeFile(path, newOpts);// ��ʱ����bmΪ��
		newOpts.inJustDecodeBounds = false;
		int w = newOpts.outWidth;
		int h = newOpts.outHeight;
		// ���űȡ������ǹ̶��������ţ�ֻ�ø߻��߿�����һ����ݽ��м��㼴��
		int be = 1;// be=1��ʾ������
		if (w > h && w > width) {// ����ȴ�Ļ���ݿ�ȹ̶���С����
			be = (int) (newOpts.outWidth / width);
		} else if (w < h && h > height) {// ���߶ȸߵĻ���ݿ�ȹ̶���С����
			be = (int) (newOpts.outHeight / height);
		}
		if (be <= 0)
			be = 1;
		newOpts.inSampleSize = be;// �������ű���
		// ���¶���ͼƬ��ע���ʱ�Ѿ���options.inJustDecodeBounds ���false��
		bitmap = BitmapFactory.decodeFile(path, newOpts);
		bitmap = compressImage(bitmap, 100, imageType);// ѹ���ñ����С���ٽ�������ѹ��
		int degree = readPictureDegree(path);
		bitmap = rotaingImageView(degree, bitmap);
		return bitmap;
	}

	/**
	 * ͼƬ����ѹ��
	 * 
	 * @param image
	 * @size ͼƬ��С��kb��
	 * @return
	 */
	public static Bitmap compressImage(Bitmap image, int size, String imageType) {
		try {
			ByteArrayOutputStream baos = new ByteArrayOutputStream();
			if (imageType.equalsIgnoreCase("png")) {
				image.compress(Bitmap.CompressFormat.PNG, 100, baos);
			} else {
				image.compress(Bitmap.CompressFormat.JPEG, 100, baos);// ����ѹ������������100��ʾ��ѹ������ѹ�������ݴ�ŵ�baos��
			}
			int options = 100;
			while (baos.toByteArray().length / 1024 > size) { // ѭ���ж����ѹ����ͼƬ�Ƿ����100kb,���ڼ���ѹ��
				baos.reset();// ����baos�����baos
				options -= 10;// ÿ�ζ�����10
				if (imageType.equalsIgnoreCase("png")) {
					image.compress(Bitmap.CompressFormat.PNG, options, baos);
				} else {
					image.compress(Bitmap.CompressFormat.JPEG, options, baos);// ����ѹ��options%����ѹ�������ݴ�ŵ�baos��
				}
				
			}
			ByteArrayInputStream isBm = new ByteArrayInputStream(
					baos.toByteArray());// ��ѹ��������baos��ŵ�ByteArrayInputStream��
			Bitmap bitmap = BitmapFactory.decodeStream(isBm, null, null);// ��ByteArrayInputStream������ͼƬ
			return bitmap;
		} catch (Exception e) {
			return null;
		}
	}

	/**
	 * ��ȡͼƬ���ԣ���ת�ĽǶ�
	 * 
	 * @param path
	 *            ͼƬ���·��
	 * @return degree��ת�ĽǶ�
	 */
	public static int readPictureDegree(String path) {
		int degree = 0;
		try {
			ExifInterface exifInterface = new ExifInterface(path);
			int orientation = exifInterface.getAttributeInt(
					ExifInterface.TAG_ORIENTATION,
					ExifInterface.ORIENTATION_NORMAL);
			switch (orientation) {
			case ExifInterface.ORIENTATION_ROTATE_90:
				degree = 90;
				break;
			case ExifInterface.ORIENTATION_ROTATE_180:
				degree = 180;
				break;
			case ExifInterface.ORIENTATION_ROTATE_270:
				degree = 270;
				break;
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		return degree;
	}

	/**
	 * ��תͼƬ
	 * 
	 * @param angle
	 * @param bitmap
	 * @return Bitmap
	 */
	public static Bitmap rotaingImageView(int angle, Bitmap bitmap) {
		if (bitmap == null)
			return null;
		// ��תͼƬ ����
		Matrix matrix = new Matrix();
		matrix.postRotate(angle);
		// �����µ�ͼƬ
		Bitmap resizedBitmap = Bitmap.createBitmap(bitmap, 0, 0,
				bitmap.getWidth(), bitmap.getHeight(), matrix, true);
		return resizedBitmap;
	}
	
	/**
	 * ����ͼƬ��ָ�����
	 */
	public static Bitmap scaleBitmap(Bitmap bitmap,int scaleWidth) {
		// ������Ļ��С
		int oldW = bitmap.getWidth();
		//���ͼƬ�����ͺ�С���Ͳ�ѹ����
		if(oldW <= scaleWidth){
			return bitmap;
		}
		int oldH = bitmap.getHeight();
		float aspectRatio = (float) scaleWidth / (float) oldW;
		int scaledHeight = (int) (oldH * aspectRatio);
		Bitmap scaledBitmap = null;
			scaledBitmap = Bitmap.createScaledBitmap(bitmap, scaleWidth,
					scaledHeight, false);
		return scaledBitmap;
	}

	/**
	 * ��ȡ��Ӧ��Ļ��С��ͼ
	 */
	public static Bitmap sacleBitmap(Context context, Bitmap bitmap) {
		// ������Ļ��С
		int width = bitmap.getWidth();
		int height = bitmap.getHeight();
		DisplayMetrics metrics = context.getResources().getDisplayMetrics();
		int screenWidth = metrics.widthPixels;
		float aspectRatio = (float) screenWidth / (float) width;
		int scaledHeight = (int) (height * aspectRatio);
		Bitmap scaledBitmap = null;
		try {
			scaledBitmap = Bitmap.createScaledBitmap(bitmap, screenWidth,
					scaledHeight, false);
		} catch (OutOfMemoryError e) {
		}
		return scaledBitmap;
	}



	
	

}
