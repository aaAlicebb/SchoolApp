package com.example.userbean;

import com.example.bean.CommonResultResBean;


public class UserActiveVerifyResBean extends CommonResultResBean{
	

	private Integer userId;
	
	private String Name;

	private String telephone;

	public Integer getUserId() {
		return userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}

	public String getTelephone() {
		return telephone;
	}

	public void setTelephone(String telephone) {
		this.telephone = telephone;
	}
	


	
}
