package com.example.web;

import java.lang.reflect.InvocationTargetException;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpSession;

import org.apache.commons.beanutils.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.example.bean.ArticleBean;
import com.example.bean.ArticleCommentReqBean;
import com.example.bean.ArticleCommentResBean;
import com.example.bean.ArticleDeleteReqBean;
import com.example.bean.ArticleDetailReqBean;
import com.example.bean.ArticleDetailResBean;
import com.example.bean.ArticleListReqBean;
import com.example.bean.ArticleListResBean;
import com.example.bean.ArticleSendReqBean;
import com.example.bean.ArticleTypeListResBean;
import com.example.bean.CommentBean;
import com.example.bean.CommentSendReqBean;
import com.example.bean.CommonResultResBean;
import com.example.common.utils.JsonUtil;
import com.example.entity.Article;
import com.example.entity.Comment;
import com.example.entity.Image;
import com.example.service.ArticleService;
import com.example.service.ArticleTypeService;
import com.example.service.CommentService;
import com.example.service.GradeService;
import com.example.service.ImageService;

@Controller
@RequestMapping(value = "/article", produces = "application/json; charset=utf-8")
public class ArticleController {

	@Autowired 
	ArticleService articleService;
	@Autowired 
	GradeService gradeService;
	@Autowired  
	CommentService commentService;
	@Autowired
	ArticleTypeService articleTypeService;
	@Autowired
	ImageService imageService;

	@ResponseBody
	@RequestMapping(value = "/typelist.do")
	public String getTypeList(HttpSession session) {
		ArticleTypeListResBean bean = new ArticleTypeListResBean();
		bean.setTypeList(articleTypeService.getAll());
		return JsonUtil.toJsonString(bean);
	}

	@ResponseBody
	@RequestMapping(value = "/normalArticleList")
	public String getNormalArticleList(@RequestParam("params") String params,
			HttpSession session) {
		ArticleListReqBean reqBean = JsonUtil.parseObject(params,
				ArticleListReqBean.class);
		System.out.println("normal");
		System.out.println(reqBean.getRole().toString());
		System.out.println(reqBean.getFromId().toString());
		System.out.println(reqBean.getPersonId().toString());
		System.out.println(reqBean.getTypeId().toString());
		ArticleListResBean resBean = new ArticleListResBean();
		List<Article> articles = articleService
				.getNormalArticleList(reqBean.getTypeId(), reqBean.getFromId(),
						reqBean.getPageSize());
		List<ArticleBean> articleBeans = articleService.articleList2BeanList(articles);
		resBean.setArticles(articleBeans);
		return JsonUtil.toJsonString(resBean);

	}

	@ResponseBody
	@RequestMapping(value = "/gradeArticleList")
	public String getGradeArticleList(@RequestParam("params") String params,
			HttpSession session) {
		ArticleListReqBean reqBean = JsonUtil.parseObject(params,
				ArticleListReqBean.class);
		System.out.println(reqBean.getRole().toString());
		System.out.println(reqBean.getFromId().toString());
		System.out.println(reqBean.getTypeId().toString());
		System.out.println(reqBean.getPersonId().toString());
		System.out.println(reqBean.getGradeId().toString());
		ArticleListResBean resBean = new ArticleListResBean();
		List<Article> articles = articleService.getGradeArticleList(
				reqBean.getTypeId(), reqBean.getGradeId(), reqBean.getFromId(),
				reqBean.getPageSize());
		List<ArticleBean> articleBeans = articleService.articleList2BeanList(articles);
		resBean.setArticles(articleBeans);
		return JsonUtil.toJsonString(resBean);

	}

	@ResponseBody
	@RequestMapping(value = "/articleDetail")
	public String getArticleDetail(@RequestParam("params") String params,
			HttpSession session) {
		ArticleDetailReqBean reqBean = JsonUtil.parseObject(params,
				ArticleDetailReqBean.class);
		System.out.println(reqBean.getArticleId().toString());
		ArticleDetailResBean resBean = new ArticleDetailResBean();
		Article article = articleService.get(reqBean.getArticleId());
		ArticleBean bean = articleService.article2Bean(article);
		resBean.setArticle(bean);
		return JsonUtil.toJsonString(resBean);
	}

	@ResponseBody
	@RequestMapping(value = "/getComment")
	public String getArticleComments(@RequestParam("params") String params,
			HttpSession session) {
		ArticleCommentReqBean reqBean = JsonUtil.parseObject(params,
				ArticleCommentReqBean.class);
		ArticleCommentResBean resBean = new ArticleCommentResBean();
		List<Comment> comments = commentService.getArticleComments(
				reqBean.getArticleId(), reqBean.getFromId(),
				reqBean.getPageSize());
		List<CommentBean> commentBeans = new ArrayList<CommentBean>(
				comments.size());
		try {
			for (Comment comment : comments) {
				CommentBean bean = new CommentBean();
				BeanUtils.copyProperties(bean, comment);
				String[] info = commentService.getCommentAuthorInfo(
						comment.getAuthorType(), comment.getAuthorId());
				bean.setAuthorName(info[0]);
				bean.setAuthorPhotoUrl(info[1]);
				// 如果不是根评论，获取父评论的信息
				if (comment.getRootId() != -1) {
					Comment root = commentService.get(comment.getRootId());
					String[] rootInfo = commentService.getCommentAuthorInfo(
							root.getAuthorType(), root.getAuthorId());
					bean.setRootName(rootInfo[0]);
				}
				commentBeans.add(bean);
			}
			resBean.setComments(commentBeans);
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		} catch (InvocationTargetException e) {
			e.printStackTrace();
		}

		return JsonUtil.toJsonString(resBean);
	}

