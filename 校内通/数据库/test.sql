/*
Navicat MySQL Data Transfer

Source Server         : communication
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2016-12-07 19:01:24
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for article
-- ----------------------------
DROP TABLE IF EXISTS `article`;
CREATE TABLE `article` (
  `articleId` int(11) NOT NULL AUTO_INCREMENT,
  `authorType` int(11) NOT NULL,
  `authorId` int(11) NOT NULL,
  `gradeId` int(11) NOT NULL,
  `deliverTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `typeId` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `content` text NOT NULL,
  `top` int(11) NOT NULL DEFAULT '0',
  `isDelete` int(11) NOT NULL,
  `upNumber` int(11) NOT NULL,
  `commentNumber` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`articleId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of article
-- ----------------------------
INSERT INTO `article` VALUES ('2', '0', '2', '-1', '2015-07-09 21:07:20', '1', '武汉好人榜巡展到我园', '武汉市好人榜来咱们的幼儿园啦，大家快来看看，希望大家能向他们学习', '1', '0', '-33', '15');

-- ----------------------------
-- Table structure for article_type
-- ----------------------------
DROP TABLE IF EXISTS `article_type`;
CREATE TABLE `article_type` (
  `typeId` int(11) NOT NULL AUTO_INCREMENT,
  `typeName` varchar(255) NOT NULL,
  `articleCount` int(255) NOT NULL DEFAULT '0',
  `photoUrl` varchar(255) DEFAULT NULL,
  `typeDesc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`typeId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of article_type
-- ----------------------------
INSERT INTO `article_type` VALUES ('1', '校园公告', '213', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypexiaoyuan.jpg', '校园里重要的通知公告，家长老师们都请多注意');
INSERT INTO `article_type` VALUES ('2', '班级公告', '54', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypebanji_gonggao.jpg', '班级里大大小小的通知，请多多关注哦');
INSERT INTO `article_type` VALUES ('3', '班级论坛', '443', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypebanji_bbs.jpg', '专属班级的论坛，老师们家长们多多交流吧');
INSERT INTO `article_type` VALUES ('4', '亲子话题', '3243', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypeqinzi.jpg', '多关心孩子和家长们之间的话题，不容错过');
INSERT INTO `article_type` VALUES ('5', '幼儿阅读', '677', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypeyuedu.jpg', '适合家长讲给宝宝的小故事');
INSERT INTO `article_type` VALUES ('6', '照片秀', '544', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypeshaiwa.png', '晒晒家里的萌娃们吧，分享一些他们带给我们的欢乐');
INSERT INTO `article_type` VALUES ('7', '跳骚市场', '334', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypetiaozao.jpg', '物尽所用，东西虽小，情谊无价');
INSERT INTO `article_type` VALUES ('8', '大杂烩', '332', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypetucao.jpg', '想说什么说什么啦，尽情吐槽吧');

-- ----------------------------
-- Table structure for check_in
-- ----------------------------
DROP TABLE IF EXISTS `check_in`;
CREATE TABLE `check_in` (
  `checkId` int(11) NOT NULL AUTO_INCREMENT,
  `childId` int(11) NOT NULL,
  `checkTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`checkId`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of check_in
-- ----------------------------
INSERT INTO `check_in` VALUES ('1', '11', '2015-04-14 07:34:53');
INSERT INTO `check_in` VALUES ('2', '11', '2015-04-14 16:05:55');
INSERT INTO `check_in` VALUES ('3', '11', '2015-04-15 07:40:57');
INSERT INTO `check_in` VALUES ('4', '11', '2015-04-15 16:05:20');
INSERT INTO `check_in` VALUES ('5', '12', '2015-04-16 08:17:00');
INSERT INTO `check_in` VALUES ('6', '12', '2015-04-16 16:16:23');
INSERT INTO `check_in` VALUES ('7', '13', '2015-04-15 07:56:26');
INSERT INTO `check_in` VALUES ('8', '14', '2015-04-14 07:40:27');
INSERT INTO `check_in` VALUES ('9', '15', '2015-04-15 16:16:29');
INSERT INTO `check_in` VALUES ('10', '16', '2015-04-14 07:45:30');
INSERT INTO `check_in` VALUES ('11', '17', '2015-04-15 16:05:35');
INSERT INTO `check_in` VALUES ('12', '18', '2015-04-16 07:56:37');
INSERT INTO `check_in` VALUES ('13', '19', '2015-04-15 16:16:38');
INSERT INTO `check_in` VALUES ('14', '20', '2015-04-15 07:50:04');
INSERT INTO `check_in` VALUES ('15', '20', '2015-04-15 16:17:06');
INSERT INTO `check_in` VALUES ('16', '20', '2015-04-16 07:59:08');
INSERT INTO `check_in` VALUES ('17', '21', '2015-04-15 16:17:10');
INSERT INTO `check_in` VALUES ('18', '21', '2015-04-15 16:17:12');
INSERT INTO `check_in` VALUES ('19', '22', '2015-04-15 16:17:13');

-- ----------------------------
-- Table structure for child
-- ----------------------------
DROP TABLE IF EXISTS `child`;
CREATE TABLE `child` (
  `childId` int(11) NOT NULL AUTO_INCREMENT,
  `gradeId` int(11) NOT NULL,
  `parentId` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `stuNum` int(11) NOT NULL,
  `gender` int(11) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `photoUrl` varchar(255) DEFAULT NULL,
  `birthday` date DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`childId`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of child
-- ----------------------------
INSERT INTO `child` VALUES ('1', '1', '1', '张小山', '11001', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_zhangxiaoshang.jpg', '2010-04-12', '武汉大学');
INSERT INTO `child` VALUES ('2', '1', '2', '李小倩', '11002', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child11.jpg', '2010-05-17', '武汉大学');
INSERT INTO `child` VALUES ('3', '1', '3', '赵小文', '11003', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child12.jpg', '2010-01-13', '武汉大学');
INSERT INTO `child` VALUES ('4', '1', '4', '李小明', '11004', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child13.jpg', '2010-02-17', '武汉大学');
INSERT INTO `child` VALUES ('5', '1', '5', '王小明', '11005', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child14.jpg', '2010-06-15', '武汉大学');
INSERT INTO `child` VALUES ('6', '1', '1', '张小红', '11006', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_zhangxiaohong.jpg', '2010-04-12', '武汉大学');
INSERT INTO `child` VALUES ('7', '1', '6', '李小文', '11007', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child15.jpg', '2010-02-16', '武汉大学');
INSERT INTO `child` VALUES ('8', '1', '7', '赵小端', '11008', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child16.jpg', '2010-05-18', '武汉大学');
INSERT INTO `child` VALUES ('9', '1', '8', '赵小燕', '11009', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child17.jpg', '2010-01-11', '武汉大学');
INSERT INTO `child` VALUES ('10', '1', '9', '张文文', '11010', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child18.jpg', '2010-02-24', '武汉大学');
INSERT INTO `child` VALUES ('11', '2', '5', '王语嫣', '12001', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child19.jpg', '2010-06-22', '武汉大学');
INSERT INTO `child` VALUES ('12', '2', '10', '程灵素', '12002', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child11.jpg', '2010-01-12', '武汉大学');
INSERT INTO `child` VALUES ('13', '2', '11', '任盈盈', '12003', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child14.jpg', '2010-07-13', '武汉大学');
INSERT INTO `child` VALUES ('14', '2', '12', '令狐冲', '12004', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child16.jpg', '2010-01-26', '武汉大学');
INSERT INTO `child` VALUES ('15', '2', '13', '段誉', '12005', '0', '6', 'http://7xinjs.com1.z0.glb.clouddn.com/child12.jpg', '2009-12-23', '武汉大学');
INSERT INTO `child` VALUES ('16', '2', '14', '张无忌', '12006', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child20.jpg', '2010-05-03', '武汉大学');
INSERT INTO `child` VALUES ('17', '2', '15', '虚竹', '12007', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child19.jpg', '2010-06-22', '武汉大学');
INSERT INTO `child` VALUES ('18', '2', '16', '木婉清', '12008', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child15.jpg', '2010-05-30', '武汉大学');
INSERT INTO `child` VALUES ('19', '2', '17', '黄蓉', '12009', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child13.jpg', '2010-02-28', '武汉大学');
INSERT INTO `child` VALUES ('20', '2', '18', '郭靖', '12010', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child16.jpg', '2010-04-22', '武汉大学');
INSERT INTO `child` VALUES ('21', '3', '19', '卫栖梧', '13001', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child18.jpg', '2010-05-05', '武汉大学');
INSERT INTO `child` VALUES ('22', '3', '20', '叶凡', '13002', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child14.jpg', '2010-02-18', '武汉大学');
INSERT INTO `child` VALUES ('23', '3', '21', '唐小婉', '13003', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child12.jpg', '2010-05-04', '武汉大学');
INSERT INTO `child` VALUES ('24', '3', '22', '叶英', '13004', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child11.jpg', '2010-05-30', '武汉大学');
INSERT INTO `child` VALUES ('25', '3', '23', '曹雪阳', '13005', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child20.jpg', '2010-01-01', '武汉大学');
INSERT INTO `child` VALUES ('26', '3', '3', '赵云睿', '13006', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child19.jpg', '2010-04-29', '武汉大学');
INSERT INTO `child` VALUES ('27', '3', '25', '李承恩', '13007', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child18.jpg', '2010-05-14', '武汉大学');
INSERT INTO `child` VALUES ('28', '3', '24', '曲云', '13008', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child17.jpg', '2010-02-16', '武汉大学');
INSERT INTO `child` VALUES ('29', '3', '26', '谢云流', '13009', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child16.jpg', '2010-02-16', '武汉大学');
INSERT INTO `child` VALUES ('30', '3', '27', '叶孟秋', '13010', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child15.jpg', '2010-04-03', '武汉大学');
INSERT INTO `child` VALUES ('31', '3', '28', '王遗风', '13011', '0', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child14.jpg', '2010-04-22', '武汉大学');
INSERT INTO `child` VALUES ('32', '3', '29', '叶舒歌', '13012', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child13.jpg', '2010-03-11', '武汉大学');
INSERT INTO `child` VALUES ('33', '3', '30', '高绛婷', '13013', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child11.jpg', '2010-10-27', '武汉大学');
INSERT INTO `child` VALUES ('34', '3', '31', '叶婧衣', '13014', '1', '5', 'http://7xinjs.com1.z0.glb.clouddn.com/child12.jpg', '2010-08-14', '武汉大学');

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment` (
  `commentId` int(11) NOT NULL AUTO_INCREMENT,
  `articleId` int(11) NOT NULL,
  `authorType` int(11) NOT NULL,
  `authorId` int(11) NOT NULL,
  `commentTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `rootId` int(11) NOT NULL,
  `content` varchar(255) NOT NULL,
  PRIMARY KEY (`commentId`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of comment
-- ----------------------------
INSERT INTO `comment` VALUES ('6', '10', '2', '1', '2015-05-17 15:23:51', '-1', '还能怎么办，陪着一起玩啊');
INSERT INTO `comment` VALUES ('7', '10', '2', '1', '2015-05-17 15:24:18', '-1', '原来就是你家熊孩子坑我排位啊');
INSERT INTO `comment` VALUES ('8', '2', '2', '1', '2015-05-18 17:31:27', '-1', '希望幼儿园可以多举办这样的活动，给孩子们带来正能量！');
INSERT INTO `comment` VALUES ('9', '2', '1', '1', '2015-05-18 17:33:55', '8', '谢谢您给我们幼儿园提的建议，我们会在每个月都举办一次。');
INSERT INTO `comment` VALUES ('10', '2', '2', '1', '2015-05-18 17:35:14', '9', '不用谢，张老师，我们都希望孩子能更好的成长嘛');
INSERT INTO `comment` VALUES ('11', '3', '2', '1', '2015-07-09 15:18:33', '-1', '好的，支持一下');
INSERT INTO `comment` VALUES ('12', '3', '2', '1', '2015-07-09 15:18:43', '11', '哦呵呵');
INSERT INTO `comment` VALUES ('13', '4', '2', '1', '2015-07-09 15:22:04', '-1', '哈哈');
INSERT INTO `comment` VALUES ('14', '5', '2', '2', '2015-07-09 16:13:00', '-1', '放几天假呀');
INSERT INTO `comment` VALUES ('15', '5', '2', '2', '2015-07-09 16:13:13', '-1', '好吧，当我没问');

-- ----------------------------
-- Table structure for contact
-- ----------------------------
DROP TABLE IF EXISTS `contact`;
CREATE TABLE `contact` (
  `contactId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `selfTelephone` varchar(255) NOT NULL,
  `contactTelephone` varchar(255) NOT NULL,
  `selfRole` int(11) NOT NULL,
  `contactRole` int(11) NOT NULL,
  PRIMARY KEY (`contactId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of contact
-- ----------------------------
INSERT INTO `contact` VALUES ('1', '13300000000', '13300000000', '2', '2');
INSERT INTO `contact` VALUES ('2', '13300000000', '13311111111', '2', '2');
INSERT INTO `contact` VALUES ('3', '13300000000', '13211111111', '2', '1');
INSERT INTO `contact` VALUES ('4', '13300000000', '13111111111', '2', '0');
INSERT INTO `contact` VALUES ('5', '13311111111', '13300000000', '2', '2');
INSERT INTO `contact` VALUES ('6', '13211111111', '13300000000', '1', '2');
INSERT INTO `contact` VALUES ('7', '13211111111', '13311111111', '1', '2');
INSERT INTO `contact` VALUES ('8', '13211111111', '13222222222', '1', '1');

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course` (
  `courseId` int(11) NOT NULL AUTO_INCREMENT,
  `courseName` varchar(255) NOT NULL,
  PRIMARY KEY (`courseId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES ('1', '语文');
INSERT INTO `course` VALUES ('2', '数学');
INSERT INTO `course` VALUES ('3', '英语');
INSERT INTO `course` VALUES ('4', '美术');
INSERT INTO `course` VALUES ('5', '礼仪');
INSERT INTO `course` VALUES ('6', '体育');
INSERT INTO `course` VALUES ('7', '艺术');
INSERT INTO `course` VALUES ('8', '保健');
INSERT INTO `course` VALUES ('9', '活动');

-- ----------------------------
-- Table structure for course_table
-- ----------------------------
DROP TABLE IF EXISTS `course_table`;
CREATE TABLE `course_table` (
  `courseTableId` int(11) NOT NULL AUTO_INCREMENT,
  `courseId` int(11) NOT NULL,
  `teacherId` int(11) NOT NULL,
  `gradeId` int(11) NOT NULL,
  `startTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `endTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `day` int(11) NOT NULL,
  PRIMARY KEY (`courseTableId`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of course_table
-- ----------------------------
INSERT INTO `course_table` VALUES ('1', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('2', '1', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('3', '4', '5', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('4', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('5', '5', '7', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('6', '6', '10', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('7', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('8', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('9', '7', '11', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('10', '2', '8', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('11', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('12', '3', '2', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('13', '4', '5', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('14', '8', '9', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('15', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('16', '1', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('17', '5', '7', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('18', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('19', '2', '8', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('20', '6', '10', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('21', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('22', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('23', '7', '11', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('24', '3', '2', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('25', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('26', '1', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('27', '4', '5', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('28', '8', '8', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('29', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('30', '5', '7', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('31', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('32', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('33', '2', '8', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('34', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('35', '9', '1', '1', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('36', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('37', '6', '10', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('38', '1', '6', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('39', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('40', '4', '5', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('41', '5', '7', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('42', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('43', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('44', '4', '5', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('45', '7', '11', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('46', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('47', '2', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('48', '3', '2', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('49', '8', '9', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('50', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('51', '6', '10', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('52', '1', '6', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('53', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('54', '5', '7', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('55', '2', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('56', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('57', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('58', '4', '5', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('59', '7', '11', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('60', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('61', '3', '2', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('62', '1', '6', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('63', '8', '9', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('64', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('65', '5', '7', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('66', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('67', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('68', '2', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('69', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('70', '9', '3', '2', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('71', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('72', '5', '7', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('73', '6', '10', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('74', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('75', '1', '6', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('76', '4', '5', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('77', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '1');
INSERT INTO `course_table` VALUES ('78', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('79', '3', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('80', '4', '5', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('81', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('82', '7', '11', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('83', '2', '8', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('84', '8', '9', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '2');
INSERT INTO `course_table` VALUES ('85', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('86', '2', '8', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('87', '6', '10', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('88', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('89', '1', '6', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('90', '5', '7', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('91', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('92', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '3');
INSERT INTO `course_table` VALUES ('93', '1', '6', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('94', '4', '5', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('95', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('96', '7', '11', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('97', '3', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('98', '8', '9', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '4');
INSERT INTO `course_table` VALUES ('99', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('100', '2', '8', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('101', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('102', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('103', '5', '7', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('104', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');
INSERT INTO `course_table` VALUES ('105', '9', '4', '3', '2015-05-01 12:20:06', '2014-11-05 19:38:19', '5');

-- ----------------------------
-- Table structure for director
-- ----------------------------
DROP TABLE IF EXISTS `director`;
CREATE TABLE `director` (
  `directorId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `gender` varchar(5) NOT NULL,
  `age` int(11) NOT NULL,
  `birthday` date DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `telephone` varchar(30) NOT NULL,
  `photoUrl` varchar(255) DEFAULT NULL,
  `des` varchar(255) DEFAULT NULL,
  `password` varchar(255) NOT NULL,
  `role` int(11) NOT NULL,
  `token` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`directorId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of director
-- ----------------------------
INSERT INTO `director` VALUES ('1', '李明', '0', '42', '1973-05-15', '武汉市武昌区建设路28号', '13111111111', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man3.jpg', '武汉市统一幼儿园园长', 'cc1ebcff6fa0717058cf3a13ec789fce', '0', null);
INSERT INTO `director` VALUES ('2', '李红', '1', '30', '1985-08-22', '武汉市武昌区武珞路235号', '13122222222', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_women3.jpg', '武汉市统一幼儿园园长助理', '584a6f5fa352a7d813919968d62b29e7', '1', null);

-- ----------------------------
-- Table structure for grade
-- ----------------------------
DROP TABLE IF EXISTS `grade`;
CREATE TABLE `grade` (
  `gradeId` int(11) NOT NULL AUTO_INCREMENT,
  `gradeName` varchar(255) NOT NULL,
  PRIMARY KEY (`gradeId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of grade
-- ----------------------------
INSERT INTO `grade` VALUES ('1', '小班');
INSERT INTO `grade` VALUES ('2', '中班');
INSERT INTO `grade` VALUES ('3', '大班');

-- ----------------------------
-- Table structure for group_person_relation
-- ----------------------------
DROP TABLE IF EXISTS `group_person_relation`;
CREATE TABLE `group_person_relation` (
  `relationId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `groupId` varchar(255) NOT NULL,
  `personId` int(11) NOT NULL,
  `personType` int(11) NOT NULL,
  PRIMARY KEY (`relationId`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of group_person_relation
-- ----------------------------
INSERT INTO `group_person_relation` VALUES ('3', 'a', '1', '2');
INSERT INTO `group_person_relation` VALUES ('4', 'b', '1', '2');
INSERT INTO `group_person_relation` VALUES ('6', 'a', '10', '2');
INSERT INTO `group_person_relation` VALUES ('7', 'b', '10', '2');
INSERT INTO `group_person_relation` VALUES ('8', 'a', '9', '2');
INSERT INTO `group_person_relation` VALUES ('9', 'b', '9', '2');
INSERT INTO `group_person_relation` VALUES ('10', 'a', '8', '2');
INSERT INTO `group_person_relation` VALUES ('11', 'b', '8', '2');
INSERT INTO `group_person_relation` VALUES ('12', 'a', '7', '2');
INSERT INTO `group_person_relation` VALUES ('13', 'b', '7', '2');
INSERT INTO `group_person_relation` VALUES ('14', 'a', '6', '2');
INSERT INTO `group_person_relation` VALUES ('15', 'b', '6', '2');
INSERT INTO `group_person_relation` VALUES ('16', 'a', '5', '2');
INSERT INTO `group_person_relation` VALUES ('17', 'b', '5', '2');
INSERT INTO `group_person_relation` VALUES ('18', 'a', '4', '2');
INSERT INTO `group_person_relation` VALUES ('19', 'b', '4', '2');
INSERT INTO `group_person_relation` VALUES ('20', 'a', '3', '2');
INSERT INTO `group_person_relation` VALUES ('21', 'b', '3', '2');
INSERT INTO `group_person_relation` VALUES ('22', 'a', '2', '2');
INSERT INTO `group_person_relation` VALUES ('23', 'b', '2', '2');
INSERT INTO `group_person_relation` VALUES ('26', 'a', '2', '1');
INSERT INTO `group_person_relation` VALUES ('27', 'b', '2', '1');
INSERT INTO `group_person_relation` VALUES ('28', 'a', '3', '1');
INSERT INTO `group_person_relation` VALUES ('29', 'b', '3', '1');
INSERT INTO `group_person_relation` VALUES ('30', 'a', '4', '1');
INSERT INTO `group_person_relation` VALUES ('31', 'b', '4', '1');
INSERT INTO `group_person_relation` VALUES ('32', 'a', '5', '1');
INSERT INTO `group_person_relation` VALUES ('33', 'b', '5', '1');
INSERT INTO `group_person_relation` VALUES ('34', 'a', '6', '1');
INSERT INTO `group_person_relation` VALUES ('35', 'b', '6', '1');
INSERT INTO `group_person_relation` VALUES ('36', 'a', '7', '1');
INSERT INTO `group_person_relation` VALUES ('37', 'b', '7', '1');
INSERT INTO `group_person_relation` VALUES ('38', 'a', '8', '1');
INSERT INTO `group_person_relation` VALUES ('39', 'b', '8', '1');
INSERT INTO `group_person_relation` VALUES ('40', 'a', '9', '1');
INSERT INTO `group_person_relation` VALUES ('41', 'b', '9', '1');
INSERT INTO `group_person_relation` VALUES ('42', 'a', '10', '1');
INSERT INTO `group_person_relation` VALUES ('43', 'b', '10', '1');
INSERT INTO `group_person_relation` VALUES ('44', 'a', '11', '1');
INSERT INTO `group_person_relation` VALUES ('45', 'b', '11', '1');
INSERT INTO `group_person_relation` VALUES ('46', 'a', '1', '0');
INSERT INTO `group_person_relation` VALUES ('47', 'b', '1', '0');
INSERT INTO `group_person_relation` VALUES ('48', 'a', '1', '1');
INSERT INTO `group_person_relation` VALUES ('49', 'b', '1', '1');
INSERT INTO `group_person_relation` VALUES ('50', 'a', '2', '0');
INSERT INTO `group_person_relation` VALUES ('51', 'b', '2', '0');

-- ----------------------------
-- Table structure for growth_record
-- ----------------------------
DROP TABLE IF EXISTS `growth_record`;
CREATE TABLE `growth_record` (
  `recordId` int(11) NOT NULL AUTO_INCREMENT,
  `childId` int(11) NOT NULL,
  `recordTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `authorType` int(255) NOT NULL,
  `authorId` int(11) NOT NULL,
  `content` varchar(255) NOT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `privacy` int(11) NOT NULL,
  PRIMARY KEY (`recordId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of growth_record
-- ----------------------------
INSERT INTO `growth_record` VALUES ('1', '1', '2015-06-03 14:30:24', '2', '1', '小山今天很乖，回家自己很自觉的把家庭作业做完了', '0', '0');
INSERT INTO `growth_record` VALUES ('2', '1', '2015-06-03 14:32:38', '1', '1', '小山同学今天给老师送了一朵花，很有爱哦', '0', '0');
INSERT INTO `growth_record` VALUES ('3', '1', '2015-06-03 14:33:40', '2', '1', '小山这个月重了2斤，长高了2厘米，不错不错', '0', '0');
INSERT INTO `growth_record` VALUES ('4', '1', '2015-06-03 14:35:37', '1', '1', '小山同学在活动课上和同桌小红获得了两人三足游戏的第一名，值得表扬哈', '0', '0');
INSERT INTO `growth_record` VALUES ('5', '1', '2015-06-03 16:17:51', '2', '1', '今天给小山讲了愚公移山的故事，他居然问我愚公为啥不去找挖掘机来帮忙？', '0', '2');

-- ----------------------------
-- Table structure for health_info
-- ----------------------------
DROP TABLE IF EXISTS `health_info`;
CREATE TABLE `health_info` (
  `infoId` int(11) NOT NULL AUTO_INCREMENT,
  `childId` int(11) NOT NULL,
  `height` double NOT NULL,
  `weight` double NOT NULL,
  `infoDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`infoId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of health_info
-- ----------------------------
INSERT INTO `health_info` VALUES ('1', '1', '100.5', '14.6', '2015-01-01 11:57:12');
INSERT INTO `health_info` VALUES ('2', '1', '101', '15.5', '2015-02-01 11:57:28');
INSERT INTO `health_info` VALUES ('3', '1', '101.6', '16.6', '2015-03-01 11:57:28');
INSERT INTO `health_info` VALUES ('4', '1', '102.3', '18.2', '2015-04-01 11:57:29');
INSERT INTO `health_info` VALUES ('5', '1', '103.6', '18.5', '2015-05-01 11:57:31');
INSERT INTO `health_info` VALUES ('6', '22', '116.5', '23.5', '2014-02-04 19:41:53');
INSERT INTO `health_info` VALUES ('7', '22', '117.1', '24', '2014-06-14 19:43:44');
INSERT INTO `health_info` VALUES ('8', '22', '117.8', '24.5', '2014-10-21 19:43:46');
INSERT INTO `health_info` VALUES ('9', '22', '118.5', '25.5', '2015-01-27 19:43:48');
INSERT INTO `health_info` VALUES ('10', '22', '118.7', '25.9', '2015-04-14 19:43:51');

-- ----------------------------
-- Table structure for image
-- ----------------------------
DROP TABLE IF EXISTS `image`;
CREATE TABLE `image` (
  `imgId` int(11) NOT NULL AUTO_INCREMENT,
  `imgIndex` int(11) NOT NULL,
  `imgType` int(11) NOT NULL,
  `sourceId` int(11) NOT NULL,
  `imgDesc` varchar(255) DEFAULT NULL,
  `imgUrl` varchar(255) NOT NULL,
  PRIMARY KEY (`imgId`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of image
-- ----------------------------
INSERT INTO `image` VALUES ('1', '0', '0', '1', 'Test', 'http://7xinjs.com1.z0.glb.clouddn.com/testat3.jpg');
INSERT INTO `image` VALUES ('2', '1', '0', '1', 'Come', 'http://7xinjs.com1.z0.glb.clouddn.com/testat1.jpg');
INSERT INTO `image` VALUES ('3', '0', '1', '1', 'First', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypegonggao1.jpg');
INSERT INTO `image` VALUES ('4', '2', '0', '1', 'fff', 'http://7xinjs.com1.z0.glb.clouddn.com/testat1.jpg');
INSERT INTO `image` VALUES ('5', '3', '0', '1', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/testat2.jpg');
INSERT INTO `image` VALUES ('6', '4', '0', '1', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/testat3.jpg');
INSERT INTO `image` VALUES ('7', '5', '0', '1', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/testat4.jpg');
INSERT INTO `image` VALUES ('8', '6', '0', '1', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/testat5.jpg');
INSERT INTO `image` VALUES ('9', '7', '0', '1', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/testat6.jpg');
INSERT INTO `image` VALUES ('10', '0', '0', '2', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypegonggao1.jpg');
INSERT INTO `image` VALUES ('11', '1', '0', '2', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypegonggao2.jpg');
INSERT INTO `image` VALUES ('12', '2', '0', '2', 'jjj', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypegonggao3.jpg');
INSERT INTO `image` VALUES ('14', '0', '0', '9', null, 'http://7xinjs.com1.z0.glb.clouddn.com/82d97ad632b842a8a9b4444f36e692ca');
INSERT INTO `image` VALUES ('15', '1', '0', '9', null, 'http://7xinjs.com1.z0.glb.clouddn.com/61c0d75602fa4cbf85616ffb478443ea');
INSERT INTO `image` VALUES ('16', '2', '0', '9', null, 'http://7xinjs.com1.z0.glb.clouddn.com/26958d7779dd4ae9892230d714899d36');
INSERT INTO `image` VALUES ('17', '0', '0', '10', null, 'http://7xinjs.com1.z0.glb.clouddn.com/241a92e372284c419acb58de83b10117');
INSERT INTO `image` VALUES ('18', '1', '0', '10', null, 'http://7xinjs.com1.z0.glb.clouddn.com/e63d4092915c4933bf8d37a86684d284');
INSERT INTO `image` VALUES ('19', '2', '0', '10', null, 'http://7xinjs.com1.z0.glb.clouddn.com/2daf5aa2eaa24effadfde5b14fa504e8');
INSERT INTO `image` VALUES ('20', '1', '1', '1', '额', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypegonggao2.jpg');
INSERT INTO `image` VALUES ('21', '0', '1', '3', 's', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypegonggao3.jpg');
INSERT INTO `image` VALUES ('22', '0', '1', '5', null, 'http://7xinjs.com1.z0.glb.clouddn.com/2c4bd24a187c4379b1d90c538f00dddf');
INSERT INTO `image` VALUES ('23', '1', '1', '5', null, 'http://7xinjs.com1.z0.glb.clouddn.com/18f844a8a6814b5696f98ef7160b8bde');
INSERT INTO `image` VALUES ('24', '0', '0', '13', null, 'http://7xinjs.com1.z0.glb.clouddn.com/b91363e9af5740e19fb2986c9f15f5c1');
INSERT INTO `image` VALUES ('25', '1', '0', '13', null, 'http://7xinjs.com1.z0.glb.clouddn.com/15db78ea6df6477694dd0eabc91ec88a');
INSERT INTO `image` VALUES ('26', '2', '0', '13', null, 'http://7xinjs.com1.z0.glb.clouddn.com/9d44d89bdb174e3182383824e6ef47b2');
INSERT INTO `image` VALUES ('27', '0', '0', '21', null, 'http://7xinjs.com1.z0.glb.clouddn.com/8ec28b89ae59447997d03bb12cc44f52');
INSERT INTO `image` VALUES ('28', '0', '0', '22', null, 'http://7xinjs.com1.z0.glb.clouddn.com/05d452b97ba2496e90cae372da9928a2');
INSERT INTO `image` VALUES ('29', '1', '0', '22', null, 'http://7xinjs.com1.z0.glb.clouddn.com/3f60f7b3cdec4f1188260b58c62acf62');
INSERT INTO `image` VALUES ('30', '2', '0', '22', null, 'http://7xinjs.com1.z0.glb.clouddn.com/7c1954afdf1f4d66845a5dddf3d54d21');
INSERT INTO `image` VALUES ('31', '0', '0', '23', null, 'http://7xinjs.com1.z0.glb.clouddn.com/99918d2c7e1745abadb90f221f0c069d');
INSERT INTO `image` VALUES ('32', '0', '0', '24', null, 'http://7xinjs.com1.z0.glb.clouddn.com/111083a3fba04b4ea123b18f93d036d4');
INSERT INTO `image` VALUES ('33', '0', '0', '25', null, 'http://7xinjs.com1.z0.glb.clouddn.com/c9ad192bc8e2439bb08915b065c45786');
INSERT INTO `image` VALUES ('34', '1', '0', '25', null, 'http://7xinjs.com1.z0.glb.clouddn.com/ead036ee968f4d7d8f64073c0be121d9');
INSERT INTO `image` VALUES ('35', '2', '0', '25', null, 'http://7xinjs.com1.z0.glb.clouddn.com/102e4bfcf2a841b4b1eb0fc02197b23f');

-- ----------------------------
-- Table structure for k_group
-- ----------------------------
DROP TABLE IF EXISTS `k_group`;
CREATE TABLE `k_group` (
  `groupId` varchar(255) NOT NULL,
  `groupName` varchar(255) NOT NULL,
  `photoUrl` varchar(255) DEFAULT NULL,
  `desc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`groupId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of k_group
-- ----------------------------
INSERT INTO `k_group` VALUES ('a', '小班交流群', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypexiaoyuan.jpg', '小班滴进来');
INSERT INTO `k_group` VALUES ('b', '统一幼儿园校群', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypexiaoyuan.jpg', '校群');
INSERT INTO `k_group` VALUES ('c', '中班交流群', 'http://7xinjs.com1.z0.glb.clouddn.com/bbstypexiaoyuan.jpg', '中班滴进来');

-- ----------------------------
-- Table structure for parent
-- ----------------------------
DROP TABLE IF EXISTS `parent`;
CREATE TABLE `parent` (
  `parentId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `note` varchar(20) DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `birthday` date DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `telephone` varchar(30) NOT NULL,
  `photoUrl` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `activation` int(11) NOT NULL,
  `token` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`parentId`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of parent
-- ----------------------------
INSERT INTO `parent` VALUES ('1', '张大山', null, '0', '28', '2015-05-18', '珞瑜路广埠屯华师对面', '13300000000', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man1.jpg', 'B75005AA8388D5F08735BC1DE789ECE1', '0', 'O4pE+CKb7pQnSmq9lcYSEqaNpMYvuhjheujpINLfy/KRo3rtufpiQfNhEOoPnqva2UlGVnanQmQlL12mdWES9qNyMV/KQK31');
INSERT INTO `parent` VALUES ('2', '李倩倩', null, null, null, '2015-07-17', '明明哦哦', '13311111111', 'http://7xinjs.com1.z0.glb.clouddn.com/674e8dd924d14e5295e6ce587b776149', 'E062F5400DC7A2592C03C1900D64F011', '1', 'gamcxJuoEAiLKRctqwjcF87MZGLNPoTPrjoYHfuMbZPTo0+HQEDMSrxYTYHes19jCmPZUOoF54JkiasoKu01bJCTU9brdE/P');
INSERT INTO `parent` VALUES ('3', '赵无极', null, null, null, '2015-07-27', '哈哈哈', '13322222222', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man2.jpg', '6A739D16295F86A8080269D45F42CB8D', '1', 'T3AO+apXA0WS+qd3DZbugxE/0tp9CXhE7CvjV/Yx5QFyvkiY4Q2MhfEvytgitDCuNIuDb4hx56YjE0JhXAzRG3AUZuYnk3LG');
INSERT INTO `parent` VALUES ('4', '李忘生', null, '0', '27', '1988-06-09', null, '13333333333', 'http://7xinjs.com1.z0.glb.clouddn.com/12f6a3effc594ef6acc82df15f8f22e4', 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('5', '王自建', null, '0', '30', '1985-11-28', null, '13344444444', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man3.jpg', 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('6', '李复', null, '0', '31', '1984-11-30', null, '13355555555', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man4.jpg', 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('7', '赵敏', null, '1', '29', '1986-08-21', null, '13366666666', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man1.jpg', 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('8', '赵高', null, '0', '30', '1985-06-18', null, '13377777777', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man2.jpg', 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('9', '张良', null, '0', '29', '1984-06-06', null, '13388888888', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man3.jpg', 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('10', '程咬金', null, '0', '30', '1985-08-23', null, '13399999999', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man4.jpg', 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('11', '任我行', null, '0', '30', '1985-08-18', null, '13400000000', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('12', '令狐伤', null, '0', '31', '1984-08-24', null, '13411111111', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('13', '段正淳', null, '0', '29', '1986-07-08', null, '13422222222', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('14', '张翠山', null, '0', '28', '1987-06-20', null, '13433333333', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('15', '叶二娘', null, '1', '27', '1988-09-15', null, '13444444444', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('16', '秦红棉', null, '1', '30', '1980-02-14', null, '13455555555	', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('17', '黄药师', null, '0', '31', '1984-03-22', null, '13466666666', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('18', '郭啸天', null, '0', '32', '1983-11-23', null, '13477777777', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('19', '卫斯理', null, '0', '30', '1985-08-16', null, '13488888888', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('20', '叶蒙', null, '0', '29', '1986-05-15', null, '13499999999', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('21', '唐简', null, '0', '30', '1985-08-25', null, '13500000000', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('22', '叶子轩', null, '0', '28', '1987-03-18', null, '13511111111', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('23', '曹操', null, '0', '30', '1985-03-27', null, '13522222222', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('24', '赵涵雅', null, '1', '28', '1987-09-20', null, '13533333333', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('25', '李白', null, '0', '29', '1986-07-24', null, '13544444444', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('26', '谷之岚', null, '1', '28', '1987-10-14', null, '13555555555', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('27', '叶名威', null, '0', '30', '1985-08-14', null, '13566666666', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('28', '卓婉清', null, '1', '26', '1989-08-19', null, '13577777777', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('29', '叶松贤', null, '0', '32', '1983-03-30', null, '13588888888', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('30', '何邪', null, '1', '29', '1986-12-26', null, '13599999999', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);
INSERT INTO `parent` VALUES ('31', '叶无道', null, '0', '30', '1985-05-07', null, '13600000000', null, 'B75005AA8388D5F08735BC1DE789ECE1', '1', null);

-- ----------------------------
-- Table structure for teacher
-- ----------------------------
DROP TABLE IF EXISTS `teacher`;
CREATE TABLE `teacher` (
  `teacherId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `gender` int(11) NOT NULL,
  `age` int(11) NOT NULL,
  `birthday` date DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `telephone` varchar(30) NOT NULL,
  `photoUrl` varchar(255) DEFAULT NULL,
  `des` varchar(255) DEFAULT NULL,
  `password` varchar(255) NOT NULL,
  `courseId` int(11) NOT NULL,
  `role` int(11) NOT NULL,
  `token` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`teacherId`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of teacher
-- ----------------------------
INSERT INTO `teacher` VALUES ('1', '张红', '1', '32', '1983-06-28', '武汉市汉阳区建设路4号', '13211111111', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_women1.jpg', '1班班主任', 'B75005AA8388D5F08735BC1DE789ECE1', '1', '0', 'JWkzX6Iwr+rLp+vTk8I+T87MZGLNPoTPrjoYHfuMbZOuPvw+vwB2MUO9Wvz1XAfKJbBDq3ktY6JkiasoKu01bJCTU9brdE/P');
INSERT INTO `teacher` VALUES ('2', '张明', '0', '29', '1986-12-24', '武汉市武昌区南湖大道20号', '13222222222', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man4.jpg', '1班2班英语老师', 'B75005AA8388D5F08735BC1DE789ECE1', '3', '1', 'inxj1S43qlBi5GktiWPkvc7MZGLNPoTPrjoYHfuMbZPTo0+HQEDMSmJsFcniMy5mhmbK2ARoOzOzLQIz08Vhj8WUwFYtkIC9');
INSERT INTO `teacher` VALUES ('3', '张艳', '1', '35', '1980-05-09', '武汉市洪山区洪山大道120号', '13233333333', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_women4.jpg', '2班班主任', 'B75005AA8388D5F08735BC1DE789ECE1', '2', '0', null);
INSERT INTO `teacher` VALUES ('4', '李伟', '0', '30', '1985-08-01', '武汉市武昌区珞喻路56号', '13244444444', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man4.jpg', '3班班主任', 'B75005AA8388D5F08735BC1DE789ECE1', '3', '0', 'w9ZXKCTPn7Za461CbO+xvM7MZGLNPoTPrjoYHfuMbZPTo0+HQEDMSu7BNJLiClzCcxbu94C9yVVIXLVoR8VXB0W9rhJxKm4k');
INSERT INTO `teacher` VALUES ('5', '李艳', '1', '25', '1990-06-20', '武汉市武昌区南湖大道46号', '13255555555', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_women2.jpg', '美术老师', 'B75005AA8388D5F08735BC1DE789ECE1', '4', '1', null);
INSERT INTO `teacher` VALUES ('6', '赵明', '0', '31', '1984-01-18', '武汉市武昌区广八路12号', '13266666666', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man2.jpg', '2班3班语文老师', 'B75005AA8388D5F08735BC1DE789ECE1', '1', '1', null);
INSERT INTO `teacher` VALUES ('7', '赵红', '1', '27', '1988-04-14', '武汉市武昌区八一路9号', '13277777777', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_women3.jpg', '礼仪老师', 'B75005AA8388D5F08735BC1DE789ECE1', '5', '1', null);
INSERT INTO `teacher` VALUES ('8', '赵伟', '0', '24', '1991-11-21', '武汉市武昌区武珞路129号', '13288888888', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man3.jpg', '1班3班数学老师', 'B75005AA8388D5F08735BC1DE789ECE1', '2', '1', null);
INSERT INTO `teacher` VALUES ('9', '赵艳', '1', '26', '1989-09-05', '武汉市汉阳区建设路56号', '13299999999', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_women4.jpg', '保健老师', 'B75005AA8388D5F08735BC1DE789ECE1', '8', '1', null);
INSERT INTO `teacher` VALUES ('10', '赵军', '0', '34', '1981-09-18', '武汉市青山区仁和路25号', '13200000000', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man2.jpg', '体育老师', 'B75005AA8388D5F08735BC1DE789ECE1', '6', '1', null);
INSERT INTO `teacher` VALUES ('11', '张伟', '0', '28', '1987-11-25', '武汉市武昌区武珞路88号', '13210101010', 'http://7xinjs.com1.z0.glb.clouddn.com/avatar_man3.jpg', '艺术老师', 'B75005AA8388D5F08735BC1DE789ECE1', '7', '1', null);

-- ----------------------------
-- Table structure for teacher_grade_relation
-- ----------------------------
DROP TABLE IF EXISTS `teacher_grade_relation`;
CREATE TABLE `teacher_grade_relation` (
  `relationId` int(11) NOT NULL AUTO_INCREMENT,
  `teacherId` int(11) NOT NULL,
  `gradeId` int(11) NOT NULL,
  `isHead` int(11) NOT NULL,
  PRIMARY KEY (`relationId`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of teacher_grade_relation
-- ----------------------------
INSERT INTO `teacher_grade_relation` VALUES ('1', '1', '1', '0');
INSERT INTO `teacher_grade_relation` VALUES ('2', '2', '1', '1');
INSERT INTO `teacher_grade_relation` VALUES ('3', '2', '2', '1');
INSERT INTO `teacher_grade_relation` VALUES ('4', '3', '2', '0');
INSERT INTO `teacher_grade_relation` VALUES ('5', '4', '3', '0');
INSERT INTO `teacher_grade_relation` VALUES ('6', '5', '1', '1');
INSERT INTO `teacher_grade_relation` VALUES ('7', '5', '2', '1');
INSERT INTO `teacher_grade_relation` VALUES ('8', '5', '3', '1');
INSERT INTO `teacher_grade_relation` VALUES ('9', '6', '2', '1');
INSERT INTO `teacher_grade_relation` VALUES ('10', '6', '3', '1');
INSERT INTO `teacher_grade_relation` VALUES ('11', '7', '1', '1');
INSERT INTO `teacher_grade_relation` VALUES ('12', '7', '2', '1');
INSERT INTO `teacher_grade_relation` VALUES ('13', '7', '3', '1');
INSERT INTO `teacher_grade_relation` VALUES ('14', '8', '1', '1');
INSERT INTO `teacher_grade_relation` VALUES ('15', '8', '3', '1');
INSERT INTO `teacher_grade_relation` VALUES ('16', '9', '1', '1');
INSERT INTO `teacher_grade_relation` VALUES ('17', '9', '2', '1');
INSERT INTO `teacher_grade_relation` VALUES ('18', '9', '3', '1');
INSERT INTO `teacher_grade_relation` VALUES ('19', '10', '1', '1');
INSERT INTO `teacher_grade_relation` VALUES ('20', '10', '2', '1');
INSERT INTO `teacher_grade_relation` VALUES ('21', '10', '3', '1');
INSERT INTO `teacher_grade_relation` VALUES ('22', '11', '1', '1');
INSERT INTO `teacher_grade_relation` VALUES ('23', '11', '2', '1');
INSERT INTO `teacher_grade_relation` VALUES ('24', '11', '3', '1');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `mark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', '张三', '123', '测试');
INSERT INTO `user` VALUES ('2', null, '34', null);
INSERT INTO `user` VALUES ('3', '小燕', '43', '游客');
INSERT INTO `user` VALUES ('4', 'tt', '21', 'rr');
INSERT INTO `user` VALUES ('5', '小oo', '421', '测试');
INSERT INTO `user` VALUES ('6', null, '8039A51EBC0514DFF9E3006518C63E76BC1A9297276BC41D79C1AD56', null);
INSERT INTO `user` VALUES ('7', '123', '123', '测试');
INSERT INTO `user` VALUES ('10', '1232534', '4', 'æµè¯');
INSERT INTO `user` VALUES ('11', '格式', '', '测试1');
INSERT INTO `user` VALUES ('12', null, '', null);
