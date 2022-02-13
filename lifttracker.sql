create database lifttracker;

create table lifttracker.users
(
	userId int not null auto_increment primary key,
    username varchar(20),
    `password` varchar(20),
    displayName varchar(50)
);

create table lifttracker.lifts
(
	liftId int not null auto_increment primary key,
    liftName varchar(50),
    bodyPart varchar(30),
    liftWeight float,
    liftDate date,
    sets int,
    reps int,
    notes varchar(1000),
    userId int,
    foreign key (userId) references lifttracker.users(userId)
);

create table lifttracker.journals
(
	entryId int not null auto_increment primary key,
    entry varchar(1000),
    userId int,
    foreign key (userId) references lifttracker.users(userId)
);

create table lifttracker.meals
(
	mealId int not null auto_increment primary key,
    mealDate date,
    servingsProtein float,
    servingsCarb float,
    servingsFat float,
    servingsVeggie float,
    mealType varchar(30),
    wasTemplate bit,
    userId int,
    foreign key (userId) references lifttracker.users(userId)
);

create table lifttracker.measurements
(
	measId int not null auto_increment primary key,
    measDate date,
    weight float,
    waist float,
    chest float,
    fupa float,
    hip float,
    arm float,
    leg float,
    notes varchar(500),
    userId int,
    foreign key (userId) references lifttracker.users(userId)
);

create table lifttracker.workouts
(
	workoutId int not null auto_increment primary key,
    workoutDate date,
    workoutDescription varchar(150),
    workoutNotes varchar(1000)
);

create table lifttracker.workoutslifts
(
	wlId int not null auto_increment primary key,
    workoutId int,
    liftId int,
    foreign key (workoutId) references workouts(workoutId),
    foreign key (liftId) references lifts(liftId)
);

create table lifttracker.records(
	recordId int not null auto_increment primary key,
    recordDate date,
    liftName varchar(50),
    weight float
);