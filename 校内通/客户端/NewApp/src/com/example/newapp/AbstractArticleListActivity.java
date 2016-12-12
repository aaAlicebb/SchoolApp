package com.example.newapp;

import in.srain.cube.views.loadmore.LoadMoreContainer;
import in.srain.cube.views.loadmore.LoadMoreHandler;
import in.srain.cube.views.loadmore.LoadMoreListViewContainer;
import in.srain.cube.views.ptr.PtrDefaultHandler;
import in.srain.cube.views.ptr.PtrFrameLayout;
import in.srain.cube.views.ptr.PtrHandler;
import in.srain.cube.views.ptr.header.StoreHouseHeader;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.Header;

import android.content.Intent;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import android.widget.AbsListView;
import android.widget.AbsListView.OnScrollListener;
import android.widget.ListView;

import com.example.adapter.CommonAdapter;
import com.example.adapter.ViewHolder;
import com.example.app.Constant.CONFIG;
import com.example.app.Constant.URL;
import com.example.bean.ArticleBean;
import com.example.bean.ArticleDetailReqBean;
import com.example.bean.ArticleListReqBean;
import com.example.bean.ArticleListResBean;
import com.example.bean.ArticleType;
import com.example.bean.CommonResultResBean;
import com.example.bean.UpRecordEntity;
import com.example.db.dao.UpRecordDao;
import com.example.util.DimenUtil;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.TipUtil;
import com.melnykov.fab.FloatingActionButton;

//@ContentView(R.layout.activity_article_list)
public abstract class AbstractArticleListActivity extends BaseActivity {

	protected Toolbar mainToolbar;
	protected PtrFrameLayout mPtrFrameLayout;
	protected LoadMoreListViewContainer loadMoreContainer;
	protected ListView listView;
	protected FloatingActionButton fab;

	CommonAdapter<ArticleBean> mAdapter;
	
	protected ArticleType mArticleType;

	protected UpRecordDao upRecordDao = new UpRecordDao();

	List<ArticleBean> mDatas = new ArrayList<ArticleBean>();

	protected void go2DetailActivity(int articleId) {
		Intent intent = new Intent(context, ArticleDetailActivity.class);
		intent.putExtra("articleId", articleId);
		startActivity(intent);
	}

	@Override
	protected void initView() {
		super.initView();
		// header
		setContentView(R.layout.activity_article_list);
		
		mArticleType = (ArticleType) getIntent().getSerializableExtra(
				"articleType");
		
		mPtrFrameLayout = (PtrFrameLayout) findViewById(R.id.ptrFrameLayout);
		mainToolbar = (Toolbar) findViewById(R.id.mainToolbar);
		
		setSupportActionBar(mainToolbar);
		
		loadMoreContainer = (LoadMoreListViewContainer) findViewById(R.id.loadMoreContainer);
		listView = (ListView) findViewById(R.id.listView);
		fab = (FloatingActionButton) findViewById(R.id.fab);
		if (fab != null)
			fab.attachToListView(listView, null,new OnScrollListener() {
				
				@Override
				public void onScrollStateChanged(AbsListView view, int scrollState) {
					loadMoreContainer.scrollStateChanged(view, scrollState);
				}
				
				@Override
				public void onScroll(AbsListView view, int firstVisibleItem,
						int visibleItemCount, int totalItemCount) {
					loadMoreContainer.scroll(view, firstVisibleItem, visibleItemCount, totalItemCount);
				}
			});
		final StoreHouseHeader header = new StoreHouseHeader(this);
		header.setPadding(0, DimenUtil.dpToPx(15), 0, 0);
		/**
		 * using a string, support: A-Z 0-9 - . you can add more letters by
		 * {@link in.srain.cube.views.ptr.header.StoreHousePath#addChar}
		 */
		header.initWithString("example");

		mPtrFrameLayout.setDurationToCloseHeader(1000);
		mPtrFrameLayout.setHeaderView(header);
		mPtrFrameLayout.addPtrUIHandler(header);
		mPtrFrameLayout.setLoadingMinTime(1000);
		mPtrFrameLayout.setPtrHandler(new PtrHandler() {
			@Override
			public boolean checkCanDoRefresh(PtrFrameLayout frame,
					View content, View header) {

				// return true;
				// here check list view, not content.
				return PtrDefaultHandler.checkContentCanBePulledDown(frame,
						listView, header);
			}

			@Override
			public void onRefreshBegin(PtrFrameLayout frame) {
				loadNewData();
			}
		});

		// header place holder
//		View headerMarginView = new View(context);
//		headerMarginView.setLayoutParams(new AbsListView.LayoutParams(
//				ViewGroup.LayoutParams.MATCH_PARENT, DimenUtil.dpToPx(20)));
//		listView.addHeaderView(headerMarginView);

		loadMoreContainer.useDefaultFooter();

		if (mAdapter == null) {
			mAdapter = new CommonAdapter<ArticleBean>(context, mDatas,
					getItemLayoutId()) {

				@Override
				public void convert(int position, ViewHolder helper,
						ArticleBean item) {
					initItemView(position, helper, item);
				}
			};
			listView.setAdapter(mAdapter);
		}

		// auto load data
		mPtrFrameLayout.postDelayed(new Runnable() {
			@Override
			public void run() {
				mPtrFrameLayout.autoRefresh(true);
			}
		}, 150);

		loadMoreContainer.setLoadMoreHandler(new LoadMoreHandler() {
			@Override
			public void onLoadMore(LoadMoreContainer loadMoreContainer) {
				loadMoreData();
			}
		});

	}

	

