QuartzNServiceBusSample
=======================

This is an example of using NServiceBus with Quartz.NET to trigger scheduled messages. NServiceBus has support for [scheduling periodic messages](http://nservicebus.com/Scheduling.aspx), but that doesn't allow things to happen on a certain date/time.

Instead, we can use Quartz.NET to trigger messages on a cron-type schedule, like once a month, twice a day at 8 AM and 4 PM etc.

To run:

* Create a database named "QuartzNServiceBusSample" in your local .\SQLExpress instance. You can change the server/database name by modifying the App.config file in the QuartzNServiceBusSample.Scheduler project.
* Run the QuartzTables.sql against that database
* Open the solution and run

The example uses a secondly trigger to trigger Quartz to send a message every 5 seconds. You can modify the trigger to build daily/monthly triggers.