# Asp Labb3 API

## Get People
(GET Request) https://localhost:7059/api/people

## Get Interest By People
(GET Request)https://localhost:7059/api/interests/(Id Of Person You Want Interest From)

## Get Links By People
(GET Request) https://localhost:7059/api/Links/(Id You Want Links From)

## Connect Person To Interest
(POST Request) https://localhost:7059/api/Interests/connect

Example Request Body
{
  "personId": 2,
  "interestId": 7
}
Example Response Body
{
    "$id": "1",
    "personId": 2,
    "person": null,
    "interestId": 7,
    "interest": null
}

## Add Link To Person/Interest
(POST Request) https://localhost:7059/api/Links

Example Request Body
{
    "personId": 2,
    "interestId": 6,
    "URL": "https://testlink.org/"
}
Example Response Body
{
    "$id": "1",
    "interestLinkId": 10,
    "interestId": 6,
    "interest": null,
    "personId": 2,
    "person": null,
    "url": "https://testlink.org/"
}
