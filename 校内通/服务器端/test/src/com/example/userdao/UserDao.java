package com.example.userdao;



import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.example.entity.User;

@Repository
public class UserDao extends BaseHibernateDao<User> {


}
