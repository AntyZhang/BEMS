insert into flowdefines(flowtype,flowstepdefine,creattime,creator)
values('NEWEQ','[{"Index":1,"Owner":"test01"},{"Index":2,"Owner":"test02"}]','2019-10-06 00:00:00',1);


insert into users(accountname,password,displayname,address,phone,memo,createtime,createby,lastmodifytime,lastmodifyby,state)
value('Admin','e10adc3949ba59abbe56e057f20f883e','管理员','总部','110','00000','2019-06-01','system',null,null,1);

insert into users(accountname,password,displayname,address,phone,memo,createtime,createby,lastmodifytime,lastmodifyby,state)
value('test01','e10adc3949ba59abbe56e057f20f883e','测试01','总部','101','1111111','2019-06-01','system',null,null,1);
insert into users(accountname,password,displayname,address,phone,memo,createtime,createby,lastmodifytime,lastmodifyby,state)
value('test02','e10adc3949ba59abbe56e057f20f883e','测试02','总部','102','222222','2019-06-01','system',null,null,1);