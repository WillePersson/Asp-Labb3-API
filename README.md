# Asp Labb3 API

## Get People
(GET Request) https://localhost:7059/api/people

## Get Interest By People
(GET Request)https://localhost:7059/api/interests/(Id Of Person You Want Interest From)

## Get Links By People
(GET Request) https://localhost:7059/api/Links/(Id You Want Links From)

## Connect Person To Interest
(POST Request) https://localhost:7059/api/Interests/connect

Example Request Body<br>
{<br>
  "personId": 2,<br>
  "interestId": 7<br>
}<br>
Example Response Body<br>
{<br>
    "$id": "1",<br>
    "personId": 2,<br>
    "person": null,<br>
    "interestId": 7,<br>
    "interest": null<br>
}<br>

## Add Link To Person/Interest
(POST Request) https://localhost:7059/api/Links

Example Request Body<br>
{<br>
    "personId": 2,<br>
    "interestId": 6,<br>
    "URL": "https://testlink.org/"<br>
}<br>
Example Response Body<br>
{<br>
    "$id": "1",<br>
    "interestLinkId": 10,<br>
    "interestId": 6,<br>
    "interest": null,<br>
    "personId": 2,<br>
    "person": null,<br>
    "url": "https://testlink.org/"<br>
}<br>
