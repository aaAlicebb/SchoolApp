package com.example.bean;

import java.util.List;

import com.example.entity.ArticleType;

public class ArticleTypeListResBean extends CommonResultResBean{
	
	private List<ArticleType> typeList;

	public List<ArticleType> getTypeList() {
		return typeList;
	}

	public void setTypeList(List<ArticleType> typeList) {
		this.typeList = typeList;
	}

}
