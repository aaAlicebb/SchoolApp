package com.example.common.im.message;

import io.rong.imkit.model.ProviderTag;
import io.rong.imkit.model.UIMessage;
import io.rong.imkit.widget.provider.IContainerItemProvider;
import io.rong.imlib.model.Message;
import io.rong.message.ContactNotificationMessage;
import android.content.Context;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.TextUtils;
import android.text.method.LinkMovementMethod;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * Created by Bob on 2015/4/17.
 */
@ProviderTag(messageContent = ContactNotificationMessage.class, showPortrait = false, centerInHorizontal = true,showProgress = false)
public class DeContactNotificationMessageProvider extends IContainerItemProvider.MessageProvider<ContactNotificationMessage> {

    @Override
    public Spannable getContentSummary(ContactNotificationMessage data) {
        if (data != null && !TextUtils.isEmpty(data.getMessage()))
            return new SpannableString(data.getMessage());
        return null;
    }


    @Override
    public View newView(Context context, ViewGroup group) {
        View view = LayoutInflater.from(context).inflate(io.rong.imkit.R.layout.rc_item_information_notification_message, null);
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
	public void bindView(View v, int arg1, ContactNotificationMessage content,
			UIMessage arg3) {
		// TODO Auto-generated method stub
		 ViewHolder viewHolder = (ViewHolder) v.getTag();

	        if (content != null) {
	            if (!TextUtils.isEmpty(content.getMessage()))
	                viewHolder.contentTextView.setText(content.getMessage());
	        }
	}

	@Override
	public void onItemClick(View view, int position,
			ContactNotificationMessage context, UIMessage message) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onItemLongClick(View arg0, int arg1,
			ContactNotificationMessage arg2, UIMessage arg3) {
		// TODO Auto-generated method stub
		
	}
}
