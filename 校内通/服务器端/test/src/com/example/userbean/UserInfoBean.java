package com.example.userbean;

import java.util.Date;
import java.util.Set;

import com.example.bean.CommonResultResBean;

public class UserInfoBean  {
	
	private Integer userId;
	private String name;
	private Integer gender;
	private Integer age;
	private Date birthday;
	private String address;
	private String telephone;
	private String photoUrl;
	private String token;
	private String password;
	public Integer getUserId() {
		return userId;
	}
	public void setUserId(Integer userId) {
		this.userId = userId;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Integer getGender() {
		return gender;
	}
	public void setGender(Integer gender) {
		this.gender = gender;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	public Date getBirthday() {
		return birthday;
	}
	public void setBirthday(Date birthday) {
		this.birthday = birthday;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getTelephone() {
		return telephone;
	}
	public void setTelephone(String telephone) {
		this.telephone = telephone;
	}
	public String getPhotoUrl() {
		return photoUrl;
	}
	public void setPhotoUrl(String photoUrl) {
		this.photoUrl = photoUrl;
	}
	public String getToken() {
		return token;
	}
	public void setToken(String token) {
		this.token = token;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public UserInfoBean(Integer userId, String name, Integer gender,
			Integer age, Date birthday, String address, String telephone,
			String photoUrl, String token, String password) {
		super();
		this.userId = userId;
		this.name = name;
		this.gender = gender;
		this.age = age;
		this.birthday = birthday;
		this.address = address;
		this.telephone = telephone;
		this.photoUrl = photoUrl;
		this.token = token;
		this.password = password;
	}
	public UserInfoBean() {
		super();
	}
	
	

}
