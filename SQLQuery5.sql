--1.      Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.
CREATE VIEW view_product_order_siddique
AS
SELECT p.ProductName, SUM(d.Quantity) as Total_Ordered_Quantity
FROM Products p INNER JOIN [Order Details] d ON d.ProductID = p.ProductID
GROUP BY ProductName
SELECT *
FROM view_product_order_siddique
--2.      Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.
CREATE PROC sp_product_order_quantity_Siddique
@product_id int, @ordered_quantity int out
AS
BEGIN
SELECT @ordered_quantity = SUM(d.Quantity)
FROM Products p INNER JOIN [Order Details] d ON d.ProductID = p.ProductID
WHERE p.ProductID = @product_id
END
BEGIN
DECLARE @ordered_quantity INT
EXEC sp_product_order_quantity_Siddique 15,@ordered_quantity OUT
PRINT @ordered_quantity
END
--3.      Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.
CREATE PROC sp_product_order_city_Siddique
@product_name varchar(20)
AS
BEGIN
SELECT TOP 5 o.ShipCity, SUM(d.Quantity) as Order_Quantity
FROM Products p INNER JOIN [Order Details] d ON d.ProductID = p.ProductID
INNER JOIN Orders o ON o.OrderID = d.OrderID
WHERE p.ProductName = @product_name
GROUP BY ProductName, ShipCity
ORDER BY SUM(d.Quantity) DESC
END
BEGIN
EXEC sp_product_order_city_Siddique 'Chai'
END
--4.      Create 2 new tables “people_your_last_name” “city_your_last_name”. 
--City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
--People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
--Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. 
--Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. 
--(after test) Drop both tables and view.
CREATE TABLE people_Siddique
(
id int ,
name varchar(20),
city int
)
CREATE TABLE city_Siddique
(
id int,
city varchar(20)
)
INSERT into city_Siddique values(1,'Seattle')
INSERT into city_Siddique values(2,'Green Bay')
SELECT * FROM city_Siddique

INSERT into people_Siddique values(1,'Aaron Rodgers',1)
INSERT into people_Siddique values(2,'Russell Wilson',2)
INSERT into people_Siddique values(3,'Jody Nelson',2)
SELECT * FROM people_Siddique

DELETE FROM city_Siddique WHERE city = 'Seattle'

INSERT into city_Siddique values(3,'Madison')
UPDATE people_Siddique
SET city=3 WHERE city=1



CREATE VIEW packers_Siddique
AS
SELECT name FROM people_Siddique WHERE city = 'Green Bay'

SELECT * 
FROM packers_Siddique

DROP table people_Siddique
DROP table city_Siddique
DROP view packers_Siddique
--5.       Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
CREATE PROC sp_birthday_employees_Siddique
AS
BEGIN
CREATE table birthday_employees_siddique(id int primary key,
[last name] varchar(20), 
[first name] varchar(20), 
birthdate datetime)
INSERT into birthday_employees_siddique(id, [last name], [first name], birthdate) 
SELECT e.EmployeeId, e.LastName, e.FirstName, e.BirthDate FROM Employees as e
WHERE month(e.birthdate)=2;
END

EXEC sp_birthday_employees_Siddique

SELECT *
FROM birthday_employees_siddique

DROP table birthday_employees_siddique

SELECT *
FROM Employees
--6.      How do you make sure two tables have the same data?
/*We can use EXCEPT key word 
SELECT *
FROM table 1
SELECT *
FROM table 2 */