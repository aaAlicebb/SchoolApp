package com.example.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.bean.im.ContactBean;
import com.example.entity.Contact;
import com.example.entity.KGroup;
import com.example.entity.User;
import com.example.userdao.ContactDao;
import com.example.userdao.GroupDao;
import com.example.userdao.GroupPersonRelationDao;
import com.example.userdao.UserDao;
@Service
@Transactional
public class IMService {
	
	@Autowired @Qualifier("groupDao")
	GroupDao groupDao;
	@Autowired @Qualifier("contactDao")
	ContactDao contactDao;
	@Autowired @Qualifier("groupPersonRelationDao")
	GroupPersonRelationDao relationDao;
	@Autowired @Qualifier("userDao")
	UserDao userDao;
	
	public List<ContactBean> getGroupAndContact(Integer personId,Integer personType,String telephone){
		List<ContactBean> results = new ArrayList<ContactBean>();
		//获取用户�?��的群
		List<KGroup> groups = groupDao.getGroupList(personId, personType);
		for (KGroup group : groups) {
			ContactBean bean = new ContactBean();
			bean.setId(group.getGroupId());
			bean.setName(group.getGroupName());
			bean.setPhotoUrl(group.getPhotoUrl());
			bean.setType(0);
			bean.setDesc(group.getDesc());
			results.add(bean);
		}
		//获取用户�?��联系�?
		//先获取到用户的telephone
		List<Contact> contacts = contactDao.findByProperty("selfTelephone", telephone);
		for (Contact contact : contacts) {
			ContactBean bean = new ContactBean();
			bean.setId(contact.getContactTelephone());
			String name = null,photoUrl=null,desc=null;
			switch (contact.getContactRole()) {
			//老师
			case 1:
				User p1 = userDao.findUniqueByProperty("telephone", contact.getContactTelephone());
				name = p1.getName();
				photoUrl = p1.getPhotoUrl();
				desc = "学生";
				break;
				//学生
			case 2:
				User p = userDao.findUniqueByProperty("telephone", contact.getContactTelephone());
				name = p.getName();
				photoUrl = p.getPhotoUrl();
				desc = "学生";
				break;

			}
			bean.setName(name);
			bean.setPhotoUrl(photoUrl);
			bean.setType(1);
			bean.setDesc(desc);
			results.add(bean);
		}
		return results;
	}
	
	

}
