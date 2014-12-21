-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 19, 2014 at 05:21 PM
-- Server version: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `istanbul`
--

-- --------------------------------------------------------

--
-- Table structure for table `answers`
--

CREATE TABLE IF NOT EXISTS `answers` (
`id` int(5) NOT NULL,
  `content` text NOT NULL,
  `topic_id` int(5) NOT NULL,
  `date_created` datetime NOT NULL,
  `user_id` int(5) NOT NULL,
  `username` varchar(255) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=159 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `answers`
--

INSERT INTO `answers` (`id`, `content`, `topic_id`, `date_created`, `user_id`, `username`) VALUES
(1, '123123', 1, '2014-12-18 00:25:09', 12, 'admin'),
(2, 'nikolaasdasdasd', 1, '2014-12-18 00:25:37', 12, 'test'),
(3, 'Това е вторият отговор по темата!', 1, '2014-12-18 00:32:19', 12, 'test'),
(4, 'Нова проба', 1, '2014-12-18 00:43:41', 12, 'test'),
(5, 'Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.', 1, '2014-12-18 00:50:09', 12, 'test'),
(6, 'Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.', 3, '2014-12-18 00:51:39', 12, 'test'),
(7, 'Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.', 3, '2014-12-18 00:51:44', 12, 'test'),
(8, 'Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.', 3, '2014-12-18 00:52:03', 12, 'test'),
(9, 'asdasdasd', 1, '2014-12-18 01:09:21', 12, 'test'),
(10, '<script>alert(''proba'')</script>', 1, '2014-12-18 01:45:31', 20, 'test20'),
(11, 'Some проба', 1, '2014-12-18 10:16:44', 12, 'admin'),
(12, 'asd', 1, '2014-12-18 11:15:28', 12, 'admin'),
(13, 'asd', 1, '2014-12-18 11:15:33', 12, 'admin'),
(14, '21asdasdasd', 1, '2014-12-18 11:16:14', 12, 'admin'),
(15, 'Нова проба\r\n', 1, '2014-12-18 11:17:56', 12, 'admin'),
(16, 'aszxzczxc', 1, '2014-12-18 11:18:01', 12, 'admin'),
(17, 'asdasd', 1, '2014-12-18 11:22:02', 12, 'admin'),
(18, 'asdzxc', 1, '2014-12-18 11:22:06', 12, 'admin'),
(19, 'zxasdasdasd', 1, '2014-12-18 11:22:11', 12, 'admin'),
(20, 'zxcasdasdsad', 1, '2014-12-18 11:22:16', 12, 'admin'),
(21, '123', 14, '2014-12-18 19:57:42', 12, 'admin'),
(22, '1', 14, '2014-12-18 19:57:48', 12, 'admin'),
(23, '1', 14, '2014-12-18 19:57:53', 12, 'admin'),
(24, '1', 14, '2014-12-18 19:57:58', 12, 'admin'),
(25, '1', 14, '2014-12-18 19:58:03', 12, 'admin'),
(26, '6', 14, '2014-12-18 19:58:08', 12, 'admin'),
(27, '7', 14, '2014-12-18 21:06:48', 12, 'admin'),
(28, '123123', 1, '2014-12-19 00:01:14', 12, 'admin'),
(29, '123123', 1, '2014-12-19 00:01:18', 12, 'admin'),
(30, '213213', 1, '2014-12-19 00:01:23', 12, 'admin'),
(31, '21323', 1, '2014-12-19 00:01:28', 12, 'admin'),
(32, '213123', 1, '2014-12-19 00:01:33', 12, 'admin'),
(33, '213', 1, '2014-12-19 00:07:16', 12, 'admin'),
(34, '213123', 1, '2014-12-19 00:07:22', 12, 'admin'),
(35, 'sad', 1, '2014-12-19 00:07:29', 12, 'admin'),
(36, 'asd', 1, '2014-12-19 00:07:44', 12, 'admin'),
(37, 'asd', 1, '2014-12-19 00:07:48', 12, 'admin'),
(38, 'asdasd', 1, '2014-12-19 00:07:52', 12, 'admin'),
(39, 'asdasd', 1, '2014-12-19 00:07:56', 12, 'admin'),
(40, 'asasd', 1, '2014-12-19 00:08:03', 12, 'admin'),
(41, '213', 1, '2014-12-19 00:09:05', 12, 'admin'),
(42, '1', 4, '2014-12-19 00:28:52', 12, 'admin'),
(43, '2', 4, '2014-12-19 00:28:56', 12, 'admin'),
(44, '3', 4, '2014-12-19 00:29:00', 12, 'admin'),
(45, '4', 4, '2014-12-19 00:29:04', 12, 'admin'),
(46, '5', 4, '2014-12-19 00:31:03', 12, 'admin'),
(47, '6', 4, '2014-12-19 00:31:09', 12, 'admin'),
(48, '7', 4, '2014-12-19 00:31:17', 12, 'admin'),
(49, '1', 1, '2014-12-19 13:35:24', 12, 'admin'),
(50, '2', 1, '2014-12-19 13:35:28', 12, 'admin'),
(51, '3', 1, '2014-12-19 13:35:33', 12, 'admin'),
(52, '3', 1, '2014-12-19 13:35:33', 12, 'admin'),
(53, '3', 1, '2014-12-19 13:35:33', 12, 'admin'),
(54, '3', 1, '2014-12-19 13:35:33', 12, 'admin'),
(55, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(56, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(57, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(58, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(59, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(60, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(61, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(62, '3', 1, '2014-12-19 13:35:34', 12, 'admin'),
(63, '333', 1, '2014-12-19 13:35:49', 12, 'admin'),
(64, '333', 1, '2014-12-19 13:35:49', 12, 'admin'),
(65, '333', 1, '2014-12-19 13:35:50', 12, 'admin'),
(66, '333', 1, '2014-12-19 13:35:51', 12, 'admin'),
(67, '333', 1, '2014-12-19 13:35:51', 12, 'admin'),
(68, '333', 1, '2014-12-19 13:35:51', 12, 'admin'),
(69, '333', 1, '2014-12-19 13:35:51', 12, 'admin'),
(70, '333', 1, '2014-12-19 13:35:51', 12, 'admin'),
(71, '333', 1, '2014-12-19 13:35:52', 12, 'admin'),
(72, '333', 1, '2014-12-19 13:35:52', 12, 'admin'),
(73, '333', 1, '2014-12-19 13:35:52', 12, 'admin'),
(74, '333', 1, '2014-12-19 13:35:52', 12, 'admin'),
(75, '333', 1, '2014-12-19 13:35:52', 12, 'admin'),
(76, '333', 1, '2014-12-19 13:35:52', 12, 'admin'),
(77, '333', 1, '2014-12-19 13:35:53', 12, 'admin'),
(78, '333', 1, '2014-12-19 13:35:53', 12, 'admin'),
(79, '333', 1, '2014-12-19 13:35:53', 12, 'admin'),
(80, '333', 1, '2014-12-19 13:35:53', 12, 'admin'),
(81, '333', 1, '2014-12-19 13:35:53', 12, 'admin'),
(82, '333', 1, '2014-12-19 13:35:53', 12, 'admin'),
(83, '23', 1, '2014-12-19 13:36:15', 12, 'admin'),
(84, '23', 1, '2014-12-19 13:36:15', 12, 'admin'),
(85, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(86, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(87, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(88, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(89, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(90, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(91, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(92, '23', 1, '2014-12-19 13:36:16', 12, 'admin'),
(93, '23', 1, '2014-12-19 13:36:17', 12, 'admin'),
(94, '23', 1, '2014-12-19 13:36:17', 12, 'admin'),
(95, '23', 1, '2014-12-19 13:36:17', 12, 'admin'),
(96, '23', 1, '2014-12-19 13:36:17', 12, 'admin'),
(97, '23', 1, '2014-12-19 13:36:17', 12, 'admin'),
(98, '23', 1, '2014-12-19 13:36:17', 12, 'admin'),
(99, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(100, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(101, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(102, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(103, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(104, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(105, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(106, '23', 1, '2014-12-19 13:36:18', 12, 'admin'),
(107, '23', 1, '2014-12-19 13:36:19', 12, 'admin'),
(108, '23', 1, '2014-12-19 13:36:19', 12, 'admin'),
(109, '23', 1, '2014-12-19 13:36:19', 12, 'admin'),
(110, '23', 1, '2014-12-19 13:36:19', 12, 'admin'),
(111, '123123', 1, '2014-12-19 13:36:29', 12, 'admin'),
(112, '123123', 1, '2014-12-19 13:36:29', 12, 'admin'),
(113, '123123', 1, '2014-12-19 13:36:29', 12, 'admin'),
(114, '123123', 1, '2014-12-19 13:36:30', 12, 'admin'),
(115, '123123', 1, '2014-12-19 13:36:30', 12, 'admin'),
(116, '123123', 1, '2014-12-19 13:36:30', 12, 'admin'),
(117, '123123', 1, '2014-12-19 13:36:30', 12, 'admin'),
(118, '123123', 1, '2014-12-19 13:36:30', 12, 'admin'),
(119, '123123', 1, '2014-12-19 13:36:31', 12, 'admin'),
(120, '123123', 1, '2014-12-19 13:36:31', 12, 'admin'),
(121, '123123', 1, '2014-12-19 13:36:31', 12, 'admin'),
(122, '123123', 1, '2014-12-19 13:36:32', 12, 'admin'),
(123, '123123', 1, '2014-12-19 13:36:32', 12, 'admin'),
(124, '123123', 1, '2014-12-19 13:36:32', 12, 'admin'),
(125, '123123', 1, '2014-12-19 13:36:32', 12, 'admin'),
(126, '123123', 1, '2014-12-19 13:36:32', 12, 'admin'),
(127, '123123', 1, '2014-12-19 13:36:32', 12, 'admin'),
(128, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(129, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(130, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(131, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(132, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(133, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(134, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(135, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(136, '123123', 1, '2014-12-19 13:36:33', 12, 'admin'),
(137, '123123', 1, '2014-12-19 13:36:34', 12, 'admin'),
(138, '123123', 1, '2014-12-19 13:36:34', 12, 'admin'),
(139, '123123', 1, '2014-12-19 13:36:34', 12, 'admin'),
(140, '123123', 1, '2014-12-19 13:36:34', 12, 'admin'),
(141, '123123', 1, '2014-12-19 13:36:34', 12, 'admin'),
(142, '123123', 1, '2014-12-19 13:36:34', 12, 'admin'),
(143, 'asd', 1, '2014-12-19 13:37:54', 12, 'admin'),
(144, 'asd', 1, '2014-12-19 13:37:55', 12, 'admin'),
(145, 'asd', 1, '2014-12-19 13:37:56', 12, 'admin'),
(146, 'asdasd', 1, '2014-12-19 13:38:10', 12, 'admin'),
(147, 'asd', 1, '2014-12-19 13:39:19', 12, 'admin'),
(148, 'asd', 1, '2014-12-19 13:39:21', 12, 'admin'),
(149, '2323', 1, '2014-12-19 13:40:37', 12, 'admin'),
(150, '2323', 1, '2014-12-19 13:40:38', 12, 'admin'),
(151, 'aa', 1, '2014-12-19 13:40:47', 12, 'admin'),
(152, 'aa', 1, '2014-12-19 13:40:48', 12, 'admin'),
(153, 'asdasd', 1, '2014-12-19 13:42:32', 12, 'admin'),
(154, '', 1, '2014-12-19 14:00:55', 12, 'admin'),
(155, 't', 1, '2014-12-19 14:06:23', 12, 'admin'),
(156, 't', 1, '2014-12-19 14:07:30', 12, 'admin'),
(157, 'asas', 1, '2014-12-19 14:12:12', 12, 'admin'),
(158, '213', 1, '2014-12-19 14:17:17', 12, 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
`id` int(5) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`, `description`) VALUES
(1, 'Category 1', 'This is the description of category 1'),
(2, 'Category 2', 'This is the description of category 2');

-- --------------------------------------------------------

--
-- Table structure for table `topics`
--

CREATE TABLE IF NOT EXISTS `topics` (
`id` int(5) NOT NULL,
  `name` varchar(255) NOT NULL,
  `content` text NOT NULL,
  `category_id` int(5) NOT NULL,
  `views` int(11) NOT NULL DEFAULT '0',
  `user_id` int(5) NOT NULL,
  `username` varchar(255) NOT NULL,
  `date_created` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `topics`
--

INSERT INTO `topics` (`id`, `name`, `content`, `category_id`, `views`, `user_id`, `username`, `date_created`) VALUES
(1, 'Топик 1', 'This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1. This is the content of topic 1', 1, 1780, 12, 'admin', '2014-12-17 02:06:09'),
(3, 'Topic 2', 'This is the content of topic 2', 2, 110, 12, 'admin', '2014-12-01 12:08:09'),
(4, 'Topic 3', 'This is the content of topic 3', 2, 337, 13, 'test1', '2014-12-11 15:07:28'),
(14, 'asdasd', 'asdasd', 2, 320, 12, 'admin', '2014-12-18 13:06:05'),
(15, 'Май стана', 'охххх', 1, 63, 12, 'admin', '2014-12-18 13:06:48'),
(16, 'asd', 'asd', 1, 37, 12, 'admin', '2014-12-18 13:08:25'),
(17, 'Nikola', 'asdasd', 1, 26, 12, 'admin', '2014-12-18 13:12:06'),
(18, 'Proba', 'awd', 1, 44, 12, 'admin', '2014-12-18 19:06:47');

-- --------------------------------------------------------

--
-- Table structure for table `topic_tags`
--

CREATE TABLE IF NOT EXISTS `topic_tags` (
`id` int(5) NOT NULL,
  `topic_id` int(5) NOT NULL,
  `tag` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
`id` int(5) NOT NULL,
  `username` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `role_id` int(1) NOT NULL DEFAULT '3',
  `register_date` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `name`, `password`, `email`, `role_id`, `register_date`) VALUES
(12, 'admin', 'Administrator', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin@admin.bg', 1, '2014-12-17 00:00:21'),
(13, 'test1', 'Test 1', 'test1', 'a@abv.bg', 3, '2014-12-17 01:03:40'),
(16, 'test2', 'Nikola Nikolov', 'Nikola1*', 'asd@abv.bg', 3, '2014-12-17 11:35:25'),
(17, 'test3', 'test3', 'Nikola1*', 'asd@abv.bg', 3, '2014-12-17 11:36:16'),
(18, 'test13', 'test13', 'Nikola1*', 'a@abv.bgsa.bga', 3, '2014-12-17 21:17:25'),
(19, 'test14', 'test14', 'Nikola1*', 'n@gmail.com', 3, '2014-12-17 21:24:54'),
(20, 'test20', 'test20222', 'Nikola3*', 'na@gmail.com', 3, '2014-12-18 01:44:46'),
(22, 'niko', 'Nikola', '56e4c282aa5116225561bced84b26a9ddb4b0b7ad7f3e09601c2752d2259f4d3', 'nikola@gmail.com', 3, '2014-12-18 09:51:10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `answers`
--
ALTER TABLE `answers`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `topics`
--
ALTER TABLE `topics`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `topic_tags`
--
ALTER TABLE `topic_tags`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `answers`
--
ALTER TABLE `answers`
MODIFY `id` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=159;
--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
MODIFY `id` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `topics`
--
ALTER TABLE `topics`
MODIFY `id` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=19;
--
-- AUTO_INCREMENT for table `topic_tags`
--
ALTER TABLE `topic_tags`
MODIFY `id` int(5) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
MODIFY `id` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=23;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
