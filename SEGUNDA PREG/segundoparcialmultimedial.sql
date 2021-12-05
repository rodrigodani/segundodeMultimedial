-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-12-2021 a las 00:05:19
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
-- Base de datos: `segundoparcialmultimedial`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujocondicionante`
--

CREATE TABLE `flujocondicionante` (
  `proceso` varchar(1000) DEFAULT NULL,
  `si` varchar(1000) DEFAULT NULL,
  `no` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `flujocondicionante`
--

INSERT INTO `flujocondicionante` (`proceso`, `si`, `no`) VALUES
('P4', 'P5', 'P6');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujoproceso`
--

CREATE TABLE `flujoproceso` (
  `flujo` varchar(1000) DEFAULT NULL,
  `proceso` varchar(1000) DEFAULT NULL,
  `tipo` varchar(1000) DEFAULT NULL,
  `rol` varchar(1000) DEFAULT NULL,
  `procesosiguiente` varchar(1000) DEFAULT NULL,
  `formulario` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `flujoproceso`
--

INSERT INTO `flujoproceso` (`flujo`, `proceso`, `tipo`, `rol`, `procesosiguiente`, `formulario`) VALUES
('F1', 'P2', 'P', 'Comite electoral', 'P3', 'fecha'),
('F1', 'P5', 'F', 'Frente', '', 'habilitacion'),
('F1', 'P1', 'I', 'Frente', 'P2', 'index'),
('F1', 'P6', 'F', 'Frente', '', 'inhabilitacion'),
('F1', 'P4', 'C', 'Comite electoral', '', 'observaciones'),
('F1', 'P3', 'P', 'Frente', 'P4', 'presdoc');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seguimiento`
--

CREATE TABLE `seguimiento` (
  `numerotram` varchar(100) NOT NULL,
  `usuario` varchar(100) NOT NULL,
  `proceso` varchar(100) NOT NULL,
  `fecha_inicio` varchar(100) NOT NULL,
  `fecha_fin` varchar(100) NOT NULL,
  `devolver_a` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `seguimiento`
--

INSERT INTO `seguimiento` (`numerotram`, `usuario`, `proceso`, `fecha_inicio`, `fecha_fin`, `devolver_a`) VALUES
('1', 'ip', 'P1', '02/12/2021', '02/12/2021', ''),
('1', 'comite', 'P2', '02/Dec/2021', '02/Dec/2021', 'ip'),
('1', 'ip', 'P3', '02/Dec/2021', '02/Dec/2021', 'comite'),
('1', 'comite', 'P4', '02/Dec/2021', '02/Dec/2021', 'ip'),
('1', 'ip', 'P5', '02/Dec/2021', '', 'comite'),
('6', 'pic', 'P1', '02/12/2021', '02/12/2021', ''),
('6', 'comite', 'P2', '02/Dec/2021', '02/Dec/2021', 'pic'),
('6', 'pic', 'P3', '02/Dec/2021', '02/Dec/2021', 'comite'),
('6', 'comite', 'P4', '02/Dec/2021', '02/Dec/2021', 'pic'),
('6', 'pic', 'P6', '02/Dec/2021', '', 'comite');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `nick` varchar(100) NOT NULL,
  `contrasenia` varchar(100) NOT NULL,
  `rol` varchar(100) DEFAULT 'Frente'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`nick`, `contrasenia`, `rol`) VALUES
('comite', '123456', 'Comite electoral'),
('ip', '123456', 'Frente'),
('pic', '123456', 'Frente');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `flujoproceso`
--
ALTER TABLE `flujoproceso`
  ADD UNIQUE KEY `formulario` (`formulario`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD UNIQUE KEY `nick` (`nick`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
