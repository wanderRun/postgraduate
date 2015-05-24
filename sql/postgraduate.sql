-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 2015-05-19 11:06:56
-- 服务器版本： 5.6.20
-- PHP Version: 5.5.15

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

CREATE TABLE IF NOT EXISTS `student_information` (
`id` int(11) NOT NULL,
  `apply_place` varchar(32) NOT NULL DEFAULT '',
  `aplly_number` varchar(32) NOT NULL DEFAULT '',
  `name` varchar(32) NOT NULL DEFAULT '',
  `name_spell` varchar(32) NOT NULL DEFAULT '',
  `number` varchar(32) NOT NULL DEFAULT '',
  `card_type` varchar(32) NOT NULL DEFAULT '',
  `card_number` varchar(32) NOT NULL DEFAULT '',
  `birth` varchar(32) NOT NULL DEFAULT '',
  `nation` varchar(32) NOT NULL DEFAULT '',
  `gender` varchar(32) NOT NULL DEFAULT '',
  `marriage` varchar(32) NOT NULL DEFAULT '',
  `soldier` varchar(32) NOT NULL DEFAULT '',
  `politics_status` varchar(32) NOT NULL DEFAULT '',
  `native_place` varchar(32) NOT NULL DEFAULT '',
  `birth_place` varchar(32) NOT NULL DEFAULT '',
  `register_place` varchar(32) NOT NULL DEFAULT '',
  `register_address` varchar(32) NOT NULL DEFAULT '',
  `record_place` varchar(32) NOT NULL DEFAULT '',
  `record_ministry` varchar(32) NOT NULL DEFAULT '',
  `record_address` varchar(32) NOT NULL DEFAULT '',
  `record_place_postcode` varchar(32) NOT NULL DEFAULT '',
  `work_place` varchar(32) NOT NULL DEFAULT '',
  `work_experience` varchar(32) NOT NULL DEFAULT '',
  `reward_punishment` varchar(32) NOT NULL DEFAULT '',
  `family` varchar(32) NOT NULL DEFAULT '',
  `contact_address` varchar(32) NOT NULL DEFAULT '',
  `contact_postcode` varchar(32) NOT NULL DEFAULT '',
  `fixed_line_phone` varchar(32) NOT NULL DEFAULT '',
  `mobile_phone` varchar(32) NOT NULL DEFAULT '',
  `email` varchar(32) NOT NULL DEFAULT '',
  `source` varchar(32) NOT NULL DEFAULT '',
  `same_education` varchar(32) NOT NULL DEFAULT '',
  `school_code` varchar(32) NOT NULL DEFAULT '',
  `school_name` varchar(32) NOT NULL DEFAULT '',
  `major_name` varchar(32) NOT NULL DEFAULT '',
  `study_type` varchar(32) NOT NULL DEFAULT '',
  `last_education` varchar(32) NOT NULL DEFAULT '',
  `diploma_number` varchar(32) NOT NULL DEFAULT '',
  `graduate_date` varchar(32) NOT NULL DEFAULT '',
  `register_number` varchar(32) NOT NULL DEFAULT '',
  `last_degree` varchar(32) NOT NULL DEFAULT '',
  `graduate_number` varchar(32) NOT NULL DEFAULT '',
  `adjust_major_code` varchar(32) NOT NULL DEFAULT '',
  `adjust_major_name` varchar(32) NOT NULL DEFAULT '',
  `apply_place_code` varchar(32) NOT NULL DEFAULT '',
  `apply_faculty` varchar(32) NOT NULL DEFAULT '',
  `apply_faculty_name` varchar(32) NOT NULL DEFAULT '',
  `apply_major_code` varchar(32) NOT NULL DEFAULT '',
  `apply_major_name` varchar(32) NOT NULL DEFAULT '',
  `apply_work_direction` varchar(32) NOT NULL DEFAULT '',
  `apply_work_direction_name` varchar(32) NOT NULL DEFAULT '',
  `exam_type` varchar(32) NOT NULL DEFAULT '',
  `special_plan` varchar(32) NOT NULL DEFAULT '',
  `apply_type` varchar(32) NOT NULL DEFAULT '',
  `orientation_train_place_code` varchar(32) NOT NULL DEFAULT '',
  `orientation_train_place` varchar(32) NOT NULL DEFAULT '',
  `standby_information` varchar(32) NOT NULL DEFAULT '',
  `standby_information_one` varchar(32) NOT NULL DEFAULT '',
  `standby_information_two` varchar(32) NOT NULL DEFAULT '',
  `standby_information_three` varchar(32) NOT NULL DEFAULT '',
  `political_code` varchar(32) NOT NULL DEFAULT '',
  `political_name` varchar(32) NOT NULL DEFAULT '',
  `foreign_code` varchar(32) NOT NULL DEFAULT '',
  `foreign_name` varchar(32) NOT NULL DEFAULT '',
  `business_one_code` varchar(32) NOT NULL DEFAULT '',
  `business_one_name` varchar(32) NOT NULL DEFAULT '',
  `business_two_code` varchar(32) NOT NULL DEFAULT '',
  `business_two_name` varchar(32) NOT NULL DEFAULT '',
  `political_score` int(11) NOT NULL DEFAULT '0',
  `foreign_score` int(11) NOT NULL DEFAULT '0',
  `business_one_score` int(11) NOT NULL DEFAULT '0',
  `business_two_score` int(11) NOT NULL DEFAULT '0',
  `total_score` int(11) NOT NULL DEFAULT '0',
  `volunteer_type` varchar(32) NOT NULL DEFAULT '',
  `tutor` varchar(32) NOT NULL DEFAULT '',
  `student_confirm_status` varchar(32) NOT NULL DEFAULT '',
  `student_confirm_time` varchar(32) NOT NULL DEFAULT '',
  `student_reexamine` varchar(32) NOT NULL DEFAULT '',
  `teacher_id` varchar(32) NOT NULL DEFAULT '',
  `teacher_name` varchar(32) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- 表的结构 `teacher_information`
--

CREATE TABLE IF NOT EXISTS `teacher_information` (
`id` int(11) NOT NULL,
  `teacher_id` varchar(16) NOT NULL DEFAULT '',
  `teacher_name` varchar(32) NOT NULL DEFAULT '',
  `teacher_password` varchar(32) NOT NULL DEFAULT ''
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `teacher_information`
--

INSERT INTO `teacher_information` (`id`, `teacher_id`, `teacher_name`, `teacher_password`) VALUES
(1, '1', '斌', 'dhu@123'),
(2, '2', '王', 'dhu@123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `student_information`
--
ALTER TABLE `student_information`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `teacher_information`
--
ALTER TABLE `teacher_information`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `student_information`
--
ALTER TABLE `student_information`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `teacher_information`
--
ALTER TABLE `teacher_information`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
