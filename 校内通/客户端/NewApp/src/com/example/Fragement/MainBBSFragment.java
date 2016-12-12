package com.example.Fragement;

import java.util.List;

import android.graphics.Rect;
import android.os.Bundle;
import android.preference.PreferenceActivity.Header;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;

import com.example.adapter.ArticleTypeAdapter;
import com.example.app.Constant.URL;
import com.example.bean.ArticleType;
import com.example.bean.ArticleTypeListResBean;
import com.example.newapp.R;
import com.example.util.DimenUtil;
import com.example.util.HttpBeanCallBack;
import com.example.util.HttpUtil;
import com.example.util.TipUtil;
import com.lidroid.xutils.view.annotation.ViewInject;

public class MainBBSFragment extends BaseFragment {
	
	@ViewInject(R.id.bbsRecyclerView)
	 RecyclerView bbsRecyclerView;
	 List<ArticleType> typeList;
	 ArticleTypeAdapter adapter;

	@Override
	public View initView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		return inflater.inflate(R.layout.fragment_main_bbs, null);
	}
	
	@Override
	protected void initData() {
		super.initData();
		showLoadingView();
		
		bbsRecyclerView.setLayoutManager(new GridLayoutManager(getActivity(), 2));
		final int inset = DimenUtil.dpToPx(4);
		bbsRecyclerView.addItemDecoration(new RecyclerView.ItemDecoration(){

			 @Override
			    public void getItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state) {

			        //We can supply forced insets for each item view here in the Rect
			        super.getItemOffsets(outRect, view, parent, state);
			        outRect.set(inset, inset, inset, inset);
			    }
			
		});
//		bbsRecyclerView.setOnScrollListener(recyclerScrollListener);
		bbsRecyclerView.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                return false;
            }
        });
		
		HttpUtil.post(URL.ARTICLE_TYPE, null, new HttpBeanCallBack<ArticleTypeListResBean>() {

			@Override
			public void onFailure(int statusCode, String errorMsg) {
				// TODO Auto-generated method stub
				hideLoadingView();
				TipUtil.show("获取失败");
			}

			@Override
			public void onSuccess(int statusCode,
					org.apache.http.Header[] headers,
					ArticleTypeListResBean responseBean) {
				// TODO Auto-generated method stub
					hideLoadingView();
					typeList = responseBean.getTypeList();
					adapter = new ArticleTypeAdapter(typeList, getActivity());
					bbsRecyclerView.setAdapter(adapter);
			}
			
			
		});
	}
		

}

