PharmacyManagementSystem - READ ME

Running The Project
Reconnecting the Database to SQL Server (Restore or Attach):
-------------------------------------------------- ----------------------
a. Attach
Open SQL Server Management Studio (SSMS).
Right-click on Databases and select Attach.
Click the Add button in the window that opens and select the shared .MDF file. The LDF file is found automatically.
Add the database to SQL Server by pressing the OK button.
-------------------------------------------------------------------------
b. Restore
If you are going to open it with .bak file:
Right-click on Databases and select Restore Database.
Select Device and show the shared .bak file.
Load the database from the backup by clicking OK.
--------------------------------------------------------------------------
Databes Connection String : My connection string is in my system code, you can run it like this if you want.
-> "Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"
-------------------------------------------------------------------------
1. Open Visual Studio or your preferred IDE.
2. Start the application by running the login.cs file.
3. You can use the doctor or pharmacist functions by logging in.

CONTENTS OF vs.FEATURES AND DATABASE DETAILS  
Overview: 
PharmacyManagementSystem is a database-supported desktop application designed for doctors and pharmacists. This system includes many features such as prescription creation, report generation, data listing for doctors, as well as similar features for pharmacists such as patient and drug management, sales transactions, and invoice preparation. The system offers different functionalities according to the user type (doctor or pharmacist).

Features

General

1. Login and Registration:
- Users can log in or register as "Doctor" or "Pharmacist" from the login screen (Login.cs).
2. Account Management:
- Users can view and edit their profile information (DrProfile.cs and PhProfile.cs).
3. System Login Management:
- Users can log in to the systems according to their type (DrForm.cs and Ph.Form.cs).

Doctor Functions

1. Prescription Creation:
- Doctors can create prescriptions for patients (CreatePrescription.cs).
2. Prescriptions:
- All prescriptions created or filtered by expiration date and view (Prescriptions.cs).
3. Patient Management:
- Doctors can view patient information (Patients.cs).
4. Report Preparation:
- Doctors can report patient and medicine information (CreateReport.cs).
5. Reports:
- Reports created for medicines and patients or filtered by expiration date and view (Reports.cs).
6. Medicine Management:
- Doctors can view medicine information, active ingredients (Medicines.cs).

Pharmacist Functions

1. Prescriptions:
- All prescriptions created or filtered by expiration date and view (Prescriptions.cs).
2. Reports:
- Reports created for medicine and patients or filtered by expiration date and view (Reports.cs).
3. Medication Management:
- Pharmacists can view medicine information and active ingredients (Medicines.cs).
4. Patient Management:
- Pharmacists can view patient information (Patients.cs).
5. Doctor Management:
- Pharmacists can view doctor information (Doctors.cs).
6. Sales Management:
- Pharmacists can perform sales transactions from defined prescriptions (Sales.cs).
- Pharmacists can access report information and medicine information while making sales and make sales accordingly (Form2.cs).
- Pharmacists can also sell medicines without a prescription (WhitePrescriptions.cs).
7. Invoice Management:
- Pharmacists can create invoices from sales and view them as PDFs (Invoince.cs).
8. Stock Management:
- Pharmacists can view and update current medicine stocks (AddStock.cs and StockInfo.cs).
9. Current Income Management:
- Pharmacists can view daily sales amount and incomes. (CAS.cs).


Database Details

The system works with various tables, 6 procedures, 3 functions, 2 views, and 3 triggers:

Tables
- Doctors: Stores doctor information.
- Pharmacists: Stores pharmacist information.
- Users: Stores information of registered users in the system.
- Patients: Stores patient information.
- Medicines: Stores medicine information and stock quantity and status.
- Prescriptions: Stores prescriptions.
- Reports: Stores reports.
- MedicinesOnPresicriptions: Stores medicine in prescriptions.
- Sales: Contains sales records.
- AddForSales: Keeps the medicine sold.
- Invoinces: Contains invoice records.
- CAS: Keeps daily current information.


Store Procedures

1.sp_RegisterPhWithPhoneCheck: For Pharmacists; When a new user registers to the system, it checks the previously registered phone numbers and asks the user for a phone number that is not registered. Used in PhSignUp.cs.
2.sp_RegisterDrWithPhoneCheck: For Doctors; When a new user registers to the system, it checks the previously registered phone numbers and asks the user for a phone number that is not registered. Used in DrSignUp.
3.GetPrescriptionsByDoctor: After a doctor creates a prescription in the system, it shows only the prescriptions created by that doctor from all the prescriptions created. Used in CreatePrescription.cs.
4.CalculateMedicineCost: When adding a medicine for sale, it calculates the price of the medicines according to their quantity. Used in Form2.cs.
5.CheckMedicineReport: Determines reported medicines and unreported medicines. If the medicine is reported and does not have a report, it does not perform the sales transaction. Used in Form2.cs.
6.sp_AddMedicines: Adding a medicine that is not in the medicine list. Used in AddStock.cs.

Functions

1.GetWhitePrescriptionMedicines(): Filters medicines with a white prescription type. This shows that those medicines can be purchased without a prescription. Used in WhitePrescriptions.cs.
2.CalculateWhitePrescriptionCost: Calculates white prescriptions at the discounted price. Used in WhitePrescriptions.cs.
3.dbo.CalculateTotalPrice: When making a sale, it adds up the prescription number at the discounted price and the non-prescription number at the undiscounted price. Finds the total sales price. Used in Sales.cs.

Views

1.ExpiredReports: Shows reports that have expired. Used in Reports.cs.
2.ExpiredPrescriptions: Lists prescriptions that have been created 4 days ago. Used in Prescriptions.cs and Sales.cs.

Triggers

1.trg_UpdateStock: Decreases the stock amount according to the number of units sold after the sale is made.
2.trg_UpdateStockStatus: Indicates the situation when the stock amount is below 20.
3.UpdateCASAfterSale1: Updates daily income and sales when a sale is added.


