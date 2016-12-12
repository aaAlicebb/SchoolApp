package com.example.adapter;

import io.rong.imkit.RongIM;

import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.SectionIndexer;
import android.widget.TextView;

import com.example.bean.im.ContactBean;
import com.example.newapp.R;
import com.example.util.ImageLoaderHelper;
import com.example.util.ImageLoaderHelper.ImageLoadingType;
import com.makeramen.roundedimageview.RoundedImageView;

public class ContactAdapter extends BaseAdapter implements SectionIndexer{
	
	List<ContactBean> mDatas;
	Context context;
	
	
	public ContactAdapter(Context mContext, List<ContactBean> list) {
		this.context = mContext;
		this.mDatas = list;
	}
	
	/**
	 * 当ListView数据发生变化时,调用此方法来更新ListView
	 * @param list
	 */
	public void updateListView(List<ContactBean> list){
		this.mDatas = list;
		notifyDataSetChanged();
	}

	@Override
	public int getCount() {
		return mDatas.size();
	}

	@Override
	public Object getItem(int position) {
		return null;
	}

	@Override
	public long getItemId(int position) {
		return 0;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		ViewHolder viewHolder = null;
		final ContactBean mContent = mDatas.get(position);
		if (convertView == null) {
			viewHolder = new ViewHolder();
			convertView = LayoutInflater.from(context).inflate(R.layout.item_contact_list, null);
			viewHolder.catalogTextView = (TextView) convertView.findViewById(R.id.catalogTextView);
			viewHolder.nameTextView = (TextView) convertView.findViewById(R.id.nameTextView);
			viewHolder.descTextView = (TextView) convertView.findViewById(R.id.descTextView);
			viewHolder.contactLayout = convertView.findViewById(R.id.contactLayout);
			viewHolder.avatarImageView = (RoundedImageView) convertView.findViewById(R.id.avatarImageView);
			convertView.setTag(viewHolder);
		} else {
			viewHolder = (ViewHolder) convertView.getTag();
		}
		
		//根据position获取分类的首字母的Char ascii值
		int section = getSectionForPosition(position);
		
		//如果当前位置等于该分类首字母的Char的位置 ，则认为是第一次出现
		if(position == getPositionForSection(section)){
			viewHolder.catalogTextView.setVisibility(View.VISIBLE);
			viewHolder.catalogTextView.setText(mContent.getSortLetters());
		}else{
			viewHolder.catalogTextView.setVisibility(View.GONE);
		}
	
		viewHolder.nameTextView.setText(mContent.getName());
		viewHolder.descTextView.setText(mContent.getDesc());
		viewHolder.descTextView.setText(mContent.getDesc());
		ImageLoaderHelper.displayImage(mContent.getPhotoUrl(), viewHolder.avatarImageView,ImageLoadingType.AVATAR);
		viewHolder.contactLayout.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				if(mContent.getType()==0){//群组
					RongIM.getInstance().startGroupChat(context, mContent.getId(), mContent.getName());
				}else if(mContent.getType()==1){
					RongIM.getInstance().startPrivateChat(context,mContent.getId()/*接受者的 userId*/,mContent.getName()/*该聊天的标题*/);
				}
				
				
			}
		});
		return convertView;
	}
	
	final static class ViewHolder {
		TextView catalogTextView;
		TextView nameTextView;
		TextView descTextView;
		View contactLayout;
		RoundedImageView avatarImageView;
	}

	@Override
	public Object[] getSections() {
		return null;
	}

	@Override
	public int getPositionForSection(int sectionIndex) {
		for (int i = 0; i < getCount(); i++) {
			String sortStr = mDatas.get(i).getSortLetters();
			char firstChar = sortStr.toUpperCase().charAt(0);
			if (firstChar == sectionIndex) {
				return i;
			}
		}
		
		return -1;
	}

	@Override
	public int getSectionForPosition(int position) {
		return mDatas.get(position).getSortLetters().charAt(0);
	}

}
