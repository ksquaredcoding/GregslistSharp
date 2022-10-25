-- Active: 1666715469942@@SG-wood-cinema-3385-6834-mysql-master.servers.mongodirector.com@3306@garbagecollector

CREATE TABLE
    IF NOT EXISTS jobs(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        company VARCHAR(255) NOT NULL,
        jobTitle VARCHAR(255) NOT NULL,
        hours int NOT NULL CHECK (hours >= 0),
        rate DECIMAL(10, 2) NOT NULL CHECK (rate >= 0),
        description VARCHAR(255)
    );

INSERT INTO
    jobs(
        company,
        jobTitle,
        rate,
        description
    )
VALUES (
        "KFC",
        "Chicken Slinger",
        15,
        "Don't be a chicken, sling some chicken!"
    )