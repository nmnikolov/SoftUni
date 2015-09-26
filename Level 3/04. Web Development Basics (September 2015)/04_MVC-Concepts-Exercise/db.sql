DROP DATABASE IF EXISTS `application`;

-- Task 1
CREATE DATABASE `application` 
CHARACTER SET utf8 
COLLATE utf8_general_ci;

USE `application`;

CREATE TABLE `users` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    gold INT NOT NULL,
    food INT NOT NULL);
    
CREATE TABLE `buildings` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL UNIQUE);
        
CREATE TABLE `building_levels` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    building_id INT NOT NULL,
    `level` INT NOT NULL,
    gold INT NOT NULL,
    food INT NOT NULL,
    FOREIGN KEY (building_id) REFERENCES buildings(id),
    KEY (`level`));
    
CREATE TABLE `user_buildings` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    building_id INT NOT NULL,
    level_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (building_id) REFERENCES buildings(id),
    FOREIGN KEY (level_id) REFERENCES building_levels(`level`));
  
-- Task 2
insert into buildings (name) values 
    ('restaurant'),
    ('bank');
    
insert into building_levels (building_id, level, gold, food) values 
    (1, 0, 0, 0),
    (1, 1, 100, 50),
    (1, 2, 200, 100),
    (1, 3, 400, 200),
    (2, 0, 0, 0),
    (2, 1, 200, 100),
    (2, 2, 400, 200),
    (2, 3, 800, 400);
    
