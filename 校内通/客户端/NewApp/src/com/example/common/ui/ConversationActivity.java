package com.example.common.ui;

import android.content.Intent;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;

import com.example.newapp.BaseActivity;
import com.example.newapp.R;
import com.lidroid.xutils.view.annotation.ContentView;
import com.lidroid.xutils.view.annotation.ViewInject;

@ContentView(R.layout.activity_conversation)
public class ConversationActivity extends BaseActivity {

	@ViewInject(R.id.mainToolbar)
	Toolbar mainToolbar;
	String targetId;

	@Override
	protected void initView() {
		super.initView();
		setSupportActionBar(mainToolbar);
		 
		// getSupportActionBar().setLogo(R.drawable.ic_launcher);
		Intent intent = getIntent();
		targetId = intent.getData().getQueryParameter("targetId");
		String title = intent.getData().getQueryParameter("title");
		getSupportActionBar().setTitle(title); // 设置会话 title
		getSupportActionBar().setDisplayHomeAsUpEnabled(true);
		getSupportActionBar().setHomeAsUpIndicator(
				R.drawable.ic_arrow_back_white);
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

}