	@ResponseBody
	@RequestMapping(value = "/sendComment")
	public String sendComment(@RequestParam("params") String params,
			HttpSession session) {
		CommentSendReqBean reqBean = JsonUtil.parseObject(params,
				CommentSendReqBean.class);
		CommonResultResBean resBean = new CommonResultResBean();
		Integer rootId = reqBean.getRootId();
		if(rootId ==null) rootId = -1;
		boolean result = articleService.addComment(reqBean.getArticleId(),
				reqBean.getAuthorType(), reqBean.getAuthorId(), new Timestamp(
						System.currentTimeMillis()), rootId,
				reqBean.getContent());
		if (!result)
			resBean.setResult(CommonResultResBean.RESULT_CODE_FAIL);
		return JsonUtil.toJsonString(resBean);
	}

	@ResponseBody
	@RequestMapping(value = "/sendArticle")
	public String sendArticle(@RequestParam("params") String params,
			HttpSession session) {
		ArticleSendReqBean reqBean = JsonUtil.parseObject(params,
				ArticleSendReqBean.class);
		CommonResultResBean resBean = new CommonResultResBean();
		Article article = new Article(reqBean.getAuthorType(),
				reqBean.getAuthorId(), reqBean.getGradeId(), new Timestamp(
						System.currentTimeMillis()), reqBean.getTypeId(),
				reqBean.getTitle(), reqBean.getContent(), 0, 0,0,0);
		
			articleService.save(article);
			try {
			List<String> imgUrls = reqBean.getImgUrls();
			System.out.println("图片地址为："+imgUrls);
			if(imgUrls!=null && !imgUrls.isEmpty()){
				List<Image> imagess= new ArrayList<Image>();
				for (int i=0;i<imgUrls.size();i++) {
					Image img = new Image();
					img.setImgIndex(i);
					img.setImgType(0);//帖子type�?
					img.setImgUrl(imgUrls.get(i));
					img.setSourceId(article.getArticleId());
					imagess.add(img);
					
				}
				imageService.saveAll(imagess);
				System.out.println("图片地址为："+imgUrls.get(0).toString());
				System.out.println("图片地址为："+imagess.get(0).getImgType());
				System.out.println("图片地址为："+imagess.get(0).getSourceId());
				System.out.println("图片地址为："+imagess.get(0).getImgUrl());
				System.out.println("图片地址为："+imagess.get(0).getImgIndex().toString());
				
			}
		} catch(Exception e){
			
			e.printStackTrace();
		}
		
		return JsonUtil.toJsonString(resBean);
	}

	@ResponseBody
	@RequestMapping(value = "/up")
	public String articleUp(@RequestParam("params") String params,
			HttpSession session) {
		/*
		 * 对帖子点�?
		 */
		ArticleDetailReqBean reqBean = JsonUtil.parseObject(params,
				ArticleDetailReqBean.class);
		CommonResultResBean resBean = new CommonResultResBean();
		boolean result = articleService.upArticle(reqBean.getArticleId());
		if (!result)
			resBean.setResult(CommonResultResBean.RESULT_CODE_FAIL);
		return JsonUtil.toJsonString(resBean);
	}

	@ResponseBody
	@RequestMapping(value = "/cancelUp")
	public String articleCancelUp(@RequestParam("params") String params,
			HttpSession session) {
		/*
		 * 对帖子点赞
		 */
		ArticleDetailReqBean reqBean = JsonUtil.parseObject(params,
				ArticleDetailReqBean.class);
		CommonResultResBean resBean = new CommonResultResBean();
		boolean result = articleService.cancelUpArticle(reqBean.getArticleId());
		if (!result)
			resBean.setResult(CommonResultResBean.RESULT_CODE_FAIL);
		return JsonUtil.toJsonString(resBean);
	}

	@ResponseBody
	@RequestMapping(value = "/deleteArticle")
	public String deleteArticle(@RequestParam("params") String params,
			HttpSession session) {
		ArticleDeleteReqBean reqBean = JsonUtil.parseObject(params, ArticleDeleteReqBean.class);
		CommonResultResBean resBean = new CommonResultResBean();
		//根据请求的role和personId与session里的值来判断用户是否有权限，这里暂时不做
		boolean success = articleService.deleteArticle(reqBean.getArticleId());
		resBean.setResult(success?1:0);
		return JsonUtil.toJsonString(resBean);
		
	}
	
	/**
	 * 获取自己发表的所有帖�?
	 * 
	 * @param params
	 * @param session
	 * @return
	 */
//	 @ResponseBody
//	 @RequestMapping(value = "/getMyArticle")
//	 public String getMyArticle(@RequestParam("params") String params,
//	 HttpSession session) {
//	 ArticleDetailReqBean reqBean = JsonUtil.parseObject(params,
//	 ArticleDetailReqBean.class);
// return JsonUtil.toJsonString(resBean);
	// }

}
