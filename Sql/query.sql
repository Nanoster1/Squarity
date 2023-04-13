CREATE TABLE products(id INTEGER PRIMARY KEY, name VARCHAR(100));
CREATE TABLE categories(id INTEGER PRIMARY KEY, name VARCHAR(100));
CREATE TABLE products_categories(
    product_id INTEGER FOREIGN KEY REFERENCES products(id),
    category_id INTEGER FOREIGN KEY REFERENCES categories(id),
    PRIMARY KEY (product_id, category_id)
);
INSERT INTO products
VALUES (1, 'IKEA Table'),
    (2, 'IKEA Chair'),
    (3, 'Audi A8'),
    (4, 'TESLA'),
    (5, 'IPhone 25'),
    (6, 'Thing');
INSERT INTO categories
VALUES (1, 'Furniture'),
    (2, 'Car'),
    (3, 'Technic');
INSERT INTO products_categories
VALUES (1, 1),
    (2, 1),
    (3, 2),
    (4, 2),
    (4, 3),
    (5, 3);
SELECT p.name AS 'Product Name',
    ISNULL(c.name, 'No category :(') AS 'Category Name'
FROM products AS p
    LEFT JOIN products_categories AS pc ON pc.product_id = p.id
    LEFT JOIN categories AS c ON pc.category_id = c.id;