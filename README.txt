# Native apps II: mobile apps voor Windows (TI) (Herexamen)

## Info
Groep : NL7  
GroepsLeden:  
* Angelo Carly
* Simon Anckaert
* Robbie Verdurme

## Installation
Bij properties moeten zowel frontend als backend aangeduid staan bij het runnen van multiple projects:  
* Bij backend werkten wij met 'Start without debugging'
* Bij frontend gebruikten wij 'Start'

In StadsApp_Backend in de folder 'Migration' een file verwijderen:
* ..._initial.cs

Daarna in Package Manager Console bij Default Project 'StadsApp_Backend' aanduiden en de volgende commando's intypen:
* Add-Migration initial
* sqllocaldb.exe stop
* sqllocaldb.exe delete
* Update-database

Hierna het project runnen en als het opgestart is weer afsluiten en daarna het volgende commando invoeren in Package Manager Console bij Default Project 'StadsApp_Backend':
* Update-database

## User accounts
Hierna is het mogelijk om in te loggen als ondernemer met volgende gegevens:
* email: ondernemer@gent.be
* wachtwoord: Password0!

en als gebruiker:
* email: user@gent.be
* wachtwoord: Password0!
