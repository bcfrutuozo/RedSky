RedSky is a small ERP project that I built from scratch to bill service invoices, implemented only for the Sorocaba city, in Brazil. It was written using DDD pattern and changed a lot due to the urgent modifications I did to make the invoice processing.
The whole concept of the system was to use a mapper to another Database containing the main enterprise data. So it's possible to manually write the SQL queries of the billing business model and store it in the RedSky database to process the information, generate an XLSX file for the client, process the bill batch into the Sorocaba city API and, finally, send a customized e-mail to the customer with all the data generated.

Today, it's frozen for more than a year and I probably won't return to develop it.
