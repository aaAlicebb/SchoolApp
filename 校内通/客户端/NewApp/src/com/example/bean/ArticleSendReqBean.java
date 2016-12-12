package com.example.bean;

import java.util.List;

public class ArticleSendReqBean {
	
	private Integer authorType;
	private Integer authorId;
	private Integer gradeId;
	private Integer typeId;
	private String title;
	private String content;
	private List<String> imgUrls;
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
	 * @return the imgUrls
	 */
	public List<String> getImgUrls() {
		return imgUrls;
	}
	/**
	 * @param imgUrls the imgUrls to set
	 */
	public void setImgUrls(List<String> imgUrls) {
		this.imgUrls = imgUrls;
	}
	

}
