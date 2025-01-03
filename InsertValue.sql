﻿USE Bus_server_prod
GO

Insert Into UserRole Values
	('Admin'),
	('Staff'),
	('Customer'),
	('VipCustomer')

Insert Into TripStatus Values
	('Availible'),
	('Unavailible')

Insert Into BusStatus Values
	('Availible'),
	('Unavailible')

INSERT INTO Bus VALUES 
	('NT106.1', 30, 1), 
	('NT106.2', 30, 1), 
	('NT106.3', 30, 1), 
	('NT106.4', 30, 1), 
	('NT106.5', 30, 1), 
	('NT106.6', 30, 1),
	('NT106.7', 30, 1),
	('NT106.8', 30, 1),
	('NT106.9', 30, 1),
	('NT106.10', 30, 1),
	('NT106.11', 30, 1),
	('NT106.12', 30, 1),
	('NT106.13', 30, 1),
	('NT106.14', 30, 1),
	('NT106.15', 30, 1),
	('NT106.16', 30, 1),
	('NT106.17', 30, 1),
	('NT106.18', 30, 1);

INSERT INTO Seat (LicensePlate, SeatName, IsBook) VALUES
	('NT106.1', 'A1', 0),
	('NT106.1', 'A2', 0),
	('NT106.1', 'A3', 0),
	('NT106.1', 'A4', 0),
	('NT106.1', 'A5', 0),
	('NT106.1', 'A6', 0),
	('NT106.1', 'A7', 0),
	('NT106.1', 'A8', 0),
	('NT106.1', 'A9', 0),
	('NT106.1', 'A10', 0),
	('NT106.1', 'B1', 0),
	('NT106.1', 'B2', 0),
	('NT106.1', 'B3', 0),
	('NT106.1', 'B4', 0),
	('NT106.1', 'B5', 0),
	('NT106.1', 'B6', 0),
	('NT106.1', 'B7', 0),
	('NT106.1', 'B8', 0),
	('NT106.1', 'B9', 0),
	('NT106.1', 'B10', 0),
	('NT106.1', 'C1', 0),
	('NT106.1', 'C2', 0),
	('NT106.1', 'C3', 0),
	('NT106.1', 'C4', 0),
	('NT106.1', 'C5', 0),
	('NT106.1', 'C6', 0),
	('NT106.1', 'C7', 0),
	('NT106.1', 'C8', 0),
	('NT106.1', 'C9', 0),
	('NT106.1', 'C10', 0),
	('NT106.2', 'A1', 0),
	('NT106.2', 'A2', 0),
	('NT106.2', 'A3', 0),
	('NT106.2', 'A4', 0),
	('NT106.2', 'A5', 0),
	('NT106.2', 'A6', 0),
	('NT106.2', 'A7', 0),
	('NT106.2', 'A8', 0),
	('NT106.2', 'A9', 0),
	('NT106.2', 'A10', 0),
	('NT106.2', 'B1', 0),
	('NT106.2', 'B2', 0),
	('NT106.2', 'B3', 0),
	('NT106.2', 'B4', 0),
	('NT106.2', 'B5', 0),
	('NT106.2', 'B6', 0),
	('NT106.2', 'B7', 0),
	('NT106.2', 'B8', 0),
	('NT106.2', 'B9', 0),
	('NT106.2', 'B10', 0),
	('NT106.2', 'C1', 0),
	('NT106.2', 'C2', 0),
	('NT106.2', 'C3', 0),
	('NT106.2', 'C4', 0),
	('NT106.2', 'C5', 0),
	('NT106.2', 'C6', 0),
	('NT106.2', 'C7', 0),
	('NT106.2', 'C8', 0),
	('NT106.2', 'C9', 0),
	('NT106.2', 'C10', 0),
	('NT106.3', 'A1', 0),
	('NT106.3', 'A2', 0),
	('NT106.3', 'A3', 0),
	('NT106.3', 'A4', 0),
	('NT106.3', 'A5', 0),
	('NT106.3', 'A6', 0),
	('NT106.3', 'A7', 0),
	('NT106.3', 'A8', 0),
	('NT106.3', 'A9', 0),
	('NT106.3', 'A10', 0),
	('NT106.3', 'B1', 0),
	('NT106.3', 'B2', 0),
	('NT106.3', 'B3', 0),
	('NT106.3', 'B4', 0),
	('NT106.3', 'B5', 0),
	('NT106.3', 'B6', 0),
	('NT106.3', 'B7', 0),
	('NT106.3', 'B8', 0),
	('NT106.3', 'B9', 0),
	('NT106.3', 'B10', 0),
	('NT106.3', 'C1', 0),
	('NT106.3', 'C2', 0),
	('NT106.3', 'C3', 0),
	('NT106.3', 'C4', 0),
	('NT106.3', 'C5', 0),
	('NT106.3', 'C6', 0),
	('NT106.3', 'C7', 0),
	('NT106.3', 'C8', 0),
	('NT106.3', 'C9', 0),
	('NT106.3', 'C10', 0),
	('NT106.4', 'A1', 0),
	('NT106.4', 'A2', 0),
	('NT106.4', 'A3', 0),
	('NT106.4', 'A4', 0),
	('NT106.4', 'A5', 0),
	('NT106.4', 'A6', 0),
	('NT106.4', 'A7', 0),
	('NT106.4', 'A8', 0),
	('NT106.4', 'A9', 0),
	('NT106.4', 'A10', 0),
	('NT106.4', 'B1', 0),
	('NT106.4', 'B2', 0),
	('NT106.4', 'B3', 0),
	('NT106.4', 'B4', 0),
	('NT106.4', 'B5', 0),
	('NT106.4', 'B6', 0),
	('NT106.4', 'B7', 0),
	('NT106.4', 'B8', 0),
	('NT106.4', 'B9', 0),
	('NT106.4', 'B10', 0),
	('NT106.4', 'C1', 0),
	('NT106.4', 'C2', 0),
	('NT106.4', 'C3', 0),
	('NT106.4', 'C4', 0),
	('NT106.4', 'C5', 0),
	('NT106.4', 'C6', 0),
	('NT106.4', 'C7', 0),
	('NT106.4', 'C8', 0),
	('NT106.4', 'C9', 0),
	('NT106.4', 'C10', 0),
	('NT106.5', 'A1', 0),
	('NT106.5', 'A2', 0),
	('NT106.5', 'A3', 0),
	('NT106.5', 'A4', 0),
	('NT106.5', 'A5', 0),
	('NT106.5', 'A6', 0),
	('NT106.5', 'A7', 0),
	('NT106.5', 'A8', 0),
	('NT106.5', 'A9', 0),
	('NT106.5', 'A10', 0),
	('NT106.5', 'B1', 0),
	('NT106.5', 'B2', 0),
	('NT106.5', 'B3', 0),
	('NT106.5', 'B4', 0),
	('NT106.5', 'B5', 0),
	('NT106.5', 'B6', 0),
	('NT106.5', 'B7', 0),
	('NT106.5', 'B8', 0),
	('NT106.5', 'B9', 0),
	('NT106.5', 'B10', 0),
	('NT106.5', 'C1', 0),
	('NT106.5', 'C2', 0),
	('NT106.5', 'C3', 0),
	('NT106.5', 'C4', 0),
	('NT106.5', 'C5', 0),
	('NT106.5', 'C6', 0),
	('NT106.5', 'C7', 0),
	('NT106.5', 'C8', 0),
	('NT106.5', 'C9', 0),
	('NT106.5', 'C10', 0),
	('NT106.6', 'A1', 0),
	('NT106.6', 'A2', 0),
	('NT106.6', 'A3', 0),
	('NT106.6', 'A4', 0),
	('NT106.6', 'A5', 0),
	('NT106.6', 'A6', 0),
	('NT106.6', 'A7', 0),
	('NT106.6', 'A8', 0),
	('NT106.6', 'A9', 0),
	('NT106.6', 'A10', 0),
	('NT106.6', 'B1', 0),
	('NT106.6', 'B2', 0),
	('NT106.6', 'B3', 0),
	('NT106.6', 'B4', 0),
	('NT106.6', 'B5', 0),
	('NT106.6', 'B6', 0),
	('NT106.6', 'B7', 0),
	('NT106.6', 'B8', 0),
	('NT106.6', 'B9', 0),
	('NT106.6', 'B10', 0),
	('NT106.6', 'C1', 0),
	('NT106.6', 'C2', 0),
	('NT106.6', 'C3', 0),
	('NT106.6', 'C4', 0),
	('NT106.6', 'C5', 0),
	('NT106.6', 'C6', 0),
	('NT106.6', 'C7', 0),
	('NT106.6', 'C8', 0),
	('NT106.6', 'C9', 0),
	('NT106.6', 'C10', 0),
	('NT106.7', 'A1', 0),
	('NT106.7', 'A2', 0),
	('NT106.7', 'A3', 0),
	('NT106.7', 'A4', 0),
	('NT106.7', 'A5', 0),
	('NT106.7', 'A6', 0),
	('NT106.7', 'A7', 0),
	('NT106.7', 'A8', 0),
	('NT106.7', 'A9', 0),
	('NT106.7', 'A10', 0),
	('NT106.7', 'B1', 0),
	('NT106.7', 'B2', 0),
	('NT106.7', 'B3', 0),
	('NT106.7', 'B4', 0),
	('NT106.7', 'B5', 0),
	('NT106.7', 'B6', 0),
	('NT106.7', 'B7', 0),
	('NT106.7', 'B8', 0),
	('NT106.7', 'B9', 0),
	('NT106.7', 'B10', 0),
	('NT106.7', 'C1', 0),
	('NT106.7', 'C2', 0),
	('NT106.7', 'C3', 0),
	('NT106.7', 'C4', 0),
	('NT106.7', 'C5', 0),
	('NT106.7', 'C6', 0),
	('NT106.7', 'C7', 0),
	('NT106.7', 'C8', 0),
	('NT106.7', 'C9', 0),
	('NT106.7', 'C10', 0),
	('NT106.8', 'A1', 0),
	('NT106.8', 'A2', 0),
	('NT106.8', 'A3', 0),
	('NT106.8', 'A4', 0),
	('NT106.8', 'A5', 0),
	('NT106.8', 'A6', 0),
	('NT106.8', 'A7', 0),
	('NT106.8', 'A8', 0),
	('NT106.8', 'A9', 0),
	('NT106.8', 'A10', 0),
	('NT106.8', 'B1', 0),
	('NT106.8', 'B2', 0),
	('NT106.8', 'B3', 0),
	('NT106.8', 'B4', 0),
	('NT106.8', 'B5', 0),
	('NT106.8', 'B6', 0),
	('NT106.8', 'B7', 0),
	('NT106.8', 'B8', 0),
	('NT106.8', 'B9', 0),
	('NT106.8', 'B10', 0),
	('NT106.8', 'C1', 0),
	('NT106.8', 'C2', 0),
	('NT106.8', 'C3', 0),
	('NT106.8', 'C4', 0),
	('NT106.8', 'C5', 0),
	('NT106.8', 'C6', 0),
	('NT106.8', 'C7', 0),
	('NT106.8', 'C8', 0),
	('NT106.8', 'C9', 0),
	('NT106.8', 'C10', 0),
	('NT106.9', 'A1', 0),
	('NT106.9', 'A2', 0),
	('NT106.9', 'A3', 0),
	('NT106.9', 'A4', 0),
	('NT106.9', 'A5', 0),
	('NT106.9', 'A6', 0),
	('NT106.9', 'A7', 0),
	('NT106.9', 'A8', 0),
	('NT106.9', 'A9', 0),
	('NT106.9', 'A10', 0),
	('NT106.9', 'B1', 0),
	('NT106.9', 'B2', 0),
	('NT106.9', 'B3', 0),
	('NT106.9', 'B4', 0),
	('NT106.9', 'B5', 0),
	('NT106.9', 'B6', 0),
	('NT106.9', 'B7', 0),
	('NT106.9', 'B8', 0),
	('NT106.9', 'B9', 0),
	('NT106.9', 'B10', 0),
	('NT106.9', 'C1', 0),
	('NT106.9', 'C2', 0),
	('NT106.9', 'C3', 0),
	('NT106.9', 'C4', 0),
	('NT106.9', 'C5', 0),
	('NT106.9', 'C6', 0),
	('NT106.9', 'C7', 0),
	('NT106.9', 'C8', 0),
	('NT106.9', 'C9', 0),
	('NT106.9', 'C10', 0),
	('NT106.10', 'A1', 0),
	('NT106.10', 'A2', 0),
	('NT106.10', 'A3', 0),
	('NT106.10', 'A4', 0),
	('NT106.10', 'A5', 0),
	('NT106.10', 'A6', 0),
	('NT106.10', 'A7', 0),
	('NT106.10', 'A8', 0),
	('NT106.10', 'A9', 0),
	('NT106.10', 'A10', 0),
	('NT106.10', 'B1', 0),
	('NT106.10', 'B2', 0),
	('NT106.10', 'B3', 0),
	('NT106.10', 'B4', 0),
	('NT106.10', 'B5', 0),
	('NT106.10', 'B6', 0),
	('NT106.10', 'B7', 0),
	('NT106.10', 'B8', 0),
	('NT106.10', 'B9', 0),
	('NT106.10', 'B10', 0),
	('NT106.10', 'C1', 0),
	('NT106.10', 'C2', 0),
	('NT106.10', 'C3', 0),
	('NT106.10', 'C4', 0),
	('NT106.10', 'C5', 0),
	('NT106.10', 'C6', 0),
	('NT106.10', 'C7', 0),
	('NT106.10', 'C8', 0),
	('NT106.10', 'C9', 0),
	('NT106.10', 'C10', 0),
	('NT106.11', 'A1', 0),
	('NT106.11', 'A2', 0),
	('NT106.11', 'A3', 0),
	('NT106.11', 'A4', 0),
	('NT106.11', 'A5', 0),
	('NT106.11', 'A6', 0),
	('NT106.11', 'A7', 0),
	('NT106.11', 'A8', 0),
	('NT106.11', 'A9', 0),
	('NT106.11', 'A10', 0),
	('NT106.11', 'B1', 0),
	('NT106.11', 'B2', 0),
	('NT106.11', 'B3', 0),
	('NT106.11', 'B4', 0),
	('NT106.11', 'B5', 0),
	('NT106.11', 'B6', 0),
	('NT106.11', 'B7', 0),
	('NT106.11', 'B8', 0),
	('NT106.11', 'B9', 0),
	('NT106.11', 'B10', 0),
	('NT106.11', 'C1', 0),
	('NT106.11', 'C2', 0),
	('NT106.11', 'C3', 0),
	('NT106.11', 'C4', 0),
	('NT106.11', 'C5', 0),
	('NT106.11', 'C6', 0),
	('NT106.11', 'C7', 0),
	('NT106.11', 'C8', 0),
	('NT106.11', 'C9', 0),
	('NT106.11', 'C10', 0),
	('NT106.12', 'A1', 0),
	('NT106.12', 'A2', 0),
	('NT106.12', 'A3', 0),
	('NT106.12', 'A4', 0),
	('NT106.12', 'A5', 0),
	('NT106.12', 'A6', 0),
	('NT106.12', 'A7', 0),
	('NT106.12', 'A8', 0),
	('NT106.12', 'A9', 0),
	('NT106.12', 'A10', 0),
	('NT106.12', 'B1', 0),
	('NT106.12', 'B2', 0),
	('NT106.12', 'B3', 0),
	('NT106.12', 'B4', 0),
	('NT106.12', 'B5', 0),
	('NT106.12', 'B6', 0),
	('NT106.12', 'B7', 0),
	('NT106.12', 'B8', 0),
	('NT106.12', 'B9', 0),
	('NT106.12', 'B10', 0),
	('NT106.12', 'C1', 0),
	('NT106.12', 'C2', 0),
	('NT106.12', 'C3', 0),
	('NT106.12', 'C4', 0),
	('NT106.12', 'C5', 0),
	('NT106.12', 'C6', 0),
	('NT106.12', 'C7', 0),
	('NT106.12', 'C8', 0),
	('NT106.12', 'C9', 0),
	('NT106.12', 'C10', 0),
	('NT106.13', 'A1', 0),
	('NT106.13', 'A2', 0),
	('NT106.13', 'A3', 0),
	('NT106.13', 'A4', 0),
	('NT106.13', 'A5', 0),
	('NT106.13', 'A6', 0),
	('NT106.13', 'A7', 0),
	('NT106.13', 'A8', 0),
	('NT106.13', 'A9', 0),
	('NT106.13', 'A10', 0),
	('NT106.13', 'B1', 0),
	('NT106.13', 'B2', 0),
	('NT106.13', 'B3', 0),
	('NT106.13', 'B4', 0),
	('NT106.13', 'B5', 0),
	('NT106.13', 'B6', 0),
	('NT106.13', 'B7', 0),
	('NT106.13', 'B8', 0),
	('NT106.13', 'B9', 0),
	('NT106.13', 'B10', 0),
	('NT106.13', 'C1', 0),
	('NT106.13', 'C2', 0),
	('NT106.13', 'C3', 0),
	('NT106.13', 'C4', 0),
	('NT106.13', 'C5', 0),
	('NT106.13', 'C6', 0),
	('NT106.13', 'C7', 0),
	('NT106.13', 'C8', 0),
	('NT106.13', 'C9', 0),
	('NT106.13', 'C10', 0),
	('NT106.14', 'A1', 0),
	('NT106.14', 'A2', 0),
	('NT106.14', 'A3', 0),
	('NT106.14', 'A4', 0),
	('NT106.14', 'A5', 0),
	('NT106.14', 'A6', 0),
	('NT106.14', 'A7', 0),
	('NT106.14', 'A8', 0),
	('NT106.14', 'A9', 0),
	('NT106.14', 'A10', 0),
	('NT106.14', 'B1', 0),
	('NT106.14', 'B2', 0),
	('NT106.14', 'B3', 0),
	('NT106.14', 'B4', 0),
	('NT106.14', 'B5', 0),
	('NT106.14', 'B6', 0),
	('NT106.14', 'B7', 0),
	('NT106.14', 'B8', 0),
	('NT106.14', 'B9', 0),
	('NT106.14', 'B10', 0),
	('NT106.14', 'C1', 0),
	('NT106.14', 'C2', 0),
	('NT106.14', 'C3', 0),
	('NT106.14', 'C4', 0),
	('NT106.14', 'C5', 0),
	('NT106.14', 'C6', 0),
	('NT106.14', 'C7', 0),
	('NT106.14', 'C8', 0),
	('NT106.14', 'C9', 0),
	('NT106.14', 'C10', 0),
	('NT106.15', 'A1', 0),
	('NT106.15', 'A2', 0),
	('NT106.15', 'A3', 0),
	('NT106.15', 'A4', 0),
	('NT106.15', 'A5', 0),
	('NT106.15', 'A6', 0),
	('NT106.15', 'A7', 0),
	('NT106.15', 'A8', 0),
	('NT106.15', 'A9', 0),
	('NT106.15', 'A10', 0),
	('NT106.15', 'B1', 0),
	('NT106.15', 'B2', 0),
	('NT106.15', 'B3', 0),
	('NT106.15', 'B4', 0),
	('NT106.15', 'B5', 0),
	('NT106.15', 'B6', 0),
	('NT106.15', 'B7', 0),
	('NT106.15', 'B8', 0),
	('NT106.15', 'B9', 0),
	('NT106.15', 'B10', 0),
	('NT106.15', 'C1', 0),
	('NT106.15', 'C2', 0),
	('NT106.15', 'C3', 0),
	('NT106.15', 'C4', 0),
	('NT106.15', 'C5', 0),
	('NT106.15', 'C6', 0),
	('NT106.15', 'C7', 0),
	('NT106.15', 'C8', 0),
	('NT106.15', 'C9', 0),
	('NT106.15', 'C10', 0),
	('NT106.16', 'A1', 0),
	('NT106.16', 'A2', 0),
	('NT106.16', 'A3', 0),
	('NT106.16', 'A4', 0),
	('NT106.16', 'A5', 0),
	('NT106.16', 'A6', 0),
	('NT106.16', 'A7', 0),
	('NT106.16', 'A8', 0),
	('NT106.16', 'A9', 0),
	('NT106.16', 'A10', 0),
	('NT106.16', 'B1', 0),
	('NT106.16', 'B2', 0),
	('NT106.16', 'B3', 0),
	('NT106.16', 'B4', 0),
	('NT106.16', 'B5', 0),
	('NT106.16', 'B6', 0),
	('NT106.16', 'B7', 0),
	('NT106.16', 'B8', 0),
	('NT106.16', 'B9', 0),
	('NT106.16', 'B10', 0),
	('NT106.16', 'C1', 0),
	('NT106.16', 'C2', 0),
	('NT106.16', 'C3', 0),
	('NT106.16', 'C4', 0),
	('NT106.16', 'C5', 0),
	('NT106.16', 'C6', 0),
	('NT106.16', 'C7', 0),
	('NT106.16', 'C8', 0),
	('NT106.16', 'C9', 0),
	('NT106.16', 'C10', 0),
	('NT106.17', 'A1', 0),
	('NT106.17', 'A2', 0),
	('NT106.17', 'A3', 0),
	('NT106.17', 'A4', 0),
	('NT106.17', 'A5', 0),
	('NT106.17', 'A6', 0),
	('NT106.17', 'A7', 0),
	('NT106.17', 'A8', 0),
	('NT106.17', 'A9', 0),
	('NT106.17', 'A10', 0),
	('NT106.17', 'B1', 0),
	('NT106.17', 'B2', 0),
	('NT106.17', 'B3', 0),
	('NT106.17', 'B4', 0),
	('NT106.17', 'B5', 0),
	('NT106.17', 'B6', 0),
	('NT106.17', 'B7', 0),
	('NT106.17', 'B8', 0),
	('NT106.17', 'B9', 0),
	('NT106.17', 'B10', 0),
	('NT106.17', 'C1', 0),
	('NT106.17', 'C2', 0),
	('NT106.17', 'C3', 0),
	('NT106.17', 'C4', 0),
	('NT106.17', 'C5', 0),
	('NT106.17', 'C6', 0),
	('NT106.17', 'C7', 0),
	('NT106.17', 'C8', 0),
	('NT106.17', 'C9', 0),
	('NT106.17', 'C10', 0),
	('NT106.18', 'A1', 0),
	('NT106.18', 'A2', 0),
	('NT106.18', 'A3', 0),
	('NT106.18', 'A4', 0),
	('NT106.18', 'A5', 0),
	('NT106.18', 'A6', 0),
	('NT106.18', 'A7', 0),
	('NT106.18', 'A8', 0),
	('NT106.18', 'A9', 0),
	('NT106.18', 'A10', 0),
	('NT106.18', 'B1', 0),
	('NT106.18', 'B2', 0),
	('NT106.18', 'B3', 0),
	('NT106.18', 'B4', 0),
	('NT106.18', 'B5', 0),
	('NT106.18', 'B6', 0),
	('NT106.18', 'B7', 0),
	('NT106.18', 'B8', 0),
	('NT106.18', 'B9', 0),
	('NT106.18', 'B10', 0),
	('NT106.18', 'C1', 0),
	('NT106.18', 'C2', 0),
	('NT106.18', 'C3', 0),
	('NT106.18', 'C4', 0),
	('NT106.18', 'C5', 0),
	('NT106.18', 'C6', 0),
	('NT106.18', 'C7', 0),
	('NT106.18', 'C8', 0),
	('NT106.18', 'C9', 0),
	('NT106.18', 'C10', 0);

