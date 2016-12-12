package com.example.util;

public abstract class FileLoadCallBack {
	
	public void onProcess(String key, double percent){};
	
	public abstract void onSuccess(String key);
	
	public abstract void onFailure(String errorMsg);

}
