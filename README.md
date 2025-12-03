## 🚗 Car Wash Bay Tracking System (C# Console App)

A C# console application that manages daily operations for a car wash bay by registering washers, tracking incoming vehicles, applying pricing rules, and enforcing service limits.

This project was built to demonstrate core C# fundamentals, business-logic validation, and clean console application structure.

## Features

✅ Register washers (staff)
✅ Register vehicles for washing
✅ Automatically apply washing fees based on vehicle type
✅ Limit washers to a maximum of 2 cars at a time
✅ Prevent the same car from being registered more than once per day
✅ Display live washer assignment status

 ## Pricing Rules
Vehicle Type	Cost (UGX)
Truck	20,000
Minivan	15,000
Saloon	10,000
Motorbike	5,000
Technology Stack

Language: C#

Framework: .NET 8 Console Application

Storage: In-memory (List<> collections)

IDE: Visual Studio 2022+ or VS Code

📂 Project Structure
CarWashBay/
 ├── Program.cs         # Main application logic
 ├── CarWashBay.csproj  # .NET project configuration
 └── README.md          # Project documentation

▶️ Running the Project
✅ Option 1 – Visual Studio (Recommended)

Install Visual Studio 2022+

Install .NET 8 SDK
