package com.example.entity;

import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * 所有实体类的父类
 * 
 */
public class BaseEntity {

	@Override
	public String toString() {
		return ToStringBuilder.reflectionToString(this);
	}

}
