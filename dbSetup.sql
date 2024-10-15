CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE IF NOT EXISTS chores (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    NAME VARCHAR(255) NOT NULL,
    DESCRIPTION VARCHAR(255),
    IsComplete BOOLEAN DEFAULT FALSE,
    BrowniePoints SMALLINT UNSIGNED DEFAULT 0
)

INSERT INTO
    chores (
        name,
        description,
        IsComplete,
        BrowniePoints
    )
VALUES (
        "Walk Angel",
        "The 20 foot bulldog that Dad still keeps around, don't worry she doesn't bite",
        FALSE,
        10000
    )