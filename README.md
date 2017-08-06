# CreateIncidentCstoServiceNow

This is an example C# command line programm that will take 5 input parameters which will be used to 
create an ServiceNow incident using REST API. If not all 5 parameters are supplied the programm will not
exit with a message.

Command line:<BR/>
CreateIncidentCstoServiceNow.exe %1 %2 %3 %4 %5<BR/>
CreateIncidentCstoServiceNow.exe "ServiceNow Instance Name" "Username" "Password" "Short Description" "Description"
