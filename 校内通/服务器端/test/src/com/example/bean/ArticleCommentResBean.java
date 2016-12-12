package com.example.bean;

import java.util.List;


public class ArticleCommentResBean extends CommonResultResBean{
	
	private List<CommentBean> comments;

	public List<CommentBean> getComments() {
		return comments;
	}

	public void setComments(List<CommentBean> comments) {
		this.comments = comments;
	}

	

}
