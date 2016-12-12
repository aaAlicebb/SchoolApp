package com.example.entity;

import java.sql.Timestamp;
import java.util.List;

/**
 * Article entity. @author MyEclipse Persistence Tools
 */

public class Article extends BaseEntity implements java.io.Serializable {

	// Fields

	private Integer articleId;
	private Integer authorType;
	private Integer authorId;
	private Integer gradeId;
	private Timestamp deliverTime;
	private Integer typeId;
	private String title;
	private String content;
	private Integer top;
	private Integer isDelete;
	private Integer upNumber;
	private Integer commentNumber;
	private List<Image> imgUrls;

	// Constructors

	/** default constructor */
	public Article() {
	}

	/** full constructor */
	public Article(Integer authorType, Integer authorId, Integer gradeId,
			Timestamp deliverTime, Integer typeId, String title,
			String content, Integer top, Integer isDelete, Integer upNumber,
			Integer commentNumber) {
		this.authorType = authorType;
		this.authorId = authorId;
		this.gradeId = gradeId;
		this.deliverTime = deliverTime;
		this.typeId = typeId;
		this.title = title;
		this.content = content;
		this.top = top;
		this.isDelete = isDelete;
		this.upNumber = upNumber;
		this.commentNumber = commentNumber;
	}

	// Property accessors

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

	public Integer getGradeId() {
		return this.gradeId;
	}

	public void setGradeId(Integer gradeId) {
		this.gradeId = gradeId;
	}

	public Timestamp getDeliverTime() {
		return this.deliverTime;
	}

	public void setDeliverTime(Timestamp deliverTime) {
		this.deliverTime = deliverTime;
	}

	public Integer getTypeId() {
		return this.typeId;
	}

	public void setTypeId(Integer typeId) {
		this.typeId = typeId;
	}

	public String getTitle() {
		return this.title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Integer getTop() {
		return this.top;
	}

	public void setTop(Integer top) {
		this.top = top;
	}

	public Integer getIsDelete() {
		return this.isDelete;
	}

	public void setIsDelete(Integer isDelete) {
		this.isDelete = isDelete;
	}

	public Integer getUpNumber() {
		return this.upNumber;
	}

	public void setUpNumber(Integer upNumber) {
		this.upNumber = upNumber;
	}

	public Integer getCommentNumber() {
		return this.commentNumber;
	}

	public void setCommentNumber(Integer commentNumber) {
		this.commentNumber = commentNumber;
	}

	public List<Image> getImgUrls() {
		return imgUrls;
	}

	public void setImgUrls(List<Image> imgUrls) {
		this.imgUrls = imgUrls;
	}
	
}