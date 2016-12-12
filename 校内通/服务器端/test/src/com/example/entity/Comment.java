package com.example.entity;

import java.sql.Timestamp;

/**
 * Comment entity. @author MyEclipse Persistence Tools
 */

public class Comment extends BaseEntity implements java.io.Serializable {

	// Fields

	private Integer commentId;
	private Integer articleId;
	private Integer authorType;
	private Integer authorId;
	private Timestamp commentTime;
	private Integer rootId;
	private String content;

	// Constructors

	/** default constructor */
	public Comment() {
	}

	/** full constructor */
	public Comment(Integer articleId, Integer authorType, Integer authorId,
			Timestamp commentTime, Integer rootId, String content) {
		this.articleId = articleId;
		this.authorType = authorType;
		this.authorId = authorId;
		this.commentTime = commentTime;
		this.rootId = rootId;
		this.content = content;
	}

	// Property accessors

	public Integer getCommentId() {
		return this.commentId;
	}

	public void setCommentId(Integer commentId) {
		this.commentId = commentId;
	}

	public Integer getArticleId() {
		return this.articleId;
	}

	public void setArticleId(Integer articleId) {
		this.articleId = articleId;
	}

	public Integer getAuthorType() {
		return this.authorType;
	}

	public void setAuthorType(Integer authorType) {
		this.authorType = authorType;
	}

	public Integer getAuthorId() {
		return this.authorId;
	}

	public void setAuthorId(Integer authorId) {
		this.authorId = authorId;
	}

	public Timestamp getCommentTime() {
		return this.commentTime;
	}

	public void setCommentTime(Timestamp commentTime) {
		this.commentTime = commentTime;
	}

	public Integer getRootId() {
		return this.rootId;
	}

	public void setRootId(Integer rootId) {
		this.rootId = rootId;
	}

	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

}