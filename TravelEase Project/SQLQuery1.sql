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
    status VARCHAR(50), --CHECK (status IN ('Confirmed', 'Cancelled', 'Pending'))	
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

-- 11. Itinerary
CREATE TABLE Itinerary (
    trip_design_id INT,
    order_id INT,
    location VARCHAR(100),
    stay_days INT,
    rating FLOAT,
    add_date DATE,
    PRIMARY KEY (trip_design_id, order_id),
    FOREIGN KEY (trip_design_id) REFERENCES TripDesign(trip_design_id)
);

-- 12. Transport Provider
CREATE TABLE TransportProvider (
    transporter_id INT PRIMARY KEY,
    name VARCHAR(100),
    gov_registration VARCHAR(50),
    email VARCHAR(100),
    contact_no VARCHAR(20),
    rating FLOAT
);

-- 13. Transport Vehicle
CREATE TABLE TransportVehicle (
    registration_no VARCHAR(50) PRIMARY KEY,
    transporter_id INT,
    pricing FLOAT,
    capacity INT,
    FOREIGN KEY (transporter_id) REFERENCES TransportProvider(transporter_id)
);

-- 14. Transport Route
CREATE TABLE TransportRoute (
    announced_trip_id INT,
    registration_no VARCHAR(50),
    from_order_id INT,
    to_order_id INT,
    actual_departure_time DATETIME,
    planned_departure_time DATETIME,
    planned_arrival_time DATETIME,
    actual_arrival_time DATETIME,
    PRIMARY KEY (announced_trip_id, registration_no),
    FOREIGN KEY (announced_trip_id) REFERENCES AnnouncedTrip(announced_trip_id),
    FOREIGN KEY (registration_no) REFERENCES TransportVehicle(registration_no)
);

-- 15. Hotel Provider
CREATE TABLE HotelProvider (
    hotel_id INT PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100),
    contact_no VARCHAR(20),
    location VARCHAR(100),
    rating FLOAT,
    gov_registration VARCHAR(50)
);

-- 16. Room
CREATE TABLE Room (
    room_no INT,
    hotel_id INT,
    type VARCHAR(50),
    price FLOAT,
    status VARCHAR(50),
    rating FLOAT,
    PRIMARY KEY (room_no, hotel_id),
    FOREIGN KEY (hotel_id) REFERENCES HotelProvider(hotel_id)
);

-- 17. Tour Guide
CREATE TABLE TourGuide (
    guide_id INT PRIMARY KEY,
    name VARCHAR(100),
    rating FLOAT
);

-- 18. AnnouncedTrip_Hotel
CREATE TABLE AnnouncedTripHotel (
    announced_trip_id INT,
    order_id INT,
    hotel_id INT,
    PRIMARY KEY (announced_trip_id, order_id, hotel_id),
    FOREIGN KEY (announced_trip_id) REFERENCES AnnouncedTrip(announced_trip_id),
    FOREIGN KEY (hotel_id) REFERENCES HotelProvider(hotel_id)
);

-- 19. Stay_Guide
CREATE TABLE Stay_Guide (
    announced_trip_id INT,
    order_id INT,
    guide_id INT,
    PRIMARY KEY (announced_trip_id, order_id, guide_id),
    FOREIGN KEY (announced_trip_id) REFERENCES AnnouncedTrip(announced_trip_id),
    FOREIGN KEY (guide_id) REFERENCES TourGuide(guide_id)
);

-- 20. Stay
CREATE TABLE Stay (
    announced_trip_id INT,
    order_id INT,
    activity_provider_id INT,
    PRIMARY KEY (announced_trip_id, order_id, activity_provider_id),
    FOREIGN KEY (announced_trip_id) REFERENCES AnnouncedTrip(announced_trip_id),
    FOREIGN KEY (activity_provider_id) REFERENCES ActivityProvider(activity_provider_id)
);

-- 21. Activity Provider
CREATE TABLE ActivityProvider (
    activity_provider_id INT PRIMARY KEY,
    type VARCHAR(100),
    price FLOAT,
    rating FLOAT
);

-- 22. Inquiry
CREATE TABLE Inquiry (
    inquiry_id INT PRIMARY KEY,
    operator_id INT,
    user_id INT,
    operator_response TEXT,
    user_inquiry TEXT,
    inquiry_generated_time DATETIME,
    response_time DATETIME,
    user_inquiry_time DATETIME,
    FOREIGN KEY (user_id) REFERENCES AppUser(user_id),
    FOREIGN KEY (operator_id) REFERENCES Trip_Operator(operator_id)
);
