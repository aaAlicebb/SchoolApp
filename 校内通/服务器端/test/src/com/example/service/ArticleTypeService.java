package com.example.service;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.entity.ArticleType;
import com.example.service.BaseService;


@Service("articleTypeService")
@Transactional
	
public class ArticleTypeService extends BaseService<ArticleType>{

}
