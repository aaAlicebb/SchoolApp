package com.example.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.entity.Comment;
import com.example.entity.User;
import com.example.userdao.CommentDao;


@Service("commentService")
@Transactional
public class CommentService extends BaseService<Comment>{
	
	@Autowired @Qualifier("commentDao")
	CommentDao commentDao;
	@Autowired
	UserService userService;
	
	/**
	 * 分页获取评论列表
	 * @param articleId
	 * @param fromId
	 * @param pageSize
	 * @return
	 */
	public List<Comment> getArticleComments(Integer articleId,Integer fromId,Integer pageSize){
		return commentDao.getArticleComments(articleId, fromId, pageSize);
	}
	
	/**
	 * 获取评论作�?的信�?
	 * @param authorType
	 * @param authorId
	 * @return  [0]:authorName  [1]:authorPhotoUrl
	 */
	public String[] getCommentAuthorInfo(Integer authorType,Integer authorId){
		String[] result = new String[2];
		switch (authorType) {
		case 1://老师
			User user1 = userService.get(authorId);
			result[0] = user1.getName();
			result[1] = user1.getPhotoUrl();
			break;
		case 2://学生
			User user = userService.get(authorId);
			result[0] = user.getName();
			result[1] = user.getPhotoUrl();
			break;
		}
		return result;
	}


}
