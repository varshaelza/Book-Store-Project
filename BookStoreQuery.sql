--create database BookStoreDB
--use BookStoreDB


--drop table Purchases
--drop table Cart
--drop table WishList
--drop table Orders
--drop table Discount
--drop table Users
--drop table Books
--drop table Category

------------------------------------------------CREATE TABLES--------------------------------------------------------

--create table Category
--(
--categoryId int identity,
--categoryName varchar(30) not null,
--categoryDesc varchar(100),
--categoryImg varbinary(MAX),
--categoryStatus bit not null,
--categoryPosition int not null,
--categoryCreatedAt datetime not null

--constraint UK_categoryposition unique(categoryPosition),
--constraint PK_Category primary key(categoryId)
--);

--create table Books(
--   bookId int identity,
--   categoryId int,
--   title varchar(50) not null,
--   ISBN int not null,
--   [year] int not null,
--   bookPrice float not null,
--   bookDescription varchar(50),
--   bookPosition int not null,
--   bookStatus bit not null,
--   bookImage varbinary(max),

--   constraint PK_books primary key(bookId),
--   constraint UK_bookposition unique(bookPosition),
--   constraint UK_bookISBN unique(ISBN),
--   constraint FK_BookCategoryID foreign key(categoryId) references Category(categoryId)
--)

--create table Users(
--  userId int identity,
--  userName varchar(50) not null,
--  [password] varchar(20) not null,
--  firstName varchar(20) not null,
--  lastName varchar(20),
--  userEmail varchar(50) not null,
--  userMobile float,
--  IsAdmin bit default 0,
--  userAddress varchar(100) not null,

--  constraint PK_users primary key(userId)
--)

--create table Discount
--(
--couponId int identity,
--couponCode varchar(20) not null,
--minPurchase float not null,
--disPercent float not null,

--constraint PK_discount primary key(couponId),
--constraint UK_couponcode unique(couponCode)
--)

--create table Orders
--(
--orderId int identity,
--userId int, 
--couponId int,
--totalAmt float not null,
--datetimeOrder datetime not null

--constraint PK_Order primary key(orderId),
--constraint FK_OrderUserID foreign key(userId) references Users(userId),
--constraint FK_CartCouponID foreign key(couponId) references Discount(couponId)
--);

--create table WishList
--(
--wishId int identity,
--bookId int,
--userId int,

--constraint PK_wishlist primary key(wishId),
--constraint FK_WishBookID foreign key(bookId) references Books(bookId),
--constraint FK_WishUserID foreign key(userId) references Users(userId)
--)

--create table Purchases
--(
--purchaseId int identity,
--bookId int,
--qty int not null,
--orderId int,

--constraint PK_purchases primary key(purchaseId),
--constraint FK_PurchaseBookID foreign key(bookId) references Books(bookId),
--constraint FK_PurchaseOrderID foreign key(orderId) references Orders(orderId)
--)

--create table Cart
--(
--cartId int identity,
--userId int,
--bookId int

--constraint PK_Cart primary key(cartId),
--constraint FK_CartBookID foreign key(bookId) references Books(bookId),
--constraint FK_CartUserID foreign key(userId) references Users(userId)
--);

------------------------------------------------ALTER TABLES--------------------------------------------------------

--alter table Users add constraint UK_username unique(userName)
--alter table Books alter column bookDescription varchar(500)
--alter table Category alter column categoryDesc varchar(500)
--alter table Users add isLoggedIn bit default 0;

------------------------------------------------INSERT INTO TABLES--------------------------------------------------------

