Задание №2

1 запрос:
select 
    c.client_name, 
    COUNT(cc.id) AS contact_count
from clients c
left join client_contacts cc ON c.id = cc.client_id
group by c.client_name;

2 запрос:
select 
    c.client_name
from clients c
join client_contacts cc ON c.id = cc.client_id
group by c.client_name
having COUNT(cc.id) > 2;
