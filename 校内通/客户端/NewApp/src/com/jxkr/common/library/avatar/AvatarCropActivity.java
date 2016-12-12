package com.jxkr.common.library.avatar;

import java.io.File;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;

import com.example.newapp.R;
import com.example.util.SdCardUtil;
import com.jxkr.common.library.pickphoto.ScreenUtils;

public class AvatarCropActivity extends Activity implements OnClickListener {

	private ImageCutView imageCutView;
//	Button btn_back;
//	Button btn_done;
	private Bitmap bitmap;
	private String activityClass;
	
	// 自己修改需要的路径
	public static final String AVATAR_PATH = SdCardUtil.getAppDirectory()+"/avatar/";
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.avatar_crop);
		new File(AVATAR_PATH).mkdir();
		imageCutView = (ImageCutView) findViewById(R.id.imageCutView);
//		btn_back = (Button) findViewById(R.id.btn_back);
//		btn_done = (Button) findViewById(R.id.btn_done);
		findViewById(R.id.btn_done).setOnClickListener(this);
		findViewById(R.id.btn_back).setOnClickListener(this);
		
		String imagePath = getIntent().getStringExtra("path");
		///storage/emulated/0/iquanlin/photo/20150109142437.jpg
		activityClass = getIntent().getStringExtra("activityClass");
//		ImageLoader.getInstance().loadImage(imagePath, imageCutView);
		Bitmap bm = ImageUtil.getLocalThumbImg(imagePath, ScreenUtils.getScreenW(), ScreenUtils.getScreenH(), "jpg");
		imageCutView.setImageBitmap(bm);
	}

	

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_done:
			bitmap = imageCutView.onClip();
			String avatarPath = AVATAR_PATH+"avatar.jpg";
			ImageUtil.saveBitmap(bitmap, 100, avatarPath);
			
			Intent intent;
			try {
				intent = new Intent(AvatarCropActivity.this, Class.forName(activityClass));
				intent.putExtra("avatarPath", avatarPath);
				intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_SINGLE_TOP);
				startActivity(intent);
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
			break;
		case R.id.btn_back:
			finish();
			break;
		}
	}
 
}
