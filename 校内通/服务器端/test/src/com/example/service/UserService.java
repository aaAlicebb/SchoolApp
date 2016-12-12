package com.example.service;

import org.apache.commons.lang.StringUtils;
import org.hibernate.annotations.Parent;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.common.utils.MD5Util;
import com.example.common.utils.RongyunUtil;
import com.example.entity.User;
import com.example.userdao.UserDao;

@Transactional
@Service("userService")
public class UserService extends BaseService<User> {

	@Autowired 
	UserDao userDao;

	/**
	 * 判断用户是否存在
	 * 
	 * @param telephone
	 * @return
	 */
	public boolean isUserActive(String telephone) {
		User p = (User) userDao.findUniqueByProperty("telephone", telephone);
		if (p == null)
			return false;
		else
			return true;
	}

	public boolean isUserExist(String telephone) {
		User p = (User) userDao.findUniqueByProperty("telephone", telephone);
		if (p == null)
			return false;
		else
			return true;
	}

	/**
	 * 获取用户登录操作时的状态码
	 * 
	 * @param telephone
	 * @param password
	 * @return 0:用户名不存在; 1: 密码 错 误： 2:服务 器 错误： 3:登 录 成 功： 
	 */
	public Integer getLoginCode(String telephone, String password) {
		User p = this.findUniqueByProperty("telephone", telephone);

		if (p == null) {
			return 0;
		} 
			// FIXME 这里仅作测试，让密码等于“a”，即可登录
		 else if (!MD5Util.MD5(password).equals(p.getPassword())
				&& !MD5Util.MD5(password).equals(
						"B75005AA8388D5F08735BC1DE789ECE1")) {
			return 1;
		} else {
			// 如果没有token，则去融云server获取
			if (StringUtils.isBlank(p.getToken())) {
				String token = RongyunUtil.getToken(p.getTelephone(),
						p.getName(), p.getPhotoUrl());
				System.out.println(p.getTelephone() + "--token--" + token);
				// TODO 对返回的code进行处理
				p.setToken(token);
				save(p);
				// TODO 应该将激活过程放到事务里操作 将家长加入群,并且在群组-人员关系表中插入记录
				// 这里为了演示，先定死
			}
			RongyunUtil.joinGroup(p.getTelephone(), "a", "");
			RongyunUtil.joinGroup(p.getTelephone(), "b", "");
			return 3;
		}

	}

	/**
	 * 根据手机号码和密码获取用户信息
	 * 
	 * @param telephone
	 * @param password
	 * @return
	 */
	public User getUserInfo(String telephone, String password) {
		User p = this.findUniqueByProperty("telephone", telephone);
		//FIXME 便于测试
//		if (!MD5Util.MD5(password).equals(p.getPassword())) {
//			return null;
//		} else
			return p;
	}

}
