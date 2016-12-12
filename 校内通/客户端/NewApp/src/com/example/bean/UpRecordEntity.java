package com.example.bean;

import com.lidroid.xutils.db.annotation.Column;
import com.lidroid.xutils.db.annotation.Id;
import com.lidroid.xutils.db.annotation.Table;

@Table(name = "up_record")
public class UpRecordEntity {
	
	public UpRecordEntity() {
	}
	
	@Column(column = "id")
	@Id
	private Integer id;
	
	@Column(column = "articleId")
	private Integer articleId;

    @Column(column = "personId")
    private Integer personId;
    
    @Column(column = "personType")
    private Integer personType;
    
    @Column(column = "status")
    private Integer status;//0：未点赞, 1：点赞
    
    
    

	public UpRecordEntity(Integer articleId, Integer personId,
			Integer personType, Integer status) {
		super();
		this.articleId = articleId;
		this.personId = personId;
		this.personType = personType;
		this.status = status;
	}

	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public Integer getArticleId() {
		return articleId;
	}

	public void setArticleId(Integer articleId) {
		this.articleId = articleId;
	}

	public Integer getPersonId() {
		return personId;
	}

	public void setPersonId(Integer personId) {
		this.personId = personId;
	}

	public Integer getPersonType() {
		return personType;
	}

	public void setPersonType(Integer personType) {
		this.personType = personType;
	}

	public Integer getStatus() {
		return status;
	}

	public void setStatus(Integer status) {
		this.status = status;
	}
    
    
	

}
