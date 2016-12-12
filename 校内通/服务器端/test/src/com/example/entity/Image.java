package com.example.entity;

/**
 * Image entity. @author MyEclipse Persistence Tools
 */

public class Image extends BaseEntity implements java.io.Serializable {

	// Fields

	private Integer imgId;
	private Integer imgIndex;
	private Integer imgType;
	private Integer sourceId;
	private String imgDesc;
	private String imgUrl;

	// Constructors

	/** default constructor */
	public Image() {
	}

	/** minimal constructor */
	public Image(Integer imgIndex, Integer imgType, Integer sourceId,
			String imgUrl) {
		this.imgIndex = imgIndex;
		this.imgType = imgType;
		this.sourceId = sourceId;
		this.imgUrl = imgUrl;
	}

	/** full constructor */
	public Image(Integer imgIndex, Integer imgType, Integer sourceId,
			String imgDesc, String imgUrl) {
		this.imgIndex = imgIndex;
		this.imgType = imgType;
		this.sourceId = sourceId;
		this.imgDesc = imgDesc;
		this.imgUrl = imgUrl;
	}

	// Property accessors

	public Integer getImgId() {
		return this.imgId;
	}

	public void setImgId(Integer imgId) {
		this.imgId = imgId;
	}

	public Integer getImgIndex() {
		return this.imgIndex;
	}

	public void setImgIndex(Integer imgIndex) {
		this.imgIndex = imgIndex;
	}

	public Integer getImgType() {
		return this.imgType;
	}

	public void setImgType(Integer imgType) {
		this.imgType = imgType;
	}

	public Integer getSourceId() {
		return this.sourceId;
	}

	public void setSourceId(Integer sourceId) {
		this.sourceId = sourceId;
	}

	public String getImgDesc() {
		return this.imgDesc;
	}

	public void setImgDesc(String imgDesc) {
		this.imgDesc = imgDesc;
	}

	public String getImgUrl() {
		return this.imgUrl;
	}

	public void setImgUrl(String imgUrl) {
		this.imgUrl = imgUrl;
	}

}