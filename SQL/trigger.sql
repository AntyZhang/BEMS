delimiter ###
create trigger after_create_ticket after 
update on flowprogress for each row
begin    
    insert into flowprogresshistory(ticketID,flowtype,step,comments,actionby,actiontime )
    values(OLD.ticketID,OLD.flowtype,OLD.CurrentFlowstep,OLD.Comments,New.LastUpdateBy,New.LastUpdateTime);
end ###
delimiter ;
