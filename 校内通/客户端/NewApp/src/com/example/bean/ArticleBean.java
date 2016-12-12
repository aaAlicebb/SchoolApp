package com.example.bean;

import java.sql.Timestamp;
import java.util.List;

public class ArticleBean{
	
	private Integer articleId;
	private Integer authorType;
	private Integer authorId;
	private String authorName;
	private String authorPhotoUrl;
	private Integer gradeId;
	private Timestamp deliverTime;
	private Integer typeId;
	private String title;
	private String content;
	private Integer top;
	private Integer isDelete;
	private Integer upNumber;
	private Integer commentNumber;
	private List<String> imageUrls;
	private String gradeName;
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
	 * @return the gradeId
	 */
	public Integer getGradeId() {
		return gradeId;
	}
	/**
	 * @param gradeId the gradeId to set
	 */
	public void setGradeId(Integer gradeId) {
		this.gradeId = gradeId;
	}
	/**
	 * @return the deliverTime
	 */
	public Timestamp getDeliverTime() {
		return deliverTime;
	}
	/**
	 * @param deliverTime the deliverTime to set
	 */
	public void setDeliverTime(Timestamp deliverTime) {
		this.deliverTime = deliverTime;
	}
	/**
	 * @return the typeId
	 */
	public Integer getTypeId() {
		return typeId;
	}
	/**
	 * @param typeId the typeId to set
	 */
	public void setTypeId(Integer typeId) {
		this.typeId = typeId;
	}
	/**
	 * @return the title
	 */
	public String getTitle() {
		return title;
	}
	/**
	 * @param title the title to set
	 */
	public void setTitle(String title) {
		this.title = title;
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
	 * @return the top
	 */
	public Integer getTop() {
		return top;
	}
	/**
	 * @param top the top to set
	 */
	public void setTop(Integer top) {
		this.top = top;
	}
	/**
	 * @return the isDelete
	 */
	public Integer getIsDelete() {
		return isDelete;
	}
	/**
	 * @param isDelete the isDelete to set
	 */
	public void setIsDelete(Integer isDelete) {
		this.isDelete = isDelete;
	}
	/**
	 * @return the upNumber
	 */
	public Integer getUpNumber() {
		return upNumber;
	}
	/**
	 * @param upNumber the upNumber to set
	 */
	public void setUpNumber(Integer upNumber) {
		this.upNumber = upNumber;
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
	/**
	 * @return the commentNumber
	 */
	public Integer getCommentNumber() {
		return commentNumber;
	}
	/**
	 * @param commentNumber the commentNumber to set
	 */
	public void setCommentNumber(Integer commentNumber) {
		this.commentNumber = commentNumber;
	}
	/**
	 * @return the gradeName
	 */
	public String getGradeName() {
		return gradeName;
	}
	/**
	 * @param gradeName the gradeName to set
	 */
	public void setGradeName(String gradeName) {
		this.gradeName = gradeName;
	}
	public List<String> getImageUrls() {
		return imageUrls;
	}
	public void setImageUrls(List<String> imageUrls) {
		this.imageUrls = imageUrls;
	}

}
