CREATE TABLE characters (
                            id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(255) NOT NULL,
                            height VARCHAR(10) DEFAULT NULL,
                            weight VARCHAR(10) DEFAULT NULL,
                            hairColor VARCHAR(255) DEFAULT NULL,
                            skinColor VARCHAR(255) DEFAULT NULL,
                            eyeColor VARCHAR(255) DEFAULT NULL,
                            birthYear VARCHAR(10) DEFAULT NULL,
                            gender VARCHAR(255) DEFAULT NULL,
                            planet_id INT DEFAULT NULL,
                            planet_title VARCHAR(255) DEFAULT NULL
);