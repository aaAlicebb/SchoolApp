package com.example.app;

import java.util.Date;

import com.example.bean.GradeBean;

public class StuInfoBean {
	private Integer stuId;
	private GradeBean gradeBean;
	private String name;
	private Integer stuNum;
	private Integer gender;
	private Integer age;
	private String photoUrl;
	private String telephone;
	private String token;
	private String password;
	private Integer activation;
	public Integer getStuId() {
		return stuId;
	}
	public void setStuId(Integer stuId) {
		this.stuId = stuId;
	}
	public GradeBean getGradeBean() {
		return gradeBean;
	}
	public void setGradeBean(GradeBean gradeBean) {
		this.gradeBean = gradeBean;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Integer getStuNum() {
		return stuNum;
	}
	public void setStuNum(Integer stuNum) {
		this.stuNum = stuNum;
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
	public String getPhotoUrl() {
		return photoUrl;
	}
	public void setPhotoUrl(String photoUrl) {
		this.photoUrl = photoUrl;
	}
	public String getTelephone() {
		return telephone;
	}
	public void setTelephone(String telephone) {
		this.telephone = telephone;
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
	private Date birthday;
	private String address;
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
	public Integer getActivation() {
		return activation;
	}
	public void setActivation(Integer activation) {
		this.activation = activation;
	}
	public StuInfoBean(Integer stuId, GradeBean gradeBean, String name,
			Integer stuNum, Integer gender, Integer age, String photoUrl,
			String telephone,String password,
			Integer activation, Date birthday, String address) {
		super();
		this.stuId = stuId;
		this.gradeBean = gradeBean;
		this.name = name;
		this.stuNum = stuNum;
		this.gender = gender;
		this.age = age;
		this.photoUrl = photoUrl;
		this.telephone = telephone;
		this.password = password;
		this.activation = activation;
		this.birthday = birthday;
		this.address = address;
	}
	public StuInfoBean() {
		// TODO Auto-generated constructor stub
	}
	
}
