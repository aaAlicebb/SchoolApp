package com.example.util;

import java.lang.reflect.ParameterizedType;
import java.lang.reflect.Type;

import com.lidroid.xutils.HttpUtils;
import com.lidroid.xutils.exception.HttpException;
import com.lidroid.xutils.http.RequestParams;
import com.lidroid.xutils.http.ResponseInfo;
import com.lidroid.xutils.http.callback.RequestCallBack;
import com.lidroid.xutils.http.client.HttpRequest;
import com.lidroid.xutils.util.LogUtils;

/**
 * 与网络请求相关的工具类
 * 
 *
 */




public class HttpUtil {

	static final HttpUtils httpUtils = new HttpUtils();

	/**
	 * 以post方式上传数据访问服务器
	 * 
	 * @param url
	 * @param jsonBean
	 * @param callback
	 */
	public static <T> void post(String url, Object jsonBean,
			final HttpBeanCallBack<T> callback) {
		RequestParams params = new RequestParams();
		if (jsonBean != null)
			params.addBodyParameter("params", JsonUtil.toJsonString(jsonBean));
		httpUtils.send(HttpRequest.HttpMethod.POST, url, params,
				new RequestCallBack<String>() {

					@Override
					public void onFailure(HttpException exception, String error) {
						LogUtils.e(error);
						TipUtil.show(exception.getExceptionCode()+"连接服务器失败，请重试");
						callback.onFailure(exception.getExceptionCode(), error);
					}

					@Override
					public void onSuccess(ResponseInfo<String> responseInfo) {
						@SuppressWarnings("unchecked")
						T t = (T) JsonUtil.parseObject(responseInfo.result,
								getGenericType(callback, 0));
						callback.onSuccess(responseInfo.statusCode,
								responseInfo.getAllHeaders(), t);

					}
				});
	}

	@SuppressWarnings("rawtypes")
	private static <T> Class getGenericType(HttpBeanCallBack<T> callback,
			int index) {
		Type genType = callback.getClass().getGenericSuperclass();
		if (!(genType instanceof ParameterizedType)) {
			return Object.class;
		}
		Type[] params = ((ParameterizedType) genType).getActualTypeArguments();
		if (index >= params.length || index < 0) {
			throw new RuntimeException("Index outof bounds");
		}
		if (!(params[index] instanceof Class)) {
			return Object.class;
		}
		return (Class) params[index];
	}

}
