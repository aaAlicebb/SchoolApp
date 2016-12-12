package com.example.bean;

/**
 * 这个按理说可以设计成所有response实体类的父类
 * 那么每个response类里都会有result属性
 * 可以适应多种情况，比如是否登录的验证等等
 * 统一了接口
 * @author WangJun
 *
 */
public class CommonResultResBean {
	
	/**
	 * 成功
	 */
	public static final Integer RESULT_CODE_SUCCESS = 0;
	/**
	 * 失败
	 */
	public static final Integer RESULT_CODE_FAIL = -1;
	/**
	 * 未登录
	 */
	public static final Integer RESULT_CODE_NOT_LOGIN = -2;
	/**
	 * 请求参数不合法
	 */
	public static final Integer RESULT_CODE_PARAM_INVALID = -3;
	
	private Integer result = RESULT_CODE_SUCCESS;

	public Integer getResult() {
		return result;
	}

	public void setResult(Integer result) {
		this.result = result;
	}

}
