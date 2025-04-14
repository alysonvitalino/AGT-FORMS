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
aliquota_iss DECIMAL (10,2),
lei_vigente VARCHAR(255)
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

INSERT INTO aliquotas (id_aliquota, municipio, cod_servico, desc_servico, aliquota_iss, lei_vigente) VALUES
(0, 'Nenhum','0.00','Nenhuma alíquota selecionada.','0', NULL),
(1, 'Curitiba','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário. ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(2, 'Curitiba','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes, inclusive (exceto - sondagem, perfuração de poços, escavação, drenagem e irrigação, terraplanagem, pavimentação.', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(3, 'Curitiba','7.04', 'Demolição. ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(4, 'Curitiba','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres (exceto o fornecimento de mercadorias produzidas pelo prestador dos serviços, fora do local da prestação dos serviços, que fica sujeito ao ICMS) ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(5, 'Curitiba','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer. ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(6, 'Curitiba','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres', '2,50', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(7, 'Curitiba','7.11', 'Decoração E Jardinagem, Inclusive Corte E Poda De Árvores', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(8, 'Curitiba','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(9, 'Curitiba','7.16', 'Florestamento, reflorestamento,  semeadura, adubação e congêneres', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(10, 'Curitiba','7.17', 'Escoramento, contenção de encostas e serviços congêneres', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(11, 'Curitiba','7.18', '- Limpeza E Dragagem De Rios, Portos, Canais, Baías, Lagos, Lagoas, Represas, Açudes E Congêneres e ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(12, 'Curitiba','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(13, 'Curitiba','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas', '2,50', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(14, 'Curitiba','16.02', 'Outros serviços de transporte de natureza municipal. (Incluído pela Lei Complementar nº 157, de 2016)', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(15, 'Curitiba','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(16, 'Curitiba','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(17, 'Pinhais','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei nº 501/2001, art. 8º-A, II');


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

INSERT INTO unidades (id_unidade, cod_erp, cod_entidade, cnpj_unidade, nome_fantasia, endereco_unidade, cidade_unidade, cep_unidade) 
VALUES 
(1, 1001, 'SESI', '12.345.678/0001-90', 'Unidade A', 'Rua das Flores, 123', 'São Paulo', '01234-567'),
(2, 1002, 'SENAI', '98.765.432/0001-01', 'Unidade B', 'Avenida Paulista, 987', 'São Paulo', '01310-000'),
(3, 1003, 'FIEP', '21.987.654/0001-02', 'Unidade C', 'Rua Rio de Janeiro, 456', 'Rio de Janeiro', '20000-000'),
(4, 1004, 'IEL', '34.567.890/0001-03', 'Unidade D', 'Rua Bahia, 789', 'Salvador', '40000-000'),
(5, 1005, 'MATRIZ', '45.678.901/0001-04', 'Unidade E', 'Avenida Brasil, 234', 'Belo Horizonte', '30100-000'),
(6, 1006, 'ENT006', '56.789.012/0001-05', 'Unidade F', 'Rua dos Andradas, 555', 'Porto Alegre', '90000-000'),
(7, 1007, 'ENT007', '67.890.123/0001-06', 'Unidade G', 'Rua Paraná, 321', 'Curitiba', '80000-000'),
(8, 1008, 'ENT008', '78.901.234/0001-07', 'Unidade H', 'Rua Amazonas, 1234', 'Recife', '50000-000'),
(9, 1009, 'ENT009', '89.012.345/0001-08', 'Unidade I', 'Avenida Rio Branco, 432', 'Fortaleza', '60000-000'),
(10, 1010, 'ENT010', '90.123.456/0001-09', 'Unidade J', 'Rua Sergipe, 765', 'Manaus', '69000-000');

SELECT cod_erp, cod_entidade, cnpj_unidade, nome_fantasia, endereco_unidade, cidade_unidade, cep_unidade FROM unidades;

SELECT municipio, cod_servico, desc_servico, aliquota_iss FROM aliquotas;

SELECT * FROM aliquotas;

INSERT INTO logins(login, senha)  VALUES("Alyson", "123456");

select login, senha FROM logins WHERE login = "alyson" AND senha = "123456";


