package com.example.service;

import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;

import com.example.userdao.BaseHibernateDao;
public abstract class BaseService<T> {
	
	
	@Autowired(required=false)
	protected BaseHibernateDao<T> dao;
	public Logger logger = LoggerFactory.getLogger(getClass());
	protected void setBaseDao(BaseHibernateDao<T> dao) {
		this.dao = dao;
	}

		
	public void saveAll(List<T> list){
		for (T t : list) {
			dao.save(t);
			logger.debug("save entity: {}", t);
			
		}
	}
	
	/**
	 * 保存新增或修改的对象.
	 */
	public void save(final T entity) {
		dao.save(entity);
	}

	/**
	 * 删除对象.
	 * 
	 * @param entity
	 *            对象必须是session中的对象或含id属性的transient对象.
	 */
	public void delete(final T entity) {
		dao.delete(entity);
	}

	/**
	 * 按id删除对象.
	 */
	public void delete(final Integer id) {
		delete(get(id));
	}

	/**
	 * 按id获取对象.
	 */
	public T get(final Integer id) {
		return dao.get(id);
	}
	
	/**
	 * 获取全部对象.
	 */
	public List<T> getAll() {
		return dao.getAll();
	}
	
	/**
	 * 获取全部对象, 支持按属性行序.
	 */
	public List<T> getAll(String orderByProperty, boolean isAsc) {
		return dao.getAll(orderByProperty, isAsc);
	}
	
	
	/**
	 * 按属性查找对象列表, 默认匹配方式为Like.
	 */
	public List<T> findByProperty(final String propertyName, final String value) {
//		Assert.isNull(propertyName, "propertyName不能为空");
		return dao.findByProperty(propertyName, value);
	}

	/**
	 * 按属性查找唯一对象, 默认匹配方式为Like.
	 */
	public T findUniqueByProperty(final String propertyName, final String value) {
//		Assert.isNull(propertyName, "propertyName不能为空");
		return dao.findUniqueByProperty(propertyName, value);
	}

	
	
	
	

}
