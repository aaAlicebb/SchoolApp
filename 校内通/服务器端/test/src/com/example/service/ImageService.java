package com.example.service;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.example.entity.Image;
import com.example.service.BaseService;


@Service("imageService")
@Transactional
public class ImageService extends BaseService<Image>{
	
	
	

}
