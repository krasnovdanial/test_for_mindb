SELECT Products.name [Имя продукта], Category.name [Имя категории]
FROM Products 
LEFT JOIN ProductsCategory  ON Products.id = ProductsCategory.products_id
JOIN Category ON Category.id = ProductsCategory.category_id
ORDER BY Products.name