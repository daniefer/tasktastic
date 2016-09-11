# tasktastic
Simple task management web app

Project is divided into 2 vertical tiers, one for reading and the other for writing. Both tiers are used together in the FrontEndWebSite project to build a task management web app.

## Goals:
The goal of this architecture is to allow for maximal scalability by building an [event store](https://msdn.microsoft.com/en-us/library/jj591559.aspx) into the back-end web api.
This may include: 
1. building or using an existing [service bus](http://docs.particular.net/samples/step-by-step/) framework to relay events between the read and write silos
2. building or using an existing [event storing](https://msdn.microsoft.com/en-us/library/jj591559.aspx) framework.
3. building or using an existing [messaging queue](https://msdn.microsoft.com/en-us/library/ms711472(v=vs.85).aspx) framework (still learning, this may be the same as an event store).

## To Build:
Clone repo and open in visual studio (2015 or later). 
You may need to install a few extensions into Visual Studio in order for the SCSS files to process. I use Web Compiler and Web Extension 2015.3.
Build in Debug or Release mode. 


## To Configure:
Currently there is no configuration steps required because the project does not work yet.
The basic overview is that:
1. The FrontEndWebSite will need to know where the WebApiWithODataRead and WebApiWithODataWrite endpoints are
2. WebApiWithODataRead and WebApiWithODataWrite will need to know were the data-store is located.
3. If wanting to use third party identity providers, each one will need to be configured in the authentication section. Where this is located is yet to be determined.

### To Run:
There are 3 main pieces to required (or will be required that is) to run the app: FrontEndWebSite, WebApiWithODataRead, and WebApiWithODataWrite.

## Resources:
The below resources are being used determine how to accomplish the goals section.
* https://msdn.microsoft.com/en-us/library/jj591559.aspx
* https://www.rabbitmq.com/
* https://msdn.microsoft.com/en-us/library/ms711472(v=vs.85).aspx
* http://docs.particular.net/samples/step-by-step/ 