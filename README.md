# Lab4_MIP
Să se descarce pachetul SQLite (utilitarul din linia de comandă și DLL-urile pentru .NET).
Din linie de comandă:
Lansați sqlite3.exe.
Să se creeze o tabelă users cu câmpuri specifice (FirstName, LastName, CNP).
Să se insereze 3 utilizatori.
Să se vizualizeze toate înregistrările.
Să se șteargă toate înregistrările și tabelul users.
Să se închidă sqlite3.exe.

Se consideră aplicația construită în laboratorul anterior.
Să se adauge un meniu cu următoarea structură:
Database:
Connect.
Disconnect.
AddKeyword.
ViewKeywords.
Help:
About.

Fie o bază de date SQLite cu un singur tabel denumit Keywords având câmpurile:
id: integer, primary key, autoincrement.
keyword: TEXT.
Să se adauge o nouă clasă SQLiteHandler.
În clasa adăugată să se implementeze următoarele metode:
ConnectToDb(): Conectare la baza de date cu crearea automată a acesteia dacă nu există și cu crearea automată a tabelei Keywords.
DisconnectFromDb(): închiderea conexiunii.
InsertKeyword(string k): adăugarea unui cuvânt cheie în baza de date.
GetAllKeywords(): returnează o listă de string-uri reprezentând cuvintele cheie.

Să se apeleze metodele clasei nou create din meniul adăugat.
Introducerea unui nou keyword se va realiza dintr-un nou Form.
Noul form va conține:
Eticheta, textbox, butoane OK și Cancel.
Lansarea noului form se va realiza prin apelul metodei ShowDialog().
Se va verifica dacă valoarea returnată de ShowDialog() este OK sau Cancel. Doar pentru OK se va realiza adăugarea în baza de date.




