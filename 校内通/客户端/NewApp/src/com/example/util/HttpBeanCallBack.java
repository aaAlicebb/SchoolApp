package com.example.util;

import org.apache.http.Header;

abstract class HttpBaseCallBack {
};

public abstract class HttpBeanCallBack<T> extends HttpBaseCallBack {
	public abstract void onFailure(int statusCode, String errorMsg);

	public abstract void onSuccess(int statusCode, final Header[] headers,
			final T responseBean);
}
