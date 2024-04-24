CREATE TABLE spaceships (
                            id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(255) NOT NULL,
                            model VARCHAR(255) DEFAULT NULL,
                            manufacturer VARCHAR(255) DEFAULT NULL,
                            costInCredits INT DEFAULT NULL,
                            length VARCHAR(10) DEFAULT NULL,
                            maxSpeed VARCHAR(10) DEFAULT NULL,
                            crew INT DEFAULT NULL,
                            passengers INT DEFAULT NULL,
                            cargoCapacity INT DEFAULT NULL,
                            hyperdriveRating DECIMAL(2,1) DEFAULT NULL,
                            mglt INT DEFAULT NULL,
                            consumables VARCHAR(10) DEFAULT NULL,
                            class VARCHAR(255) DEFAULT NULL
);