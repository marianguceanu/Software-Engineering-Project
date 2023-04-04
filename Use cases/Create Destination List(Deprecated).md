## ID:1

## Create Destination List

| **Primary actor** | **Secondary actor** | **Description**                                                                      | **Trigger**                   | **Precondition**                                               | **Postcondition**                    |
| :---------------: | :-----------------: | ------------------------------------------------------------------------------------ | ----------------------------- | -------------------------------------------------------------- | ------------------------------------ |
|       Admin       |          -          | A destination list is needed to handle and better manage all of the data of the app. | Base functionality of the app | At least one destination is available, one user and one admin. | The admin is able to manage the list |

|      **Normal flow**      | **Alternative flow**            | **Exception**                                |
| :-----------------------: | ------------------------------- | -------------------------------------------- |
| Create a destination list | Create a public destination     | The destination is not valid                 |
|             -             | Add the destination to the list | The destination was not created yet          |
|             -             | Modify destination              | The new data of the destination is not valid |
|             -             | Remove destination              | The destination is not in the list           |
