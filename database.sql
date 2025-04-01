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
observacao_cadastro VARCHAR (2048)
);

INSERT INTO aliquotas VALUES (1, "Curitiba", "7.04", "Demolição", "5");
INSERT INTO aliquotas VALUES (2, "Guaratuba", "7.04", "Demolição", "5");
INSERT INTO aliquotas VALUES (3, "Curitiba", "7.02", "Construção", "10");
INSERT INTO aliquotas VALUES (4, "Guaratuba", "7.02", "Construção", "10");
INSERT INTO aliquotas VALUES (5, "Curitiba", "7.10", "Coleta", "3");
INSERT INTO logins(login, senha)  VALUES("Alyson", "123456");
select * from logins;
select login, senha FROM logins WHERE login = "alyson" AND senha = "123456";
INSERT INTO cadastro (
    id_cadastro, unidade_cadastro, municipio_cadastro, cnpj_cadastro, 
    sistema_cadastro, site_cadastro, login_cadastro, senha_cadastro, 
    vencimento_cadastro, observacao_cadastro
) VALUES
(1, 101, 'São Paulo', '12.345.678/0001-99', 'Sistema A', 'https://www.sistemaa.com', 'usuario1', 'senha123', 30, 'Primeiro registro'),
(2, 102, 'Rio de Janeiro', '98.765.432/0001-88', 'Sistema B', 'https://www.sistemab.com', 'usuario2', 'senha456', 60, 'Segundo registro'),
(3, 103, 'Belo Horizonte', '56.789.123/0001-77', 'Sistema C', 'https://www.sistemac.com', 'usuario3', 'senha789', 90, 'Terceiro registro'),
(4, 104, 'Porto Alegre', '34.567.890/0001-66', 'Sistema D', 'https://www.sistemad.com', 'usuario4', 'senha101', 120, 'Quarto registro'),
(5, 105, 'Curitiba', '78.901.234/0001-55', 'Sistema E', 'https://www.sistemae.com', 'usuario5', 'senha202', 150, 'Quinto registro'),
(6, 106, 'Salvador', '45.678.901/0001-44', 'Sistema F', 'https://www.sistemaf.com', 'usuario6', 'senha303', 180, 'Sexto registro'),
(7, 107, 'Fortaleza', '23.456.789/0001-33', 'Sistema G', 'https://www.sistemag.com', 'usuario7', 'senha404', 210, 'Sétimo registro'),
(8, 108, 'Recife', '67.890.123/0001-22', 'Sistema H', 'https://www.sistemah.com', 'usuario8', 'senha505', 240, 'Oitavo registro'),
(9, 109, 'Manaus', '89.012.345/0001-11', 'Sistema I', 'https://www.sistemai.com', 'usuario9', 'senha606', 270, 'Nono registro'),
(10, 110, 'Goiânia', '90.123.456/0001-00', 'Sistema J', 'https://www.sistemaj.com', 'usuario10', 'senha707', 300, 'Décimo registro');


