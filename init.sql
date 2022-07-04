create database actorsdb;
\c actorsdb;
drop table if exists actors;
create table actors
(
  name     varchar(100) not null,
  actor_id varchar(100) not null
);

INSERT INTO actors
(name, actor_id)
VALUES('Chris Hemsworth', 'nm1165110'),
('Natalie Portman', 'nm0000204');