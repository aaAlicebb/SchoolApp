package com.example.bean.im;

public class ContactBean {
	
	private String name;
	/**
	 * 0:群组 ，1：联系人
	 */
	private Integer type;
	
	private String photoUrl;
	
	/**
	 * 描述，如校长啊，一班班主任啊，美术老师啊，一班交流群啊
	 */
	private String desc;
	
	/**
	 * 根据type，此id可代表群组的groupId,或者联系人的userId(也就是telephone)
	 */
	private String id;
	
	/**
	 * 用于排序，在客户端使用
	 */
	private String sortLetters;

	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}

	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @return the type
	 */
	public Integer getType() {
		return type;
	}

	/**
	 * @param type the type to set
	 */
	public void setType(Integer type) {
		this.type = type;
	}

	/**
	 * @return the photoUrl
	 */
	public String getPhotoUrl() {
		return photoUrl;
	}

	/**
	 * @param photoUrl the photoUrl to set
	 */
	public void setPhotoUrl(String photoUrl) {
		this.photoUrl = photoUrl;
	}

	/**
	 * @return the desc
	 */
	public String getDesc() {
		return desc;
	}

	/**
	 * @param desc the desc to set
	 */
	public void setDesc(String desc) {
		this.desc = desc;
	}

	/**
	 * @return the id
	 */
	public String getId() {
		return id;
	}

	/**
	 * @param id the id to set
	 */
	public void setId(String id) {
		this.id = id;
	}

	/**
	 * @return the sortLetters
	 */
	public String getSortLetters() {
		return sortLetters;
	}

	/**
	 * @param sortLetters the sortLetters to set
	 */
	public void setSortLetters(String sortLetters) {
		this.sortLetters = sortLetters;
	}
	
	

}
