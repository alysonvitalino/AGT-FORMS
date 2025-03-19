create database agt;
use agt;


CREATE TABLE logins
(
id_login int auto_increment primary key,
login VARCHAR(255) NOT NULL,
senha VARCHAR(255) NOT NULL
);

CREATE TABLE aliquotas (
id_municipio INT NOT NULL PRIMARY KEY,
municipio VARCHAR (255),
cod_servico DECIMAL (10,2),
desc_servico TEXT,
aliquota_iss DECIMAL (10,1)
);

CREATE TABLE unidades (
id_unidade INT NOT NULL PRIMARY KEY,
cod_erp INT NOT NULL,
cod_entidade VARCHAR (255),
cnpj_unidade VARCHAR (20),
nome_fantasia VARCHAR (255),
endereco_unidade TEXT,
cidade_unidade VARCHAR (255),
cep_unidade VARCHAR (15)
);

CREATE TABLE cadastro (
id_cadastro INT NOT NULL PRIMARY KEY,
unidade_cadastro INT NOT NULL,
municipio_cadastro VARCHAR (255),
cnpj_cadastro VARCHAR (20),
sistema_cadastro VARCHAR (255),
site_cadastro VARCHAR (2048),
login_cadastro VARCHAR (255),
senha_cadastro VARCHAR (255),
vencimento_cadastro INT NOT NULL,
obervacao_cadastro VARCHAR (2048)
);


INSERT INTO logins(login, senha)  VALUES("Alyson", "123456");
select * from logins;
select login, senha FROM logins WHERE login = "alyson" AND senha = "123456";

