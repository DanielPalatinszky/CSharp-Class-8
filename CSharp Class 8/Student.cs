using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Class_8
{
    // Az átláthatóság kedvéért egy fájlba rakom az összes Student verziót, de élesben egy fájlban csak egy osztály legyen!

    // Első osztályunk, amely egy diák adatait és műveleteit ábrázolja
    class Studentv1
    {
        // struct-hoz hasonlóan a nekünk szükséges adatok egy diákról:
        public string classId;
        public string name;

        public List<int> grades;
    }

    // Student, egyedi konstruktorral
    class Studentv2
    {
        public string classId;
        public string name;

        public List<int> grades;

        // Konstruktor, amely paraméterként átveszi az osztályt és a nevet, majd beírja az osztály megfelelő adattagjaiba
        // A paraméterek neve lehet bármi, azonban általában megegyezik az adattag nevével!
        // Konstruktort úgy hozunk létre mintha metódust készítenénk, csak nincs visszatérési típusa és a neve megegyezik az osztály nevével:
        public Studentv2(string classId, string name)
        {
            // Következő órán megbeszéljük mi az a "this", most jegyezzük meg, hogy az egyenlőség bal oldalán a "this." után az osztályunk adattagjai vannak
            // Az egyenlőség jobb oldalán pedig a konstruktor paraméterei szerepelnek
            // Azaz egyszerűen beírjuk az osztály adattagjaiba a példányosításkor a konstruktornak átadott adatokat
            this.classId = classId;
            this.name = name;

            // A jegyek listát egyszerűen példányosítjuk, hogy ne felejtsük el később:
            this.grades = new List<int>();
        }
    }

    // Student több konstruktorral
    class Studentv3
    {
        public string classId;
        public string name;

        public List<int> grades;

        // 1. konstruktor
        public Studentv3(string classId, string name)
        {
            this.classId = classId;
            this.name = name;
            this.grades = new List<int>();
        }

        // 2. konstruktor
        // Mintha alapértelmezett konstruktor lenne
        public Studentv3()
        {

        }

        // 3. konstruktor
        public Studentv3(string name)
        {
            this.name = name;
            this.grades = new List<int>();
        }
    }

    // Student kezdeti értékekkel rendelkező adatagokkal:
    class Studentv4
    {
        public string classId = "10g"; // Adhatunk kezdeti értéket, de nincs sok értelme, hiszen a diákok többségének úgyis egyedi osztálya lesz
        public string name = "Teszt Elek"; // Adhatunk kezdeti értéket, de nincs sok értelme, hiszen a diákok többségének úgyis egyedi neve lesz

        public List<int> grades = new List<int>(); // Ebben az esetben megéri az alapértelmezett érték, hiszen így nem felejtjük el a lista létrehozását és a konstruktorokban sem kell bajlódni vele
    }

    // Student adattal és viselkedéssel:
    class Studentv5
    {
        public string classId;
        public string name;

        public List<int> grades = new List<int>();

        public Studentv5(string classId, string name)
        {
            this.classId = classId;
            this.name = name;
        }

        // Diák átlagának lekérése
        public double GetAverage()
        {
            return grades.Average();
        }
    }

    // Student az egységbezárás betartásával:

    class Studentv6
    {
        // Az adattagok legyenek privátak, mivel az osztály dolga ezeket kezelni
        private string classId;
        private string name;

        private List<int> grades = new List<int>();

        public Studentv6(string classId, string name)
        {
            this.classId = classId;
            this.name = name;
        }

        public double GetAverage()
        {
            return grades.Average();
        }

        // Azoknak a metódusoknak a nevét, amik egy adattagot adnak vissza Get-el kezdjük, majd utána jön az adattag neve
        // Ezeket a metódusokat hívjuk gettereknek

        // Azoknak a metódusoknak a nevét, amik egy adattag értékét módosítják Set-el kezdjük, majd utána jön az adattag neve
        // Ezeket a metódusokat hívjuk settereknek

        // Hozzunk létre metódusokat az adatok lekérdezéséhez és módosításához:

        // Az osztály csak lekérdezhető, kívülről senki nem módosíthatja tetszés szerint (getter):
        public string GetClassId()
        {
            return classId;
        }

        // A név csak lekérdezhető, kívülről senki nem módosíthatja tetszés szerint (getter):
        public string GetName()
        {
            return name;
        }

        // Példa setter:
        /*public void SetName(string name)
        {
            this.name = name;
        }*/

        // Ha valaki osztályzatot akar adni a diáknak, akkor azt csak ellenőrzött körülmények között teheti meg, így biztos nem romlik el az osztály működése:
        public void AddGrade(int grade)
        {
            if (grade < 1 || grade > 5)
                throw new Exception("Rossz jegy! A jegy csak 1, 2, 3, 4 vagy 5 lehet!");

            grades.Add(grade);
        }
    }
}
