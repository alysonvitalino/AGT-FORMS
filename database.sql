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

CREATE TABLE contador_relatorios (
    id INT PRIMARY KEY,
    quantidade INT NOT NULL
);


INSERT INTO contador_relatorios (id, quantidade) VALUES (1, 0);

INSERT INTO aliquotas (id_aliquota, municipio, cod_servico, desc_servico, aliquota_iss, lei_vigente) VALUES
(0,  'Nenhum','0.00','Nenhuma alíquota selecionada.','0', NULL),
(1,  'Curitiba','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário. ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(2,  'Curitiba','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes, inclusive (exceto - sondagem, perfuração de poços, escavação, drenagem e irrigação, terraplanagem, pavimentação.', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(3,  'Curitiba','7.04', 'Demolição. ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(4,  'Curitiba','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres (exceto o fornecimento de mercadorias produzidas pelo prestador dos serviços, fora do local da prestação dos serviços, que fica sujeito ao ICMS) ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(5,  'Curitiba','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer. ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(6,  'Curitiba','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres', '2,50', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(7,  'Curitiba','7.11', 'Decoração E Jardinagem, Inclusive Corte E Poda De Árvores', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(8,  'Curitiba','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(9,  'Curitiba','7.16', 'Florestamento, reflorestamento,  semeadura, adubação e congêneres', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(10, 'Curitiba','7.17', 'Escoramento, contenção de encostas e serviços congêneres', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(11, 'Curitiba','7.18', '- Limpeza E Dragagem De Rios, Portos, Canais, Baías, Lagos, Lagoas, Represas, Açudes E Congêneres e ', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(12, 'Curitiba','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(13, 'Curitiba','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas', '2,50', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(14, 'Curitiba','16.02', 'Outros serviços de transporte de natureza municipal. (Incluído pela Lei Complementar nº 157, de 2016)', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(15, 'Curitiba','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(16, 'Curitiba','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 40/2001, art. 8º-A, II'),
(17, 'Pinhais','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(18, 'Pinhais','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(19, 'Pinhais','7.04', 'Demolição.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(20, 'Pinhais','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(21, 'Pinhais','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(22, 'Pinhais','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei nº 501/2001, art. 8º-A, II'),
(23, 'Pinhais','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(24, 'Pinhais','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(25, 'Pinhais','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(26, 'Pinhais','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(27, 'Pinhais','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(28, 'Pinhais','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(29, 'Pinhais','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei nº 501/2001, art. 8º-A, II'),
(30, 'Pinhais','16.02', 'Outros serviços de transporte de natureza municipal. (Incluído pela Lei Complementar nº 157, de 2016)', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(31, 'Pinhais','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(32, 'Pinhais','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei nº 501/2001, art. 8º-A, II'),
(33, 'Londrina','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(34, 'Londrina','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(35, 'Londrina','7.04', 'Demolição.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(36, 'Londrina','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(37, 'Londrina','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(38, 'Londrina','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(39, 'Londrina','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(40, 'Londrina','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(41, 'Londrina','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(42, 'Londrina','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(43, 'Londrina','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(44, 'Londrina','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(45, 'Londrina','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(46, 'Londrina','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(47, 'Londrina','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(48, 'Londrina','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 416/2011, art. 8º-A, II'),
(49, 'Maringá','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(50, 'Maringá','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(51, 'Maringá','7.04', 'Demolição.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(52, 'Maringá','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(53, 'Maringá','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(54, 'Maringá','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(55, 'Maringá','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(56, 'Maringá','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(57, 'Maringá','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(58, 'Maringá','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(59, 'Maringá','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(60, 'Maringá','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(61, 'Maringá','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(62, 'Maringá','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(63, 'Maringá','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(64, 'Maringá','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 632/2006, art. 8º-A, II'),
(65, 'Ponta Grossa','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(66, 'Ponta Grossa','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(67, 'Ponta Grossa','7.04', 'Demolição.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(68, 'Ponta Grossa','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(69, 'Ponta Grossa','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(70, 'Ponta Grossa','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(71, 'Ponta Grossa','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(72, 'Ponta Grossa','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(73, 'Ponta Grossa','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(74, 'Ponta Grossa','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(75, 'Ponta Grossa','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(76, 'Ponta Grossa','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(77, 'Ponta Grossa','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(78, 'Ponta Grossa','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(79, 'Ponta Grossa','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(80, 'Ponta Grossa','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 222/2007, art. 8º-A, II'),
(81, 'São José dos Pinhais','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(82, 'São José dos Pinhais','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(83, 'São José dos Pinhais','7.04', 'Demolição.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(84, 'São José dos Pinhais','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(85, 'São José dos Pinhais','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(86, 'São José dos Pinhais','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(87, 'São José dos Pinhais','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(88, 'São José dos Pinhais','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(89, 'São José dos Pinhais','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(90, 'São José dos Pinhais','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(91, 'São José dos Pinhais','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(92, 'São José dos Pinhais','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(93, 'São José dos Pinhais','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(94, 'São José dos Pinhais','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(95, 'São José dos Pinhais','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(96, 'São José dos Pinhais','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(97, 'Cascavel','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(98, 'Cascavel','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(99, 'Cascavel','7.04', 'Demolição.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(100, 'Cascavel','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(101, 'Cascavel','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(102, 'Cascavel','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(103, 'Cascavel','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(104, 'Cascavel','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(105, 'Cascavel','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(106, 'Cascavel','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(107, 'Cascavel','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(108, 'Cascavel','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(109, 'Cascavel','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(110, 'Cascavel','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(111, 'Cascavel','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(112, 'Cascavel','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 3.448/2007, art. 8º-A, II'),
(113, 'Foz do Iguaçu','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(114, 'Foz do Iguaçu','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(115, 'Foz do Iguaçu','7.04', 'Demolição.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(116, 'Foz do Iguaçu','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(117, 'Foz do Iguaçu','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(118, 'Foz do Iguaçu','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(119, 'Foz do Iguaçu','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(120, 'Foz do Iguaçu','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(121, 'Foz do Iguaçu','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(122, 'Foz do Iguaçu','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(123, 'Foz do Iguaçu','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(124, 'Foz do Iguaçu','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(125, 'Foz do Iguaçu','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(126, 'Foz do Iguaçu','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(127, 'Foz do Iguaçu','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(128, 'Foz do Iguaçu','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 82/2003, art. 8º-A, II'),
(129, 'Colombo','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(130, 'Colombo','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(131, 'Colombo','7.04', 'Demolição.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(132, 'Colombo','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(133, 'Colombo','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(134, 'Colombo','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(135, 'Colombo','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(136, 'Colombo','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(137, 'Colombo','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(138, 'Colombo','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(139, 'Colombo','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(140, 'Colombo','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(141, 'Colombo','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(142, 'Colombo','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(143, 'Colombo','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(144, 'Colombo','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 17/2003, art. 8º-A, II'),
(145, 'Guarapuava','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(146, 'Guarapuava','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(147, 'Guarapuava','7.04', 'Demolição.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(148, 'Guarapuava','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(149, 'Guarapuava','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(150, 'Guarapuava','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(151, 'Guarapuava','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(152, 'Guarapuava','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(153, 'Guarapuava','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(154, 'Guarapuava','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(155, 'Guarapuava','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(156, 'Guarapuava','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(157, 'Guarapuava','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(158, 'Guarapuava','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(159, 'Guarapuava','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(160, 'Guarapuava','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 052/2003, art. 8º-A, II'),
(161, 'Araucária','3.05', 'Cessão de andaimes, palcos, coberturas e outras estruturas de uso temporário.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(162, 'Araucária','7.02', 'Execução, por administração, empreitada ou subempreitada, de obras de construção civil, hidráulica ou elétrica e de outras obras semelhantes.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(163, 'Araucária','7.04', 'Demolição.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(164, 'Araucária','7.05', 'Reparação, conservação e reforma de edifícios, estradas, pontes, portos e congêneres.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(165, 'Araucária','7.09', 'Varrição, coleta, remoção, incineração, tratamento, reciclagem, separação e destinação final de lixo, rejeitos e outros resíduos quaisquer.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(166, 'Araucária','7.10', 'Limpeza, manutenção e conservação de vias e logradouros públicos, imóveis, chaminés, piscinas, parques, jardins e congêneres.', '2,50', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(167, 'Araucária','7.11', 'Decoração e jardinagem, inclusive corte e poda de árvores.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(168, 'Araucária','7.12', 'Controle e tratamento de efluentes de qualquer natureza e de agentes físicos, químicos e biológicos.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(169, 'Araucária','7.16', 'Florestamento, reflorestamento, semeadura, adubação e congêneres.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(170, 'Araucária','7.17', 'Escoramento, contenção de encostas e serviços congêneres.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(171, 'Araucária','7.18', 'Limpeza e dragagem de rios, portos, canais, baías, lagos, lagoas, represas, açudes e congêneres.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(172, 'Araucária','7.19', 'Acompanhamento e fiscalização da execução de obras de engenharia, arquitetura e urbanismo.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(173, 'Araucária','11.0', 'Vigilância, segurança ou monitoramento de bens e pessoas.', '2,50', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(174, 'Araucária','16.02', 'Outros serviços de transporte de natureza municipal.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(175, 'Araucária','17.05', 'Fornecimento de mão-de-obra, mesmo em caráter temporário, inclusive de empregados ou trabalhadores, avulsos ou temporários, contratados pelo prestador de serviço.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II'),
(176, 'Araucária','17.10', 'Planejamento, organização e administração de feiras, exposições, congressos e congêneres.', '5', 'Lei Complementar nº 01/2004, art. 8º-A, II');






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

select * from logins;


