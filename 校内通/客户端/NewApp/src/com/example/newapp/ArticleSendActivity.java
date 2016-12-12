package com.example.newapp;

import java.io.File;
import java.util.ArrayList;

import org.apache.http.Header;

import android.content.Intent;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;

import com.daimajia.androidanimations.library.Techniques;
import com.daimajia.androidanimations.library.YoYo;
import com.example.app.Constant.URL;
import com.example.bean.ArticleSendReqBean;
import com.example.bean.CommonResultResBean;
import com.example.bean.UpTokenResBean;
import com.example.util.FileLoadCallBack;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.ImageCompressUtil;
import com.example.util.QiniuUtil;
import com.example.util.SdCardUtil;
import com.example.util.TipUtil;
import com.example.util.UUIDUtil;
import com.jxkr.common.library.pickphoto.NoScrollGridView;
import com.jxkr.common.library.pickphoto.PhotoMainAdapter;
import com.jxkr.common.library.pickphoto.PhotoMainAdapter.ViewHolder;
import com.jxkr.common.library.pickphoto.PhotoPreviewActivity;
import com.jxkr.common.library.pickphoto.PhotoWallActivity;
import com.lidroid.xutils.view.annotation.ContentView;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.lidroid.xutils.view.annotation.event.OnClick;
import com.rengwuxian.materialedittext.MaterialEditText;

@ContentView(R.layout.activity_article_send)
public class ArticleSendActivity extends BaseActivity {

	@ViewInject(R.id.mainToolbar)
	protected Toolbar mainToolbar;
	@ViewInject(R.id.imageGridView)
	protected NoScrollGridView imageGridView;
	@ViewInject(R.id.titleEditText)
	protected MaterialEditText titleEditText;
	@ViewInject(R.id.contentEditText)
	protected MaterialEditText contentEditText;
	@ViewInject(R.id.submitBtn)
	protected View submitBtn;

	public String uptoken = null;

	private PhotoMainAdapter adapter;

	private ArrayList<String> imagePathList = new ArrayList<String>();

	public static final int SMALL_IMAGE_CAPACITY = 300;

	protected ArrayList<String> uploadedImageUrlList = new ArrayList<String>();
	
	public static final String CACHE_DIR = SdCardUtil.getAppDirectory()
			+ "/cache/";
	
	private File[] cacheFiles = new File[PhotoMainAdapter.MAX_SELECT_PHOTO_NUM];
	
	public static final int OP_CODE_CHOOSE_PHOTO = 1;
	public static final int OP_CODE_PREVIEW_PHOTO = 2;
	
	boolean imageUploadSuccess = false;
	
	int mGradeId = -1;
	int mArticleType = -1;
	
	@Override
	protected void initView() {
		super.initView();
		setSupportActionBar(mainToolbar);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case android.R.id.home:
			finish();
			break;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	protected void initData() {
		mGradeId = getIntent().getIntExtra("gradeId", -1);
		mArticleType = getIntent().getIntExtra("articleType", -1);
		adapter = new PhotoMainAdapter(this, imagePathList);
		imageGridView.setAdapter(adapter);
		File cacheDir = new File(CACHE_DIR);
		cacheDir.mkdir();
		for (int i = 0; i < PhotoMainAdapter.MAX_SELECT_PHOTO_NUM; i++) {
			File file = new File(CACHE_DIR + "thumbnail"
					+i+ ".jpg");
			cacheFiles[i] = file;
		}
	}
	
	

	private void getUpToken() {
		showLoadingView();
		HttpUtil.post(URL.GET_UP_TOKEN, null,
				new HttpBeanCallBack<UpTokenResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {
						hideLoadingView();
					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							UpTokenResBean responseBean) {
						uptoken = responseBean.getUpToken();
						doUploadImage(imagePathList.get(0), 0);
					}
				});
	}
	
