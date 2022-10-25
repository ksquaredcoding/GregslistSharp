-- Active: 1666715469942@@SG-wood-cinema-3385-6834-mysql-master.servers.mongodirector.com@3306@garbagecollector

CREATE TABLE
    IF NOT EXISTS cats(
        id INT AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(255)
    );

INSERT INTO cats (name) VALUES ("Felix");

INSERT INTO cats (name) VALUES ("Garfield");

INSERT INTO cats (name) VALUES ("Sylvester");

INSERT INTO cats (name) VALUES ("Hobbs");

INSERT INTO cats (name) VALUES ("Tony");

SELECT 8 FROM cats WHERE id = 33;

DROP TABLE cats;

UPDATE cats SET age = 1;

ALTER TABLE cats ADD COLUMN( age int DEFAULT 0 );

SELECT * FROM cats WHERE NAME LIKE "F%";

DELETE FROM cats WHERE id=5;