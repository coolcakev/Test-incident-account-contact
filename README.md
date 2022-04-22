# Test-incident-account-contact
Я створив 3 Api функкції
1:
url:https://localhost:44321/Contact/Create
type:"Post"
ця функція приймає обєкт з трьох параметрів (string FirstName,string LastName,string Email)
приклад передаваних даних:
{
    "FirstName":"Test",
    "LastName":"test",
    "Email":"test@gmail.com"   
}
2:
url:https://localhost:44321/Account/Create
type:"Post"
ця функція приймає обєкт з двох параметрів (string Name,string ContactEmail)
приклад передаваних даних:
{
    "Name":"test",
    "ContactEmail":"test@gmail.com"
   
}
3:
url:https://localhost:44321/Incident/Create
type:"Post"
ця функція приймає обєкт з трьох параметрів  (string IncidentName,string Description,string AccountName)
приклад передаваних даних:
{   
    "IncidentName":""(або IncidentNameKey )
    "Description":"thi is hard battle",
    "AccountName":"test"
}
також ще створив 3 додаткові Api для діставання всіх обєктів з бд
1:
url:https://localhost:44321/Contact/GetContacts
type:"Get"
діставання всіх Contacts з бд
2:
url:https://localhost:44321/Account/GetAccounts
type:"Get"
діставання всіх Accounts з бд
1:
url:https://localhost:44321/Incident/GetIncidents
type:"Get"
діставання всіх Incidents з бд