INSERT INTO Trip VALUES ('NT106.1', N'TP.HCM', N'Hà Nội', '2024-12-15 17:00', 1);
INSERT INTO Trip VALUES ('NT106.2', N'Hà Nội', N'TP.HCM', '2024-12-16 18:00', 1);
INSERT INTO Trip VALUES ('NT106.3', N'TP.HCM', N'Cần Thơ', '2024-12-17 19:00', 1);
INSERT INTO Trip VALUES ('NT106.4', N'Cần Thơ', N'TP.HCM', '2024-12-18 20:00', 1);
INSERT INTO Trip VALUES ('NT106.5', N'TP.HCM', N'Đà Nẵng', '2024-12-19 21:00', 1);
INSERT INTO Trip VALUES ('NT106.6', N'Đà Nẵng', N'TP.HCM', '2024-12-20 22:00', 1);
INSERT INTO Trip VALUES ('NT106.7', N'Hà Nội', N'Cần Thơ', '2024-12-21 23:00', 1);
INSERT INTO Trip VALUES ('NT106.8', N'Cần Thơ', N'Hà Nội', '2024-12-15 17:00', 1);
INSERT INTO Trip VALUES ('NT106.9', N'Hà Nội', N'Đà Nẵng', '2024-12-15 17:00', 1);
INSERT INTO Trip VALUES ('NT106.10', N'Đà Nẵng', N'Hà Nội', '2024-12-15 17:00', 1);
INSERT INTO Trip VALUES ('NT106.11', N'Hà Nội', N'Huế', '2024-12-16 18:00', 1);
INSERT INTO Trip VALUES ('NT106.12', N'Huế', N'Hà Nội', '2024-12-16 18:00', 1);
INSERT INTO Trip VALUES ('NT106.13', N'Cần Thơ', N'Đà Nẵng', '2024-12-16 18:00', 1);
INSERT INTO Trip VALUES ('NT106.14', N'Đà Nẵng', N'Cần Thơ', '2024-12-17 19:00', 1);
INSERT INTO Trip VALUES ('NT106.15', N'Cần Thơ', N'Huế', '2024-12-17 19:00', 1);
INSERT INTO Trip VALUES ('NT106.16', N'Huế', N'Cần Thơ', '2024-12-17 19:00', 1);
INSERT INTO Trip VALUES ('NT106.17', N'Đà Nẵng', N'Huế', '2024-12-18 20:00', 1);
INSERT INTO Trip VALUES ('NT106.18', N'Huế', N'Đà Nẵng', '2024-12-18 20:00', 1);


