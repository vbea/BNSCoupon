create table BNSCoupon (
	id int primary key identity(1,1),  --id
	qq varchar(11) not null,	-- QQ号码
	psd varchar(50) null,	--密码或提示
	name varchar(30) not null,	--昵称
	sex int not null,			--性别
	vocation int not null,		--职业
	redate datetime not null,	--注册时间
	[level]	int not null,		--等级
	stard int not null,			--星级
	coupon bigint,			--点券数量
	remark varchar(100), --备注（说明）
	checked datetime,	--上次检查的时间
	valid bit not null		--是否显示
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

insert into Setting values ('showAccount', 0, null)--是否显示完整账号
insert into Setting values ('showStore', 0, null)--是否展示商品
insert into Setting values ('orderby', null, 0)


insert into Store1 (name,category,cost,price,maxs,mark,isDelete) select name,category,cost,price,maxs,mark,isDelete from Store






create view BNSVIEW1 as
select t.id,qq,psd,name,gender,race,v.vocation,redate,level,stard,coupon,remark,checked from (select b.id,qq,psd,name,gender,vocation,redate,level,stard,coupon,remark,checked from BNSCoupon b left join gender g on b.sex=g.pid where valid=1)t join Vocation v on t.vocation=v.id 

select * from BNSVIEW1 order by level desc,stard desc












insert into Threshold (minlevel,minStard,coupon,cycle,remark,isvalid)
values (50,0,15888,'每周','50级以上每周发放15888点券',1)

insert into gender values ('男')
insert into gender values ('女')

