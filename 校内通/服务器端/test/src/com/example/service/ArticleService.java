package com.example.service;

import java.lang.reflect.InvocationTargetException;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.beanutils.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.bean.ArticleBean;
import com.example.entity.Article;
import com.example.entity.Comment;
import com.example.entity.Grade;
import com.example.entity.Image;
import com.example.entity.User;
import com.example.userdao.ArticleDao;
import com.example.userdao.CommentDao;


@Service
@Transactional
public class ArticleService extends BaseService<Article>{

	@Autowired
	ArticleDao articleDao;
	@Autowired 
	CommentDao commentDao;
	/**
	 * 分页获取普�?帖子列表
	 * @param typeId
	 * @param fromId
	 * @param pageSize
	 * @return
	 */
	
	public List<Article> getNormalArticleList(Integer typeId,Integer fromId,Integer pageSize){
		return articleDao.getNormalArticleList(typeId, fromId, pageSize);
	}
	
	/**
	 * 分页获取班级帖子列表
	 * @param typeId
	 * @param gradeId
	 * @param fromId
	 * @param pageSize
	 * @return
	 */
	public List<Article> getGradeArticleList(Integer typeId,Integer gradeId,Integer fromId,Integer pageSize){
		return articleDao.getGradeArticleList(typeId, gradeId, fromId, pageSize);
	}
	
	public List<Article> getHomeNoticeList(Integer gradeId){
		List<Article> result = new ArrayList<Article>();
		//校园置顶公告
		List<Article> campus = articleDao.getTopArticleList(1, gradeId);
		//班级置顶公告
		List<Article> grades = articleDao.getTopArticleList(2, gradeId);
		result.addAll(campus);
		result.addAll(grades);
		return result;
	}
	
	
	@Autowired
	UserService userService;
	@Autowired 
	GradeService gradeService;
	
	/**顶帖操作
	 * @param articleId
	 * @return
	 */
	public boolean upArticle(Integer articleId){
		return articleDao.upArticle(articleId);
	}
	
	/**
	 * 取消点赞
	 * @param articleId
	 * @return
	 */
	public boolean cancelUpArticle(Integer articleId) {
		return articleDao.cancelUpArticle(articleId);
	}
	
	/**
	 * 删除帖子
	 * @param articleId
	 * @return
	 */
	public boolean deleteArticle(Integer articleId){
		return articleDao.deleteArticle(articleId);
	}
	
	/**添加评论
	 * @param articleId
	 * @return
	 */
	public boolean addComment(Integer articleId,Integer authorType,Integer authorId,Timestamp commentTime,Integer rootId,String content){
		Comment comment = new Comment(articleId, authorType, authorId, commentTime, rootId, content);
		commentDao.save(comment);
		return articleDao.addArticleCommentNum(articleId);
	}
	
	/**
	 * 获取帖子作�?的信�?
	 * @param authorType
	 * @param authorId
	 * @return
	 */
	public String[] getAuthorInfo(Integer authorType,Integer authorId){
		String authorName=null,authorPhotoUrl=null;
		switch (authorType) {
		case 1:// 老师
		
			User users = userService.get(authorId);
			authorName = users.getName();
			authorPhotoUrl = users.getPhotoUrl();
			break;
		case 2:// 学生
			User user = userService.get(authorId);
			authorName = user.getName();
			authorPhotoUrl = user.getPhotoUrl();
			break;

		}
		return new String[]{authorName,authorPhotoUrl};
	}
	
	/**将article封装成bean
	 * @param article
	 * @return
	 */
	public ArticleBean article2Bean(Article article){
		ArticleBean bean = new ArticleBean();
		try {
		String info[] = this.getAuthorInfo(article.getAuthorType(), article.getAuthorId());
		bean.setAuthorName(info[0]);
		bean.setAuthorPhotoUrl(info[1]);
		System.out.println(article.getGradeId().toString());
		if (article.getGradeId() != null && article.getGradeId() > 0) {
			Grade grade = gradeService.get(article.getGradeId());
			if (grade != null) {
				bean.setGradeName(grade.getGradeName());
			}
		}
		BeanUtils.copyProperties(bean, article);
		List<String> imageUrls = new ArrayList<String>();
		if (article.getImgUrls() != null) {
			for (Image image : article.getImgUrls()) {
				imageUrls.add(image.getImgUrl());
			}
			bean.setImageUrls(imageUrls);
		}
		
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		} catch (InvocationTargetException e) {
			e.printStackTrace();
		}
		return bean;
	}
	
	/**将article集合转变成bean集合
	 * @param articles
	 * @return
	 */
	public List<ArticleBean> articleList2BeanList(List<Article> articles){
		List<ArticleBean> articleBeans = new ArrayList<ArticleBean>(
				articles.size());
				for (Article article : articles) {
					ArticleBean bean = this.article2Bean(article);
					articleBeans.add(bean);
			}
		return articleBeans;
	}

	

}
