-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 13, 2024 at 12:02 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hardware management system`
--

-- --------------------------------------------------------

--
-- Table structure for table `bill`
--

CREATE TABLE `bill` (
  `Item_ID` int(11) NOT NULL,
  `Name_I` varchar(30) NOT NULL,
  `Quantity_B` int(11) NOT NULL,
  `Discount_I` int(11) NOT NULL,
  `Discount` double NOT NULL,
  `Total` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bill`
--

INSERT INTO `bill` (`Item_ID`, `Name_I`, `Quantity_B`, `Discount_I`, `Discount`, `Total`) VALUES
(1, 'screw driver flat', 2, 0, 0, 420),
(2, 'plier', 3, 0, 0, 1944),
(4, 'nose plier', 3, 0, 0, 1320);

-- --------------------------------------------------------

--
-- Table structure for table `business`
--

CREATE TABLE `business` (
  `Item_ID` int(11) NOT NULL,
  `Dealer_ID` int(11) NOT NULL,
  `Price_D` double NOT NULL,
  `Price_I` double NOT NULL,
  `Profit` double NOT NULL,
  `Discount_I` double NOT NULL,
  `Final_Profit` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cus_return`
--

CREATE TABLE `cus_return` (
  `Item_ID` int(11) NOT NULL,
  `Dealer_ID` int(11) NOT NULL,
  `Quantity_R` int(11) NOT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cus_return`
--

INSERT INTO `cus_return` (`Item_ID`, `Dealer_ID`, `Quantity_R`, `Date`) VALUES
(11, 12, 11, '2024-02-12'),
(11, 112, 10, '2024-02-12'),
(11, 12, 23, '2024-02-13');

-- --------------------------------------------------------

--
-- Table structure for table `dealer`
--

CREATE TABLE `dealer` (
  `Dealer_ID` int(4) NOT NULL,
  `Name_D` varchar(20) NOT NULL,
  `Item_ID` int(4) NOT NULL,
  `Company` varchar(20) NOT NULL,
  `Price_D` double NOT NULL,
  `Quantity_D` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dealer`
--

INSERT INTO `dealer` (`Dealer_ID`, `Name_D`, `Item_ID`, `Company`, `Price_D`, `Quantity_D`) VALUES
(6, 'aaa', 11, 'ccc', 200, 10),
(11, 'ddd', 123, 'sss', 111, 11),
(12, 'aaa', 12, 'sss', 123, 12),
(13, 'bbb', 11, 'aaaa', 123, 11);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `Emp_ID` int(11) NOT NULL,
  `Name_E` int(11) NOT NULL,
  `Position` int(11) NOT NULL,
  `Mobile Number` int(30) NOT NULL,
  `NIC` int(11) NOT NULL,
  `Address` int(11) NOT NULL,
  `Monthly_Salary` double NOT NULL,
  `Bonus` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `store`
--

CREATE TABLE `store` (
  `Item_ID` int(4) NOT NULL,
  `Name_I` varchar(30) NOT NULL,
  `Price_I` double NOT NULL,
  `Quantity_I` int(11) NOT NULL,
  `Dealer_ID` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store`
--

INSERT INTO `store` (`Item_ID`, `Name_I`, `Price_I`, `Quantity_I`, `Dealer_ID`) VALUES
(1, 'screw driver flat', 210, 10, 11),
(2, 'plier', 810, 15, 13),
(4, 'nose plier', 550, 18, 13),
(5, 'grinding disc', 300, 20, 13),
(6, 'hand axe', 1500, 8, 13);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bill`
--
ALTER TABLE `bill`
  ADD PRIMARY KEY (`Item_ID`);

--
-- Indexes for table `dealer`
--
ALTER TABLE `dealer`
  ADD PRIMARY KEY (`Dealer_ID`);

--
-- Indexes for table `store`
--
ALTER TABLE `store`
  ADD PRIMARY KEY (`Item_ID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `bill_ibfk_1` FOREIGN KEY (`Item_ID`) REFERENCES `store` (`Item_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
