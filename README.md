# TianyuanDeng.TaskManagement

This project was a BackEnd of Task Management system.

# API

There have 3 API controller. 
||Task| TasksHistory | User
|--|-------- | ----- | ------
|GET All| /api/Tasks/all |/api/TasksHistory/{id} |/api/User/all
|GET| /api/Tasks/{id} |/api/TasksHistory/{id} |/api/User/{id}
|POST|/api/Tasks |/api/TasksHistory |/api/User
|Put|/api/Tasks |/api/TasksHistory |/api/User
|Delete|/api/Tasks/delete(Json)| /api/TasksHistory/{id} |  /api​/User​/{id}

For the user delete, it's using url directly.
But for the tasks which is using Json to delete. 

