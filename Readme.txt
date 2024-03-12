Group_09 CSCE_5430 - 006
Team : SOFTENGINEERING


1. Software : ASP.NET 6.0, Visual studio 2019, MS SQL 2019
2. Unzip the Project file which have following files :
		* Group09_006_iCAREDB.bak - It is used to restore the sql tables
		* This is the connection string for our location conn.ConnectionString = "Data Source=DESKTOP-7UQ6PKP\\SQLEXPRESS;Initial Catalog=Group9_006_iCAREDB;Integrated Security=True";" in the project with your respective to configure sql in the workspace.
                * Change the connection string as per your system settings
3. Connect to the server and connect to database in the visual studios.                 
3. Operations of the actors are mentioned below:
	* Admin login : 
		- ADD, DELETE, EDIT worker records.

	* Worker Login :
		- Display Pallatee
		- Manage Documents and Import Images
		- Register Patients
		- Assign Patients

4. Features of Display Pallatee :
	* Displays the Patient documents(PDF, TXT, DOCX, PNG, JPG) where the workers can upload and download.


5. Features of Register Patients :
	* Create the Patient record with personal details, BloodGroup, BedID, Treatment Area, Treatment Id, GeoID, UserId(worker Id)

6. Features of Assign Patients :
	* Here a workers can assign the patients to self if they are unassigned to doctor/nurse.

7. Features of Manage Documents and Import Images :
	* Displays the Patient record files, where we can upload the files in this portal.

8. Treatment Record:
	* Here a patient gets assigned with multiple records of treatment records.
	* Each Treat record has associated with Drug repository.
