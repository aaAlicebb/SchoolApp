package com.example.common.im.message;

import io.rong.imkit.R;
import io.rong.imkit.model.ProviderTag;
import io.rong.imkit.model.UIMessage;
import io.rong.imkit.widget.provider.IContainerItemProvider;
import io.rong.imlib.model.Message;
import android.content.Context;
import android.text.Spannable;
import android.text.TextUtils;
import android.text.method.LinkMovementMethod;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * Created by Bob on 2015/4/17.
 */
@ProviderTag(messageContent = DeAgreedFriendRequestMessage.class, showPortrait = false, centerInHorizontal = false,showProgress = false,hide = true)
public class DeAgreedFriendRequestMessageProvider extends IContainerItemProvider.MessageProvider<DeAgreedFriendRequestMessage> {
  


    @Override
    public Spannable getContentSummary(DeAgreedFriendRequestMessage data) {
        return null;
    }
    @Override
    public View newView(Context context, ViewGroup group) {
        View view = LayoutInflater.from(context).inflate(R.layout.rc_item_information_notification_message, null);
        ViewHolder viewHolder = new ViewHolder();
        viewHolder.contentTextView = (TextView) view.findViewById(io.rong.imkit.R.id.rc_msg);
        viewHolder.contentTextView.setMovementMethod(LinkMovementMethod.getInstance());
        view.setTag(viewHolder);

        return view;
    }


    class ViewHolder {
        TextView contentTextView;
    }


	@Override
	public void bindView(View v, int arg1,
			DeAgreedFriendRequestMessage content, UIMessage arg3) {
		// TODO Auto-generated method stub
		 ViewHolder viewHolder = (ViewHolder) v.getTag();

	        if (content != null) {
	            if (!TextUtils.isEmpty(content.getMessage()))
	                viewHolder.contentTextView.setText(content.getMessage());
	        }
	}

	@Override
	public void onItemLongClick(View arg0, int arg1,
			DeAgreedFriendRequestMessage arg2, UIMessage arg3) {
		// TODO Auto-generated method stub
		
	}
	@Override
	public void onItemClick(View view, int position,
			DeAgreedFriendRequestMessage context, UIMessage message) {
		// TODO Auto-generated method stub
		
	}
}
