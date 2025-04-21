CREATE DATABASE TravelEase
USE TravelEase

-- 1. Trip Operator
CREATE TABLE Trip_Operator (
    operator_id INT PRIMARY KEY,
    password VARCHAR(100),
    email VARCHAR(100),
    joined_date DATE,
    rating FLOAT
);


Bulk insert Trip_Operator
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Trip_Operator.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Trip_Operator

-- 2. Operator Person
CREATE TABLE Operator_Person (
    operator_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    age INT,
    contact VARCHAR(20),
    FOREIGN KEY (operator_id) REFERENCES Trip_Operator(operator_id)
);

Bulk insert Operator_Person
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Operator_Person.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 3
)

select * from Operator_Person

-- 3. Operator Corporate
CREATE TABLE Operator_Corporate (
    operator_id INT PRIMARY KEY,
    company_name VARCHAR(100),
    FOREIGN KEY (operator_id) REFERENCES Trip_Operator(operator_id)
);

Bulk insert Operator_Corporate
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Operator_Corporate.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)
  
SELECT * FROM Operator_Corporate


-- 4. Trip Design
CREATE TABLE Trip_Design (
    trip_design_id INT PRIMARY KEY,
    operator_id INT,
    trip_type VARCHAR(50),
    FOREIGN KEY (operator_id) REFERENCES Trip_Operator(operator_id)
);

Bulk insert Trip_Design
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Trip_Design.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Trip_Design


-- 5. Announced Trip
CREATE TABLE Announced_Trip (
    announced_trip_id INT PRIMARY KEY,
    trip_design_id INT,
    begin_date DATE,
    end_date DATE,
    package_price FLOAT,
    cancellation_deadline DATE,
    accessibility_tags TEXT,
    max_group_size INT,
    FOREIGN KEY (trip_design_id) REFERENCES Trip_Design(trip_design_id)
);

Bulk insert Announced_Trip
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Announced_Trip.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Announced_Trip


-- 6. User
CREATE TABLE App_User (
    user_id INT PRIMARY KEY,
    email VARCHAR(100),
    joined_date DATE,
    password VARCHAR(100),
    nationality VARCHAR(50)
);


Bulk insert App_User
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\App_User.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM App_User

-- 7. Person
CREATE TABLE User_Person (
    user_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    age INT,
    contact VARCHAR(20),
    FOREIGN KEY (user_id) REFERENCES App_User(user_id)
);

Bulk insert User_Person
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\User_Person.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)
SELECT * FROM User_Person

-- 8. Corporate
CREATE TABLE User_Corporate (
    user_id INT PRIMARY KEY,
    company_name VARCHAR(100),
    FOREIGN KEY (user_id) REFERENCES App_User(user_id)
);

Bulk insert User_Corporate
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\User_Corporate.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)
SELECT * FROM User_Corporate


-- 9. Booking
CREATE TABLE Booking (
    booking_id INT PRIMARY KEY,
    announced_trip_id INT,
    user_id INT,
    status VARCHAR(50), -- TODO: COMPLETE THIS ==> CHECK (status IN ('Confirmed', 'Cancelled', 'Pending'))	
    budget_per_user FLOAT,
    payment_status VARCHAR(50),
    payment_method VARCHAR(50),
    FOREIGN KEY (announced_trip_id) REFERENCES Announced_Trip(announced_trip_id),
    FOREIGN KEY (user_id) REFERENCES App_User(user_id)
);



Bulk insert Booking
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Booking.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)
SELECT * FROM Booking



-- 10. Trip_Group
CREATE TABLE Trip_Group (
    group_member_id INT PRIMARY KEY,
    booking_id INT,
    name VARCHAR(50),
    age INT,
    FOREIGN KEY (booking_id) REFERENCES Booking(booking_id)
);

Bulk insert Trip_Group
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Trip_Group.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)
SELECT * FROM Trip_Group




-- 11. Itinerary
CREATE TABLE Itinerary (
    trip_design_id INT,
    order_id INT,
    location VARCHAR(100),
    stay_days INT,
    rating FLOAT,
    add_date DATE,
    PRIMARY KEY (trip_design_id, order_id),
    FOREIGN KEY (trip_design_id) REFERENCES Trip_Design(trip_design_id)
);

Bulk insert Itinerary
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Itinerary.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)
SELECT * FROM Itinerary



-- 12. Transport Provider
CREATE TABLE Transport_Provider (
    transporter_id INT PRIMARY KEY,
    name VARCHAR(100),
    gov_registration VARCHAR(50),
    email VARCHAR(100),
    contact_no VARCHAR(20),
    rating FLOAT
);

Bulk insert Transport_Provider
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Transport_Provider.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)
SELECT * FROM Transport_Provider



-- 13. Transport Vehicle
CREATE TABLE Transport_Vehicle (
    registration_no VARCHAR(50) PRIMARY KEY,
    transporter_id INT,
    pricing FLOAT,
    capacity INT,
    FOREIGN KEY (transporter_id) REFERENCES Transport_Provider(transporter_id)
);

Bulk insert Transport_Vehicle
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Transport_Vehicle.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Transport_Vehicle


