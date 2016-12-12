package com.example.newapp;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.Header;

import android.content.Context;
import android.graphics.Color;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.ListView;

import com.example.adapter.CommonAdapter;
import com.example.adapter.ViewHolder;
import com.example.app.Constant.CONFIG;
import com.example.app.Constant.URL;
import com.example.bean.ArticleBean;
import com.example.bean.ArticleCommentReqBean;
import com.example.bean.ArticleCommentResBean;
import com.example.bean.ArticleDetailReqBean;
import com.example.bean.ArticleDetailResBean;
import com.example.bean.CommentBean;
import com.example.bean.CommentSendReqBean;
import com.example.bean.CommonResultResBean;
import com.example.bean.UpRecordEntity;
import com.example.db.dao.UpRecordDao;
import com.example.util.DateUtil;
import com.example.util.DimenUtil;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.ImageLoaderHelper;
import com.example.util.ImageLoaderHelper.ImageLoadingType;
import com.example.util.TipUtil;
import com.lidroid.xutils.view.annotation.ContentView;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.orangegangsters.github.swipyrefreshlayout.library.SwipyRefreshLayout;
import com.orangegangsters.github.swipyrefreshlayout.library.SwipyRefreshLayout.OnRefreshListener;
import com.orangegangsters.github.swipyrefreshlayout.library.SwipyRefreshLayoutDirection;
import com.rengwuxian.materialedittext.MaterialEditText;
import com.rey.material.widget.ImageButton;
import com.rey.material.widget.TextView;

