package com.example.web;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import com.example.bean.UpTokenResBean;
import com.example.common.utils.JsonUtil;
import com.example.common.utils.QiniuUtil;


@Controller
@RequestMapping(value = "/upload", produces = "application/json; charset=utf-8", method = RequestMethod.POST)
public class UploadController {
	
	
	@ResponseBody
	@RequestMapping(value = "/getUpToken")
	public String getUpToken(){
		UpTokenResBean bean = new UpTokenResBean();
		bean.setUpToken(QiniuUtil.getUpToken());
		return JsonUtil.toJsonString(bean);
	}
	
	

}
