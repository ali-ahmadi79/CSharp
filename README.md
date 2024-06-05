CSharp MS Windows Form application.

It can be used to export or import data from source MSSQL tables and views dynamically. 

It could be beneficial for ETL as a tool.

You should configure the config.conf file located in the Debug folder at this path: "../bin/Debug/."

**config.conf includes: 

SIP: Source IP Address (ex: 192.168.0.152)

DIP: Destination IP Address (ex: 192.168.0.152)

SDB: Source DB Name

DDB: Destination DB Name

SDBU: Source SQL User Login

DDBU: Destination SQL User Login

SDBP: Source SQL User Login Password

DDBP: Destination SQL User Login Password

SDBName: (Optional)

LoadType: 

SelectedTables: 

isTargetDataToBeDeleted: 1

ScheduledTime: Scheduled time in seconds (ex: 1440)

List of Queries: Specific queries that will be run on the target DBN,

