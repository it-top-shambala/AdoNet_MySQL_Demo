classDiagram
direction BT
class table_accounts {
   varchar(20) login
   varchar(20) password
   tinyint(1) is_delete
   int account_id
}
class table_users {
   text first_name
   text last_name
   int user_id
}

table_users  -->  table_accounts : user_id:account_id
