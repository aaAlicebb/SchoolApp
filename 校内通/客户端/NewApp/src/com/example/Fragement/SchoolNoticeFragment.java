package com.example.Fragement;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.Header;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;
import android.widget.ImageView;

import com.example.adapter.CommonAdapter;
import com.example.adapter.ViewHolder;
import com.example.app.Constant.URL;
import com.example.baserbean.UserInfoBean;
import com.example.baserbean.UserInfoReqBean;
import com.example.bean.ArticleBean;
import com.example.bean.ArticleDetailReqBean;
import com.example.bean.ArticleListResBean;
import com.example.bean.CommonResultResBean;
import com.example.bean.UpRecordEntity;
import com.example.common.ui.PhotoDetailActivity;
import com.example.db.dao.UpRecordDao;
import com.example.newapp.ArticleDetailActivity;
import com.example.newapp.R;
import com.example.util.DateUtil;
import com.example.util.DimenUtil;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.ImageLoaderHelper;
import com.example.util.ImageLoaderHelper.ImageLoadingType;
import com.example.util.TipUtil;
import com.github.ksoichiro.android.observablescrollview.ObservableListView;
import com.github.ksoichiro.android.observablescrollview.ObservableScrollViewCallbacks;
import com.lidroid.xutils.view.annotation.ViewInject;
import com.rey.material.widget.TextView;

public class SchoolNoticeFragment extends BaseFragment {

	// @ViewInject(R.id.ptrFrameLayout)
	// protected PtrFrameLayout mPtrFrameLayout;
	@ViewInject(R.id.scroll)
	protected ObservableListView listView;
	protected UpRecordDao upRecordDao = new UpRecordDao();
	CommonAdapter<ArticleBean> mAdapter;
	List<ArticleBean> mDatas = new ArrayList<ArticleBean>();

