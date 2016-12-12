package com.example.bean;

import java.util.List;

public class ArticleListResBean extends CommonResultResBean{
	
	private List<ArticleBean> articles;

	public List<ArticleBean> getArticles() {
		return articles;
	}

	public void setArticles(List<ArticleBean> articles) {
		this.articles = articles;
	}

}
