package com.example.common.im;

import io.rong.imkit.RongIM;
import io.rong.imkit.RongIM.ConversationBehaviorListener;
import io.rong.imkit.RongIM.ConversationListBehaviorListener;
import io.rong.imkit.RongIM.GroupInfoProvider;
import io.rong.imkit.RongIM.GroupUserInfoProvider;
import io.rong.imkit.model.GroupUserInfo;
import io.rong.imkit.model.UIConversation;
import io.rong.imlib.RongIMClient;
import io.rong.imlib.RongIMClient.ConnectionStatusListener;
import io.rong.imlib.model.Conversation;
import io.rong.imlib.model.Conversation.ConversationType;
import io.rong.imlib.model.Group;
import io.rong.imlib.model.Message;
import io.rong.imlib.model.MessageContent;
import io.rong.imlib.model.UserInfo;
import io.rong.message.ContactNotificationMessage;
import io.rong.message.ImageMessage;
import io.rong.message.InformationNotificationMessage;
import io.rong.message.LocationMessage;
import io.rong.message.RichContentMessage;
import io.rong.message.TextMessage;
import io.rong.message.VoiceMessage;

import java.util.ArrayList;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Handler;
import android.os.Handler.Callback;
import android.util.Log;
import android.view.View;

import com.example.bean.im.ContactBean;
import com.example.common.im.message.DeAgreedFriendRequestMessage;
import com.example.common.ui.PhotoDetailActivity;
import com.example.common.ui.SOSOLocationActivity;
import com.example.util.TipUtil;

/**
 * Created by zhjchen on 1/29/15.
 */

/**
 * 融云SDK事件监听处理。 把事件统一处理，开发者可直接复制到自己的项目中去使用。
 * <p/>
 * 该类包含的监听事件有： 1、消息接收器：OnReceiveMessageListener。
 * 2、发出消息接收器：OnSendMessageListener。 3、用户信息提供者：GetUserInfoProvider。
 * 4、好友信息提供者：GetFriendsProvider。 5、群组信息提供者：GetGroupInfoProvider。
 * 6、会话界面操作的监听器：ConversationBehaviorListener。
 * 7、连接状态监听器，以获取连接相关状态：ConnectionStatusListener。 8、地理位置提供者：LocationProvider。
 */
