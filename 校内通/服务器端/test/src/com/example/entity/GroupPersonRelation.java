package com.example.entity;

/**
 * GroupPersonRelation entity. @author MyEclipse Persistence Tools
 */

public class GroupPersonRelation extends BaseEntity implements java.io.Serializable {

	// Fields

	private Integer relationId;
	private String groupId;
	private Integer personId;
	private Integer personType;

	// Constructors

	/** default constructor */
	public GroupPersonRelation() {
	}

	/** full constructor */
	public GroupPersonRelation(String groupId, Integer personId,
			Integer personType) {
		this.groupId = groupId;
		this.personId = personId;
		this.personType = personType;
	}

	// Property accessors

	public Integer getRelationId() {
		return this.relationId;
	}

	public void setRelationId(Integer relationId) {
		this.relationId = relationId;
	}

	public String getGroupId() {
		return this.groupId;
	}

	public void setGroupId(String groupId) {
		this.groupId = groupId;
	}

	public Integer getPersonId() {
		return this.personId;
	}

	public void setPersonId(Integer personId) {
		this.personId = personId;
	}

	public Integer getPersonType() {
		return this.personType;
	}

	public void setPersonType(Integer personType) {
		this.personType = personType;
	}

}