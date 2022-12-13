-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 13 dec 2022 kl 09:38
-- Serverversion: 10.4.25-MariaDB
-- PHP-version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `repostök`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `bills`
--

CREATE TABLE `bills` (
  `id` int(11) NOT NULL,
  `tenant_id` int(11) NOT NULL,
  `room_id` int(11) NOT NULL,
  `landlord_id` int(11) NOT NULL,
  `bill_date` date NOT NULL,
  `payment_due_date` date NOT NULL,
  `ocr_number` varchar(64) NOT NULL,
  `price` int(11) NOT NULL,
  `paid_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellstruktur `issue_conversations`
--

CREATE TABLE `issue_conversations` (
  `id` int(11) NOT NULL,
  `tenant_id` int(11) NOT NULL,
  `title` varchar(32) NOT NULL,
  `is_archived` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `issue_conversations`
--

INSERT INTO `issue_conversations` (`id`, `tenant_id`, `title`, `is_archived`) VALUES
(1, 5, 'Trasig Lampa', 1),
(2, 1, 'Trasig Lampa', 0),
(3, 4, 'Vi vill ha en ölkyl!', 0);

-- --------------------------------------------------------

--
-- Tabellstruktur `landlords`
--

CREATE TABLE `landlords` (
  `id` int(11) NOT NULL,
  `full_name` varchar(64) NOT NULL,
  `login_name` varchar(64) NOT NULL,
  `password` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `landlords`
--

INSERT INTO `landlords` (`id`, `full_name`, `login_name`, `password`) VALUES
(1, 'Petrus Johansson', 'petflask', 'apa123');

-- --------------------------------------------------------

--
-- Tabellstruktur `messages`
--

CREATE TABLE `messages` (
  `id` int(11) NOT NULL,
  `conversation_id` int(11) NOT NULL,
  `tenant_id` int(11) DEFAULT NULL,
  `landlord_id` int(11) DEFAULT NULL,
  `message` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `messages`
--

INSERT INTO `messages` (`id`, `conversation_id`, `tenant_id`, `landlord_id`, `message`) VALUES
(1, 1, 5, NULL, 'Det finns en trasig lampa i lokal 1.\r\nNär kan ni lösa detta?'),
(2, 1, NULL, 1, 'Vi jobbar på det så snart vi kan.'),
(3, 1, 5, NULL, 'Tack!'),
(4, 2, 1, NULL, 'Vi har en trasig lampa i rum 3. Vi kan inte se något.'),
(5, 1, NULL, 1, 'Fixat!'),
(6, 2, NULL, 1, 'Igen? Fixar det inom veckan.'),
(7, 3, 4, NULL, 'Hej! Skulle ni kunna sätta in en ölkyl i vår replokal? De blir så varma annars.'),
(8, 3, NULL, 1, 'Absolut! Detta kommer kosta 4000kr. '),
(9, 3, 4, NULL, 'Gött. När kommer den?'),
(10, 3, NULL, 1, 'Jag har ångrat mig, jag behåller ölkylen till mig själv. tack och hej');

-- --------------------------------------------------------

--
-- Tabellstruktur `rooms`
--

CREATE TABLE `rooms` (
  `id` int(11) NOT NULL,
  `rent_per_month` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `rooms`
--

INSERT INTO `rooms` (`id`, `rent_per_month`) VALUES
(1, 1800),
(2, 2400),
(3, 2400),
(4, 1500),
(5, 2200),
(6, 1800);

-- --------------------------------------------------------

--
-- Tabellstruktur `rooms_to_tenants`
--

CREATE TABLE `rooms_to_tenants` (
  `tenant_id` int(11) NOT NULL,
  `room_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `rooms_to_tenants`
--

INSERT INTO `rooms_to_tenants` (`tenant_id`, `room_id`) VALUES
(1, 3),
(2, 3),
(3, 3),
(4, 3),
(5, 3),
(5, 1),
(2, 1),
(3, 4),
(1, 4);

-- --------------------------------------------------------

--
-- Tabellstruktur `tenants`
--

CREATE TABLE `tenants` (
  `id` int(11) NOT NULL,
  `full_name` varchar(64) NOT NULL,
  `email` varchar(64) NOT NULL,
  `adress` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `tenants`
--

INSERT INTO `tenants` (`id`, `full_name`, `email`, `adress`) VALUES
(1, 'Kimfan Krische', 'kimp@mail.com', 'Bösebrötgatan 7'),
(2, 'Kapten Magnusson', '240snusit@gmail.com', 'Bråkmakargatan 14'),
(3, 'Han Berit', 'bert@mail.com', 'Arpeggiogatan 15'),
(4, 'Skräene Gustafsson', 'gusf@mail.com', 'Hesevrölargatan 19'),
(5, 'Pestrus Jönsson', 'vissfiskurator@mail.com', 'Grönbogatan 5');

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `bills`
--
ALTER TABLE `bills`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_bills_tenant_id` (`tenant_id`),
  ADD KEY `fk_bills_room_id` (`room_id`),
  ADD KEY `fk_bills_landlord_id` (`landlord_id`);

--
-- Index för tabell `issue_conversations`
--
ALTER TABLE `issue_conversations`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_issue_conversations_tenant_id` (`tenant_id`);

--
-- Index för tabell `landlords`
--
ALTER TABLE `landlords`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_messages_conversation_id` (`conversation_id`);

--
-- Index för tabell `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Index för tabell `rooms_to_tenants`
--
ALTER TABLE `rooms_to_tenants`
  ADD KEY `fk_rooms_to_tenants_tenant_id` (`tenant_id`),
  ADD KEY `fk_rooms_to_tenants_room_id` (`room_id`);

--
-- Index för tabell `tenants`
--
ALTER TABLE `tenants`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `bills`
--
ALTER TABLE `bills`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT för tabell `issue_conversations`
--
ALTER TABLE `issue_conversations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT för tabell `landlords`
--
ALTER TABLE `landlords`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT för tabell `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT för tabell `rooms`
--
ALTER TABLE `rooms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT för tabell `tenants`
--
ALTER TABLE `tenants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restriktioner för dumpade tabeller
--

--
-- Restriktioner för tabell `bills`
--
ALTER TABLE `bills`
  ADD CONSTRAINT `fk_bills_landlord_id` FOREIGN KEY (`landlord_id`) REFERENCES `landlords` (`id`),
  ADD CONSTRAINT `fk_bills_room_id` FOREIGN KEY (`room_id`) REFERENCES `rooms` (`id`),
  ADD CONSTRAINT `fk_bills_tenant_id` FOREIGN KEY (`tenant_id`) REFERENCES `tenants` (`id`);

--
-- Restriktioner för tabell `issue_conversations`
--
ALTER TABLE `issue_conversations`
  ADD CONSTRAINT `fk_issue_conversations_tenant_id` FOREIGN KEY (`tenant_id`) REFERENCES `tenants` (`id`);

--
-- Restriktioner för tabell `messages`
--
ALTER TABLE `messages`
  ADD CONSTRAINT `fk_messages_conversation_id` FOREIGN KEY (`conversation_id`) REFERENCES `issue_conversations` (`id`);

--
-- Restriktioner för tabell `rooms_to_tenants`
--
ALTER TABLE `rooms_to_tenants`
  ADD CONSTRAINT `fk_rooms_to_tenants_room_id` FOREIGN KEY (`room_id`) REFERENCES `rooms` (`id`),
  ADD CONSTRAINT `fk_rooms_to_tenants_tenant_id` FOREIGN KEY (`tenant_id`) REFERENCES `tenants` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
