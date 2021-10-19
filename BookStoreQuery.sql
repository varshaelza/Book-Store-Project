--create database BookStoreDB
--use BookStoreDB

create table Category
(
categoryId int identity,
categoryName varchar(30) not null,
categoryDesc varchar(100),
categoryImg varbinary(MAX),
categoryStatus bit not null,
categoryPosition int not null,
categoryCreatedAt datetime not null

constraint UK_categoryposition unique(categoryPosition),
constraint PK_Category primary key(categoryId)
);

create table Books(
   bookId int identity,
   categoryId int,
   title varchar(50) not null,
   ISBN int not null,
   [year] int not null,
   bookPrice float not null,
   bookDescription varchar(50),
   bookPosition int not null,
   bookStatus bit not null,
   bookImage varbinary(max),

   constraint PK_books primary key(bookId),
   constraint UK_bookposition unique(bookPosition),
   constraint UK_bookISBN unique(ISBN),
   constraint FK_BookCategoryID foreign key(categoryId) references Category(categoryId)
)

create table Users(
  userId int identity,
  userName varchar(50) not null,
  [password] varchar(20) not null,
  firstName varchar(20) not null,
  lastName varchar(20),
  userEmail varchar(50) not null,
  userMobile float,
  IsAdmin bit default 0,
  userAddress varchar(100) not null,

  constraint PK_users primary key(userId)
)

create table Discount
(
couponId int identity,
couponCode varchar(20) not null,
minPurchase float not null,
disPercent float not null,

constraint PK_discount primary key(couponId),
constraint UK_couponcode unique(couponCode)
)

create table Orders
(
orderId int identity,
userId int, 
couponId int,
totalAmt float not null,
datetimeOrder datetime not null

constraint PK_Order primary key(orderId),
constraint FK_OrderUserID foreign key(userId) references Users(userId),
constraint FK_CartCouponID foreign key(couponId) references Discount(couponId)
);

create table WishList
(
wishId int identity,
bookId int,
userId int,

constraint PK_wishlist primary key(wishId),
constraint FK_WishBookID foreign key(bookId) references Books(bookId),
constraint FK_WishUserID foreign key(userId) references Users(userId)
)

create table Purchases
(
purchaseId int identity,
bookId int,
qty int not null,
orderId int,

constraint PK_purchases primary key(purchaseId),
constraint FK_PurchaseBookID foreign key(bookId) references Books(bookId),
constraint FK_PurchaseOrderID foreign key(orderId) references Orders(orderId)
)

create table Cart
(
cartId int identity,
userId int,
bookId int

constraint PK_Cart primary key(cartId),
constraint FK_CartBookID foreign key(bookId) references Books(bookId),
constraint FK_CartUserID foreign key(userId) references Users(userId)
);



