Backendowa aplikacja w C# i ASP.NET Core służąca do zarządzania salami szkoleniowymi i ich rezerwacjami. Zamiast tradycyjnej bazy danych, 
system przechowuje informacje w pamięci operacyjnej programu, wczytując gotową pulę danych przy każdym uruchomieniu. Aplikacja umożliwia 
pełną obsługę tych zasobów: przeglądanie, filtrowanie, dodawanie, edycję oraz usuwanie poszczególnych sal i spotkań. Wbudowana logika weryfikuje 
wprowadzane informacje, zapobiegając błędom takim jak braki w formularzach, nakładające się na siebie rezerwacje czy próby usunięcia zaplanowanej 
już sali. Każda wykonana akcja zwraca odpowiedni, standardowy kod HTTP, który jasno informuje o sukcesie, nieprawidłowych danych lub ewentualnym 
konflikcie biznesowym.
