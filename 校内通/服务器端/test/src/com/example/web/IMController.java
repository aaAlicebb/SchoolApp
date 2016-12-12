package com.example.web;

import java.util.List;

import javax.servlet.http.HttpSession;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.example.bean.im.ContactBean;
import com.example.bean.im.ContactListReqBean;
import com.example.bean.im.ContactListResBean;
import com.example.common.utils.JsonUtil;
import com.example.service.IMService;

@Controller
@RequestMapping(value = "/im", produces = "application/json; charset=utf-8", method = RequestMethod.POST)
public class IMController {
	
	@Autowired
	IMService imService;
	
	@ResponseBody
	@RequestMapping(value = "/groupAndContactList")
	public String getCourseList(@RequestParam("params") String params,
			HttpSession session) {
		ContactListReqBean reqBean = JsonUtil.parseObject(params, ContactListReqBean.class);
		ContactListResBean resBean = new ContactListResBean();
		List<ContactBean> list = imService.getGroupAndContact(reqBean.getPersonId(), reqBean.getPersonType(), reqBean.getTelephone());
		resBean.setContactBeans(list);;
		return JsonUtil.toJsonString(resBean);
		
	}

}
