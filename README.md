# Weather Forecasting API

## Overview

This solution is a web API that enables users to retrieve weather forecasts based on the city name and optionally a specific date. The API is designed to be straightforward and efficient, providing accurate weather information as per the following logic:

- **City Not Found**: If the specified city is not found, an empty response will be returned.
- **Date Not Specified**: If no date is specified, the forecast for the current day will be returned.
- **Forecast Range**: The API supports requesting forecasts for up to 5 days ahead. If the specified date exceeds this range, an empty response will be returned.

## Features

- **Simple and Intuitive**: Easy to use with a clear and straightforward request and response structure.
- **Flexible Date Handling**: Automatically returns the current day's forecast if no date is provided.
- **City-Based Search**: Retrieve weather forecasts by specifying the city name.
- **Future Forecasts**: Request weather forecasts for up to 5 days in advance.

## API Endpoints

### Get Weather Forecast

**Endpoint**: `/WeatherForecast`

**Method**: `GET`

**Parameters**:
- `city` (string, required): The name of the city for which the weather forecast is requested.
- `date` (date, optional): The specific date for the weather forecast. If not provided, the current day's forecast is returned.

**Example Request**:
```http
GET /WeatherForecast?city=London&date=2024-07-31

**Example Responses**:
```http
[
    {
        "date": "2023-07-31",
        "temperature": 21.5,
        "pressure": 1012,
        "humidity": 60,
        "windSpeed": 5.4,
        "weatherConditions": "Clear"
    }
]
