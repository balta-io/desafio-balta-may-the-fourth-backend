CREATE TABLE vehicles (
                          id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                          name VARCHAR(255) NOT NULL,
                          model VARCHAR(255)DEFAULT NULL,
                          manufacturer VARCHAR(255) DEFAULT NULL,
                          costInCredits INT DEFAULT NULL,
                          length VARCHAR(50)DEFAULT NULL,
                          maxSpeed VARCHAR(50)DEFAULT NULL,
                          crew INT DEFAULT NULL,
                          passengers INT DEFAULT NULL,
                          cargoCapacity VARCHAR(50) DEFAULT NULL,
                          consumables VARCHAR(50) DEFAULT NULL,
                          class VARCHAR(50) DEFAULT NULL
);