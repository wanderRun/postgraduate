-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 2015-04-24 21:27:30
-- 服务器版本： 5.6.24
-- PHP Version: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `postgraduate`
--

-- --------------------------------------------------------

--
-- 表的结构 `student_information`
--

DROP TABLE IF EXISTS `student_information`;
CREATE TABLE `student_information` (
  `apply_place` varchar(10) NOT NULL DEFAULT '',
  `aplly_number` varchar(20) NOT NULL DEFAULT '',
  `name` varchar(20) NOT NULL DEFAULT '',
  `name_spell` varchar(120) NOT NULL DEFAULT '',
  `number` varchar(30) NOT NULL DEFAULT '',
  `card_type` varchar(20) NOT NULL DEFAULT '',
  `card_number` varchar(20) NOT NULL DEFAULT '',
  `birth` varchar(10) NOT NULL DEFAULT '',
  `nation` varchar(10) NOT NULL DEFAULT '',
  `gender` varchar(10) NOT NULL DEFAULT '',
  `marriage` varchar(10) NOT NULL DEFAULT '',
  `soldier` varchar(10) NOT NULL DEFAULT '',
  `politics_status` varchar(20) NOT NULL DEFAULT '',
  `native_place` varchar(10) NOT NULL DEFAULT '',
  `birth_place` varchar(10) NOT NULL DEFAULT '',
  `register_place` varchar(10) NOT NULL DEFAULT '',
  `register_address` varchar(100) NOT NULL DEFAULT '',
  `record_place` varchar(10) NOT NULL DEFAULT '',
  `record_ministry` varchar(100) NOT NULL DEFAULT '',
  `record_address` varchar(100) NOT NULL DEFAULT '',
  `record_place_postcode` varchar(10) NOT NULL DEFAULT '',
  `work_place` varchar(100) NOT NULL DEFAULT '',
  `work_experience` varchar(500) NOT NULL DEFAULT '',
  `reward_punishment` varchar(500) NOT NULL DEFAULT '',
  `family` varchar(300) NOT NULL DEFAULT '',
  `contact_address` varchar(100) NOT NULL DEFAULT '',
  `contact_postcode` varchar(10) NOT NULL DEFAULT '',
  `fixed_line_phone` varchar(20) NOT NULL DEFAULT '',
  `mobile_phone` varchar(20) NOT NULL DEFAULT '',
  `email` varchar(50) NOT NULL DEFAULT '',
  `source` varchar(20) NOT NULL DEFAULT '',
  `same_education` varchar(10) NOT NULL DEFAULT '',
  `school_code` varchar(10) NOT NULL DEFAULT '',
  `school_name` varchar(50) NOT NULL DEFAULT '',
  `major_name` varchar(50) NOT NULL DEFAULT '',
  `study_type` varchar(20) NOT NULL DEFAULT '',
  `last_education` varchar(20) NOT NULL DEFAULT '',
  `diploma_number` varchar(20) NOT NULL DEFAULT '',
  `graduate_date` varchar(10) NOT NULL DEFAULT '',
  `register_number` varchar(20) NOT NULL DEFAULT '',
  `last_degree` varchar(20) NOT NULL DEFAULT '',
  `graduate_number` varchar(20) NOT NULL DEFAULT '',
  `adjust_major_code` varchar(20) NOT NULL DEFAULT '',
  `adjust_major_name` varchar(20) NOT NULL DEFAULT '',
  `apply_place_code` varchar(10) NOT NULL DEFAULT '',
  `apply_faculty` varchar(10) NOT NULL DEFAULT '',
  `apply_faculty_name` varchar(50) NOT NULL DEFAULT '',
  `apply_major_code` varchar(10) NOT NULL DEFAULT '',
  `apply_major_name` varchar(50) NOT NULL DEFAULT '',
  `apply_work_direction` varchar(10) NOT NULL DEFAULT '',
  `apply_work_direction_name` varchar(20) NOT NULL DEFAULT '',
  `exam_type` varchar(20) NOT NULL DEFAULT '',
  `special_plan` varchar(20) NOT NULL DEFAULT '',
  `apply_type` varchar(20) NOT NULL DEFAULT '',
  `orientation_train_place_code` varchar(20) NOT NULL DEFAULT '',
  `orientation_train_place` varchar(100) NOT NULL DEFAULT '',
  `standby_information` varchar(500) NOT NULL DEFAULT '',
  `standby_information_one` varchar(500) NOT NULL DEFAULT '',
  `standby_information_two` varchar(500) NOT NULL DEFAULT '',
  `standby_information_three` varchar(500) NOT NULL DEFAULT '',
  `political_code` varchar(10) NOT NULL DEFAULT '',
  `political_name` varchar(20) NOT NULL DEFAULT '',
  `foreign_code` varchar(10) NOT NULL DEFAULT '',
  `foreign_name` varchar(20) NOT NULL DEFAULT '',
  `business_one_code` varchar(10) NOT NULL DEFAULT '',
  `business_one_name` varchar(20) NOT NULL DEFAULT '',
  `business_two_code` varchar(10) NOT NULL DEFAULT '',
  `business_two_name` varchar(50) NOT NULL DEFAULT '',
  `political_score` int(11) NOT NULL DEFAULT '0',
  `foreign_score` int(11) NOT NULL DEFAULT '0',
  `business_one_score` int(11) NOT NULL DEFAULT '0',
  `business_two_score` int(11) NOT NULL DEFAULT '0',
  `total_score` int(11) NOT NULL DEFAULT '0',
  `volunteer_type` varchar(20) NOT NULL DEFAULT '',
  `tutor` varchar(20) NOT NULL DEFAULT '',
  `student_confirm_status` varchar(20) NOT NULL DEFAULT '',
  `student_confirm_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `student_reexamine` varchar(200) NOT NULL DEFAULT '',
  `teacher_id` varchar(300) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- 表的结构 `teacher_information`
--

DROP TABLE IF EXISTS `teacher_information`;
CREATE TABLE `teacher_information` (
  `teacher_id` varchar(30) NOT NULL DEFAULT '',
  `teacher_name` varchar(30) NOT NULL DEFAULT '',
  `teacher_password` varchar(30) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `student_information`
--
ALTER TABLE `student_information`
  ADD PRIMARY KEY (`number`);

--
-- Indexes for table `teacher_information`
--
ALTER TABLE `teacher_information`
  ADD PRIMARY KEY (`teacher_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
