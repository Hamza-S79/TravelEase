Select * from Announced_Trip A
where A.accessibility_tags like '%wheel%'

Select * from Announced_Trip A
join Itinerary I on I.trip_design_id = A.trip_design_id
where A.trip_design_id = 42  