--insert into Category values('Classic','Books that continue to impact generations ,and serve as a foundation to popular works other today.',null,1,2,getdate());
--insert into Category values('Mystery','The plot always revolves around a crime of sorts that must be solved—or foiled—by the protagonists.',null,0,1,getdate());
--insert into Category values('Thriller','The thriller genre sees the hero attempt to stop and defeat the villain to save their own life rather than uncover a specific crime.',null,1,4,getdate());
--insert into Category values('Short Story','Writers strictly tell their narratives through a specific theme and a series of brief scenes, though many authors compile these stories in wide-ranging collections.',null,1,3,getdate());
--insert into Category values('Autobioraphy','Serving as an official account of the details and events in the life span of a person, autobiographies are written by the subject themselves, while biographies are written by an author who is not the focus of the book.',null,0,5,getdate());
--insert into Category values('Science Fiction','Though they are often thought of in the same vein as fantasy, what distinguishes science fiction stories is that they lean heavily on themes of technology and future science.',null,0,7,getdate());
--insert into Category values('Literary Fiction','Literary fiction refers to the perceived artistic writing style of the author. Their prose is meant to evoke deep thought through stories that offer personal or social commentary on a particular theme.',null,1,6,getdate());
--insert into Category values('Historical Fiction','These books are based in a time period set in the past decades, often against the backdrop of significant (real) historical events.',null,1,9,getdate());
--insert into Category values('Poetry','With poetry—a form of written art—authors choose a particular rhythm and style to evoke and portray various emotions and ideas. ',null,0,8,getdate());
--insert into Category values('Memoir','While a form of autobiography, memoirs are more flexible in that they typically do not feature an extensive chronological account of the life of the writer.',null,1,10,getdate());


--insert into Users(userName, [password], firstName,userEmail,  userMobile,  IsAdmin, userAddress) values('admin','admin123','Admin', 'admin@123.com', 7888821213,1,'');
--insert into Users(userName, [password], firstName, lastName,  userEmail,  userMobile,  userAddress) values('berlin99','berlin123','Berlin', 'Luka','berlin@gmail.com',8999989999,'House No 143, Toronto, USA');
--insert into Users(userName, [password], firstName, lastName,  userEmail,  userMobile,  userAddress) values('tokyo99','tokyo123','Tokyo', 'Alasko','tokyo@gmail.com',7799889988,'House No 23, California, USA');
--insert into Users(userName, [password], firstName,  userEmail,  userMobile,  userAddress) values('denver99','denver123','Denver','denver@gmail.com',8888837339,'Sunny Villas, Australia');
--insert into Users(userName, [password], firstName,  userEmail,  userMobile,  userAddress) values('rio99','rio123','Rio','rio@gmail.com',7658847347,'Windy Villas, Australia');
--insert into Users(userName, [password], firstName,  userEmail,  userMobile,  userAddress) values('nairobi99','nairobi123','Nairobi','nairobi@gmail.com',795846235,'House No 56,Toronto, Canada');
--insert into Users(userName, [password], firstName,  userEmail,  userMobile,  userAddress) values('oslo99','oslo123','Oslo','oslo@gmail.com',7944786215,'House No 10,Sydney, Australia');
--insert into Users(userName, [password], firstName,  userEmail,  userMobile,  userAddress) values('palermo99','palermo123','Palermo','palermo@gmail.com',7856932145,'House No 2,Sydney, Australia');
--insert into Users(userName, [password], firstName,  userEmail,  userMobile,  userAddress) values('helsinki99','helsinki123','Helsinki','helsinki@gmail.com',7849651235,'Angel Villas, France');
--insert into Users(userName, [password], firstName,  userEmail,  userMobile,  userAddress) values('bogota99','bogota123','Bogota','rio@gmail.com',7658847347,'Rainy Villas, Australia');


