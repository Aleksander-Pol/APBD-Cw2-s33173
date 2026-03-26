# APBD Cw02 PD

## W ramach zadania domowego stworzyłem konsolową wypożyczalnię sprzętu

## Posiadane klasy
-**Device** - abstrakcyjna klasa sprzętu po którym dziedziczą klasy: **Camera**, **Laptop** i **Projector**. <br />
-**User** - abstrakcyjna klasa opisujące użytkownika systemu. Klasy dziedziczące: **Student**, **Employee**.<br />
-**Rental** - klasa opisująca moment wypożyczenia sprzętu przez użytkownika.<br />
-**RentalService** - klasa serwisowa zawierająca logikę wypożyczania sprzętu przez użytkowników.<br />

## Najważniejsze metody

### Rental
-**setPenalty()** - metoda pozwala ustawić karę za spóźniony zwrot. Obecnie algorytm przydzielania wysokości pensji jest
taki że wynosi 5% z kwoty za urządzenie pomnożone przez ilość spóźnionych dni. <br />

### RentalService
-**PrintAllDevices** - metoda wypisuje wszystkie zarejestrowane urządzenia <br />
-**PrintAllAvailableDevices** - metoda wypisuje wszystkie obecnie dostępne w wypożyczalni urządzenia <br />
-**RentDevice** - metoda która przyjmuje w parametrach użytkownika(1) który chce wypożyczyć jakiś sprzęt(2) na 
konkretną ilość dni(3). Metoda jest odporna na zły format ilości dni (np. ujemny).<br />
-**ReturnDevice** - metoda w parametrze przyjmuje użytkownika oraz sprzęt jak i również może przyjmować trzeci
parametr **days** który deafultowo przyjmuje wartość 0. Został on dodany tylko i wyłącznie w ramach zaprezentowania
działania kodu w ramach punktu 16. w wymaganiach. Ten parametr **days** sztucznie "dodaje" trochę dni do daty
oddania sprzętu przez co można zasymulować opóźniony zwrot. <br />
-**ViewActiveUserRentals** - metoda wyświetla aktywne wypożyczenia.<br />
-**ViewOutdatedRentals** - metoda wyświetla przeterminowane zwroty. Pokazuje najpierw te zakończone a potem te które
są przeterminowane ale użytkownik nadal nie zwrócił sprzętu.<br />
-**GenerateReport** - metoda wyświetla raport z działania wypożyczalni i pokazuje najważniejsze informacje odnośnie
obecnego jej stanu.


## Architektura projektu
Każda klasa z projektu została wydzielona do innego pliku. Dla zamodelowania zależności pomiędzy niektórymi obiektami użyłem
**klasy abstrakcyjnej i dziedziczenia** (Device => Laptop, Camera, Projector; User => Student, Employee). Daje mi to możliwość 
niepowtarzania się w kodzie a system jest bardziej elastyczny. Zgodnie z poleceniem w ramach projektu rozdzieliłem klasy na **model**
**domeny** - klasy przechowujące stan które same zarządzają swoimi danymi i na **model serwisowy** - klasę (RentalService) która zawiera
całą logikę biznesową wypożyczalni.


## Clean Code

### Kohezja
Przykładem dbania o kohezje w moim projekcie może być klasa **Rental** która dba o swój stan i posiada metody które tylko i wyłącznie
się jej tyczą. Gdybym wykonywał ustawianie setPenalty() w RentalService to by psuło kohezje ponieważ jest to metoda w pełni wpływająca
tylko na sam Rental. Poza tym sam podział na model domeny i serwisowy już tworzę pewną zwiększoną kohezję.

### Coupling
Przykładem niskiego couplingu jest chociażby przekazywanie klas bazowych w parametrach metod w RentalService co uelastycznia moje
metody, ponieważ one nie są zależne od tego czy np. dostaną Studenta czy Pracownika.

### Odpowiedzialności klas
Również samo zastosowanie modelu domen i serwisowego wpływa na jasny podział odpowiedzialności klas. Klasy domenowe trzymają swój stan
i posiadają metody w obrębie swoich danych, klasy serwisowe służą do obsługi "komunikacji" pomiędzy innymi klsami i logikę
biznesową, a klasa wywoławcza pokazuje przykładowe wywołanie programu.