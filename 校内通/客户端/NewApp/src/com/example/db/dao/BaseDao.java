package com.example.db.dao;

import java.lang.reflect.ParameterizedType;
import java.lang.reflect.Type;
import java.util.List;

import com.example.app.GlobalContext;
import com.lidroid.xutils.DbUtils;
import com.lidroid.xutils.exception.DbException;

public class BaseDao<T> {
	
	protected DbUtils db = GlobalContext.getInstance().getDbUtils();
	Class<T> entityClass;
	
	@SuppressWarnings("unchecked")
	public BaseDao(){
		Type genType = this.getClass().getGenericSuperclass();
		Type[] params = ((ParameterizedType) genType).getActualTypeArguments();
		entityClass =  (Class<T>) params[0];
	}
	
	public T findById(Object id){
		try {
			return  db.findById(entityClass, id);
		} catch (DbException e) {
			e.printStackTrace();
		}
		return null;
	}
	
	public List<T> findAll(){
		try {
			return db.findAll(entityClass);
		} catch (DbException e) {
			e.printStackTrace();
		}
		return null;
	}
	
	public void saveOrUpdate(T entity){
		try {
			db.saveOrUpdate(entity);
		} catch (DbException e) {
			e.printStackTrace();
		}
	}
	
	public void saveOrUpdateAll(List<T> entities){
		try {
			db.saveOrUpdateAll(entities);
		} catch (DbException e) {
			e.printStackTrace();
		}
	}
	
	public void delete(T entity){
		try {
			db.delete(entity);
		} catch (DbException e) {
			e.printStackTrace();
		}
	}
	
	public void deleteById(Object id){
		try {
			db.deleteById(entityClass, id);
		} catch (DbException e) {
			e.printStackTrace();
		}
	}
	
	
//	public T find(){
//		db.fin
//	}
	
//	public List<T> findAll(String sql,Object... params){
//		try {
//			List<DbModel> models= db.findDbModelAll(new SqlInfo(sql, params));
//			models.get(0).
//		} catch (DbException e) {
//			e.printStackTrace();
//		}
//		return null;
//	}

}
