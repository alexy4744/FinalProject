# Final Project

## Getting Started

1. Clone the repository
2. Make sure the connection string for MySQL is correct in `appsettings.json` and `appsettings.Development.json`
3. Run the migration SQL script on MySQL
4. Run the application

## API Documentation

### /Recipes

#### POST

##### Payload
```json
{
  "description": "Easy to make sugar cookies.",
  "ingredients": [
    {
      "description": "2 cups all-purpose flour",
      "name": "All-purpose flour",
      "quantity": 2
    },
    {
      "description": "1 teaspoon baking soda",
      "name": "Baking soda",
      "quantity": 1
    }
  ],
  "name": "Sugar Cookies",
  "steps": [
    "Preheat oven to 375 degrees",
    "Mix flour, baking soda, and baking powder"
  ]
}
```

##### Responses

| Code | Description                              |
| ---- |------------------------------------------|
| 200 | The recipe that was successfully created |

```json
{
  "result": {
    "description": "Easy to make sugar cookies.",
    "ingredients": [
      {
        "description": "3 cups of all-purpose flour",
        "name": "All-purpose flour",
        "quantity": 3
      },
      {
        "description": "1 teaspoon of baking soda",
        "name": "Baking soda",
        "quantity": 1
      }
    ],
    "name": "Sugar Cookies",
    "steps": [
      "Preheat oven to 375 degrees",
      "Mix flour, baking soda, and baking powder"
    ]
  },
  "statusCode": 201,
  "statusDescription": "Recipe 'Sugar Cookies' was created successfully."
}
```

#### GET

##### Responses

| Code | Description                   |
| ---- |-------------------------------|
| 200 | A list of all created recipes |

```json
{
  "result": [
    {
      "description": "Easy to make sugar cookies.",
      "ingredients": [
        {
          "description": "2 cups all-purpose flour",
          "name": "All-purpose flour",
          "quantity": 2
        },
        {
          "description": "1 teaspoon baking soda",
          "name": "Baking soda",
          "quantity": 1
        }
      ],
      "name": "Sugar Cookies",
      "steps": [
        "Preheat oven to 375 degrees",
        "Mix flour, baking soda, and baking powder"
      ]
    }
  ],
  "statusCode": 200,
  "statusDescription": "Recipes were successfully retrieved."
}
```

### /Recipes/{id}

#### DELETE

##### Parameters

| Name | Located in | Description                    | Required | Type    |
| ---- | ---------- |--------------------------------| -------- |---------|
| id | path | The ID of the recipe to delete | Yes | integer |

##### Responses

| Code | Description                         |
|------|-------------------------------------|
| 204  | The recipe was successfully deleted |
```json
{
  "statusCode": 204,
  "statusDescription": "Recipe '1' was successfully deleted."
}
```

#### GET

##### Parameters

| Name | Located in | Description                      | Required | Type |
| ---- | ---------- |----------------------------------| -------- | ---- |
| id | path | The ID of the recipe to retrieve | Yes | integer |

##### Responses

| Code | Description                       |
| ---- |-----------------------------------|
| 200 | The recipe associated with the ID |
```json
{
  "result": {
    "createdOnUtc": "2022-11-27T22:34:43.14059",
    "description": "Easy to make sugar cookies.",
    "id": 1,
    "ingredients": [
      {
        "description": "2 cups all-purpose flour",
        "name": "All-purpose flour",
        "quantity": 2
      },
      {
        "description": "1 teaspoon baking soda",
        "name": "Baking soda",
        "quantity": 1
      }
    ],
    "name": "Sugar Cookies",
    "steps": [
      "Preheat oven to 375 degrees",
      "Mix flour, baking soda, and baking powder"
    ]
  },
  "statusCode": 200,
  "statusDescription": "Recipe '1' was successfully retrieved."
}
```

#### PATCH

##### Parameters

| Name | Located in | Description                   | Required | Type |
| ---- | ---------- |-------------------------------| -------- | ---- |
| id | path | The ID of the recipe to patch | Yes | integer |

##### Payload
```json
{
    "description": "Easy to bake sugar cookies.",
    "ingredients": [
      {
        "description": "2 cups all-purpose flour",
        "name": "All-purpose flour",
        "quantity": 2
      },
      {
        "description": "1 teaspoon baking soda",
        "name": "Baking soda",
        "quantity": 1
      }
    ],
    "name": "Sugar Cookies",
    "steps": [
      "Preheat oven to 375 degrees",
      "Mix flour, baking soda, and baking powder"
    ]
  }
```

##### Responses

| Code | Description                            |
| ---- |----------------------------------------|
| 200 | The recipe after the patch was applied |
```json
{
  "result": {
    "createdOnUtc": "2022-11-27T22:34:43.14059",
    "description": "Easy to bake sugar cookies.",
    "id": 1,
    "ingredients": [
      {
        "description": "2 cups all-purpose flour",
        "name": "All-purpose flour",
        "quantity": 2
      },
      {
        "description": "1 teaspoon baking soda",
        "name": "Baking soda",
        "quantity": 1
      }
    ],
    "name": "Sugar Cookies",
    "steps": [
      "Preheat oven to 375 degrees",
      "Mix flour, baking soda, and baking powder"
    ]
  },
  "statusCode": 200,
  "statusDescription": "Recipe '1' was successfully updated."
}
```