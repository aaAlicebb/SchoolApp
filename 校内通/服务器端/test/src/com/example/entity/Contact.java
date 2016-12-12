package com.example.entity;

/**
 * Contact entity. @author MyEclipse Persistence Tools
 */

public class Contact extends BaseEntity implements java.io.Serializable {

	// Fields

	private Integer contactId;
	private String selfTelephone;
	private String contactTelephone;
	private Integer selfRole;
	private Integer contactRole;

	// Constructors

	/** default constructor */
	public Contact() {
	}

	/** full constructor */
	public Contact(String selfTelephone, String contactTelephone,
			Integer selfRole, Integer contactRole) {
		this.selfTelephone = selfTelephone;
		this.contactTelephone = contactTelephone;
		this.selfRole = selfRole;
		this.contactRole = contactRole;
	}

	// Property accessors

	public Integer getContactId() {
		return this.contactId;
	}

	public void setContactId(Integer contactId) {
		this.contactId = contactId;
	}

	public String getSelfTelephone() {
		return this.selfTelephone;
	}

	public void setSelfTelephone(String selfTelephone) {
		this.selfTelephone = selfTelephone;
	}

	public String getContactTelephone() {
		return this.contactTelephone;
	}

	public void setContactTelephone(String contactTelephone) {
		this.contactTelephone = contactTelephone;
	}

	public Integer getSelfRole() {
		return this.selfRole;
	}

	public void setSelfRole(Integer selfRole) {
		this.selfRole = selfRole;
	}

	public Integer getContactRole() {
		return this.contactRole;
	}

	public void setContactRole(Integer contactRole) {
		this.contactRole = contactRole;
	}

}