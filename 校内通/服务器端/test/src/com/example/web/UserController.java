package com.example.web;

import java.util.List;

import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.example.bean.ArticleBean;
import com.example.bean.ArticleListResBean;
import com.example.bean.CommonResultResBean;
import com.example.bean.GradeBean;
import com.example.bean.StuHomeNoticeReqBean;
import com.example.common.utils.JsonUtil;
import com.example.common.utils.MD5Util;
import com.example.common.utils.RongyunUtil;
import com.example.entity.Article;
import com.example.entity.Grade;
import com.example.entity.User;
import com.example.service.ArticleService;
import com.example.service.UserService;
import com.example.userbean.UserActiveReqBean;
import com.example.userbean.UserActiveVerifyReqBean;
import com.example.userbean.UserActiveVerifyResBean;
import com.example.userbean.UserInfoReqBean;
import com.example.userbean.UserInfoResBean;
import com.example.userbean.UserLoginReqBean;

@Controller
@RequestMapping(value = "/user", produces = "application/json; charset=utf-8", method = RequestMethod.POST)
public class UserController {

	@Autowired
	UserService userService;
	@Autowired
	ArticleService articleService;
	/**
	 * 用户激活验证
	 * 
	 * @param params
	 *            Json格式的参数
	 * @return
	 */
	@ResponseBody
	@RequestMapping(value = "/getActiveInfo.do")
	public String getActiveInfo(@RequestParam("params") String params) {
		UserActiveVerifyReqBean reqBean = JsonUtil.parseObject(params,
				UserActiveVerifyReqBean.class);
		System.out.println(reqBean.getTelephone());
		UserActiveVerifyResBean response = new UserActiveVerifyResBean();
		System.out.println(response.getName());
		// 这里为了演示，将验证码固定为123456
		if (!"123456".equals(reqBean.getVerifyCode())) {
			response.setResult(4);
			return JsonUtil.toJsonString(response);
		}
		User p = userService.findUniqueByProperty("telephone",
				reqBean.getTelephone());

		if (p == null) {// 帐号不存在
			// 返回状态码
			response.setResult(3);
		}
		if(p!=null){
			
			response.setResult(1);
		}
		return JsonUtil.toJsonString(response);
	}

	/**
	 * 完善用户信息
	 * 
	 * @param params
	 *            Json格式的参数
	 * @return
	 */
	@ResponseBody
	@RequestMapping(value = "/active.do")
	public String active(@RequestParam("params") String params) {
		UserActiveReqBean reqBean = JsonUtil.parseObject(params,
				UserActiveReqBean.class);
		System.out.println(reqBean.getUserId());
		System.out.println(reqBean.getAddress());
		System.out.println(reqBean.getPhotoUrl());
		System.out.println(reqBean.getTelephone());
		System.out.println(reqBean.getAge());
		CommonResultResBean resBean = new CommonResultResBean();
		// 进行验证。。简化操作，这里简单验证密码非空
		if (StringUtils.isEmpty(reqBean.getPassword())) {
			resBean.setResult(0);
		} else {
			// 插入用户信息
		//	User old = userService.get(reqBean.getUserId());
			User p = new User();
		//	p.setUserId(old.getUserId());
			p.setTelephone(reqBean.getTelephone());
			p.setName(reqBean.getName());
			p.setPassword(MD5Util.MD5(reqBean.getPassword()));
			p.setAddress(reqBean.getAddress());
			p.setAge(reqBean.getAge());
			p.setBirthday(reqBean.getBirthday());
			p.setGender(reqBean.getGender());
			p.setPhotoUrl(reqBean.getPhotoUrl());
			Grade grade=new Grade();
			grade.setGradeId(2);
			grade.setGradeName("二年级");
			p.setGrade(grade);
			userService.save(p);
			//TODO 应该将激活过程放到事务里操作  将学生加入群,并且在群组-人员关系表中插入记录
			//这里为了演示，先定死
			RongyunUtil.joinGroup(p.getTelephone(), "a", "");
			RongyunUtil.joinGroup(p.getTelephone(), "b", "");
			resBean.setResult(1);
		}

		return JsonUtil.toJsonString(resBean);

	}

	/**
	 * 用户激活操作
	 * 
	 * @param params
	 *            Json格式的参数
	 * @return
	 */
	@ResponseBody
	@RequestMapping(value = "/login.do")
	public String login(@RequestParam("params") String params,
			HttpSession session) {
		UserLoginReqBean reqBean = JsonUtil.parseObject(params,
				UserLoginReqBean.class);
				System.out.println("传过来的用户名"+reqBean.getTelephone());
				System.out.println("传过来的密码"+reqBean.getPassword());
		CommonResultResBean resBean = new CommonResultResBean();
		Integer code =userService.getLoginCode(reqBean.getTelephone(),
				reqBean.getPassword());
		resBean.setResult(code);
		if (code == 3) {// 登录成功，加入session
			session.setAttribute(
					"user",
					userService.findUniqueByProperty("telephone",
							reqBean.getTelephone()));
		}
		return JsonUtil.toJsonString(resBean);
	}

	/**
	 * 获取用户信息
	 * 
	 * @param params
	 *            Json格式的参数
	 * @return
	 */
	@ResponseBody
	@RequestMapping(value = "/authority/info.do")
	public String getUserInfo(@RequestParam("params") String params,
			HttpSession session) {
		UserInfoReqBean reqBean = JsonUtil.parseObject(params,
				UserInfoReqBean.class);
		User p = userService.getUserInfo(reqBean.getTelephone(),
				reqBean.getPassword());
		UserInfoResBean resBean = null;
		if (p == null) {
			resBean = new UserInfoResBean();
			resBean.setResult(0);
			return JsonUtil.toJsonString(resBean);
		}
		GradeBean bean=new GradeBean(p.getGrade().getGradeId(),
				p.getGrade().getGradeName());
		System.out.println(p.getGrade().getGradeId().toString());
		 resBean = new UserInfoResBean(p.getUserId(), 
				 p.getName(), p.getGender(), p.getAge(), 
				 p.getBirthday(), p.getAddress(), p.getTelephone(), p.getPhotoUrl(), p.getToken(),bean);
		return JsonUtil.toJsonString(resBean);
	}
	/**
	 * 获取学生班级的重要公告或通知
	 * 
	 * @param params
	 * @param session
	 * @return
	 */
	@ResponseBody
	@RequestMapping(value = "/getHomeNotice")
	public String getHomeNotice(@RequestParam("params") String params,
			HttpSession session) {
		StuHomeNoticeReqBean reqBean = JsonUtil.parseObject(params,
				StuHomeNoticeReqBean.class);
		System.out.println("用户id");
	System.out.println(reqBean.getUserId().toString());
		User students = userService.get(reqBean.getUserId());
		System.out.println(students
				.getGrade().getGradeId().toString());
		System.out.println(students
				.getName());
		System.out.println(students.getAddress());
		System.out.println(students.getToken());
		ArticleListResBean resBean = new ArticleListResBean();
		// 校园公告，班级公告的置顶帖都拿出来
		System.out.println("gradeid");
		List<Article> articles = articleService.getHomeNoticeList(students.getGrade().getGradeId());
		System.out.println(articles.get(0).getTitle());
		System.out.println("articles--" + articles);
		List<ArticleBean> beans = articleService.articleList2BeanList(articles);
		System.out.println("gradeId"+beans.get(0).getGradeId().toString());
		resBean.setArticles(beans);
		return JsonUtil.toJsonString(resBean);
	}
}
