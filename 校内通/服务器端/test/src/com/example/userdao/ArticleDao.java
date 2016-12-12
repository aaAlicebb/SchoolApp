package com.example.userdao;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.example.entity.Article;
@Repository(value="articDao")
public class ArticleDao extends BaseHibernateDao<Article> {
	
	/**
	 * 获取该类型帖子的�?��置顶帖子
	 * @param typeId
	 * @return
	 */
	public List<Article> getTopArticleList(Integer typeId,Integer gradeId){
		List<Article> tops =  this.find(
				"from Article where typeId = ? and gradeId = ? and top = 1", typeId,gradeId);
		return tops;
	}

	/**
	 * 根据typeid，fromId加载pageSize的帖�?
	 * 
	 * @param typeId
	 * @param fromId
	 * @param pageSize
	 *            这里假设会一直大于置顶帖的数�?
	 * @return
	 */
	public List<Article> getNormalArticleList(Integer typeId, Integer fromId,
			Integer pageSize) {

		List<Article> results = new ArrayList<Article>();
		String hql = null;
		if (fromId <= 0) {// 获取第一�?首先取出置顶的所有帖�?
			List<Article> tops = getTopArticleList(typeId,-1); 
			results.addAll(tops);
			hql = "from Article where typeId = ? and top = 0 and articleId > ? order by deliverTime desc";
		} else {
			hql = "from Article where typeId = ? and top = 0 and articleId < ? order by deliverTime desc";
		}
		List<Article> others = this.pagedQueryList(hql, 1,
				pageSize - results.size(), typeId, fromId);
		if(others !=null)
		results.addAll(others);
		return results;
	}

	/**
	 * 根据typeid，gradeId，fromId加载pageSize的帖�?
	 * 
	 * @param typeId
	 * @param gradeId
	 * @param fromId
	 * @param pageSize
	 * @return
	 */
	public List<Article> getGradeArticleList(Integer typeId, Integer gradeId,
			Integer fromId, Integer pageSize) {
		List<Article> results = new ArrayList<Article>();
		String hql = null;
		int grade = gradeId;
		if (fromId <= 0) {// 获取第一�?首先取出置顶的所有帖�?
			if(typeId==1){//如果是校园帖子，gradeId应该�?1
				grade=-1;
			}
			List<Article> tops = getTopArticleList(typeId,grade); 
			results.addAll(tops);
			hql = "from Article where typeId = ? and gradeId = ? and top = 0 and articleId > ? order by deliverTime desc";
		} else {
			hql = "from Article where typeId = ? and gradeId = ? and top = 0 and articleId < ? order by deliverTime desc";
		}
		
		List<Article> others = this.pagedQueryList(hql, 1,
				pageSize - results.size(), typeId, grade,fromId);
		if(others !=null)
		results.addAll(others);
		return results;
	}

	/**
	 * 顶帖操作
	 * 
	 * @param articleId
	 * @return
	 */
	public boolean upArticle(Integer articleId) {
		int flag = this
				.batchExecute(
						"update Article set upNumber = upNumber+1 where articleId = ? ",
						articleId);
		return flag == 0 ? false : true;
	}

	/**
	 * 帖子评论数操�?
	 * 
	 * @param articleId
	 * @return
	 */
	public boolean addArticleCommentNum(Integer articleId) {
		int flag = this
				.batchExecute(
						"update Article set commentNumber = commentNumber+1 where articleId = ? ",
						articleId);
		return flag == 0 ? false : true;
	}

	/**
	 * 取消点赞
	 * 
	 * @param articleId
	 * @return
	 */
	public boolean cancelUpArticle(Integer articleId) {
		int flag = this
				.batchExecute(
						"update Article set upNumber = upNumber-1 where articleId = ? ",
						articleId);
		return flag == 0 ? false : true;
	}

	public boolean deleteArticle(Integer articleId) {
		int flag = this.batchExecute("update Article set isDelete = 1 where articleId = ?", articleId);
		return flag == 0 ? false : true;
	}

}
