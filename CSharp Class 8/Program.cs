using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CSharp_Class_8.NamespaceDemoFolder1;
//using CSharp_Class_8.NamespaceDemoFolder2;

namespace CSharp_Class_8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Az 1-es struct látható, mivel a Main és a struct ugyanabban a névtérben vannak (namespace CSharp_Class_8)
            var struct1 = new NamespaceDemoStruct1();

            // A 2-es struct nem látható, mivel a Main és a struct eltérő névtérben vannak (namespace CSharp_Class_8 vs. CSharp_Class_8.NamespaceDemoFolder1)
            // Ahhoz, hogy használhassuk, be kell usingolni a névteret (using CSharp_Class_8.NamespaceDemoFolder1)
            var struct2 = new NamespaceDemoStruct2();

            // Ügyeljünk arra, hogy azonos névtérben nem lehet két ugyanolyan nevű saját típus (struct, enum stb.)
            // Eltérő névtérben lehet, ekkor viszont ha mindkét névtér be van usingolva, akkor explicit meg kell mondanunk, melyik típus szeretnénk használni
            // Példa (a fenti using CSharp_Class_8.NamespaceDemoFolder2; használatával):
            //var struct3 = new NamespaceDemoStruct2(); // Nem megy
            //var struct4 = new NamespaceDemoFolder1.NamespaceDemoStruct2(); // Megy
            //var struct5 = new NamespaceDemoFolder2.NamespaceDemoStruct2(); // Megy

            // Általában nem ajánlott két ugyanolyan nevű típust létrehozni, így kerüljük ezeket a helyzeteket!

            //--------------------------------------------------

            // Eddig tanult programozási megközelítésünk:
            // Vannak adataink és vannak metódusaink
            // A metódusok műveleteket végeznek az adatokon, de a programozó belátásán múlik, hogy a kettőt pontosan hogyan köti össze
            // Nincs közöttük semmilyen magasabb szintű, kézzelfogható kapcsolat
            // Példa: DriveTo(you, work);

            // Új megközelítés:
            // Ha körbenézünk magunk körül, akkor a tárgyaknak két nagy komponense van: tulajdonság (szín, forma, súly, kor stb.) és viselkedés/művelet (amit a tárgyon/tárggyal lehet végezni) (kinyit, bezár, indít stb.)
            // Az objektumorientált programozásnak (OOP) ez a lényege: helyezzük el egyetlen csomagba a tárgyak tulajdonságait és műveleteit
            // Példa: you.DriveTo(work); -> nem csak olvashatóbb/érthetőbb, de egyértelműbb ki, mivel, mit csinál

            //--------------------------------------------------

            // Azt a valamit, ami összeköti az adatokat és a rajtuk végezhető műveleteket, osztálynak hívjuk
            // Az osztály egy tervrajz, ami leírja milyen adatai és műveleti vannak annak a dolognak amit az osztály képvisel. Az, hogy az adott dolognak milyen adataira és műveleteire van szükségünk, az a mi döntésünk!
            // Készítsük el első osztályunkat (innentől külön fájlba is dolgozunk, lásd: Student.cs)

            // Az osztály tartalmazza a tervrajzot, azonban ahhoz, hogy használjuk és kitöltsük adatokkal az elkészült tervrajzot, ahhoz úgymond példányosítani kell az osztályt
            // Példányosítás: az osztályból (tervrajzból) létrehozunk egy konkrét egyedet (példányt), azaz egy konkrét diákot (studentet):
            var studentv1 = new Studentv1();

            // struct-okhoz hasonlóan kitölthetjük az adatokat:
            studentv1.classId = "10g";
            studentv1.name = "Teszt Elek";
            studentv1.grades = new List<int>();
            studentv1.grades.Add(5);

            // És használhatjuk azokat:
            Console.WriteLine(studentv1.name);

            // Ez eddig pontosan olyan mintha egy struct lenne, de várjuk ki a végét!

            // Elég idegesítő, hogy példányosítás után külön meg kell adni az egyes adattagok értékeit
            // Ráadásul ha elfelejtsük, akkor egy teljesen értelmetlen diákot kapunk, ami hibákhoz vezethet
            // Milyen jó lenne, ha már a példányosítás során megadhatnánk az adatokat, akár kötelezően
            // Van erre módszer: konstruktor
            // Konstruktor: olyan metódus, ami az osztály példányosításakor fut le (nem ő hozza létre az objektumot, csak képes inicializálni az adattagokat)
            // Eddig is használtunk konstruktort: Studentv1() <- ez egy konstruktor, csak nem vesz át semmilyen paramétert és nem csinál semmit
            // Hozzunk létre saját konstruktort és használjuk (Studentv2):
            var studentv2_1 = new Studentv2("10g", "Teszt Elek");
            // Vegyük észre, hogy mivel megadtunk egy saját konstruktort az osztályunknak, ezért az üres konstruktor már nem használható
            //var studentv2_2 = new Studentv2(); // nem jó
            // Ennek az az oka, hogy amíg egyetlen konstruktort sem adunk meg mi magunk, addig a fordító generál egy üres konstruktort az osztályunkba
            // Ezt az üres konstruktort hívjuk alapértelmezett konstruktornak
            // Abban a pillanatban, hogy készítünk egy saját konstruktort, a fordító nem fogja generálni az osztályunkhoz az alapértelmezette, így nem használhatjuk
            
            // Vegyük észre, hogy a konstruktor segítségével kikényszerítettük azt, hogy diákot csak úgy lehet példányosítani, hogy van osztálya, neve, illetve a jegyek listája is létre van hozva

            // Egy osztálynak több konstruktora lehet (Studentv3):
            // 1. konstruktor használata
            var studentv3_1 = new Studentv3("10g", "Teszt Elek");
            // 2. konstruktor (mintha alapértelmezett konstruktor lenne) használata
            var studentv3_2 = new Studentv3();
            // 3. konstruktor használata
            var studentv3_3 = new Studentv3("Teszt Elek");

            // A fordító intelligensen kiválasztja a megadott paraméterek alapján, hogy melyik konstruktor akarjuk hívni, csakúgy mint az egyszerű metódusoknál
            // A konstruktorok létrehozása is a metódusok túlterhelése alapján történik, azaz mindaddig létrehozhatunk egy konstruktort, amíg a paraméterlistája akár számban, akár típusban eltér az eddigi konstruktoroktól

            // Kezdeti értéket is adhatunk az adattagoknak (Studentv4):
            var studentv4 = new Studentv4();
            Console.WriteLine(studentv4.name); // Teszt Elek

            //--------------------------------------------------

            // Eddig beszéltünk az osztályok adat részéről, most beszéljünk a viselkedésről (metódusok)
            // Diák átlagának lekérése saját metódussal (Studentv5):
            var studentv5_1 = new Studentv5("10g", "Teszt Elek");
            Console.WriteLine(studentv5_1.GetAverage());

            // Van egy kis gond, bárki bármikor átírhatja egy diák bármilyen adatát, mivel publikus. Ezáltal az egész osztály működését el lehet rontani:
            var studentv5_2 = new Studentv5("10g", "Teszt Elek");
            studentv5_2.grades.Add(10); // Ilyen osztályzatot nem szabadna tudnunk hozzáadni

            // Mi a megoldás ennek elkerülésére?
            // Tegyük az adatokat priváttá és készítsünk metódusokat az adatok lekérdezéséhez és módosításához
            // Így el is jutottunk az OOP első szabályához: encapsulation (egységbezárás)
            // Egységbezárás: egy osztály adattagjai ne legyenek láthatóak. Az osztály dolga kezelni a saját adatait. Ha valaki módosítani/lekérdezni akarja, akkor azt metóduson keresztül, ellenőrizve tegye!
            // Studentv6:
            var studentv6 = new Studentv6("10g", "Teszt Elek");
            //studentv6.grades.Add(6); // Nem megy
            studentv6.AddGrade(4); // Jó
            //studentv6.AddGrade(7); // Hiba
            Console.WriteLine(studentv6.GetAverage());
            Console.WriteLine(studentv6.GetName());

            // A gettererk és setterek létrehozása annyira gyakori művelet, hogy a C#-ban van a létrehozásukra egy egyszerűbb módszer, de ezt később tanuljuk

            // Egy osztály metódusa is lehet private
            // Akkor tegyük priváttá egy osztály metódusát, ha a metódus az adott osztály belső működését valósítja meg
            // Például van egy prímszámokat generáló osztályom
            // Azokat a metódusokat, amik a prímszám generálásában vesznek részt priváttá tesszük, hiszen az osztály használóját nem érdekli, hogy hogyan generáljük a prímszámot
            // Az osztály használója csak le szeretne kérni egy prímszámot, így az osztálynak egyetlen publikus metódusa van a GetPrimeNumber()
            // Ezáltal az osztály használója nem veszik el az osztály publikusan elérhető metódusai között (hiszen csak 1 van), így teljesen egyértelmű hogyan kell használni az osztályt
            // Emellett ha valaha meg akarjuk változtatni a prímszám generálás menetét, az az osztály használóját nem befolyásolja, hiszen azokat a metódusokat meg se tudja hívni, mivel privátak
            // Ezáltal anélkül változtathatjuk az osztály működését, hogy az azt használó programok tönkremennének

            // Eljárás vs. függvény vs. metódus
            // Eljárás: utasítások elnevezett sorozata, melynek nincs visszatérési értéke (void metódus)
            // Függvény: utasítások elnevezett sorozata, melynek van visszatérési értéke (int, bool, string stb. metódus)
            // Metódus: egy olyan függvény, amely egy osztályhoz tartozik

            // Most, hogy elkészítettük első jól működő osztályunkat (Studentv6), vegyük észre, hogy eddig is rengeteg osztályt használtunk
            // Példák: List, Dictionary, Tuple, Random, Math, Console stb.

            // Sőt, maga a Main metódus is egy osztályban van, aminek a neve Program
        }
    }
}
