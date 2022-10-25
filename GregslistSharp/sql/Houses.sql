-- Active: 1666715469942@@SG-wood-cinema-3385-6834-mysql-master.servers.mongodirector.com@3306@garbagecollector

CREATE TABLE
    IF NOT EXISTS houses(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        bedrooms int NOT NULL CHECK (bedrooms >= 0),
        bathrooms int NOT NULL CHECK (bathrooms >= 0),
        levels int NOT NULL CHECK (levels >= 0),
        year int NOT NULL CHECK (year >= 1800),
        price DECIMAL(10, 2) NOT NULL CHECK (price >= 0),
        description VARCHAR(255),
        imgUrl VARCHAR(255) DEFAULT "https://www.ftmeaderelocation.com/media/com_posthousing/images/nophoto.png"
    );

INSERT INTO
    houses(
        bedrooms,
        bathrooms,
        levels,
        year,
        price,
        description,
        imgUrl
    )
VALUES (
        2,
        1,
        1,
        1985,
        100000,
        "A sponge lived here and took great care of the place!",
        "https://qph.cf2.quoracdn.net/main-qimg-85f5070cbf14670efeaeacfc2c226774-pjlq"
    )