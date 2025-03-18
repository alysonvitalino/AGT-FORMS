create database funcionarios;
use funcionarios;
create table funcionario (
id_funcionario int auto_increment primary key,
nome varchar(60),
email varchar(60)
);

select * from funcionario;

delete from funcionario where id_funcionario=2;