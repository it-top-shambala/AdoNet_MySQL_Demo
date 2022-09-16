CREATE TABLE table_accounts (
    account_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    login VARCHAR(20) NOT NULL UNIQUE,
    password VARCHAR(20) NOT NULL,
    is_delete BOOL NOT NULL DEFAULT FALSE
);

CREATE TABLE table_users (
    user_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES table_accounts(account_id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

INSERT INTO table_accounts(login, password)
    VALUE ('user', '123');
INSERT INTO table_users(first_name, last_name)
    VALUE ('Anonim', 'Anonimus');

/*
SELECT login, password
FROM table_accounts
WHERE is_delete = FALSE;

SELECT last_name, first_name
FROM table_users;

SELECT last_name, first_name,
       login, password
FROM table_users
JOIN table_accounts
    ON table_users.user_id = table_accounts.account_id
WHERE is_delete = FALSE;
*/