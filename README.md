# Exemplo - DAO

Esse repositório foi criado para exemplificar o padrão de objeto de acesso a dados (acrônimo do inglês Data Access Object - DAO), é um padrão para aplicações que utilizam persistência de dados, onde tem a separação das regras de negócio das regras de acesso a banco de dados, implementada com linguagens de programação orientadas a objetos (como por exemplo C#).

# Banco de dados
- MySQL: 10.13  Distrib 8.0.19, for Win64 (x86_64)

Script:

CREATE DATABASE `mercado_db`;

USE `mercado_db`;

CREATE TABLE `tb_produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `preco` decimal(11,2) NOT NULL,
  `categoria` varchar(50) NOT NULL,
  `qnt_estoque` int(11) NOT NULL,
  PRIMARY KEY (`id`)
);


# Linguagem de programação
- C#: Visual Studio 2019 / WindowsForms/ .NET Framewordk 4.7.2 / 

- Para integrar o MySQL com o C#, precisa estar instalado o connector .NET do MySQL.