	protected String url = URL.ARTICLE_NORMAL_LIST;

	protected void loadNewData() {
		ArticleListReqBean bean = getRequestBean();
		bean.setFromId(0);
		bean.setPageSize(CONFIG.DEFAULT_PAGE_SIZE);
		if (bean.getGradeId() != null && bean.getGradeId() > 0)
			url = URL.ARTICLE_GRADE_LIST;
		HttpUtil.post(url, bean, new HttpBeanCallBack<ArticleListResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				mPtrFrameLayout.refreshComplete();
				TipUtil.show("没有更多数据了！！");
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					ArticleListResBean responseBean) {
				mDatas.clear();
				mDatas.addAll(responseBean.getArticles());
				// binding view and data
				mAdapter.updateView(mDatas);
				mPtrFrameLayout.refreshComplete();

			}
		});

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

	protected void loadMoreData() {
		ArticleListReqBean bean = getRequestBean();
		// TODO 要不要考虑置顶帖大于一页的情况？
		// int fromId = 0;
		// for (ArticleBean a : mDatas) {
		// if(a.getTop()!=1){
		// fromId = a.getArticleId();
		// break;
		// }
		//
		// }
		bean.setFromId(mDatas.get(mDatas.size() - 1).getArticleId());
		bean.setPageSize(CONFIG.DEFAULT_PAGE_SIZE);
		if (bean.getGradeId() != null && bean.getGradeId() > 0)
			url = URL.ARTICLE_GRADE_LIST;
		HttpUtil.post(url, bean, new HttpBeanCallBack<ArticleListResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				loadMoreContainer.loadMoreError(0, "加载数据失败，请重试");
			}

			@Override
			public void onSuccess(int statusCode, Header[] headers,
					ArticleListResBean responseBean) {
				List<ArticleBean> temp = responseBean.getArticles();
				boolean emptyResult = false;
				if (temp == null || temp.isEmpty()) {
					emptyResult = true;
				} else {
					mDatas.addAll(temp);
					mAdapter.updateView(mDatas);
				}
				loadMoreContainer.loadMoreFinish(emptyResult, !emptyResult);

			}
		});
	}

	// protected abstract Integer getTypeId();
	// protected abstract Integer getGradeId();
	// protected abstract Integer getPersonId();
	// protected abstract Integer getRole();
	protected abstract ArticleListReqBean getRequestBean();

	protected abstract int getItemLayoutId();

	protected abstract void initItemView(int position, ViewHolder helper,
			ArticleBean item);

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
