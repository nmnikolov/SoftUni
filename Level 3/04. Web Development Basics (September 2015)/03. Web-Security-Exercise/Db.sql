DROP DATABASE IF EXISTS `translations`;

CREATE database `translations` 
CHARACTER SET utf8 
COLLATE utf8_general_ci;

USE `translations`;

CREATE TABLE `translations` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    tag VARCHAR(250) NOT NULL,
    text_en TEXT NOT NULL,
    text_bg TEXT NOT NULL
);

ALTER TABLE `translations` ADD INDEX `tag` (`tag`);

INSERT INTO `translations` (tag, text_en, text_bg) VALUES
	('greeting_header_hello', 'Hello', 'Здравейте'),
    ('welcome_message', 'Welcome to out site', 'Добре дошъл в нашия сайт');