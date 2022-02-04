--1.      List all cities that have both Employees and Customers.
SELECT DISTINCT City 
FROM Customers 
WHERE City IN (Select City 
From Employees)
--2.      List all cities that have Customers but no Employee.
--a.      Use sub-query
SELECT DISTINCT City 
FROM Customers 
WHERE City NOT IN (Select City 
From Employees)
--b.      Do not use sub-query
SELECT DISTINCT c.City 
FROM Customers as c
LEFT JOIN (SELECT City FROM Employees) as e
ON c.City=e.City
WHERE e.City IS NULL
--3.      List all products and their total order quantities throughout all orders.
SELECT p.ProductID, p.ProductName, SUM(d.Quantity) as TotalOrderQuantities
FROM Products p LEFT JOIN [Order Details] d ON p.ProductID = d.ProductID
GROUP BY p.ProductID, p.ProductName

--4.      List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(d.Quantity) as TotalOrderQuantities
FROM Customers c INNER JOIN Orders o ON c.City=o.ShipCity
INNER JOIN [Order Details] d ON o.OrderID=d.OrderID
GROUP BY c.City
--5.      List all Customer Cities that have at least two customers.

--a.      Use union
SELECT DISTINCT c.City 
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.City)>=2
UNION
SELECT o.ShipCity
FROM Orders o
GROUP BY o.ShipCity
HAVING COUNT(o.ShipCity)>=2
--b.      Use sub-query and no union
SELECT DISTINCT o.ShipCity 
FROM Orders o
WHERE o.ShipCity IN (SELECT City
FROM Customers 
GROUP BY City 
HAVING COUNT(*) >=2)
--6.      List all Customer Cities that have ordered at least two different kinds of products.
SELECT DISTINCT o.ShipCity as City
FROM Customers as c
RIGHT JOIN Orders o on o.ShipCity=c.City
INNER JOIN [Order Details] d ON o.OrderID=d.OrderID
GROUP BY o.ShipCity 
HAVING COUNT(*) >=2
ORDER By ShipCity

--7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT Distinct c.CustomerID,c.ContactName, c.City, o.ShipCity 
FROM Customers as c
LEFT JOIN Orders o ON o.CustomerID=c.CustomerID AND c.City <> o.ShipCity
WHERE o.ShipCity IS NOT NULL
--8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT *
FROM(SELECT c.City, dt.ProductId, dt.aver, 
DENSE_RANK() OVER(PARTITION BY dt.productId 
ORDER BY dt.[total] DESC) as RNK
FROM Customers c RIGHT JOIN (
SELECT o.customerid, d.productID, SUM(d.quantity) as 'total', AVG(d.UnitPrice) as aver from [Order Details] d
INNER JOIN Orders o on d.OrderID=o.OrderID
GROUP BY d.ProductID, o.CustomerID) as dt ON c.CustomerID= dt.CustomerID) as dt2
WHERE RNK=1 and dt2.ProductID in 
(SELECT TOP 5 ProductID
FROM [Order Details] GROUP BY ProductID ORDER BY SUM(Quantity))
--9.      List all cities that have never ordered something but we have employees there.
--a.      Use sub-query
SELECT e.City 
FROM Employees as e
WHERE e.City NOT IN (SELECT DISTINCT o.ShipCity FROM Orders o)
--b.      Do not use sub-query
SELECT DISTINCT e.CIty
FROM Employees e LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL
--10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT  o.ShipCity 
FROM Orders as o 
WHERE o.ShipCity in (
SELECT TOP 1 o.ShipCity 
FROM [Order Details] as d
INNER JOIN Orders as o ON d.OrderID=o.OrderID
GROUP BY o.ShipCity ORDER BY SUM(d.Quantity) DESC) 
GROUP BY o.ShipCity order by count(*) 

--11. How do you remove the duplicates record of a table?
We can use Common Table Expression (CTE), ROW_NUMBER() and DELETE to remove the duplicates.