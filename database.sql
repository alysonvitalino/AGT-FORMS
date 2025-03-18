

create database funcionarios;
use funcionarios;
create table funcionario (
id_funcionario int auto_increment primary key,
nome varchar(60),
email varchar(60)
);

CREATE TABLE logins
(
id_login int auto_increment primary key,
login VARCHAR(255) NOT NULL,
senha VARCHAR(255) NOT NULL
);


INSERT INTO logins(login, senha)  VALUES("Alyson", "123456");
select * from funcionario;
select * from logins;
select login, senha FROM logins WHERE login = "alyson" AND senha = "123456";

delete from funcionario where id_funcionario=2;