public final class RongCloudEvent implements
		RongIMClient.OnReceiveMessageListener, RongIM.UserInfoProvider,
		RongIM.OnSendMessageListener, RongIM.LocationProvider,
		ConnectionStatusListener, ConversationBehaviorListener,
		GroupInfoProvider, Callback, GroupUserInfoProvider, ConversationListBehaviorListener {

	private static final String TAG = RongCloudEvent.class.getSimpleName();

	private static RongCloudEvent mRongCloudInstance;

	private Context mContext;
	private Handler mHandler;

	 /**
     * 初始化 RongCloud.
     *
     * @param context 上下文。
     */
    public static void init(Context context) {

        if (mRongCloudInstance == null) {

            synchronized (RongCloudEvent.class) {

                if (mRongCloudInstance == null) {
                    mRongCloudInstance = new RongCloudEvent(context);
                }
            }
        }
    }

    /**
     * 构造方法。
     *
     * @param context 上下文。
     */
    private RongCloudEvent(Context context) {
        mContext = context;
        initDefaultListener();
        mHandler = new Handler(this);
        setOtherListener();
    }

    /**
     * RongIM.init(this) 后直接可注册的Listener。
     */
    private void initDefaultListener() {

        RongIM.setUserInfoProvider(this, true);//设置用户信息提供者。
        RongIM.setGroupInfoProvider(this, true);//设置群组信息提供者。
        RongIM.setConversationBehaviorListener(this);//设置会话界面操作的监听器。
        RongIM.setLocationProvider(this);//设置地理位置提供者,不用位置的同学可以注掉此行代码
        RongIM.setConversationListBehaviorListener(this);//会话列表界面操作的监听器
        RongIM.getInstance().setSendMessageListener(this);//设置发出消息接收监听器.

        RongIM.setGroupUserInfoProvider(this, true);
//        RongIM.setOnReceivePushMessageListener(this);//自定义 push 通知。
        //消息体内是否有 userinfo 这个属性
//        RongIM.getInstance().setMessageAttachedUserInfo(true);
    }
	/*
	 * 连接成功注册。 <p/> 在RongIM-connect-onSuccess后调用。
	 */
	public void setOtherListener() {
		  RongIM.setOnReceiveMessageListener(this);//设置消息接收监听器。
	        RongIM.setConnectionStatusListener(this);//设置连接状态监听器。
		RongIM.getInstance().setSendMessageListener(this);// 设置发出消息接收监听器.
		
	}

	/**
	 * 获取RongCloud 实例。
	 *
	 * @return RongCloud。
	 */
	public static RongCloudEvent getInstance() {
		return mRongCloudInstance;
	}

	/**
	 * 接收消息的监听器：OnReceiveMessageListener 的回调方法，接收到消息后执行。
	 *
	 * @param message
	 *            接收到的消息的实体信息。
	 * @param left
	 *            剩余未拉取消息数目。
	 */
	@Override
	public boolean onReceived(Message message, int left) {

		MessageContent messageContent = message.getContent();

		if (messageContent instanceof TextMessage) {// 文本消息
			TextMessage textMessage = (TextMessage) messageContent;
			Log.d(TAG, "onReceived-TextMessage:" + textMessage.getContent());
		} else if (messageContent instanceof ImageMessage) {// 图片消息
			ImageMessage imageMessage = (ImageMessage) messageContent;
			Log.d(TAG, "onReceived-ImageMessage:" + imageMessage.getRemoteUri());
		} else if (messageContent instanceof VoiceMessage) {// 语音消息
			VoiceMessage voiceMessage = (VoiceMessage) messageContent;
			Log.d(TAG, "onReceived-voiceMessage:"
					+ voiceMessage.getUri().toString());
		} else if (messageContent instanceof RichContentMessage) {// 图文消息
			RichContentMessage richContentMessage = (RichContentMessage) messageContent;
			Log.d(TAG,
					"onReceived-RichContentMessage:"
							+ richContentMessage.getContent());
		} else if (messageContent instanceof InformationNotificationMessage) {// 小灰条消息
			InformationNotificationMessage informationNotificationMessage = (InformationNotificationMessage) messageContent;
			Log.d(TAG, "onReceived-informationNotificationMessage:"
					+ informationNotificationMessage.getMessage());
		} else if (messageContent instanceof DeAgreedFriendRequestMessage) {// 好友添加成功消息
			DeAgreedFriendRequestMessage deAgreedFriendRequestMessage = (DeAgreedFriendRequestMessage) messageContent;
			Log.d(TAG, "onReceived-deAgreedFriendRequestMessage:"
					+ deAgreedFriendRequestMessage.getMessage());
			reciverAgreeSuccess(deAgreedFriendRequestMessage);
		} else if (messageContent instanceof ContactNotificationMessage) {// 好友添加消息
			ContactNotificationMessage contactContentMessage = (ContactNotificationMessage) messageContent;
			Log.d(TAG, "onReceived-ContactNotificationMessage:getExtra;"
					+ contactContentMessage.getExtra());
			Log.d(TAG, "onReceived-ContactNotificationMessage:+getmessage:"
					+ contactContentMessage.getMessage().toString());
			/* FIXME 收到从服务器端发过来的好友消息，发送广播提示更新ui*/
//			 Intent in = new Intent();
//			 in.setAction(MainActivity.ACTION_DMEO_RECEIVE_MESSAGE);
//			 in.putExtra("rongCloud", contactContentMessage);
//			 in.putExtra("has_message", true);
//			 mContext.sendBroadcast(in);
		} else {
			Log.d(TAG, "onReceived-其他消息，自己来判断处理");
		}

		return false;

	}

	/**
	 * 对方同意添加你为好友后，会向你发送添加成功的消息，这条消息是自定义消息，当前设置的这条消息不会在会话列表展示
	 *
	 * @param deAgreedFriendRequestMessage
	 */
	private void reciverAgreeSuccess(
			DeAgreedFriendRequestMessage deAgreedFriendRequestMessage) {
		ArrayList<UserInfo> friendreslist = new ArrayList<UserInfo>();
		// FIXME 对方同意添加你为好友后
		// if (DemoContext.getInstance() != null) {
		// friendreslist = DemoContext.getInstance().getFriends();
		// //接收到的这条消息的消息体里面有 userinfo，直接调用就可以
		// friendreslist.add(deAgreedFriendRequestMessage.getUserInfo());
		// //将此userinfo 添加到好友列表
		// DemoContext.getInstance().setFriends(friendreslist);
		// }
		// //发送广播，提示更新 UI
		// Intent in = new Intent();
		// in.setAction(MainActivity.ACTION_DMEO_AGREE_REQUEST);
		// in.putExtra("AGREE_REQUEST", true);
		// mContext.sendBroadcast(in);

	}

	/**
	 * 用户信息的提供者：GetUserInfoProvider 的回调方法，获取用户信息。
	 *
	 * @param userId
	 *            用户 Id。
	 * @return 用户信息，（注：由开发者提供用户信息）。
	 */
	@Override
	public UserInfo getUserInfo(String userId) {
		/**
		 *  自己提供用户信息，头像和昵称。
		 */
		ContactBean bean = IMDataCache.getInstance().getUserInfoById(userId);

		if (bean != null) {
			String name = bean.getName();
			String photo = bean.getPhotoUrl();
			Uri photoUri = null;
			if (photo != null)
				photoUri = Uri.parse(bean.getPhotoUrl());
			return new UserInfo(userId, name, photoUri);
		}
		return new UserInfo(userId, "未知", null);
	}

	/**
	 * 群组信息的提供者：GetGroupInfoProvider 的回调方法， 获取群组信息。
	 *
	 * @param groupId
	 *            群组 Id.
	 * @return 群组信息，（注：由开发者提供群组信息）。
	 */
	@Override
	public Group getGroupInfo(String groupId) {
		/**
		 * FIXME 自己提供 获取群组信息。。
		 */
		ContactBean bean = IMDataCache.getInstance().getGroupInfoById(groupId);
		if (bean != null) {
			String name = bean.getName();
			String photo = bean.getPhotoUrl();
			Uri photoUri = null;
			if (photo != null)
				photoUri = Uri.parse(bean.getPhotoUrl());
			return new Group(groupId, name, photoUri);
		}
		return new Group(groupId, "未知", null);
		// if (DemoContext.getInstance().getGroupMap() == null)
		// return null;
		//
		// return DemoContext.getInstance().getGroupMap().get(groupId);
	}

	/**
	 * 会话界面操作的监听器：ConversationBehaviorListener 的回调方法，当点击用户头像后执行。
	 *
	 * @param context
	 *            应用当前上下文。
	 * @param conversationType
	 *            会话类型。
	 * @param user
	 *            被点击的用户的信息。
	 * @return 返回True不执行后续SDK操作，返回False继续执行SDK操作。
	 */
	@Override
	public boolean onUserPortraitClick(Context context,
			Conversation.ConversationType conversationType, UserInfo user) {
		Log.d(TAG, "onUserPortraitClick");

		/**
		 * FIXME 当点击用户头像后执行,的回调方法。
		 */
		// Log.d("Begavior", conversationType.getName() + ":" + user.getName());
		// Intent in = new Intent(context, DePersonalDetailActivity.class);
		// in.putExtra("SEARCH_USERNAME", user.getName());
		// in.putExtra("SEARCH_USERID", user.getUserId());
		// context.startActivity(in);

		return false;
	}

	/**
	 * 会话界面操作的监听器：ConversationBehaviorListener 的回调方法，当点击消息时执行。
	 *
	 * @param context
	 *            应用当前上下文。
	 * @param message
	 *            被点击的消息的实体信息。
	 * @return 返回True不执行后续SDK操作，返回False继续执行SDK操作。
	 */
	@Override
    public boolean onMessageClick(final Context context, final View view, final Message message) {
		Log.d(TAG, "onMessageClick");

		/**
		 * FIXME ConversationBehaviorListener 的回调方法，当点击消息时执行。
		 */
		if (message.getContent() instanceof LocationMessage) {
			Intent intent = new Intent(context, SOSOLocationActivity.class);
			intent.putExtra("location", message.getContent());
			context.startActivity(intent);
		} else if (message.getContent() instanceof RichContentMessage) {
			RichContentMessage mRichContentMessage = (RichContentMessage) message
					.getContent();
			Log.d("Begavior", "extra:" + mRichContentMessage.getExtra());

		} else if (message.getContent() instanceof ImageMessage) {
			 ImageMessage imageMessage = (ImageMessage) message.getContent();
			 Intent intent = new Intent(context, PhotoDetailActivity.class);
			 ArrayList<String> allImagePaths = new ArrayList<String>(1);
			 allImagePaths.add((imageMessage.getLocalUri() == null ?
					 imageMessage.getRemoteUri() : imageMessage.getLocalUri()).toString());
			 intent.putStringArrayListExtra("allImagePaths", allImagePaths);
			 intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			 context.startActivity(intent);
		}

		Log.d("Begavior",
				message.getObjectName() + ":" + message.getMessageId());

		return false;
	}

	 /**
     * 当点击链接消息时执行。
     *
     * @param context 上下文。
     * @param link    被点击的链接。
     * @return 如果用户自己处理了点击后的逻辑处理，则返回 true， 否则返回 false, false 走融云默认处理方式。
     */
    @Override
    public boolean onMessageLinkClick(Context context, String link) {
        return false;
    }

    @Override
    public boolean onMessageLongClick(Context context, View view, Message message) {

        Log.e(TAG, "----onMessageLongClick");
        return false;
    }
	/**
	 * 连接状态监听器，以获取连接相关状态:ConnectionStatusListener 的回调方法，网络状态变化时执行。
	 *
	 * @param status
	 *            网络状态。
	 */
	@Override
	public void onChanged(ConnectionStatus status) {
		Log.d(TAG, "onChanged:" + status);
	}

	/**
	 * 位置信息提供者:LocationProvider 的回调方法，打开第三方地图页面。
	 *
	 * @param context
	 *            上下文
	 * @param callback
	 *            回调
	 */
	@Override
	public void onStartLocation(Context context, LocationCallback callback) {
		/**
		 *  demo 代码 开发者需替换成自己的代码。
		 */
		setLastLocationCallback(callback);
		Intent intent = new Intent(context, SOSOLocationActivity.class);
		intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
		context.startActivity(intent);// SOSO地图
	}

	private RongIM.LocationProvider.LocationCallback mLastLocationCallback;

	public RongIM.LocationProvider.LocationCallback getLastLocationCallback() {
		return mLastLocationCallback;
	}

	public void setLastLocationCallback(
			RongIM.LocationProvider.LocationCallback lastLocationCallback) {
		this.mLastLocationCallback = lastLocationCallback;
	}

	class LocationProvider implements RongIM.LocationProvider {

		/**
		 * 位置信息提供者:LocationProvider 的回调方法，打开第三方地图页面。
		 *
		 * @param context
		 *            上下文
		 * @param callback
		 *            回调
		 */
		@Override
		public void onStartLocation(Context context,
				RongIM.LocationProvider.LocationCallback callback) {
			/**
			 * demo 代码 开发者需替换成自己的代码。
			 */
			setLastLocationCallback(callback);
			Intent intent = new Intent(context, SOSOLocationActivity.class);
			intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			context.startActivity(intent);// SOSO地图
		}
	}

	@Override
	public boolean onUserPortraitLongClick(Context arg0, ConversationType arg1,
			UserInfo arg2) {
		// TODO Auto-generated method stub
		return false;
	}
	/**
     * 消息发送前监听器处理接口（是否发送成功可以从SentStatus属性获取）。
     *
     * @param message 发送的消息实例。
     * @return 处理后的消息实例。
     */
	@Override
	public Message onSend(Message message) {
		// TODO Auto-generated method stub
		 MessageContent messageContent = message.getContent();

	        if (messageContent instanceof TextMessage) {//文本消息
	            TextMessage textMessage = (TextMessage) messageContent;
	            Log.e("qinxiao", "--onSend:" + textMessage.getContent() + ", extra=" + message.getExtra());
	        }


	        return message;
	}

	/**
     * 消息在UI展示后执行/自己的消息发出后执行,无论成功或失败。
     *
     * @param message 消息。
     */
    @Override
    public boolean onSent(Message message, RongIM.SentMessageErrorCode sentMessageErrorCode) {
        Log.e("qinxiao", "onSent:" + message.getObjectName() + ", extra=" + message.getExtra());

        if (message.getSentStatus() == Message.SentStatus.FAILED) {

            if (sentMessageErrorCode == RongIM.SentMessageErrorCode.NOT_IN_CHATROOM) {//不在聊天室

            } else if (sentMessageErrorCode == RongIM.SentMessageErrorCode.NOT_IN_DISCUSSION) {//不在讨论组

            } else if (sentMessageErrorCode == RongIM.SentMessageErrorCode.NOT_IN_GROUP) {//不在群组

            } else if (sentMessageErrorCode == RongIM.SentMessageErrorCode.REJECTED_BY_BLACKLIST) {//你在他的黑名单中
               TipUtil.show("你在对方的黑名单中");
            }
//            else if (sentMessageErrorCode == RongIM.SentMessageErrorCode.NOT_FOLLOWED) {//未关注此公众号
//                WinToast.toast(mContext, "未关注此公众号");
//            }
        }

        MessageContent messageContent = message.getContent();

        if (messageContent instanceof TextMessage) {//文本消息
            TextMessage textMessage = (TextMessage) messageContent;
            Log.e(TAG, "onSent-TextMessage:" + textMessage.getContent());
        } else if (messageContent instanceof ImageMessage) {//图片消息
            ImageMessage imageMessage = (ImageMessage) messageContent;
            Log.d(TAG, "onSent-ImageMessage:" + imageMessage.getRemoteUri());
        } else if (messageContent instanceof VoiceMessage) {//语音消息
            VoiceMessage voiceMessage = (VoiceMessage) messageContent;
            Log.d(TAG, "onSent-voiceMessage:" + voiceMessage.getUri().toString());
        } else if (messageContent instanceof RichContentMessage) {//图文消息
            RichContentMessage richContentMessage = (RichContentMessage) messageContent;
            Log.d(TAG, "onSent-RichContentMessage:" + richContentMessage.getContent());
        } else {
            Log.d(TAG, "onSent-其他消息，自己来判断处理");
        }
        return false;
    }

	@Override
	public boolean handleMessage(android.os.Message arg0) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public GroupUserInfo getGroupUserInfo(String arg0, String arg1) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean onConversationClick(Context arg0, View arg1,
			UIConversation arg2) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean onConversationLongClick(Context arg0, View arg1,
			UIConversation arg2) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean onConversationPortraitClick(Context arg0,
			ConversationType arg1, String arg2) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean onConversationPortraitLongClick(Context arg0,
			ConversationType arg1, String arg2) {
		// TODO Auto-generated method stub
		return false;
	}
}
