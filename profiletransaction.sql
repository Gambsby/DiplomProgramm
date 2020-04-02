SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;


CREATE TABLE `answer` (
  `id` int(11) NOT NULL,
  `Content` varchar(128) NOT NULL,
  `profile_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `limits` (
  `id` int(11) NOT NULL,
  `start` text NOT NULL,
  `end` text NOT NULL,
  `profile_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `main_profile` (
  `id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `profile` (
  `id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL,
  `main_profile_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `question` (
  `id` int(11) NOT NULL,
  `content` text NOT NULL,
  `serial_number` int(11) NOT NULL,
  `profile_id` int(11) NOT NULL,
  `type_id` int(11) NOT NULL,
  `limits_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `questioned` (
  `id` int(11) NOT NULL,
  `number` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `questiontype` (
  `id` int(11) NOT NULL,
  `type` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `question_answer` (
  `id` int(11) NOT NULL,
  `question_id` int(11) NOT NULL,
  `answer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `result` (
  `id` int(11) NOT NULL,
  `questioned_id` int(11) NOT NULL,
  `question_answer_id` int(11) NOT NULL,
  `profile_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


ALTER TABLE `answer`
  ADD PRIMARY KEY (`id`),
  ADD KEY `profile_id` (`profile_id`);

ALTER TABLE `limits`
  ADD PRIMARY KEY (`id`),
  ADD KEY `profile_id` (`profile_id`);

ALTER TABLE `main_profile`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

ALTER TABLE `profile`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`),
  ADD KEY `main_profile_id` (`main_profile_id`);

ALTER TABLE `question`
  ADD PRIMARY KEY (`id`),
  ADD KEY `type_id` (`type_id`),
  ADD KEY `question_ibfk_1` (`profile_id`),
  ADD KEY `question_ibfk_3` (`limits_id`);

ALTER TABLE `questioned`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `number` (`number`);

ALTER TABLE `questiontype`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `type` (`type`);

ALTER TABLE `question_answer`
  ADD PRIMARY KEY (`id`),
  ADD KEY `answer_id` (`answer_id`),
  ADD KEY `question_answer_ibfk_2` (`question_id`);

ALTER TABLE `result`
  ADD PRIMARY KEY (`id`),
  ADD KEY `result_ibfk_2` (`question_answer_id`),
  ADD KEY `profile_id` (`profile_id`),
  ADD KEY `questioned_id` (`questioned_id`);


ALTER TABLE `answer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `limits`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `main_profile`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `profile`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `question`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `questioned`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `questiontype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `question_answer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `result`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;


ALTER TABLE `answer`
  ADD CONSTRAINT `answer_ibfk_1` FOREIGN KEY (`profile_id`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE `limits`
  ADD CONSTRAINT `limits_ibfk_1` FOREIGN KEY (`profile_id`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE `profile`
  ADD CONSTRAINT `profile_ibfk_1` FOREIGN KEY (`main_profile_id`) REFERENCES `main_profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE `question`
  ADD CONSTRAINT `question_ibfk_1` FOREIGN KEY (`profile_id`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `question_ibfk_2` FOREIGN KEY (`type_id`) REFERENCES `questiontype` (`id`),
  ADD CONSTRAINT `question_ibfk_3` FOREIGN KEY (`limits_id`) REFERENCES `limits` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE `question_answer`
  ADD CONSTRAINT `question_answer_ibfk_1` FOREIGN KEY (`answer_id`) REFERENCES `answer` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `question_answer_ibfk_2` FOREIGN KEY (`question_id`) REFERENCES `question` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE `result`
  ADD CONSTRAINT `result_ibfk_2` FOREIGN KEY (`question_answer_id`) REFERENCES `question_answer` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `result_ibfk_3` FOREIGN KEY (`profile_id`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `result_ibfk_4` FOREIGN KEY (`questioned_id`) REFERENCES `questioned` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
