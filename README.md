WEBSITE URL: Localhost:4200
Om `NG SERVE` aan te roepen is het mogelijk dat `cd courseDBWebpage` eerst gebruikt moet worden.

De backend draait op poort Localhost:7177

Hoewel deze eindopdracht maar een week lang is heb ik veel energie in design en architectuur gestoken.
Bepaalde onderdelen zoals de upload-page-component voelt voor mij nog iets te hardcoded,
maar daar tegenover staat dat ik de DTO's,
sanatizers, (Tegen XSS)
interceptors, 
en een ErrorMessage service gemaakt heb, die in meer situaties hergebruikt kunnen worden.


De backend werkt met minimale DB access. Een fileupload word als maximaal 2 transacties naar de DB gestuurt.
De parsers reporten aan de frontend op welke line iets mis is d.m.v. een custom exception.
Courses worden by default van deze week bekeken, je kan het week nummer en jaar aanpassen om de courses van andere weken te bekijken.
Er is ook een overzicht pagina van alle courses die gegeven worden, en een upload pagina.

