drop table if exists imoveis;
create table if not exists imoveis(
	id serial primary key,
	cidade varchar(100),
	bairro varchar(100),
	tipo varchar(100),
	valor float,
	qtd_de_quartos integer,
	qtd_de_vagas integer,
	qtd_de_banheiros integer,
	qtd_de_salas integer
);
select * from imoveis;
