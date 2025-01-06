Celem zadania jest przygotowanie aplikacji w .NET MAUI "Lista zakupów"
Wymagania na ocenę dopuszczającą:
-Aplikacja musi przechowywać dane na temat listy zakupów w formie plików. (nie .TXT)
-Aplikacja musi być zgodna z tematem zadania tj. "Lista zakupów"
-Projekt powinien być podzielony na widoki i modele danych
-niedopuszczalny jest ponglisz (dopuszczalne są teksty do wyświetlania w języku polskim)
-Produkty powinny być reprezentowane na interface za pomocą ContentView, który posiada następujące właściwości:
• Nazwa produktu
• jednostka w jakiej mierzymy produkt ( szt. l. kg. itp.)
• możliwość zaznaczenia elementu kupionego. taki element nie zostaje usunięty. Powinien on zostać w jakiś sposób zaznaczony (wyszarzenie, skreślenie) i umieszczony na końcu listy kategorii.
• możliwość określenia ilości poprzez wpisanie wartości liczbowej z klawiatury lub kliknięcie w "+" lub "-" aby zwiększyć/zmniejszyć o jeden ilość produktu
• możliwość całkowitego usunięcia produktu

Wymagania na ocenę dostateczną:

- Aplikacja ma dawać możliwość tworzenia nowych kategorii produktów (nabiał, warzywa, elektronika, agd, etc.) kilka z nich może być predefiniowanych już w aplikacji.
- Każda kategoria powinna być zaprezentowana w formie ContentView i mieć możliwość rozwinięcia kategorii w celu zobaczenia produktów z tej kategorii.
-Każdy produkt musi być przypisany do jakiejś kategorii już istniejącej.

Wymagania na wyższe oceny (na ocenę Dobrą muszą zostać zrealizowane 2 wymagania z poniższych, na Bardzo Dobrą - 4, a na celującą 6), przy czym wymagania 6. nie można wykonać jeśli wymaganie 1 lub 3 nie zostało zrealizowane:
1. Możliwość generowania/przełączania widoku "Listy do sklepu" w której będą pokazane tylko produkty nieoznaczone jako kupione oraz bez podziału na kategorie, ale po kategoriach posortowane. W momencie zaznaczenia elementu jako kupiony powinien on zniknąć z tego widoku a na liście z kategoriami powinien być zaznaczony jako kupiony.
2. Możliwość eksportu pliku do podzielnia się listą zakupową z innym użytkownikiem (funkcjonalność exportu i importu)
3. Możliwość oznaczenia sklepu w jakim dany produkt użytkownik chce kupić (Biedronka, Selgros itp.) i generowania widoku listy tylko dla tego konkretnego sklepu.
4. Możliwość oznaczenia w czytelny sposób, że dany produkt w liście zakupowej jest opcjonalny.
5. Zakładka z przepisami, w której możemy importować z przepisu potrzebne składniki do listy zakupów (Wraz z możliwością dodawania nowych przepisów, i przynajmniej dwoma predefiniowanymi przepisami)
6. Możliwość sortowania wyboru sortowania produktów po kategoriach (w przypadku list już wygenerowanych do konkretnego sklepu lub listy produktów niekupionych), po nazwie, po ilości.