@ContentView(R.layout.activity_article_detail)
public class ArticleDetailActivity extends BaseActivity implements
		OnRefreshListener {

	@ViewInject(R.id.mainToolbar)
	Toolbar mainToolbar;
	@ViewInject(R.id.swipyRefreshLayout)
	SwipyRefreshLayout swipyRefreshLayout;
	@ViewInject(R.id.avatarImageView)
	ImageView avatarImageView;
	@ViewInject(R.id.nameTextView)
	TextView nameTextView;
	@ViewInject(R.id.timeTextView)
	TextView timeTextView;
	@ViewInject(R.id.contentTextView)
	TextView contentTextView;
	@ViewInject(R.id.photoGridView)
	GridView photoGridView;
	@ViewInject(R.id.upNumTextView)
	TextView upNumTextView;
	@ViewInject(R.id.commentNumTextView)
	TextView commentNumTextView;
	@ViewInject(R.id.commentListView)
	ListView commentListView;
	@ViewInject(R.id.commentEditText)
	MaterialEditText commentEditText;
	@ViewInject(R.id.sendCommentButton)
	ImageButton sendCommentButton;

	UpRecordDao upRecordDao = new UpRecordDao();

	Integer articleId;
	ArticleBean articleBean;
	List<CommentBean> commentList = new ArrayList<CommentBean>();

	@Override
	protected void initView() {
		super.initView();
		setSupportActionBar(mainToolbar);
	}
	
	int imageWidth;
	
	@Override
	protected void initData() {
		super.initData();
		int width = DimenUtil.getScreenSize()[0];
		imageWidth = (width - DimenUtil.dpToPx(32)) / 3;
		articleId = getIntent().getIntExtra("articleId", -1);
		swipyRefreshLayout.setOnRefreshListener(this);
		swipyRefreshLayout.postDelayed(new Runnable() {

			@Override
			public void run() {
				swipyRefreshLayout.setRefreshing(true);
				loadContent();
			}
		}, 150);

		// swipyRefreshLayout.setRefreshing(true);
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
	protected void initListener() {
		super.initListener();
		upNumTextView.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				// 判断显示还是
				UpRecordEntity uprecord = upRecordDao.findOne(
						articleBean.getArticleId(), userInfo.getUserId(),
						2);
				if (uprecord == null) {
					uprecord = new UpRecordEntity(articleBean.getArticleId(),
							userInfo.getUserId(), 2, 1);
					upRecordDao.saveOrUpdate(uprecord);
				} else if (uprecord.getStatus() == 0) {// 未点赞
					uprecord.setStatus(1);
					upArticle(uprecord);
				} else {
					uprecord.setStatus(0);
					cancelUpArticle(uprecord);
				}
			}
		});
		sendCommentButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				sendComment();
			}
		});
		;

	}

	private void loadContent() {
		ArticleDetailReqBean bean = new ArticleDetailReqBean();
		bean.setArticleId(articleId);
		HttpUtil.post(URL.ARTICLE_DETAIL, bean,
				new HttpBeanCallBack<ArticleDetailResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {
						swipyRefreshLayout.setRefreshing(false);
					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							ArticleDetailResBean responseBean) {
//						swipyRefreshLayout.setRefreshing(false);
						articleBean = responseBean.getArticle();
						// 赋值
						nameTextView.setText(articleBean.getAuthorName());
						timeTextView.setText(DateUtil
								.getFlexibleDate(articleBean.getDeliverTime()
										.getTime()));
						contentTextView.setText(articleBean.getContent());
						upNumTextView.setText("赞  " + articleBean.getUpNumber());
						// 初始化赞的颜色
						UpRecordEntity uprecord = upRecordDao.findOne(
								articleBean.getArticleId(),
								userInfo.getUserId(), 2);
						if (uprecord == null || uprecord.getStatus() == 0) {
							upNumTextView.setTextColor(getResources().getColor(
									R.color.colorTextSecondPrimary));
						} else {
							upNumTextView.setTextColor(Color.RED);
						}
						commentNumTextView.setText("评论  "
								+ articleBean.getCommentNumber());
						nameTextView.setText(articleBean.getAuthorName());
						ImageLoaderHelper.displayImage(articleBean.getAuthorPhotoUrl(), avatarImageView,ImageLoadingType.AVATAR);
//						ImageLoaderUtil.displayImage(avatarImageView,
//								articleBean.getAuthorPhotoUrl(),
//								ImageLoadType.avatar);
						if (articleBean.getImageUrls() == null || articleBean.getImageUrls().isEmpty()) {
							photoGridView.setVisibility(View.GONE);
						} else {
							photoGridView.setVisibility(View.VISIBLE);
							photoGridView.setAdapter(new CommonAdapter<String>(context, articleBean
									.getImageUrls(), R.layout.item_article_photo) {

								@Override
								public void convert(int position, ViewHolder helper, String item) {
									ImageView image = helper.getView(R.id.photoImageView);
									ViewGroup.LayoutParams lp = image.getLayoutParams();
									lp.height = imageWidth;
									lp.width = imageWidth;
									image.setLayoutParams(lp);
									ImageLoaderHelper.displayImage(item, image);
//									ImageLoaderUtil.displayImage(image, item);
									helper.setImageByUrl(R.id.photoImageView, item);
								}
							});
							photoGridView.setOnItemClickListener(new OnItemClickListener() {

								@Override
								public void onItemClick(AdapterView<?> parent, View view,
										int position, long id) {
									// FIXME 点击显示大图，最好是平滑的那种

								}

							});

					}
						loadNewData();
				}});

	}

	private CommentAdapter mAdapter;

	private void loadNewData() {
		ArticleCommentReqBean bean = new ArticleCommentReqBean();
		bean.setArticleId(articleId);
		bean.setFromId(0);
		bean.setPageSize(CONFIG.DEFAULT_PAGE_SIZE);
		HttpUtil.post(URL.ARTICLE_COMMENT_LIST, bean,
				new HttpBeanCallBack<ArticleCommentResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {
						swipyRefreshLayout.setRefreshing(false);
					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							ArticleCommentResBean responseBean) {
						commentList.clear();
						commentList.addAll(responseBean.getComments());
						if (mAdapter == null) {
							mAdapter = new CommentAdapter(context, commentList,
									R.layout.item_article_comment);
							commentListView.setAdapter(mAdapter);
						} else {
							mAdapter.updateView(commentList);
						}
						swipyRefreshLayout.setRefreshing(false);

					}
				});

	}
