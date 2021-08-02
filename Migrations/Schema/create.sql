CREATE SEQUENCE IF NOT EXISTS public.migration_id_migration
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    NO MAXVALUE
    CACHE 1;

CREATE TABLE IF NOT EXISTS migration (
	id_migration INTEGER DEFAULT nextval('public.migration_id_migration'::regclass) NOT NULL,
	major INTEGER NOT NULL,
	minor INTEGER NOT NULL,
	"source" VARCHAR(150) 
);

CREATE SEQUENCE IF NOT EXISTS public.user_id_user
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    NO MAXVALUE
    CACHE 1;

CREATE TABLE IF NOT EXISTS "user" (
    user_id        INTEGER DEFAULT nextval('public.user_id_user'::regclass) NOT NULL,
    first_name     VARCHAR(50) NOT NULL,
    last_name      VARCHAR(50) NOT NULL,
    date_of_birth  DATE NOT NULL,
    city           VARCHAR(25) NOT NULL,
    district       VARCHAR(30) NOT NULL,
    phone_number   VARCHAR(15) NOT NULL,
	
	CONSTRAINT pk_user_id PRIMARY KEY ( user_id )
);

CREATE TABLE IF NOT EXISTS user_credentials (
    user_credentials_id INTEGER NOT NULL,
    email     VARCHAR(50) NOT NULL,
    password  VARCHAR(50) NOT NULL,
    user_id   INTEGER NOT NULL,
	
	CONSTRAINT pk_user_credentials PRIMARY KEY ( user_credentials_id ),
	CONSTRAINT fk_user_credentials_user FOREIGN KEY ( user_id ) REFERENCES "user" ( user_id )
);

CREATE UNIQUE INDEX user_credentials__idx ON
    user_credentials (
        user_id
    ASC );
