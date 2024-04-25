CREATE TABLE movies (
					id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                    title VARCHAR(255) NOT NULL,
                    episode INT DEFAULT NULL,
                    openingCrawl VARCHAR(10) DEFAULT NULL,
                    director VARCHAR(255) DEFAULT NULL,
                    producer VARCHAR(255) DEFAULT NULL,
                    releaseDate VARCHAR(255) DEFAULT NULL,
)
