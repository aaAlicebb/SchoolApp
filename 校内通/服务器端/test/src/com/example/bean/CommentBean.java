package com.example.bean;

import java.sql.Timestamp;

public class CommentBean {
	
	private Integer commentId;
	private Integer articleId;
	private Integer authorType;
	private Integer authorId;
	private String authorName;
	private String authorPhotoUrl;
	private Timestamp commentTime;
	private Integer rootId;
	private String rootName;
	private String content;
	/**
	 * @return the commentId
	 */
	public Integer getCommentId() {
		return commentId;
	}
	/**
	 * @param commentId the commentId to set
	 */
	public void setCommentId(Integer commentId) {
		this.commentId = commentId;
	}
	/**
	 * @return the articleId
	 */
	public Integer getArticleId() {
		return articleId;
	}
	/**
	 * @param articleId the articleId to set
	 */
	public void setArticleId(Integer articleId) {
		this.articleId = articleId;
	}
	/**
	 * @return the authorType
	 */
	public Integer getAuthorType() {
		return authorType;
	}
	/**
	 * @param authorType the authorType to set
	 */
	public void setAuthorType(Integer authorType) {
		this.authorType = authorType;
	}
	/**
	 * @return the authorId
	 */
	public Integer getAuthorId() {
		return authorId;
	}
	/**
	 * @param authorId the authorId to set
	 */
	public void setAuthorId(Integer authorId) {
		this.authorId = authorId;
	}
	/**
	 * @return the commentTime
	 */
	public Timestamp getCommentTime() {
		return commentTime;
	}
	/**
	 * @param commentTime the commentTime to set
	 */
	public void setCommentTime(Timestamp commentTime) {
		this.commentTime = commentTime;
	}
	/**
	 * @return the rootId
	 */
	public Integer getRootId() {
		return rootId;
	}
	/**
	 * @param rootId the rootId to set
	 */
	public void setRootId(Integer rootId) {
		this.rootId = rootId;
	}
	/**
	 * @return the rootName
	 */
	public String getRootName() {
		return rootName;
	}
	/**
	 * @param rootName the rootName to set
	 */
	public void setRootName(String rootName) {
		this.rootName = rootName;
	}
	/**
	 * @return the content
	 */
	public String getContent() {
		return content;
	}
	/**
	 * @param content the content to set
	 */
	public void setContent(String content) {
		this.content = content;
	}
	/**
	 * @return the authorName
	 */
	public String getAuthorName() {
		return authorName;
	}
	/**
	 * @param authorName the authorName to set
	 */
	public void setAuthorName(String authorName) {
		this.authorName = authorName;
	}
	/**
	 * @return the authorPhotoUrl
	 */
	public String getAuthorPhotoUrl() {
		return authorPhotoUrl;
	}
	/**
	 * @param authorPhotoUrl the authorPhotoUrl to set
	 */
	public void setAuthorPhotoUrl(String authorPhotoUrl) {
		this.authorPhotoUrl = authorPhotoUrl;
	}
	
	

}
