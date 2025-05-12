-- Inserting a new trip design to experiment with the TripDetail, TripItinerary procs
insert into Trip_Operator values
(89,'123','saleem@89',GETDATE(), 96)

select * from Trip_Design where trip_design_id = 81
select * from Itinerary where trip_design_id = 81
insert into Trip_Design values
(81,89,'TestTrip')

insert into Itinerary values
(81,0,'Murree',1,4,'2024-04-16'),
(81,1,'Swat',3,4.3,'2024-04-16'),
(81,2,'Gilgit',2,4.8,'2024-04-16')

insert into Itinerary values
(81,3,'Swat',1,4.8,'2025-05-9'),
(81,4,'Murree',1,4.8,'2025-05-9')


Select * from Announced_Trip where announced_trip_id = (Select max(announced_trip_id) from Announced_Trip)

insert into Announced_Trip values
(51,81,'2024-09-09','2024-09-15', 4000, '2024-09-05','MustafaSaleem',4)

insert into Announced_Trip values
(52,81,'2025-09-09','2025-09-15', 7500, '2025-09-05','PhirSeMustafaSaleem',4)

----------------------------------------------------