package com.example.bean;

import java.util.List;

public class CourseTableResBean extends CommonResultResBean{
	
	private List<List<CourseBean>> courses;

	public List<List<CourseBean>> getCourses() {
		return courses;
	}

	public void setCourses(List<List<CourseBean>> courses) {
		this.courses = courses;
	}
	
	

}
