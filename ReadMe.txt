Aplikacja działa na serwerze MySql i kożysta z  localhosta, korzysta z Entity Framework Core
-Apliacja składa się z 2 mikroserwisów. Jeden służy do zakładania konta i logowania, a druga służy do obliczania kalorii dla swojego psa.
-Należy otworzyć 2 solucje AccountMicroServisApi oraz DogCalApi
W obu solucjach na początku należy zrobić update bazy danych. W Packege Manager Console należy wprowadzić "update-database", Od tego moemntu możemy kożystać z  aplikacji
- Proszę uruchomić AccountMicroServisApi poprzez solucję. Mikro serwis jest wspierany przez Swager. Przy użyciu Swagera można założyć konto, lub zalogować się do jednego z  2 kont w bazie danych. 
Konto admina: email: test1@gmail.com hasło: Admin123
Konto użytkownika: test2@gmail.com hasło: User123

Rejestracja to wprowadzenie podstawowych danych i podanie roli użytkownika
1 Admin
2 User


Po zalogowaniu endpoint zwraca token JWT, który służy do autentykacji drugiego mikroserwisu.
następnie można uruchomić DogCalApi. Niestety mimo, iż włącza się Swager, może okazać się, że token w Swagerze nie działa (ale można w  łatwy sposób zdobyć konkretne linki URL od zapytań). Z Aplikacji można za to korzystać przy pomocy postmana. W nagłówku auth należy wybrać Type : "Bearer Token" i w  pole token wklejamy wygenerowany token przez api do logowania. 
Aby skorzystać z  akcji Create api/Dog/Create
wprowadzamy w formacie JSON
 {
  "name": "imię",
  "weight": 0,
  "activityLevel": 0
}
ActivityLevel można wybrać  z poniższej listy:
0 Dorosły niesterylizowany lub ciąża w pierwszych dwóch trymestrach lub dorosły niesterylizowany
1 Dorosły sterylizowany
2 Nadwaga niska aktywność
3 Leczenie otyłości lub intensywna terapia żywieniowa
4 Przyrost masy ciała i rekonwalescencja
5 Szkolenie robocze lekkie
6 Ciąża w ostatnim trymestrze lub laktacja jedno szczenię lub szkolenie robocze umiarkowane lub wzrost od czwartego do piątego miesiąca
7 Laktacja dwóch szczeniąt
8 Laktacja trzech do czterech szczeniąt lub szkolenie robocze ciężkie
9 Laktacja pięciu do sześciu szczeniąt
10 Laktacja siedmiu do ośmiu szczeniąt
11 Laktacja dziewięciu lub więcej szczeniąt
12 Wzrost od ósmego do dwunastego miesiąca

akcja api/Dog/GetMyDogs zwraca wszystkie twoje psy z  bazy.
Akcja api/Dog/GetAll zwraca wszystkie psy z  baz, ale tylko jeśli jesteś zalogowany jako admin

Akcja api/Dog/Delete usówa twojego psa z bazy danych o podanym imieniu w parametrach Key: name Value "imię psa"