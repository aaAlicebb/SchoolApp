package com.example.app;

public class Constant {

	public static class CONFIG {
		public static final int DEFAULT_PAGE_SIZE =5;
		public static final int ROLE_PARENT = 2;
	}

	public static class URL {
		// 100.64.164.128:8080
	//	public static  String ROOT = "http://stevenmoon.x10.fjjsp01.com/Kindergarten/";
		 public static  String ROOT =
		 "http://192.168.1.102:8080/test/";
		public static final String QINIU = "http://7xvsxg.com1.z0.glb.clouddn.com/";
		public static final String GET_UP_TOKEN = ROOT + "upload/getUpToken.do";
		public static final String LOGIN = ROOT + "user/login.do";
		public static final String USER_INFO = ROOT
				+ "user/authority/info.do";
		public static final String ACTIVE_INFO = ROOT
				+ "user/getActiveInfo.do";
		public static final String ACTIVE = ROOT + "user/active.do";

		// 公用接口--帖子

		public static final String ARTICLE_TYPE = ROOT + "article/typelist.do";
		public static final String ARTICLE_NORMAL_LIST = ROOT
				+ "article/normalArticleList.do";
		public static final String ARTICLE_GRADE_LIST = ROOT
				+ "article/gradeArticleList.do";
		public static final String ARTICLE_HOME_NOTICE_LIST = ROOT
				+ "user/getHomeNotice.do";
		public static final String ARTICLE_DETAIL = ROOT
				+ "article/articleDetail.do";
		public static final String ARTICLE_COMMENT_LIST = ROOT
				+ "article/getComment.do";
		public static final String ARTICLE_COMMENT_SEND = ROOT
				+ "article/sendComment.do";
		public static final String ARTICLE_SEND = ROOT
				+ "article/sendArticle.do";
		public static final String ARTICLE_UP = ROOT + "article/up.do";
		public static final String ARTICLE_UP_CANCEL = ROOT
				+ "article/cancelUp.do";

		// 公共接口--IM
		public static final String GROUP_CONTACT_LIST = ROOT
				+ "im/groupAndContactList.do";

	}

}