--insert into Books values(1,'Jane Eyre', 1050, 1847,458,'The novel revolutionised prose fiction by being the first to focus on its protagonist''s moral and spiritual development through an intimate first-person narrative, where actions and events are coloured by a psychological intensity.',1,1,null)
--insert into Books values(2,'Anatomy of a Murder',3453,1998,345.87,'Anatomy of a Murder is the story of Paul Biegler, a small town lawyer in the Upper Peninsula who takes on the case of Lieutenant Manion, charged with murder for shooting a local barkeeper.',2,1,null)
--insert into Books values(1,'Pride And Prejudice',7876 ,1813,256.39,'Pride and Prejudice is an 1813 novel of manners written by Jane Austen. Though it is mostly called a romantic novel, it is also a satire. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.',5,1,null)
--insert into Books values(5,'Wings Of Fire',2991 ,1999,386,'Wings of Fire: An Autobiography of APJ Abdul Kalam (1999), former President of India. It was written by Dr. Abdul Kalam and Arun Tiwari.',3,1,null)
--insert into Books values(3,'The Wife Between Us',5601 ,2018,299,'The Wife Between Us is a 2018 thriller novel written by Greer Hendricks and Sarah Pekkanen.',4,0,null)
--insert into Books values(10,'Becoming',1350,2018,504,'Becoming is the memoir of former First Lady of the United States Michelle Obama, published in 2018. Described by the author as a deeply personal experience, the book talks about her roots and how she found her voice, as well as her time in the White House, her public health campaign, and her role as a mother.',6,1,null)
--insert into Books values(8,'The Pillars of the Earth',4976,1989,780,'The Pillars of the Earth is a historical novel by Welsh author Ken Follett published in 1989 about the building of a cathedral in the fictional town of Kingsbridge, England',8,0,null)
--insert into Books values(3,'The Guest List',2436 ,2020,190.56,'THE GUEST LIST is a delectable blend of Agatha Christie inspiration and modern-day psychological suspense.',7,1,null)
--insert into Books values(7,'Beloved',4168,1987,1870,'Beloved is a 1987 novel by the American writer Toni Morrison. Set after the American Civil War, it tells the story of a family of former slaves whose Cincinnati home is haunted by a malevolent spirit',10,1,null)
--insert into Books values(4,'The Lottery',3661,1948,650,'"The Lottery" is a short story written by Shirley Jackson, first published in the June 25, 1948, issue of The New Yorker. The story describes a fictional small town which observes an annual rite known as "the lottery", in which a member of the community is selected by chance.',9,1,null)
--insert into Books values(3,'Da Vinci Code',1587,2003,288.19,'The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown. It is Brown''s second novel to include the character Robert Langdon',11,1,null)
--insert into Books values(6,'The Martian',8126,2011,498.89,'The Martian is a 2011 science fiction novel written by Andy Weir. It is his debut novel under his own name. The book was originally self-published in 2011 and later re-released by Crown Publishing in 2014 when Crown purchased the exclusive publishing rights.',12,1,null)
--insert into Books values(9,'Leaves Of Grass',2683,1855,210,'Leaves of Grass is a poetry collection by American poet Walt Whitman. First published in 1855, Whitman spent most of his professional life writing and rewriting Leaves of Grass, revising it multiple times until his death.',14,1,null)
--insert into Books values(4,'Stories of Your Life and Others',1100 ,2002,270,'Stories of Your Life and Others is a collection of short stories by American writer Ted Chiang originally published in 2002 by Tor Books.',13,1,null)

--insert into Discount values('BS010',1000,10);
--insert into Discount values('BS015',2000,15);
--insert into Discount values('BS020',3000,20);
--insert into Discount values('BS030',4000,30);
--insert into Discount values('BS050',5000,50);

--insert into WishList values(3,2);
--insert into WishList values(4,3);
--insert into WishList values(7,2);
--insert into WishList values(2,4);
--insert into WishList values(8,4);

--insert into Cart values(2,5);
--insert into Cart values(2,6);
--insert into Cart values(1,1);
--insert into Cart values(3,13);
--insert into Cart values(3,8);
--insert into Cart values(9,11);
--insert into Cart values(10,1);
--insert into Cart values(8,4);
--insert into Cart values(8,12);
--insert into Cart values(7,3);

--insert into Orders values(1,1,0,getdate());
--insert into Orders values(2,2,0,getdate());
--insert into Orders values(4,1,0,getdate());

--insert into Purchases values(1,2,1)
--insert into Purchases values(2,1,1)
--insert into Purchases values(3,3,2);
--insert into Purchases values(4,2,2);
--insert into Purchases values(5,2,2);
--insert into Purchases values(6,4,3);



------------------------------------------------TRIGGERS AND FUNCTIONS--------------------------------------------------------

--create function func_calctotal(@orderId int,@discount float) returns float
--begin
--	declare @total float;
--	set @total=(select sum(Purchases.qty*Books.bookPrice*(1-(@discount*.01))) from Purchases join  Books on Purchases.bookId=Books.bookId where Purchases.orderId=@orderId);
--	return @total;
--end



--create trigger trg_orderplaced
--on
--Purchases
--after
--insert
--as
--begin
--	declare @orderId int=(select orderId from inserted);
--	declare @discount int=(select Discount.disPercent from Orders join Discount on Orders.couponId=Discount.couponId where Orders.orderId=@orderId);

--	update Orders set totalAmt=(select dbo.func_calctotal(@orderId,@discount)) where orderId=@orderId
--end
