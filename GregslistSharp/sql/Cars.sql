-- Active: 1666715469942@@SG-wood-cinema-3385-6834-mysql-master.servers.mongodirector.com@3306@garbagecollector

CREATE TABLE
    IF NOT EXISTS cars(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        make VARCHAR(255) NOT NULL,
        model VARCHAR(255) NOT NULL,
        year int NOT NULL CHECK (year >= 1886),
        price DECIMAL(10, 2) NOT NULL CHECK (price >= 0),
        description VARCHAR(255),
        imgUrl VARCHAR(255) DEFAULT "https://www.autolist.com/assets/listings/default_car.jpg"
    );

INSERT INTO
    cars(
        make,
        model,
        year,
        price,
        description,
        imgUrl
    )
VALUES (
        "KFC",
        "Bucket Trés",
        1985,
        999,
        "Yum Yum!!",
        "https://www.comunicaffe.com/wp-content/uploads/2020/12/KFC_self_driving_car.jpg"
    )
SELECT *
FROM cars;

DROP TABLE cars;

DELETE from cars WHERE id = 1;

UPDATE cars
SET
    make = @make,
    model = @model,
    year = @year,
    price = @price,
    imgUrl = @imgUrl,
    description = @description
WHERE id = @id;