	private void doUploadImage(String imagePath,final int position) {
		ImageCompressUtil.compressImage2Small(imagePath, cacheFiles[position].getAbsolutePath(), SMALL_IMAGE_CAPACITY);
		final ViewHolder holder = (ViewHolder) imageGridView.getChildAt(position).getTag();
		QiniuUtil.put(cacheFiles[position].getAbsolutePath(), UUIDUtil.getUUID(), uptoken, new FileLoadCallBack() {
			
			@Override
			public void onProcess(String key, double percent) {
				super.onProcess(key, percent);
				holder.sinkingView.setPercent((float)percent);
			}
			
			@Override
			public void onSuccess(String key) {
				uploadedImageUrlList.add(URL.QINIU+key);
				// TipUtil.showShort(context, "图片上传成功");
				// 如果所有图片都上传成功了，再提交帖子
				if(position == imagePathList.size()-1){
					imageUploadSuccess = true;
					sendArticle();
				}else{//否则继续上传
					doUploadImage(imagePathList.get(position+1),position+1);
				}
			}
			
			@Override
			public void onFailure(String errorMsg) {
				hideLoadingView();
//				TipUtil.show(errorMsg);
				TipUtil.show("第"+(position+1)+"张图片上传失败,请重试");
				holder.sinkingView.clear();
			}
		});
		
	}
	
	@OnClick(R.id.submitBtn)
	protected void submitData(View v) {
		String content = contentEditText.getText().toString();
		if(TextUtils.isEmpty(content)){
			YoYo.with(Techniques.Bounce).playOn(contentEditText);
			return;
		}
		if(!imagePathList.isEmpty() && !imageUploadSuccess){
			getUpToken();
		}else{
			sendArticle();
		}
		
		 
	}
	
	void sendArticle(){
		showLoadingView();
		ArticleSendReqBean bean = new ArticleSendReqBean();
		bean.setAuthorId(userInfo.getUserId());
		bean.setAuthorType(2);
		bean.setContent(contentEditText.getText().toString());
		//FIXME 教师端的需要通过选择班级获取
		bean.setGradeId(mGradeId);
		bean.setImgUrls(uploadedImageUrlList);
		bean.setTitle(titleEditText.getText().toString());
		bean.setTypeId(mArticleType);
		HttpUtil.post(URL.ARTICLE_SEND, bean, new HttpBeanCallBack<CommonResultResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				TipUtil.show("发布失败！！");
				hideLoadingView();
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					CommonResultResBean responseBean) {
				hideLoadingView();
				finish();
			}
		});
	}

	/**
	 * 打开大图预览界面
	 * 
	 * @param position
	 *            预览的首先位置
	 * @param list
	 *            预览的数据集
	 */
	private void openPreviewActivity(int openType, int position,
			ArrayList<String> list) {
		Intent pIntent = new Intent(this, PhotoPreviewActivity.class);
		pIntent.putExtra("openType", openType);
		pIntent.putExtra("activityClass", this.getClass().getName());
		pIntent.putStringArrayListExtra("selectedImagePaths", list);
		pIntent.putStringArrayListExtra("allImagePaths", list);
		pIntent.putExtra("position", position);
		pIntent.putExtra("maxSelectImageNum", imagePathList.size());
		startActivityForResult(pIntent, OP_CODE_PREVIEW_PHOTO);
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);
		if (resultCode != RESULT_OK)
			return;
		switch (requestCode) {
		case OP_CODE_CHOOSE_PHOTO:
		case OP_CODE_PREVIEW_PHOTO:
			imagePathList.clear();
			imagePathList.addAll(data
					.getStringArrayListExtra("selectedImagePaths"));
			adapter = new PhotoMainAdapter(this, imagePathList);
			imageGridView.setAdapter(adapter);
			break;
		}

	}

	@Override
	protected void onNewIntent(Intent intent) {
		super.onNewIntent(intent);
		imagePathList.clear();
		imagePathList.addAll(intent
				.getStringArrayListExtra("selectedImagePaths"));
		adapter = new PhotoMainAdapter(this, imagePathList);
		imageGridView.setAdapter(adapter);
	}
	

	@Override
	protected void initListener() {
		imageGridView.setOnItemClickListener(new OnItemClickListener() {

			@Override 
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {
				if (imagePathList.size() != PhotoMainAdapter.MAX_SELECT_PHOTO_NUM
						&& position == adapter.getCount() - 1) {
					Intent intent = new Intent(context, PhotoWallActivity.class);
					intent.putExtra("selectedImagePaths", imagePathList);
					intent.putExtra("maxSelectImageNum",
							PhotoMainAdapter.MAX_SELECT_PHOTO_NUM);
					intent.putExtra("activityClass", ArticleSendActivity.this.getClass().getName());
					startActivityForResult(intent, OP_CODE_CHOOSE_PHOTO);
				} else {
					openPreviewActivity(
							PhotoPreviewActivity.OPEN_TYPE_MENY_PHOTO,
							position, imagePathList);
				}

			}
		});
	}
	
	

}
