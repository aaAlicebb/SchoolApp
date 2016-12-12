package com.example.userdao;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.example.entity.KGroup;

@Repository
public class GroupDao extends BaseHibernateDao<KGroup> {

	/**
	 * 根据personId和personType获取群组信息列表
	 * @param personId
	 * @param personType
	 * @return
	 */

	public List<KGroup> getGroupList(Integer personId, Integer personType) {
		return this.find(
				"select g from GroupPersonRelation r,KGroup g where r.personId = ? and r.personType = ? and r.groupId = g.groupId",
				personId, personType);
	}

}
