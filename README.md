Brief description:

	Simple mobile app to manage incoming delivery-orders. The app is thought for the shop in wich i worked as a rider.
	
	The shop (Stasera Non Esco) is actually trying to buy an orders management system. This repo contains a first demo-proposal for them. 
	
	This is just a part of the work i hope i'll do for them. They also need a management system to run on their restaurant devices (in the kitchen, at the cash-desk).
	
	I will continue to work on this project if they decide this is good enough for them. Already scheduled a couple of meetings in order to understand their needs and
	retribution proposal.


	
Tech-spech:

	Cross-platform mobile-app written in C# using Xamarin framework. 
	
	Because of the app being really simple in its logic, no use of MVVM or other particular pattern has been made.
	
	The application back-end is written in C# using .NET CORE and Entity Framework Core. The Mobile-App consumes the REST API service that it expose.
	
	You can find the back-end here: https://github.com/Gardusio/Ecommerce-Api



Backlog today (TODO) :
- Credentials recovery.
- Facebook Auth.
- Delivery date time.
- Order confirmation logic (confirmed, completed)
- Post an order that is already in order history.
- Delete single line item from cart.
- Update IOS assets. 
