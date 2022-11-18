USE master;

GO
	DROP DATABASE IF exists Chess
	CREATE DATABASE Chess

GO
	DROP TABLE IF exists Chess.dbo.users
	Create table Chess.dbo.users(
		id INT NOT NULL,
		CONSTRAINT PK_users_id PRIMARY KEY CLUSTERED (id),
		name VARCHAR(20) NOT NULL,
	)

GO
DROP TABLE IF exists Chess.dbo.scores
Create table Chess.dbo.scores(
	id INT NOT NULL,
	CONSTRAINT PK_scores_id PRIMARY KEY CLUSTERED (id),
	results INT NULL,
	users_id INT FOREIGN KEY REFERENCES Chess.dbo.users(id),
)
