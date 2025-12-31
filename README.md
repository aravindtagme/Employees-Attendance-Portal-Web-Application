🏢 Employee Management Portal – ASP.NET Web Application

📌 Project Description

The Employee Attendance Portal is a professional ASP.NET Web Application designed to transform how organizations track and manage workforce presence. It provides a high-integrity, real-time platform for capturing daily clock-in/out data, calculating net working hours, and generating administrative audits.


✨ Key Features :

📅 Daily Attendance Marking: "Punch In" and "Punch Out" functionality using server-side timestamps.

📋 Live Attendance Reports: A structured GridView for employees and managers to view historical logs.

👥 Employee Management: Admin interface to add, edit, or remove employee records.

🛡️ Secure Authentication: Secure login system to protect sensitive personnel data.

🎨 Clean UI: Responsive layout using custom CSS and Master Pages.


🛠️ Technologies Used:

⚪ Framework: ASP.NET Web Application

⚪ Language: C# (Code-Behind)

⚪ Database: Microsoft SQL Server

⚪ Data Access: ADO.NET

⚪ Frontend: ASPX, HTML5, CSS3, Bootstrap



🧱 Project Folder Structure

Employees Attendance/
│
├── CSS/                   
│   └── style.css            # Custom application styling
│
├── Pages/                     # Organized Web Forms
│   ├── Login.aspx             # User Authentication
│   ├── Attendance.aspx        # Main Punch In/Out interface
│   ├── ViewAttendance.aspx    # GridView reporting for logs
│   └── ManageEmployees.aspx   # Admin portal for employee records
│
├── Shared/                
│   └── Site1.Master       # The main layout (Header, Footer, Navigation)
│
├── Web.config             # Main configuration & Connection Strings
└── packages.config        # NuGet package dependencies


🚀 Setup Instructions:

1. Clone the Repo: git clone. 

2. Database Setup:  Open SQL Server Management Studio (SSMS).

3. Database: Execute the provided SQL script to create the EmployeesAttendanceDB.

4. Connection: Update the <connectionStrings> section in Web.config with your local server credentials.

5. IDE: Open the solution in Visual Studio.

6. Build: Rebuild the solution and run via IIS Express (F5).


👤 Author
ARAVIND M