-- 14. Transport Route
CREATE TABLE Transport_Route (
    announced_trip_id INT,
    registration_no VARCHAR(50),
    from_order_id INT,
    to_order_id INT,
    actual_departure_time DATETIME,
    planned_departure_time DATETIME,
    planned_arrival_time DATETIME,
    actual_arrival_time DATETIME,
    PRIMARY KEY (announced_trip_id, registration_no),
    FOREIGN KEY (announced_trip_id) REFERENCES Announced_Trip(announced_trip_id),
    FOREIGN KEY (registration_no) REFERENCES Transport_Vehicle(registration_no)
);

Bulk insert Transport_Route
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Transport_Route.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Transport_Route

-- 15. Hotel Provider
CREATE TABLE Hotel_Provider (
    hotel_id INT PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100),
    contact_no VARCHAR(20),
    location VARCHAR(100),
    rating FLOAT,
    gov_registration VARCHAR(50)
);


Bulk insert Hotel_Provider
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Hotel_Provider.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Hotel_Provider


-- 16. Room
CREATE TABLE Room (
    room_no INT,
    hotel_id INT,
    type VARCHAR(50),
    price FLOAT,
    status VARCHAR(50),
    rating FLOAT,
    PRIMARY KEY (room_no, hotel_id),
    FOREIGN KEY (hotel_id) REFERENCES Hotel_Provider(hotel_id)
);

Bulk insert Room
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Room.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Room

-- 17. Activity Provider
CREATE TABLE Activity_Provider (
    activity_provider_id INT PRIMARY KEY,
    type VARCHAR(100),
    price FLOAT,
    rating FLOAT
);

Bulk insert Activity_Provider
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Activity_Provider.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Activity_Provider



-- 18. Tour Guide
CREATE TABLE Tour_Guide (
    guide_id INT PRIMARY KEY,
    name VARCHAR(100),
    rating FLOAT
);

Bulk insert Tour_Guide
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Tour_Guide.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Tour_Guide


-- 19. Stay
CREATE TABLE Stay (
    announced_trip_id INT,
    order_id INT,
    hotel_id INT,
    PRIMARY KEY (announced_trip_id, order_id, hotel_id),
    FOREIGN KEY (announced_trip_id) REFERENCES Announced_Trip(announced_trip_id),
    FOREIGN KEY (hotel_id) REFERENCES Hotel_Provider(hotel_id)
);

Bulk insert Stay
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Stay.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Stay


-- 20. Stay_Guide
CREATE TABLE Stay_Guide (
    announced_trip_id INT,
    order_id INT,
    guide_id INT,
    PRIMARY KEY (announced_trip_id, order_id, guide_id),
    FOREIGN KEY (announced_trip_id) REFERENCES Announced_Trip(announced_trip_id),
    FOREIGN KEY (guide_id) REFERENCES Tour_Guide(guide_id)
);

Bulk insert Stay_Guide
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Stay_Guide.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Stay_Guide


-- 21. Stay_Activity
CREATE TABLE Stay_Activity (
    announced_trip_id INT,
    order_id INT,
    activity_provider_id INT,
    PRIMARY KEY (announced_trip_id, order_id, activity_provider_id),
    FOREIGN KEY (announced_trip_id) REFERENCES Announced_Trip(announced_trip_id),
    FOREIGN KEY (activity_provider_id) REFERENCES Activity_Provider(activity_provider_id)
);


Bulk insert Stay_Activity
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Stay_Activity.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

SELECT * FROM Stay_Activity


-- 22. Inquiry (TODO: REGENERATE INQUIRY TABLE)
CREATE TABLE Inquiry (
    inquiry_id INT PRIMARY KEY,
    user_id INT,
    operator_id INT,
    operator_response TEXT,
    user_inquiry TEXT,
    inquiry_generated_time DATETIME,
    response_time DATETIME,
    user_inquiry_time DATETIME,
    FOREIGN KEY (user_id) REFERENCES AppUser(user_id),
    FOREIGN KEY (operator_id) REFERENCES Trip_Operator(operator_id)
);

Bulk insert Inquiry
from 'E:\semester4\DB\project\TravelEase\TravelEase Project\Data\Inquiry.csv'
with
(
FORMAT = 'csv',
FIELDTERMINATOR = ',',
ROWTERMINATOR = '0x0a',
FIRSTROW = 2
)

-- 23 Admin TODO: admin needs to be added
CREATE TABLE Admin (
    admin_id INT PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    password VARCHAR(100),
    role VARCHAR(50) -- e.g., 'superadmin', 'moderator'
);

SELECT * FROM Inquiry


SELECT * FROM Trip_Operator;
SELECT * FROM Operator_Person;
SELECT * FROM Operator_Corporate;
SELECT * FROM Trip_Design;
SELECT * FROM Announced_Trip;
SELECT * FROM App_User;
SELECT * FROM User_Person;
SELECT * FROM User_Corporate;
SELECT * FROM Booking;
SELECT * FROM Trip_Group;
SELECT * FROM Itinerary;
SELECT * FROM Transport_Provider;
SELECT * FROM Transport_Vehicle;
SELECT * FROM Transport_Route;
SELECT * FROM Hotel_Provider;
SELECT * FROM Room;
SELECT * FROM Activity_Provider;
SELECT * FROM Tour_Guide;
