package com.example.bean.im;

import java.util.List;

import com.example.bean.CommonResultResBean;

public class ContactListResBean extends CommonResultResBean {
	
	private List<ContactBean> contactBeans;

	public List<ContactBean> getContactBeans() {
		return contactBeans;
	}

	public void setContactBeans(List<ContactBean> contactBeans) {
		this.contactBeans = contactBeans;
	}

}
