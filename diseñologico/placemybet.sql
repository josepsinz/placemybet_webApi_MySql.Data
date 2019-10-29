-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-10-2019 a las 16:16:01
-- Versión del servidor: 10.4.6-MariaDB
-- Versión de PHP: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `placemybet`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuesta`
--

CREATE TABLE `apuesta` (
  `Id` int(11) NOT NULL,
  `Mercado` float NOT NULL,
  `Tipo` bit(1) NOT NULL,
  `Cuota` float NOT NULL,
  `Apostado` double NOT NULL,
  `Id_Mercado` int(11) NOT NULL,
  `Email` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `apuesta`
--

INSERT INTO `apuesta` (`Id`, `Mercado`, `Tipo`, `Cuota`, `Apostado`, `Id_Mercado`, `Email`) VALUES
(72, 1.5, b'1', 1.9, 10, 1, 'pepo@gmail.com'),
(73, 2.5, b'0', 1.9, 5.45, 2, 'pepo@gmail.com'),
(74, 2.5, b'0', 1.8509, 15.5, 2, 'neila@gmail.com'),
(75, 1.5, b'0', 1.995, 2.5, 1, 'neila@gmail.com'),
(76, 2.5, b'1', 2.09903, 19.5, 2, 'juan@hotmail.com'),
(77, 2.5, b'1', 1.91153, 29.5, 2, 'juan@hotmail.com'),
(78, 1.5, b'0', 1.96951, 7.5, 1, 'juan@hotmail.com'),
(79, 1.5, b'0', 1.9, 70.5, 1, 'neila@gmail.com'),
(80, 1.5, b'0', 1.52895, 300.5, 1, 'neila@gmail.com'),
(81, 1.5, b'0', 1.16726, 30000.5, 1, 'neila@gmail.com'),
(82, 2.5, b'1', 1.72116, 50, 2, 'anagarcia@gmail.com'),
(83, 2.5, b'0', 1.5, 500, 4, 'juan@hotmail.com'),
(84, 3.5, b'1', 1.9, 20, 4, 'anagarcia@gmail.com'),
(85, 3.5, b'0', 2.03571, 70, 4, 'nuevo@gmail.com'),
(86, 3.5, b'0', 1.60143, 70, 4, 'pepo@gmail.com'),
(87, 3.5, b'0', 1.41531, 70, 4, 'pepo@gmail.com'),
(88, 3.5, b'0', 1.3119, 80, 4, 'pepo@gmail.com'),
(89, 3.5, b'0', 1.23861, 180, 4, 'pepo@gmail.com'),
(90, 3.5, b'1', 1.9, 1, 10, 'salva@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE `cuenta` (
  `Banco` varchar(20) NOT NULL,
  `Número tarjeta` bigint(20) NOT NULL,
  `Saldo` double NOT NULL,
  `Email` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cuenta`
--

INSERT INTO `cuenta` (`Banco`, `Número tarjeta`, `Saldo`, `Email`) VALUES
('Santander', 1234123412341234, 3019.23, 'anagarcia@gmail.com'),
('Bankia', 2312345645323455, 200.12, 'neila@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `evento`
--

CREATE TABLE `evento` (
  `Id` int(11) NOT NULL,
  `Fecha` datetime NOT NULL,
  `Local` varchar(20) NOT NULL,
  `Goles_Local` int(11) DEFAULT NULL,
  `Visitante` varchar(20) NOT NULL,
  `Goles_Visitante` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `evento`
--

INSERT INTO `evento` (`Id`, `Fecha`, `Local`, `Goles_Local`, `Visitante`, `Goles_Visitante`) VALUES
(1, '2019-09-25 02:00:00', 'Ontinyent', 2, 'Espanyol', 1),
(2, '2019-09-29 00:00:00', 'Otos', 2, 'Leganés', 80),
(5, '2019-10-28 23:30:00', '', -1, '', -1),
(45, '2019-10-28 22:34:00', '', -1, '', -1),
(89, '2019-10-28 23:32:00', '', -1, '', -1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercado`
--

CREATE TABLE `mercado` (
  `Id` int(11) NOT NULL,
  `Mercado` float NOT NULL,
  `Cuota_Over` float NOT NULL,
  `Cuota_Under` float NOT NULL,
  `Dinero_Over` double NOT NULL,
  `Dinero_Under` double NOT NULL,
  `Id_Evento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `mercado`
--

INSERT INTO `mercado` (`Id`, `Mercado`, `Cuota_Over`, `Cuota_Under`, `Dinero_Over`, `Dinero_Under`, `Id_Evento`) VALUES
(1, 1.5, 264.199, 0.953428, 300, 30481.5, 1),
(2, 2.5, 1.5274, 2.51304, 199, 120.95, 1),
(4, 3.5, 5.50208, 1.14826, 120, 575, 2),
(10, 3.5, 1.89059, 1.9095, 101, 100, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `Email` varchar(20) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Apellidos` varchar(20) NOT NULL,
  `Edad` int(3) NOT NULL,
  `Fondos` double NOT NULL,
  `Administrador` bit(1) NOT NULL,
  `Password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`Email`, `Nombre`, `Apellidos`, `Edad`, `Fondos`, `Administrador`, `Password`) VALUES
('anagarcia@gmail.com', 'Ana', 'García García', 23, 100, b'0', ''),
('andres@mm.com', 'Andres', 'Alfonso', 55, 0, b'0', 'Asdf.1'),
('juan@hotmail.com', 'Juan', 'Garcés', 23, 2300, b'0', ''),
('neila@gmail.com', 'Neila', 'Deba Aguirre', 25, 205, b'0', ''),
('nuevo@gmail.com', 'Felipe', 'Tomas', 29, 0, b'0', 'Abc123%'),
('pepo@gmail.com', 'Pepe', 'Ríos López', 30, 400, b'0', ''),
('rodrigo@mm.com', 'Rodrigo', 'Alberdi', 23, 50000, b'1', 'ABc123%'),
('salva@gmail.com', 'Salvador', 'Sanchez Mira', 34, 0, b'1', '2aBC123%');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuesta`
--
ALTER TABLE `apuesta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id_Evento` (`Id_Mercado`),
  ADD KEY `Email` (`Email`);

--
-- Indices de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`Número tarjeta`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indices de la tabla `evento`
--
ALTER TABLE `evento`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id_Evento` (`Id_Evento`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apuesta`
--
ALTER TABLE `apuesta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=91;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apuesta`
--
ALTER TABLE `apuesta`
  ADD CONSTRAINT `APUESTA_ibfk_1` FOREIGN KEY (`Id_Mercado`) REFERENCES `mercado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `APUESTA_ibfk_2` FOREIGN KEY (`Email`) REFERENCES `usuario` (`Email`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `CUENTA_ibfk_1` FOREIGN KEY (`Email`) REFERENCES `usuario` (`Email`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD CONSTRAINT `MERCADO_ibfk_1` FOREIGN KEY (`Id_Evento`) REFERENCES `evento` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
