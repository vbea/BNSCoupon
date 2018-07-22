create table BNSCoupon (
	id int primary key identity(1,1),  --id
	qq varchar(11) not null,	-- QQ����
	psd varchar(50) null,	--�������ʾ
	name varchar(30) not null,	--�ǳ�
	sex int not null,			--�Ա�
	vocation int not null,		--ְҵ
	redate datetime not null,	--ע��ʱ��
	[level]	int not null,		--�ȼ�
	stard int not null,			--�Ǽ�
	coupon bigint,			--��ȯ����
	remark varchar(100), --��ע��˵����
	checked datetime,	--�ϴμ���ʱ��
	valid bit not null		--�Ƿ���ʾ
	)
	
create table Threshold(
	id int primary key identity(1,1),
	minlevel int not null,
	minStard int not null,
	coupon int not null,
	cycle char(4) not null,
	dates date null,
	remark varchar(200),
	isvalid bit not null
)

create table Gender(
	id int primary key identity(1,1),
	pid int not null,
	gender varchar(10) not null
)

create table Vocation (
	id int primary key identity(101,1),
	race char(4) not null,
	vocation varchar(10) not null,
	sex varchar(10) null
)

create table Store (
	id int primary key identity(1001,1),
	name varchar(100) not null,
	category int not null,
	cost int null,
	price int not null,
	maxs int not null,
	mark varchar(200) null,
	isDelete bit not null
)

create table Category (
	id int primary key identity(1,1),
	catename nvarchar(20) not null
)

create table OrderLog (
	id int primary key identity(1,1),
	account int,
	cid int,
	cname varchar(100),
	cunit int,
	ccount int,
	price int,
	dates datetime
)

create table Setting (
 id int primary key identity(1,1),
 keys varchar(20) not null,
 state bit null,
 value int null 
)

insert into Setting values ('showAccount', 0, null)--�Ƿ���ʾ�����˺�
insert into Setting values ('showStore', 0, null)--�Ƿ�չʾ��Ʒ
insert into Setting values ('orderby', null, 0)


insert into Store1 (name,category,cost,price,maxs,mark,isDelete) select name,category,cost,price,maxs,mark,isDelete from Store






create view BNSVIEW1 as
select t.id,qq,psd,name,gender,race,v.vocation,redate,level,stard,coupon,remark,checked from (select b.id,qq,psd,name,gender,vocation,redate,level,stard,coupon,remark,checked from BNSCoupon b left join gender g on b.sex=g.pid where valid=1)t join Vocation v on t.vocation=v.id 

select * from BNSVIEW1 order by level desc,stard desc












insert into Threshold (minlevel,minStard,coupon,cycle,remark,isvalid)
values (50,0,15888,'ÿ��','50������ÿ�ܷ���15888��ȯ',1)

insert into gender values ('��')
insert into gender values ('Ů')