	int imageWidth;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		int width = DimenUtil.getScreenSize()[0];
		imageWidth = (width - DimenUtil.dpToPx(32)) / 3;
	}

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_home_notice, null);
	}

	@Override
	protected void initData() {
		super.initData();

//		listView.setTouchInterceptionViewGroup((ViewGroup) MainHomeFragment.instance
//				.getView().findViewById(R.id.container));

		if (MainHomeFragment.instance instanceof ObservableScrollViewCallbacks) {
			listView.setScrollViewCallbacks((ObservableScrollViewCallbacks) MainHomeFragment.instance);
		}

		// final StoreHouseHeader header = new StoreHouseHeader(context);
		// header.setPadding(0, LocalDisplay.dp2px(15), 0, 0);
		/**
		 * using a string, support: A-Z 0-9 - . you can add more letters by
		 * {@link in.srain.cube.views.ptr.header.StoreHousePath#addChar}
		 */
		// header.initWithString("Kindergarten");

		// mPtrFrameLayout.setDurationToCloseHeader(1000);
		// mPtrFrameLayout.setHeaderView(header);
		// mPtrFrameLayout.addPtrUIHandler(header);
		// mPtrFrameLayout.setLoadingMinTime(1000);
		// mPtrFrameLayout.setPtrHandler(new PtrHandler() {
		// @Override
		// public boolean checkCanDoRefresh(PtrFrameLayout frame,
		// View content, View header) {
		//
		// // return true;
		// // here check list view, not content.
		// return PtrDefaultHandler.checkContentCanBePulledDown(frame,
		// listView, header);
		// }
		//
		// @Override
		// public void onRefreshBegin(PtrFrameLayout frame) {
		// loadNewData();
		// }
		// });

		// header place holder

		if (mAdapter == null) {
			mAdapter = new CommonAdapter<ArticleBean>(context, mDatas,
					R.layout.item_normal_article) {

				@Override
				public void convert(int position, ViewHolder helper,
						ArticleBean item) {
					initItemView(position, helper, item);
				}
			};
			listView.setAdapter(mAdapter);
		}

		loadNewData();

		// auto load data
		// mPtrFrameLayout.postDelayed(new Runnable() {
		// @Override
		// public void run() {
		// mPtrFrameLayout.autoRefresh(true);
		// }
		// }, 150);
	}

	String url =URL.ARTICLE_HOME_NOTICE_LIST;

	@SuppressWarnings("deprecation")
	protected void loadNewData() {
		showLoadingView();
		UserInfoReqBean bean = new UserInfoReqBean();
		bean.setUserId(userInfo.getUserId());
		HttpUtil.post(url, bean, new HttpBeanCallBack<ArticleListResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				// mPtrFrameLayout.refreshComplete();
				hideLoadingView();
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					ArticleListResBean responseBean) {
				hideLoadingView();
				mDatas.clear();
				if (responseBean.getArticles() != null) {
					mDatas.addAll(responseBean.getArticles());
					// binding view and data
					mAdapter.updateView(mDatas);
				}
				else{
					TipUtil.show("获取数据为空");
				}

				// mPtrFrameLayout.refreshComplete();

			}
		});

	}

	protected void go2DetailActivity(int articleId) {
		Intent intent = new Intent(context, ArticleDetailActivity.class);
		intent.putExtra("articleId", articleId);
		startActivity(intent);
	}

	protected void initItemView(final int position, ViewHolder helper,
			final ArticleBean item) {
		TextView nameTextView = helper.getView(R.id.nameTextView);
		final TextView upNumTextView = helper.getView(R.id.upNumTextView);
		TextView commentNumTextView = helper.getView(R.id.commentNumTextView);
		View cardview = helper.getView(R.id.cardview);
		// 赋值
		nameTextView.setText(item.getAuthorName());
		upNumTextView.setText("赞  " + item.getUpNumber());
		commentNumTextView.setText("评论  " + item.getCommentNumber());
		helper.setText(R.id.timeTextView,
				DateUtil.getFlexibleDate(item.getDeliverTime().getTime()));
		helper.setText(R.id.contentTextView, item.getContent());
		TextView topTextView = helper.getView(R.id.topTextView);
		if (item.getTop() == 1)
			topTextView.setVisibility(View.VISIBLE);
		else
			topTextView.setVisibility(View.INVISIBLE);
		ImageView avatarImageView = helper.getView(R.id.avatarImageView);
		ImageLoaderHelper.displayImage(item.getAuthorPhotoUrl(),
				avatarImageView, ImageLoadingType.AVATAR);

		// 初始化赞的颜色
		UpRecordEntity uprecord = upRecordDao.findOne(item.getArticleId(),
				userInfo.getUserId(), 2);
		if (uprecord == null || uprecord.getStatus() == 0) {// 未点赞
			upNumTextView.setTextColor(getResources().getColor(
					R.color.colorTextSecondPrimary));
		} else {
			upNumTextView.setTextColor(Color.RED);
		}
		upNumTextView.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				// 判断显示还是
				UpRecordEntity uprecord = upRecordDao.findOne(
						item.getArticleId(), userInfo.getUserId(),
						2);
				if (uprecord == null) {
					uprecord = new UpRecordEntity(item.getArticleId(),
							userInfo.getUserId(), 2, 1);
					upRecordDao.saveOrUpdate(uprecord);
				} else if (uprecord.getStatus() == 0) {// 未点赞
					uprecord.setStatus(1);
					upArticle(position, uprecord);
				} else {
					uprecord.setStatus(0);
					cancelUpArticle(position, uprecord);
				}

			}
		});
		/**
		 * 点击查看详情
		 */

		cardview.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				go2DetailActivity(item.getArticleId());
			}
		});

		commentNumTextView.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				go2DetailActivity(item.getArticleId());
			}
		});

		GridView photoGridView = helper.getView(R.id.photoGridView);

		if (item.getImageUrls() == null || item.getImageUrls().isEmpty()) {
			photoGridView.setVisibility(View.GONE);
		} else {
			photoGridView.setVisibility(View.VISIBLE);
			photoGridView.setAdapter(new CommonAdapter<String>(context, item
					.getImageUrls(), R.layout.item_article_photo) {

				@Override
				public void convert(int position, ViewHolder helper, String item) {
					ImageView image = helper.getView(R.id.photoImageView);
					ViewGroup.LayoutParams lp = image.getLayoutParams();
					lp.height = imageWidth;
					lp.width = imageWidth;
					image.setLayoutParams(lp);
					ImageLoaderHelper.displayImage(item, image);
					// ImageLoaderUtil.displayImage(image, item);
				}
			});
			photoGridView.setOnItemClickListener(new OnItemClickListener() {

				@Override
				public void onItemClick(AdapterView<?> parent, View view,
						int position, long id) {
					//  点击显示大图，最好是平滑的那种
					Intent intent = new Intent(context,
							PhotoDetailActivity.class);
					intent.putExtra("position", position);
					intent.putStringArrayListExtra("allImagePaths",
							(ArrayList<String>) item.getImageUrls());
					context.startActivity(intent);

				}

			});
		}

	}

	protected void upArticle(final int position, final UpRecordEntity uprecord) {
		ArticleDetailReqBean bean = new ArticleDetailReqBean();
		bean.setArticleId(mDatas.get(position).getArticleId());
		HttpUtil.post(URL.ARTICLE_UP, bean,
				new HttpBeanCallBack<CommonResultResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {

					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							CommonResultResBean responseBean) {
						// 更新显示
						ArticleBean bean = mDatas.get(position);
						bean.setUpNumber(bean.getUpNumber() + 1);
						upRecordDao.saveOrUpdate(uprecord);
						mAdapter.updateView(mDatas);
						// upTextView.setTextColor(Color.RED);
					}
				});
	}

	protected void cancelUpArticle(final int position,
			final UpRecordEntity uprecord) {
		ArticleDetailReqBean bean = new ArticleDetailReqBean();
		bean.setArticleId(mDatas.get(position).getArticleId());
		HttpUtil.post(URL.ARTICLE_UP_CANCEL, bean,
				new HttpBeanCallBack<CommonResultResBean>() {

					@Override
					public void onFailure(int statusCode, String errorMsg) {

					}

					@Override
					public void onSuccess(int statusCode, Header[] headers,
							CommonResultResBean responseBean) {
						// 更新显示
						ArticleBean bean = mDatas.get(position);
						bean.setUpNumber(bean.getUpNumber() - 1);
						upRecordDao.saveOrUpdate(uprecord);
						mAdapter.updateView(mDatas);
						// upTextView.setTextColor(getResources().getColor(
						// R.color.colorTextSecondPrimary));
					}
				});
	}

}