/**
 * 加载更多
 */
	private void loadMoreData() {
		ArticleCommentReqBean bean = new ArticleCommentReqBean();
		bean.setArticleId(articleId);
		if(commentList.size()<=0){
			
			TipUtil.show("暂无评论！");
		}
		CommentBean last = commentList.get(commentList.size() - 1);
		bean.setFromId(last.getCommentId());
		bean.setPageSize(CONFIG.DEFAULT_PAGE_SIZE);
		HttpUtil.post(URL.ARTICLE_COMMENT_LIST, bean,
				new HttpBeanCallBack<ArticleCommentResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {
						TipUtil.show("没有更多的了！");
						swipyRefreshLayout.setRefreshing(false);
					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							ArticleCommentResBean responseBean) {
						commentList.addAll(responseBean.getComments());
						mAdapter.updateView(commentList);
						swipyRefreshLayout.setRefreshing(false);

					}
				});
	}

	Integer rootCommentId;

	class CommentAdapter extends CommonAdapter<CommentBean> {

		public CommentAdapter(Context context, List<CommentBean> mDatas,
				int itemLayoutId) {
			super(context, mDatas, itemLayoutId);
		}

		@Override
		public void convert(int position, ViewHolder helper,
				final CommentBean item) {

			ImageView image = helper.getView(R.id.image);
			ImageLoaderHelper.displayImage(item.getAuthorPhotoUrl(),image,ImageLoadingType.AVATAR);
//			ImageLoaderUtil.displayImage(image, item.getAuthorPhotoUrl(),
//					ImageLoadType.avatar);
			View commentLayout = helper.getView(R.id.commentLayout);
			TextView name = helper.getView(R.id.name);
			TextView desc = helper.getView(R.id.content);
			TextView date = helper.getView(R.id.date);
			name.setText(item.getAuthorName());
			String temp = "";

			if (item.getRootName() != null) {
				temp = "回复 " + item.getRootName() + ":";
			}

			desc.setText(temp + item.getContent());
			date.setText(DateUtil.getFlexibleDate(item.getCommentTime()
					.getTime()));

			commentLayout.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					// 点击评论进行评论
					commentEditText.requestFocus();
					commentEditText.setHint("回复" + item.getAuthorName() + ":");
					rootCommentId = item.getCommentId();
				}
			});

		}

	}

	@Override
	public void onRefresh(SwipyRefreshLayoutDirection direction) {
		if (direction == SwipyRefreshLayoutDirection.TOP) {
			loadContent();
		} else {
			loadMoreData();
		}

	}

	protected void upArticle(final UpRecordEntity uprecord) {
		ArticleDetailReqBean bean = new ArticleDetailReqBean();
		bean.setArticleId(articleBean.getArticleId());
		HttpUtil.post(URL.ARTICLE_UP, bean,
				new HttpBeanCallBack<CommonResultResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {

					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							CommonResultResBean responseBean) {
						// 更新显示
						articleBean.setUpNumber(articleBean.getUpNumber() + 1);
						upRecordDao.saveOrUpdate(uprecord);
						upNumTextView.setTextColor(Color.RED);
						upNumTextView.setText("赞  " + articleBean.getUpNumber());
					}
				});
	}

	protected void cancelUpArticle(final UpRecordEntity uprecord) {
		ArticleDetailReqBean bean = new ArticleDetailReqBean();
		bean.setArticleId(articleBean.getArticleId());
		HttpUtil.post(URL.ARTICLE_UP_CANCEL, bean,
				new HttpBeanCallBack<CommonResultResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {

					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							CommonResultResBean responseBean) {
						// 更新显示
						articleBean.setUpNumber(articleBean.getUpNumber() - 1);
						upRecordDao.saveOrUpdate(uprecord);
						upNumTextView.setTextColor(getResources().getColor(
								R.color.colorTextSecondPrimary));
						upNumTextView.setText("赞  " + articleBean.getUpNumber());
					}
				});
	}
/**
 * 显示评论
 */
public	void sendComment() {
		String content = commentEditText.getText().toString();
		if (TextUtils.isEmpty(content)) {
			return;
		}
		showLoadingView();
		CommentSendReqBean bean = new CommentSendReqBean();
		bean.setArticleId(articleId);
		bean.setRootId(rootCommentId);
		bean.setContent(content);
		bean.setAuthorId(userInfo.getUserId());
		bean.setAuthorType(2);
		HttpUtil.post(URL.ARTICLE_COMMENT_SEND, bean,
				new HttpBeanCallBack<CommonResultResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {
						hideLoadingView();
					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							CommonResultResBean responseBean) {
						hideLoadingView();
						TipUtil.show("评论发表成功");
						// 隐藏键盘
						InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
						// imm.toggleSoftInput(0,
						// InputMethodManager.HIDE_NOT_ALWAYS);
						imm.hideSoftInputFromWindow(
								commentEditText.getWindowToken(), 0); // 强制隐藏键盘
						commentEditText.setText("");
						commentEditText.setHint("说点啥吧。。。");
						// 更新评论界面
						loadNewData();

					}
				});
	}

}
