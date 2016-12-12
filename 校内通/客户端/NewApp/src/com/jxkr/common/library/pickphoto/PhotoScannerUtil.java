package com.jxkr.common.library.pickphoto;

import static com.jxkr.common.library.pickphoto.Utility.isImage;

import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;

import android.content.ContentResolver;
import android.content.Context;
import android.database.Cursor;
import android.net.Uri;
import android.provider.MediaStore;

public class PhotoScannerUtil {

	/**
	 * 
	 * 获取指定路径下的所有图片文件。
	 */
	public static ArrayList<String> getAllImagePathsByFolder(String folderPath) {
		File folder = new File(folderPath);
		String[] allFileNames = folder.list();
		if (allFileNames == null || allFileNames.length == 0) {
			return null;
		}

		ArrayList<String> imageFilePaths = new ArrayList<String>();
		for (int i = allFileNames.length - 1; i >= 0; i--) {
			if (isImage(allFileNames[i])) {
				imageFilePaths.add(folderPath + File.separator
						+ allFileNames[i]);
			}
		}

		return imageFilePaths;
	}

	/**
	 * 使用ContentProvider读取SD卡最近图片
	 * 
	 * @param maxCount
	 * @return
	 */
	public static ArrayList<String> getLatestImagePaths(Context context,
			int maxCount) {
		Uri mImageUri = MediaStore.Images.Media.EXTERNAL_CONTENT_URI;

		String key_MIME_TYPE = MediaStore.Images.Media.MIME_TYPE;
		String key_DATA = MediaStore.Images.Media.DATA;

		ContentResolver mContentResolver = context.getContentResolver();

		// 只查询jpg和png的图片,按最新修改排序
		Cursor cursor = mContentResolver.query(mImageUri,
				new String[] { key_DATA }, key_MIME_TYPE + "=? or "
						+ key_MIME_TYPE + "=? or " + key_MIME_TYPE + "=?",
				new String[] { "image/jpg", "image/jpeg", "image/png" },
				MediaStore.Images.Media.DATE_MODIFIED);

		ArrayList<String> latestImagePaths = null;
		if (cursor != null) {
			// 从最新的图片开始读取.
			// 当cursor中没有数据时，cursor.moveToLast()将返回false
			if (cursor.moveToLast()) {
				latestImagePaths = new ArrayList<String>();
				while (true) {
					// 获取图片的路径
					String path = cursor.getString(0);
					File file = new File(path);
					if (file.exists()) {
						latestImagePaths.add(path);
					}
					if (latestImagePaths.size() >= maxCount
							|| !cursor.moveToPrevious()) {
						break;
					}
				}

			}
			cursor.close();
		}

		return latestImagePaths;
	}

	/**
	 * 获取目录中最新的一张图片的绝对路径
	 * 
	 * @param folder
	 * @return
	 */
	public static String getFirstImagePath(File folder) {
		File[] files = folder.listFiles();

		for (int i = files.length - 1; i >= 0; i--) {
			File file = files[i];
			if (isImage(file.getName())) {
				return file.getAbsolutePath();
			}
		}

		return null;
	}
	
	/**
	 * 使用ContentProvider读取SD卡所有图片。
	 */
	public static ArrayList<PhotoAlbumLVItem> getImagePathsByContentProvider(Context context) {
		Uri mImageUri = MediaStore.Images.Media.EXTERNAL_CONTENT_URI;

		String key_MIME_TYPE = MediaStore.Images.Media.MIME_TYPE;
		String key_DATA = MediaStore.Images.Media.DATA;

		ContentResolver mContentResolver = context.getContentResolver();

		// 只查询jpg和png的图片
		Cursor cursor = mContentResolver.query(mImageUri,
				new String[] { key_DATA }, key_MIME_TYPE + "=? or "
						+ key_MIME_TYPE + "=? or " + key_MIME_TYPE + "=?",
				new String[] { "image/jpg", "image/jpeg", "image/png" },
				MediaStore.Images.Media.DATE_MODIFIED);

		ArrayList<PhotoAlbumLVItem> list = null;
		if (cursor != null) {
			if (cursor.moveToLast()) {
				// 路径缓存，防止多次扫描同一目录
				HashSet<String> cachePath = new HashSet<String>();
				list = new ArrayList<PhotoAlbumLVItem>();
				while (true) {
					// 获取图片的路径
					String imagePath = cursor.getString(0);
					File file = new File(imagePath);
					if (file.exists()) {// /storage/sdcard0/tencent/MicroMsg/WeiXin
						// /storage/sdcard1/tencent/MicroMsg/WeiXin
						File parentFile = file.getParentFile();
						String parentPath = parentFile.getAbsolutePath();

						// 不扫描重复路径
						if (!cachePath.contains(parentPath)) {
							String fistImage = getFirstImagePath(parentFile);
							if (fistImage != null) {
								list.add(new PhotoAlbumLVItem(parentPath,
										getImageCount(parentFile), fistImage));
							}
							cachePath.add(parentPath);
						}
					}
					if (!cursor.moveToPrevious()) {
						break;
					}
				}
			}

			cursor.close();
		}

		return list;
	}
	
	/**
	 * 获取目录中图片的个数。
	 */
	public static int getImageCount(File folder) {
		int count = 0;
		File[] files = folder.listFiles();
		for (File file : files) {
			if (isImage(file.getName())) {
				count++;
			}
		}

		return count;
	}


}
