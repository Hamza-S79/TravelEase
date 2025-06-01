use TravelEase

Create or Alter Procedure UpcomingTrips
as
Begin

Select * from Announced_Trip where begin_date >= GETDATE()

end


Create or alter Procedure ActiveTrips @id INT
as
Begin
Select * from Announced_Trip a join Booking b on a.announced_trip_id = b.announced_trip_id where b.user_id = @id and a.begin_date <= GETDATE() and a.end_date >=GETDATE()
End

Exec ActiveTrips 31

-- this is for getting the first and last location in a trip design to show on trips list
Create or Alter Procedure FirstLast @id INT
as
Begin

select res.loc, res.oi from (
Select top (1) i.location as loc, order_id as oi from Itinerary i
join Announced_Trip a on i.trip_design_id = a.trip_design_id
where a.announced_trip_id = @id and a.begin_date > i.add_date
order by i.order_id asc
) as res
Union
Select ref.loc, ref.oi from(
Select top (1) i.location as loc, order_id as oi from Itinerary i
join Announced_Trip a on i.trip_design_id = a.trip_design_id
where a.announced_trip_id = @id and a.begin_date > i.add_date
order by i.order_id desc
)as ref

End


--Self Explanatory
Create or alter Procedure FeaturedTrips
as
begin
Select top 5 * from Announced_trip order by announced_trip_id desc
end

--For Trip Information

create or alter function getTripOpId (@trip_id INT)
returns INT
as
begin
return (Select top 1 o.operator_id from Announced_Trip i join Trip_Design t on t.trip_design_id = i.trip_design_id join Trip_Operator o on o.operator_id = t.operator_id
where i.announced_trip_id = @trip_id)
end


create or alter procedure TripDetails @trip_id INT
as
begin
if (dbo.IfPersonOperator(dbo.getTripOpId(@trip_id)) = 1)
begin
Select i.*,o.operator_id, p.first_name +' '+ p.last_name as op_name  from Announced_Trip i join Trip_Design t on t.trip_design_id = i.trip_design_id join Trip_Operator o on o.operator_id = t.operator_id join Operator_Person p on p.operator_id= o.operator_id
where i.announced_trip_id = @trip_id
end

else
begin
Select i.*,o.operator_id, p.company_name as op_name  from Announced_Trip i join Trip_Design t on t.trip_design_id = i.trip_design_id join Trip_Operator o on o.operator_id = t.operator_id join Operator_Corporate p on p.operator_id= o.operator_id
where i.announced_trip_id = @trip_id
end

end

--For TripDetails Page 
create or alter procedure TripItineraries @ann_id INT
as 
begin
Select * from Itinerary i
join Announced_Trip a on i.trip_design_id = a.trip_design_id
where a.announced_trip_id = @ann_id and a.begin_date > i.add_date
order by i.order_id asc

end


create or alter procedure TripType @ann_id INT
as 
begin
Select trip_type from Trip_Design where trip_design_id = (select trip_design_id from Announced_Trip where announced_trip_id = @ann_id)
end


create or alter procedure searchResult @st VARCHAR(255)
as begin
Select * from Announced_Trip where
announced_trip_id in 
(Select announced_trip_id from Announced_Trip a 
join Itinerary i on a.trip_design_id = i.trip_design_id 
join Trip_Design t on t.trip_design_id = a.trip_design_id
where i.location like @st
or t.trip_type like @st
or a.accessibility_tags like @st
)
end



create or alter Procedure UserAuth @name VARCHAR(255), @pass VARCHAR(255)
as
Begin
Select top 1 * from App_User where email = @name and password = @pass 

end


create or alter Function IfPersonTrav (@id INT)
returns bit
as Begin
If exists (Select * from User_Person where user_id = @id)
begin
 return 1
end
return 0 
end



create or alter Function IfPersonOperator (@id INT)
returns bit
as Begin
If exists (Select * from Operator_Person where operator_id = @id)
begin
 return 1
end
return 0 
end


create or alter Procedure getInfo @u_id INT
as
Begin
If (dbo.IfPersonTrav(@u_id) = 1)
begin
 Select * from User_Person u join App_User a on a.user_id = u.user_id where u.user_id = @u_id
end

else
begin
 Select * from User_Corporate u join App_User a on a.user_id = u.user_id where u.user_id = @u_id
end
End


--Procedures for Booking IDs

create or alter function checkEmailTrav(@email varchar(255))
returns BIT
as begin
if exists (Select @email from App_User where @email = email)
begin
return 1
end

return 0 
end


create or alter procedure BookUserPerson @email VARCHAR(100), @password VARCHAR(100), @nationality VARCHAR(50), @firstn VARCHAR(50), @lastn VARCHAR(50), @age INT, @cont VARCHAR(20)
as
begin
Declare @newID INT = (Select max(user_id) from App_User) + 1
Declare @joinDate DATE = GETDATE()

Begin Transaction

if (dbo.checkEmailTrav(@email) = 0)
begin
Insert into App_User Values(@newID,@email,@joinDate, @password, @nationality)
Insert into User_Person Values(@newID, @firstn, @lastn, @age, @cont)
end
Commit
end
--##########################



Select * from Booking where user_id = 81

Select * from App_User

Select dbo.IfPersonTrav(81)

exec getInfo 1
exec UserAuth 'user16@example.com', 'pass016'
exec searchResult '%Advent%'
exec TripType 49
exec FirstLast 18
exec TripDetails 1
select dbo.getTripOpId(30)
exec TripItineraries 49
exec UpcomingTrips


Select * from App_User a join User_Person u on a.user_id= u.user_id 
Select * from Announced_Trip
Select * from Trip_Design
Select * from Trip_Operator
Select * from Operator_Person
Select * from Operator_Corporate
insert into Operator_Person Values (89,'Mustafa', 'Saleem', 21, '+92-333-3333333')
insert into Operator_Person Values (1,'Alice', 'Johnson', 28, '+44-33-3333-3333')