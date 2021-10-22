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
--bookId int,
--bookQty int

--constraint PK_Cart primary key(cartId),
--constraint FK_CartBookID foreign key(bookId) references Books(bookId),
--constraint FK_CartUserID foreign key(userId) references Users(userId)
--);


------------------------------------------------ALTER TABLES--------------------------------------------------------

--alter table Users add constraint UK_username unique(userName)
--alter table Books alter column bookDescription varchar(500)
--alter table Category alter column categoryDesc varchar(500)
--alter table Users add  isActive bit default 1;
--update Users set isActive=1;

--alter table books add Author varchar(50);
--alter table books add availableQty int;

--update books set availableQty=14, author='Charlotte Bronte' where bookId=1;
--update books set availableQty=9, author='Robert Traver' where bookId=2;
--update books set availableQty=0, author='Jane Austin' where bookId=3;
--update books set availableQty=10, author='Dr. A P J Abdul Kalam' where bookId=4;
--update books set availableQty=0, author='Greer Hendricks, Sarah Pekkanen' where bookId=5;
--update books set availableQty=20, author='Michelle Obama' where bookId=6;
--update books set availableQty=5, author='Ken Follet' where bookId=7;
--update books set availableQty=19, author='Lucy Foley' where bookId=8;
--update books set availableQty=3, author='Toni Morrison' where bookId=9;
--update books set availableQty=0, author='Shirley Jackson' where bookId=10;
--update books set availableQty=18, author='Dan Brown' where bookId=11;
--update books set availableQty=14, author='Andy Weir' where bookId=12;
--update books set availableQty=5, author='Walt Whitman' where bookId=13;
--update books set availableQty=0, author='Ted Chiang' where bookId=14;
--update books set availableQty=14, author='Elie Wisel' where bookId=16;

--alter table books add constraint checkavailability check(availableQty>=0)

--alter table Category alter column categoryImg varchar(500) 
--alter table Books alter column bookImage varchar(1000)

--update Category set categoryImg='https://st4.depositphotos.com/1005233/37899/i/600/depositphotos_378996858-stock-photo-view-blank-cover-book-isolated.jpg';
--update Category set categoryImg = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgbJRJ4Yde2OOi9ZwgeEmlTjWMd7sGhY90Jw&usqp=CAU' where categoryId = 1
--update Category set categoryImg = 'https://www.sun-sentinel.com/resizer/9xhhgqjtXA8DSl1-0rVL7vJn48o=/415x311/top/cloudfront-us-east-1.images.arcpublishing.com/tronc/P5XYR5PERJG47AAD3SYKTDVXDY.jpg' where categoryId=2;

--update Category set categoryImg = 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/hbz-thriller-index-1593712464.jpg?crop=0.502xw:1.00xh;0.250xw,0&resize=640:*' where categoryId=3;

--update Category set categoryImg = 'https://n3.sdlcdn.com/imgs/j/s/x/Short-Story-books-with-exercises-SDL856131003-1-e6632.jpg' where categoryId=4;

--update Category set categoryImg = 'https://static01.nyt.com/images/2021/09/15/books/00FALL-PREVIEW-MEMOIR/00FALL-PREVIEW-MEMOIR-articleLarge.jpg?quality=75&auto=webp&disable=upscale' where categoryId=5;

--update Category set categoryImg = 'https://www.denofgeek.com/wp-content/uploads/2021/06/Books-Banner-8.png?fit=1240%2C698' where categoryId=6;

--update Category set categoryImg = 'https://orion-uploads.openroadmedia.com/sm_254bdff4b0c6-md_2d7c5acacd29-literary-fiction.jpg' where categoryId=7;
--update Category set categoryImg = 'https://cdn.shopify.com/s/files/1/0285/2821/4050/articles/113_1110x.jpg?v=1592918177' where categoryId=8;
--update Category set categoryImg ='https://static.independent.co.uk/2021/02/23/17/poetry-books-world-poetry-day-indybest.jpg?width=982&height=726&auto=webp&quality=75' where categoryId=9;
--update Category set categoryImg = 'https://s26162.pcdn.co/wp-content/uploads/sites/2/2018/12/Memoir-Biography.png' where categoryId=10;
--update books set bookImage = 'https://s26162.pcdn.co/wp-content/uploads/sites/2/2018/12/Memoir-Biography.png';




