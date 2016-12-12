package com.example.newapp;

import java.util.ArrayList;

import android.content.Intent;
import android.graphics.Color;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;
import android.widget.ImageView;

import com.example.adapter.CommonAdapter;
import com.example.adapter.ViewHolder;
import com.example.app.Constant.CONFIG;
import com.example.app.GlobalContext;
import com.example.bean.ArticleBean;
import com.example.bean.ArticleListReqBean;
import com.example.bean.UpRecordEntity;
import com.example.common.ui.PhotoDetailActivity;
import com.example.util.DateUtil;
import com.example.util.DimenUtil;
import com.example.util.ImageLoaderHelper;
import com.example.util.ImageLoaderHelper.ImageLoadingType;
import com.rey.material.widget.TextView;

public class NormalArticleListActivity extends AbstractArticleListActivity {

	int imageWidth;

	@Override
	protected void initView() {
		super.initView();

		mainToolbar.setTitle(mArticleType.getTypeName());
		int width = DimenUtil.getScreenSize()[0];
		imageWidth = (width - DimenUtil.dpToPx(32)) / 3;
		// 是公告，不能发表帖子
		if (mArticleType.getTypeId() <= 2) {
			fab.setVisibility(View.GONE);
		}
		// final int imageHeight = (int) (imageWidth * 0.7);
	}

	@Override
	protected ArticleListReqBean getRequestBean() {
		ArticleListReqBean reqBean = new ArticleListReqBean();
		reqBean.setRole(CONFIG.ROLE_PARENT);
		reqBean.setTypeId(mArticleType.getTypeId());
		// 记得修改，从配置读取
		reqBean.setPersonId(userInfo.getUserId());
		// 如果是与班级相关的帖子
		if (mArticleType.getTypeId() <= 3) {
			reqBean.setGradeId(GlobalContext.getInstance().getUserInfo()
					.getGrade().getGradeId());
		}
		return reqBean;
	}

	@Override
	protected void initListener() {
		super.initListener();
		fab.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				Intent intent = new Intent(context, ArticleSendActivity.class);
				if (mArticleType.getTypeId() == 2
						|| mArticleType.getTypeId() == 3) {// 班级论坛，公告
					intent.putExtra("gradeId", GlobalContext.getInstance()
							.getUserInfo().getGrade().getGradeId());
				} else {
					intent.putExtra("gradeId", -1);
				}
				intent.putExtra("articleType", mArticleType.getTypeId());
				startActivity(intent);
			}
		});
	}

	@Override
	protected int getItemLayoutId() {
		return R.layout.item_normal_article;
	}

	@Override
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
		// ImageLoaderUtil.displayImage(avatarImageView,
		// item.getAuthorPhotoUrl(),
		// ImageLoadType.avatar);

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

}
