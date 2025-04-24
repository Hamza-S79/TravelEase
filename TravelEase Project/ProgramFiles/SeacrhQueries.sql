Select * from Announced_Trip A
JOIN Itinerary I on I.trip_design_id = A.trip_design_id
where I.location like '%Bali'

Select * from Announced_Trip A
join Itinerary I on I.trip_design_id = A.trip_design_id
where A.trip_design_id = 42  