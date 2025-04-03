drop database agt;
create database agt;
use agt;


CREATE TABLE logins
(
id_login int auto_increment primary key,
login VARCHAR(255) NOT NULL,
senha VARCHAR(255) NOT NULL
);

CREATE TABLE aliquotas (
id_aliquota INT NOT NULL PRIMARY KEY,
municipio VARCHAR (255),
cod_servico DECIMAL (10,2),
desc_servico TEXT,
aliquota_iss DECIMAL (10,2)
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

SELECT municipio, cod_servico, desc_servico, aliquota_iss FROM aliquotas;

INSERT INTO aliquotas (id_aliquota, municipio, cod_servico, desc_servico, aliquota_iss) VALUES
(1, 'Curitiba','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário. ', '5'),
(2, 'Curitiba','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes, inclusive (exceto - sondagem, perfuração de poços, escavação, drenagem e irrigação, terraplanagem, pavimentação, ', '5'),
(3, 'Curitiba','7.04', 'Demolição. ', '5'),
(4, 'Curitiba','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres (exceto o fornecimento de mercadorias produzidas pelo prestador dos serviços, fora do local da prestação dos serviços, que fica sujeito ao ICMS) ', '5'),
(5, 'Curitiba','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer. ', '5'),
(6, 'Curitiba','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres', '2,50'),
(7, 'Curitiba','7.11', 'Decoração E Jardinagem, Inclusive Corte E Poda De Árvores', '5'),
(8, 'Curitiba','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos', '5'),
(9, 'Curitiba','7.16', 'Florestamento, reflorestamento,  semeadura, adubação e congêneres', '5'),
(10, 'Curitiba','7.17', 'Escoramento, contenção de encostas e serviços congêneres', '5'),
(11, 'Curitiba','7.18', '- Limpeza E Dragagem De Rios, Portos, Canais, Baías, Lagos, Lagoas, Represas, Açudes E Congêneres e ', '5'),
(12, 'Curitiba','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo', '5'),
(13, 'Curitiba','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas', '2,50'),
(14, 'Curitiba','16.02', 'Outros serviços de transporte de natureza municipal. (Incluído pela Lei Complementar nº 157, de 2016)', '5'),
(15, 'Curitiba','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5'),
(16, 'Curitiba','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5'),
(17, 'Pinhais','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5');


INSERT INTO logins(login, senha)  VALUES("Alyson", "123456");

select login, senha FROM logins WHERE login = "alyson" AND senha = "123456";
INSERT INTO cadastro (
    id_cadastro, unidade_cadastro, municipio_cadastro, cnpj_cadastro, 
    sistema_cadastro, site_cadastro, login_cadastro, senha_cadastro, 
    vencimento_cadastro, observacao_cadastro
) VALUES
(1, 101, 'São Paulo', '12.345.678/0001-99', 'Sistema A', 'https://www.google.com', 'usuario1', 'senha123', 3, 'Primeiro registro'),
(2, 102, 'Rio de Janeiro', '98.765.432/0001-88', 'Sistema B', 'https://www.github.com', 'usuario2', 'senha456', 6, 'Segundo registro'),
(3, 103, 'Belo Horizonte', '56.789.123/0001-77', 'Sistema C', 'https://www.github.com/alysonvitalino', 'usuario3', 'senha789', 9, 'Terceiro registro'),
(4, 104, 'Porto Alegre', '34.567.890/0001-66', 'Sistema D', 'https://www.github.com/alysonvitalino/agt-forms', 'usuario4', 'senha101', 12, 'Quarto registro'),
(5, 105, 'Curitiba', '78.901.234/0001-55', 'Sistema E', 'https://www.instagram.com', 'usuario5', 'senha202', 15, 'Quinto registro'),
(6, 106, 'Salvador', '45.678.901/0001-44', 'Sistema F', 'https://www.facebook.com', 'usuario6', 'senha303', 18, 'Sexto registro'),
(7, 107, 'Fortaleza', '23.456.789/0001-33', 'Sistema G', 'https://www.chatgpt.com', 'usuario7', 'senha404', 21, 'Sétimo registro'),
(8, 108, 'Recife', '67.890.123/0001-22', 'Sistema H', 'https://www.gmail.com', 'usuario8', 'senha505', 24, 'Oitavo registro'),
(9, 109, 'Manaus', '89.012.345/0001-11', 'Sistema I', 'https://classroom.google.com/', 'usuario9', 'senha606', 27, 'Nono registro'),
(10, 110, 'Goiânia', '90.123.456/0001-00', 'Sistema J', 'https://www.excalidraw.com', 'usuario10', 'senha707', 30, 'Décimo registro');

SELECT * FROM aliquotas;


