SELECT p.Name productName, c.Name categoryName
	FROM Product p
	LEFT JOIN ProductInCategory pic ON pic.ProductId = p.Id
	LEFT JOIN Category c ON c.Id = pic.CategoryId