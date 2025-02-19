# VineyardAPI

API to manage vineyards, managers, grape varieties, and parcels.

## Description
This project aims to develop a system for vineyard management that allows for the management of information related to vineyards, managers, grape varieties, and parcels records. The data is stored and managed in a SQL Server database, and the API is built using ASP.NET Core.

The system includes the creation of various endpoints to interact with the database and provide key functionalities, such as:

- Getting all managers' Ids.
- Getting all managers' tax numbers, ordered by name.
- Getting the total area by grape variety.
- Getting the total area managed by each manager.
- Getting the managers for each vineyard.

This solution is composed by two projects:
- VineyardAPI: the main project
- VineyardAPITests: a project used to perform unit testing.

### Endpoints:

- **List of Manager Identifiers**
  - **Endpoint**: `GET /managers/ids`
  - **Description**: Returns a list of identifiers for all managers.

- **TaxNumber of Managers Ordered by Name**
  - **Endpoint**: `GET /managers/taxnumbers?sorted=true`
  - **Description**: Returns the tax numbers of the managers sorted alphabetically by their names.

- **Total Area by Grape Variety**
  - **Endpoint**: `GET /grapes/area`
  - **Description**: Returns a dictionary where the keys are grape variety names, and the values are the total planted area for each grape variety.

- **Total Area Managed by Each Manager**
  - **Endpoint**: `GET /managers/totalarea`
  - **Description**: Returns a dictionary where each key is the name of a manager, and the value is the total area they manage.

- **Vineyards and Their Managers**
  - **Endpoint**: `GET /vineyards/managers`
  - **Description**: Returns a dictionary where the keys are vineyard names, and the values are lists of manager names, sorted alphabetically.

### Architecture
The code is structured into different layers, including the repository layer, service layer, and application layer. The Repository and Service Design Patterns were used. The repository handles direct interaction with the database, while the service layer serves as the communication layer between the repository and the application. The application layer is responsible for modifying the data before passing it to either the repository or the service.

### Database Schema
The schema for the database is as follows:

#### Managers
| Field      | Type    | Description                              |
|------------|---------|------------------------------------------|
| Id         | int     | Primary key.                             |
| TaxNumber  | string  | Manager's tax number.                    |
| Name       | string  | Manager's name.                          |

#### Grapes
| Field      | Type    | Description                              |
|------------|---------|------------------------------------------|
| Id         | int     | Primary key.                             |
| Name       | string  | Grape variety name.                      |

#### Vineyards
| Field      | Type    | Description                              |
|------------|---------|------------------------------------------|
| Id         | int     | Primary key.                             |
| Name       | string  | Vineyard name.                           |

#### Parcels
| Field      | Type    | Description                              |
|------------|---------|------------------------------------------|
| Id         | int     | Primary key.                             |
| ManagerId  | int     | Foreign key to `Managers`.               |
| VineyardId | int     | Foreign key to `Vineyards`.              |
| GrapeId    | int     | Foreign key to `Grapes`.                 |
| YearPlanted| int     | Year the grape was planted.              |
| Area       | int     | Total area of the parcel in square meters. |

### Sample Data
The project includes initial seed data in the database when executed. Below is the sample data:

#### Managers
| Id  | TaxNumber  | Name            |
|-----|------------|-----------------|
| 1   | 132254524  | Miguel Torres   |
| 2   | 143618668  | Ana Martín      |
| 3   | 78903228   | Carlos Ruiz     |

#### Grapes
| Id  | Name       |
|-----|------------|
| 1   | Tempranillo|
| 2   | Albariño   |
| 3   | Garnacha   |

#### Vineyards
| Id  | Name                    |
|-----|-------------------------|
| 1   | Viña Esmeralda          |
| 2   | Bodegas Bilbaínas       |

#### Parcels
| Id  | ManagerId | VineyardId | GrapeId | YearPlanted | Area  |
|-----|-----------|------------|---------|-------------|-------|
| 1   | 1         | 1          | 1       | 2019        | 1500  |
| 2   | 2         | 2          | 2       | 2021        | 9000  |
| 3   | 3         | 1          | 3       | 2020        | 3000  |
| 4   | 1         | 2          | 1       | 2020        | 2000  |
| 5   | 3         | 2          | 3       | 2021        | 1000  |

### Technologies Used:
- **ASP.NET Core** for building the API.
- **SQL Server** to store information about vineyards, managers, parcels, and grape varieties.

## Usage & Execution

This repository has two branches:

- **Master Branch**: Contains the functional code, which can be executed locally.
- **VineyardAPI-Docker Branch**: Contains the Docker-Compose implementation.

You can execute the project either with Docker or using a local environment. 

### Executing in a Local Environment:

To run the API locally, SQL Server and SQL Server Management Studio must be installed and running. Follow these steps:

1. Ensure you're on the master branch.
   
2. If you have Visual Studio installed:
   - Open the `appSettings.json` file and update the **ConnectionString** (you can find it by connecting to SQL Server via SQL Server Management Studio).
   - Run the application.
   - After running in **https** mode, Swagger will be displayed, and all the mentioned endpoints will be available for testing.

### Executing with Docker:

1. Clone or download the repository using the following command:
   ```bash
   git clone https://github.com/enmabolz/VineyardAPI.git
2. After cloning, switch to the VineyardAPI-Docker branch.

3. Navigate to the solution folder (where the docker-compose.yml file is located).

4. Open the terminal and run: **docker-compose up --build**
5. The API should now be running at localhost:8081/swagger/index.
6. You can test all the endpoints in Swagger.

