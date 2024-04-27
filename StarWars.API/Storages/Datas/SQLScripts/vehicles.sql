CREATE TABLE vehicles (
                          id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                          name VARCHAR(255) NOT NULL,
                          model VARCHAR(255),
                          vehicle_class VARCHAR(255),
                          manufacturer VARCHAR(255),
                          cost_in_credits VARCHAR(255),
                          length VARCHAR(255),
                          crew VARCHAR(255),
                          passengers VARCHAR(255),
                          max_atmosphering_speed VARCHAR(255),
                          cargo_capacity VARCHAR(255),
                          consumables VARCHAR(255),
                          movieId INT DEFAULT NULL,
                          characterId INT DEFAULT NULL
);
