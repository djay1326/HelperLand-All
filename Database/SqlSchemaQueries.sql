Create database Helperland
create table customer (customerID int not null primary key, firstName nvarchar(30) not null, lastName nvarchar(30) not null, email nvarchar(30) not null, mobile nvarchar(30) not null, passwordd nvarchar(30) not null, addresss nvarchar(100) not null)

create table city (postalCode int not null primary key, cityName nvarchar(30) not null)

create table addresss (addressID int not null primary key, streetName nvarchar(30) not null, houseNumber int not null, postalCode int not null)

create table loginn (email nvarchar(30) not null, passwordd nvarchar(30) not null)

create table newsletter (email nvarchar(30) not null)

create table contactus (firstName nvarchar(30) not null, lastName nvarchar(30) not null, email nvarchar(30) not null, msg nvarchar(30) not null)

create table helpers (helperID int not null primary key, firstName nvarchar(30) not null, lastName nvarchar(30) not null, email nvarchar(30) not null, mobile nvarchar(30) not null, passwordd nvarchar(30) not null, addressID int not null )
alter table helpers add constraint helpers_addressID_FK foreign key (addressID) references addresss(addressID) 

create table cancel (cancelID int not null primary key, msg nvarchar(50) not null, customerID int not null)
create table reschedule (resID int not null primary key, newDate date not null, newTime time not null, msg nvarchar(30), customerID int not null)
create table booked (customerID int not null primary key, orderID int not null, orderDate date not null, orderTime time not null, orderHours int not null, extraServices nvarchar(30) not null, comments nvarchar(50) , pets bit , accepted bit) 

alter table cancel add constraint cancel_custID_FK foreign key(customerID) references booked(customerID)
alter table reschedule add constraint res_custID_FK foreign key (customerID) references booked(customerID)

create table invoice(orderID int not null primary key, paymentID int not null, refundID int not null)

alter table booked add constraint booked_orderID_FK foreign key(orderID) references invoice(orderID)

create table payment (paymentID int not null primary key, amount int not null, cardNumber int not null, expiryDate date not null, CVV int not null, promocode nvarchar(30) not null)
create table refund (refundID int not null primary key, refundAmount int not null, msg nvarchar(30))

alter table invoice add constraint invoice_payID_FK foreign key(paymentID) references payment(paymentID)
alter table invoice add constraint invoice_refID_FK foreign key(refundID) references refund(refundID)

select * from customer
select * from city
select * from addresss
select * from loginn
select * from newsletter
select * from contactus
select * from helpers
select * from cancel
select * from reschedule
select * from booked
select * from invoice
select * from payment
select * from refund