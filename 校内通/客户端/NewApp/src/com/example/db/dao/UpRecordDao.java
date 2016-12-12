package com.example.db.dao;

import com.example.bean.UpRecordEntity;
import com.lidroid.xutils.db.sqlite.Selector;
import com.lidroid.xutils.exception.DbException;

public class UpRecordDao extends BaseDao<UpRecordEntity>{
	
	public UpRecordEntity findOne(int articleId,int personId,int personType){
		try {
			return db.findFirst(Selector.from(UpRecordEntity.class)
					.where("articleId", "=", articleId)
					.and("personId", "=", personId)
					.and("personType", "=", personType)
					);
		} catch (DbException e) {
			e.printStackTrace();
		}
		return null;
	}

}
