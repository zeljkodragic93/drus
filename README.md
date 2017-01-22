# drus

Upustvo:

-Napraviti novu bazu podataka koja se zove Scada
-Pokrenuti SQL skriptu iz root foldera
-U App config u svim projektima u kojima ima conneciton string izmjeniti data source tako da odgovara imenu SQL server instance na tom racunaru
-ScadaCLient (koji predstavlja mjerac) prima ime postojece lokacije kao argument komandne linije
-NAPOMENA: ime mjeraca koje ScadaService dodijeli se cuva u uniqueID.txt
-ObseverClient (koji prestavlja klijenta koji prati mjerace) listu zainteresovanih mjeraca prima kao argument komandne linije u csw formatu
