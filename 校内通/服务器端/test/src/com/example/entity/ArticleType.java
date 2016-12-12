package com.example.entity;

/**
 * ArticleType entity. @author MyEclipse Persistence Tools
 */

public class ArticleType extends BaseEntity implements java.io.Serializable {

	// Fields

	private Integer typeId;
	private String typeName;
	private Integer articleCount;
	private String photoUrl;
	private String typeDesc;

	// Constructors

	/** default constructor */
	public ArticleType() {
	}

	/** minimal constructor */
	public ArticleType(String typeName, Integer articleCount) {
		this.typeName = typeName;
		this.articleCount = articleCount;
	}

	/** full constructor */
	public ArticleType(String typeName, Integer articleCount, String photoUrl,
			String typeDesc) {
		this.typeName = typeName;
		this.articleCount = articleCount;
		this.photoUrl = photoUrl;
		this.typeDesc = typeDesc;
	}

	// Property accessors

	public Integer getTypeId() {
		return this.typeId;
	}

	public void setTypeId(Integer typeId) {
		this.typeId = typeId;
	}

	public String getTypeName() {
		return this.typeName;
	}

	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}

	public Integer getArticleCount() {
		return this.articleCount;
	}

	public void setArticleCount(Integer articleCount) {
		this.articleCount = articleCount;
	}

	public String getPhotoUrl() {
		return this.photoUrl;
	}

	public void setPhotoUrl(String photoUrl) {
		this.photoUrl = photoUrl;
	}

	public String getTypeDesc() {
		return this.typeDesc;
	}

	public void setTypeDesc(String typeDesc) {
		this.typeDesc = typeDesc;
	}

}