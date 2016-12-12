package com.example.service;

import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import org.apache.commons.beanutils.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.bean.GradeBean;
import com.example.entity.Grade;
import com.example.userdao.GradeDao;

@Service("gradeService")
@Transactional
public class GradeService extends BaseService<Grade> {

	@Autowired @Qualifier("gradeDao")
	GradeDao gradeDao;
	/**
	 * 获取�?��的班级信�?
	 * 
	 * @return 获取所有班级对象的集合
	 */
	public Set<GradeBean> getAllGrades() {
		Set<GradeBean> gradeBeans = new HashSet<GradeBean>();
		List<Grade> grades = new ArrayList<Grade>();
		grades = dao.getAll("gradeId", true);
		try {
			for (Grade grade : grades) {
				GradeBean bean = new GradeBean();
				BeanUtils.copyProperties(bean, grade);
				bean.setGradeId(grade.getGradeId());
				bean.setGradeName(grade.getGradeName());
				gradeBeans.add(bean);
			}
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		} catch (InvocationTargetException e) {
			e.printStackTrace();
		}
		return gradeBeans;
	}
	

}
