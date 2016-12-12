package com.example.bean;

import java.util.List;

public class CourseListResBean extends CommonResultResBean{
	
	private List<CourseBean> courses;

	public List<CourseBean> getCourses() {
		return courses;
	}

	public void setCourses(List<CourseBean> courses) {
		this.courses = courses;
	}
	
	

}
