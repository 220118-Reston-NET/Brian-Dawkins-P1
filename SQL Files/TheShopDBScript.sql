--Starts my tables that belong to my customer model 
--Create statement to create customer table 
create table customer(
	CustomerId int identity (1,1) primary key,	
	Name varchar(50),
	_address varchar(50)	
);

create table phoneNumber(
	phoneNumberId int identity (1,1) primary key,
	_pnumber varchar(50) 
);

create table ListOfOrder(
	listId int identity (1,1) primary key,
	listofOrder varchar(50) 
);

--Ends my tables that belong to my customer model
insert into customer 
values ('Brian Dawkins', '5058 Brighton Drive'),
	('Kayla Shirk', '1909 University Blvd S')
	
insert into phoneNumber 
values ('904-654-3613'),
	('904-535-6961')
	
select * from customer 

--Starts the relationship tables between Customer, phonenumber, and ListOfOrder 
--Many to Many between customer and phonenumber (Spouses could have same phone number)
create table customer_phonenumbers(
	CustomerId int foreign key references customer(CustomerId),
	phoneNumberId int foreign key references phoneNumber(phoneNumberId)
);

insert into customer_phonenumbers 
values (1,1), (2,2)
	
select * from customer_phonenumbers cp 
--One to Many relationship between customer and list of orders
alter table ListOfOrder 
add customerId int foreign key references Customer(CustomerId)

--Where we have our insert statements to add values 


--Ends my relationship tables between Customer, phonenumber, and ListOfOrder 


--Starts my tables that belong to my Order Model
create table Orders(
	OrderId int identity (1,1) primary key,
	total int 
);
 insert into Orders 
 values (30, 2, 1), (45, 2, 3), (70, 4, 2), (10, 5, 5)
select * from Orders o 

insert into Orders (total)  
values (45)
	
	
create table Location(
	StoreId int identity (1,1) primary key,
	LName varchar(50),
	LAddress varchar(50),
);
select * from Location l 
insert into Location 
values ('Southside', '2431 Southside Blvd'),
	('Northside', '5679 Northside Blvd'),
	('Eastside', '1267 Eastside Blvd'),
	('Westside', '4387 Westside Blvd')

create table LineItems(
	ProductId int foreign key references Product(ProductId),
	OrderId int foreign key references Orders(OrderId),
	Quantity int 
)

insert into LineItems 
values (1, 2, 5)
alter table LineItems 
add Quantity int

select * from LineItems li 
insert into LineItems 

--Ends my tables that belong to my Order Model 

--Starts the relationship tables between Orders, Locations, and LineItems 
--One to many (One store can have many Orders)
alter table Orders 
add StoreId int identity (1,1) foreign key references Location(StoreId)

--Many to Many (Many orders can have many Line items)
create table Orders_LineItems(
	OrderId int foreign key references Orders(OrderId),
	ItemId int foreign key references LineItems(ItemId)
)

insert into Orders_LineItems 
values (3,2)

--Many Locations can have many Line Items
create table Locations_LineItems(
	StoreId int foreign key references Location(StoreId),
	ItemId int foreign key references LineItems(ItemId)
)

--Where our insert statements go for values 

select * from Orders o
inner join Orders_LineItems oli on o.OrderId = oli.OrderId 
inner join LineItems li on li.ItemId = oli.ItemId 
--Ends the relationship tables between Orders, Locations, and LineItems 

--Relationship between customers and locations
--Many to Many 
create table customers_locations(
	CustomerId int foreign key references Customer(CustomerId),
	StoreId int foreign key references Location(StoreId)
)

--Relationship between customers and orders 
--One to Many customers can have more than one order
alter table Orders 
add CustomerId int foreign key references Customer(CustomerId)

select c.CustomerId, o.OrderId, o.total  from Orders o  
inner join customer c on o.CustomerId  = c.CustomerId  

select c.CustomerId, oli.OrderId from Orders_LineItems oli 

create table Product(
	ProductId int identity (1,1) primary key,
	Name varchar(50),
	Price int,
	Category varchar(50)
)

insert into Product 
values ('Jerseys', 10, 'Basketball'), ('Helmets', 15, 'Football'), ('Cleats', 15, 'Baseball'), ('Skates', 20, 'Hockey')

select * from Location l 


create table Inventory(
	ProductId int foreign key references Product(ProductId),
	StoreId int foreign key references Location(StoreId),
	Quantity int
)

Update Inventory set Quantity = 10
where ProductId= 1 and StoreId = 2

insert into Inventory 
values (1, 2, 100), (2, 2, 100), (3, 2, 100), (4, 2, 100), (1, 3, 100), (2, 3, 100),
 (3, 3, 100), (4, 3, 100), (1, 4, 100), (2, 4, 100), (3, 4, 100), (4, 4, 100), (1, 5, 100),
 (2, 5, 100), (3, 5, 100), (4, 5, 100)
select * from Inventory i 

select o.StoreId, o.OrderId, o.total from Orders o 
inner join Location l on o.StoreId = L.StoreId 
where 

select i.ProductId, StoreId, Quantity from Inventory i 
inner join Product p on i.ProductId = p.ProductId 
where StoreId = 3
select * from customer c 

select o.OrderId, o.StoreId, total from Orders o 
inner join Location l on o.StoreId = l.StoreId 

select customerId from customer c 

select * from Inventory i 
where StoreId = 2

select Quantity from Inventory i2
where StoreId = 2 and ProductId = 2

update Inventory set Quantity = Quantity - 1
where ProductId = 1 and StoreId = 2 

select * from Orders o

insert into Orders 
values (100, 3, 3)

insert into LineItems 
values ()

select o.OrderId, o.StoreId, total from Orders o 

select * from LineItems li 
insert into LineItems 
values (1,2,3)

select * from Inventory i 

select * from Product p 

insert into Inventory values (ProductId, StoreId, Name, Price, Quantity)

select * from Location l 

insert into In

INSERT INTO Product (Name, Price, Category, Description) VALUES('', 0, '', '')



