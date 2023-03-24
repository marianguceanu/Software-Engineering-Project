# **Software Engineering Project**

## **Destination Bucket List** - This is an app that allows people to create a personal private vacation destinations bucket list.

## **_Requirements_**

<!-- TODO - Requirement 1 -->

**_1._** **A vacation destination is a place with a geolocation, title, image, description, stay dates.**

<!-- TODO - Requirement 2 -->

**_2._** **There is a public list of destinations managed by an admin.** _(Use case: Create Destination List)_

- **_2.1._** Create a public destination. _(Sub use case: Create Public Destination)_
- **_2.1._** Add a vacation destination to the public list . _(Sub use case: Add Destination To List)_
- **_2.2._** Remove a vacation destination from the public list. _(Sub use case: Remove Destination From List)_
- **_2.3._** Modify a vacation destination from the public list. _(Sub use case: Modify Destination From List)_

<!-- TODO - Requirement 3 -->

**_3._** **Bucket list is private, each user should be able to register and add public items or create new ones private.**

<!-- TODO - Requirement 4 -->

**_4._** **User should be able to manage items, including removal.** _(Use case: Create Bucket List)_

- **_4.1._** Create a private vacation destination. _(Sub use case: Create Private Destination)_
- **_4.2._** Add a public vacation destination to the bucket list. _(Sub usecase: Add Destination To Bucket List)_
- **_4.3._** Add a private vacation destination to the bucket list. _(Sub use case: Add Private Destination To Bucket List)_
- **_4.4._** Remove a vacation destination from the bucket list. _(Sub use case: Remove Destination From Bucket List)_
- **_4.5._** Modify a vacation destination from the bucket list. _(Sub use case: Modify Destination From Bucket List)_

<!-- TODO - Requirement 5 -->

**_5._** **Desktop app or web app.** _(Use case: Develop Application)_

- **_5.1._** Implement the backend of the application using a REST API. _(Sub use case: Implement Backend)_
- **_5.1._** Implement the frontend of the application using a framework. _(Sub use case: Implement Frontend)_

<!-- TODO - Requirement 6 -->

**_6._** **Propose friendly display of items and ways to manage them.** _(Use case: Display Items)_

- **_6.1._** Display items in a list, sorted alphabetically.

<!-- TODO - Requirement 7 -->

**_7._** **Users can cancel their account (GDPR) or modify it.** _(Use case: Manage Account)_

- **_7.1._** Create account. _(Sub use case: Create Account)_
- **_7.1_** Modify account information. _(Sub use case: Modify Account)_
- **_7.2_** Delete account. _(Sub use case: Delete Account)_

## <!-- Make a table with all of the uses cases, having an ID, and their sub use cases -->

| **_Use case_**                 | **_Actors_** |
| ------------------------------ | ------------ |
| Add Destination                | Admin        |
| Modify Destination             | Admin        |
| Remove Destination             | Admin        |
| Add Public Destination         | User         |
| Add Private Destination        | User         |
| Modifiy Destination            | User         |
| Remove Destination             | User         |
| Display items                  | User, Admin  |
| Create Account                 | User         |
| Modify Account                 | User         |
| Remove Account (Automatically) | User         |

<!-- TODO - add private destination to public list wihtout stay dates AltFLow -->
