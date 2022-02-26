﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tanulo_kviz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<RadioButton> buttons = new List<RadioButton>();
        public Dictionary<string, Tantargy> tantargyNyilvantarto = new Dictionary<string, Tantargy>();
        public List<Tantargy> targyak = new List<Tantargy>();
        Tantargy selectedTargy = null;
        Tema selectedTema = null;
        public List<Kerdes> betoltottKerdesek = new List<Kerdes>();
        int oldalIndex = 0;
        Kerdes currentKerdes = null;

        List<Button> oldalValtoGombok = new List<Button>();
        bool kiertekelt = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        public class Tantargy
        {
            public Dictionary<string, Tema> temaNyilvantarto = new Dictionary<string, Tema>();
            public List<Tema> temak = new List<Tema>();
            public string nev;

            public Tantargy(string eleresiUt)
            {
                string[] allomany = File.ReadAllLines(eleresiUt);


                nev = allomany[0].Split(';')[0];


                List<string> temaFajtak = new List<string>();
                foreach (string sor in allomany)
                {
                    string temaNev = sor.Split(';')[1];
                    if (!temaFajtak.Contains(temaNev))
                    {
                        temaFajtak.Add(temaNev);
                        Tema ujTema = new Tema(temaNev, allomany);
                        temaNyilvantarto.Add(ujTema.nev, ujTema);
                        temak.Add(ujTema);
                    }
                }
            }
        }

        public class Tema
        {
            public List<Kerdes> kerdesek = new List<Kerdes>();
            public string nev;
            public Tema(string nev, string[] allomany)
            {
                this.nev = nev;
                foreach (string sor in allomany)
                {
                    if (sor.Split(';')[1] == nev)
                    {
                        Kerdes kerdes = new Kerdes(sor);
                        kerdesek.Add(kerdes);
                    }

                }
            }
        }

        public class Kerdes
        {
            public string kerdes;
            public string helyesValasz;
            public string valasz2;
            public string valasz3;
            public string valasz4;

            public string valasztott = null;

            public List<string> sorrend = new List<string>();

            public List<string> valaszok = new List<string>();
            public Kerdes(string sor)
            {
                string[] splitek = sor.Split(';');
                kerdes = splitek[2];
                helyesValasz = splitek[3];
                valasz2 = splitek[4];
                valasz3 = splitek[5];

                valasz4 = splitek[6];
                FeltöltValaszok();

            }

            public void FeltöltValaszok()
            {
                valaszok.Add(helyesValasz);
                valaszok.Add(valasz2);
                valaszok.Add(valasz3);
                valaszok.Add(valasz4);
            }
        }
    }
}
