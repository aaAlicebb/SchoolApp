package com.example.junit;
import java.sql.Date;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.example.entity.User;
import com.example.service.UserService;
@RunWith(SpringJUnit4ClassRunner.class)
// 加载spring配置文件
@ContextConfiguration(locations = { "classpath:applicationContext_test.xml" })
public class testJunit {
	private UserService userService;
	  @Test
	  public void testUser() throws Exception {
	    User user = new User();
//	    user.setName("中国人名共和国");
//	    user.setUserId(111);
//	    user.setPassword("123455");
//	    user.setAddress("fsaf");
//	    user.setAge(10);
//	    user.setGender(0);
//	    user.setTelephone("34542353251");
//	    userService.save(user);
	    userService.findUniqueByProperty("name", "黄蓉");
	    user=userService.findUniqueByProperty("name", "黄蓉");
	    System.out.println(user.getName());
	  }
}
