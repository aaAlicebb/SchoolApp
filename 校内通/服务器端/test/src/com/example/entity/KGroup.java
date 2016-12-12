package com.example.entity;

/**
 * KGroup entity. @author MyEclipse Persistence Tools
 */

public class KGroup extends BaseEntity implements java.io.Serializable {

	// Fields

	private String groupId;
	private String groupName;
	private String photoUrl;
	private String desc;

	// Constructors

	/** default constructor */
	public KGroup() {
	}

	/** minimal constructor */
	public KGroup(String groupId, String groupName) {
		this.groupId = groupId;
		this.groupName = groupName;
	}

	/** full constructor */
	public KGroup(String groupId, String groupName, String photoUrl, String desc) {
		this.groupId = groupId;
		this.groupName = groupName;
		this.photoUrl = photoUrl;
		this.desc = desc;
	}

	// Property accessors

	public String getGroupId() {
		return this.groupId;
	}

	public void setGroupId(String groupId) {
		this.groupId = groupId;
	}

	public String getGroupName() {
		return this.groupName;
	}

	public void setGroupName(String groupName) {
		this.groupName = groupName;
	}

	public String getPhotoUrl() {
		return this.photoUrl;
	}

	public void setPhotoUrl(String photoUrl) {
		this.photoUrl = photoUrl;
	}

	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		this.desc = desc;
	}

}