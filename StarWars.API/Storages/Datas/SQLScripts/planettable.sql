CREATE TABLE planet (
                        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                        name VARCHAR(255) NOT NULL,
                        rotationPeriod VARCHAR(255) NOT NULL,
                        orbitalPeriod VARCHAR(255) NOT NULL,
                        diameter VARCHAR(255) NOT NULL,
                        climate VARCHAR(255) NOT NULL,
                        gravity VARCHAR(255) NOT NULL,
                        terrain VARCHAR(255) NOT NULL,
                        surfaceWater VARCHAR(255) NOT NULL,
                        population VARCHAR(255) DEFAULT NULL,
                        characterId INT DEFAULT NULL,
                        character_title VARCHAR(255) DEFAULT NULL,
                        movieId INT DEFAULT NULL,
                        movie_title VARCHAR(255) DEFAULT NULL

)