--alter table Cart add constraint UK_bookUser UNIQUE(bookId,userId)

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

--insert into Cart values(2,5,2);
--insert into Cart values(2,6,1);
--insert into Cart values(1,1,1);
--insert into Cart values(3,13,2);
--insert into Cart values(3,8,3);
--insert into Cart values(9,11,5);
--insert into Cart values(10,1,5);
--insert into Cart values(8,4,1);
--insert into Cart values(8,12,1);
--insert into Cart values(7,3,1);


--insert into Orders values(1,1,0,getdate());
--insert into Orders values(2,2,0,getdate());
--insert into Orders values(4,1,0,getdate());
--insert into Orders values(5,2,0,getdate());
--insert into Orders values(6,1,0,getdate());

--insert into Purchases values(1,2,1)
--insert into Purchases values(2,1,1)
--insert into Purchases values(3,3,2);
--insert into Purchases values(4,2,2);
--insert into Purchases values(5,2,2);
--insert into Purchases values(6,4,3);
--insert into Purchases values(9,1,4);
--insert into Purchases values(10,1,4);
--insert into Purchases values(6,2,5);
--insert into Purchases values(13,1,5);



------------------------------------------------TRIGGERS AND FUNCTIONS--------------------------------------------------------

--create function func_calctotal(@orderId int,@discount float) returns float
--begin
--	declare @total float;
--	set @total=(select sum(Purchases.qty*Books.bookPrice*(1-(@discount*.01))) from Purchases join  Books on Purchases.bookId=Books.bookId where Purchases.orderId=@orderId);
--	return @total;
--end


--alter trigger trg_orderplaced
--on
--Purchases
--after
--insert,update,delete
--as
--begin
--	declare @orderId int;
--	declare @discount float;
--	declare @bookId int;
--	declare @userId int;
--	declare @qty int;
	
--	if(exists (select * from deleted))
--	begin
--	set @orderId =(select orderId from deleted);
--	set @discount =(select Discount.disPercent from Orders join Discount on Orders.couponId=Discount.couponId where Orders.orderId=@orderId);
--	set @qty=(select qty from inserted);
--	set @bookId=(select bookId from inserted);
--	update books set availableQty=(availableQty+@qty) where bookId=@bookId;
--	end

--	if(exists (select * from inserted))
--	begin

--	set @orderId=(select orderId from inserted);
--	set @bookId=(select bookId from inserted);
--	set @qty=(select qty from inserted);
--	set @userId=(select Orders.userId from Purchases join Orders on Purchases.orderId=Orders.orderId where Orders.orderId=@orderId);
--	set @discount =(select Discount.disPercent from Orders join Discount on Orders.couponId=Discount.couponId where Orders.orderId=@orderId);
--	update books set availableQty=(availableQty-@qty) where bookId=@bookId;
--	delete from Cart where bookId=@bookId and userId=@userId
--	end

	
--	update Orders set totalAmt=(select dbo.func_calctotal(@orderId,@discount)) where orderId=@orderId
--end

--alter trigger purchase_Add
--on
--Orders
--after insert
--as begin
--	declare @orderId int=(select orderId from inserted);
--	declare @userId int = (select userId from Orders where orderId=@orderId);
--	insert into Purchases values((select bookId from Cart where userId = @userId),(select bookQty from Cart where userId = @userId),@orderId);
--end


--------------------------------------------------TESTING-------------------------------------------------------
--insert into Cart values(4,9,1)
--insert into Orders values(4,1,0,getdate());
