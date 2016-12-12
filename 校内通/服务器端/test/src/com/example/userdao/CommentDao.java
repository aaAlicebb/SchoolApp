
package com.example.userdao;

import java.util.List;

import javax.annotation.Resource;

import org.hibernate.envers.AuditOverride;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Repository;

import com.example.entity.Comment;

@Repository
public class CommentDao extends BaseHibernateDao<Comment> {

	/**
	 * 根据articleId，fromid,pagesize加载帖子的评论列�?
	 * 
	 * @param articleId
	 * @param fromId
	 * @param pageSize
	 * @return
	 */
	
	public List<Comment> getArticleComments(Integer articleId, Integer fromId,
			Integer pageSize) {
		String hql = null;
		if (fromId <= 0) {
			hql = "from Comment where articleId = ? and commentId > ? order by commentTime desc";
		} else {
			hql = "from Comment where articleId = ? and commentId < ? order by commentTime desc";
		}
		return this.pagedQuery(hql, 1, pageSize, articleId, fromId).getResult();
	}

}
