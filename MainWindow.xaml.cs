using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private int counter = 1;
        private List<Cat> cats = new List<Cat>();

        private CatVMEdit catVMEdit;

        private CatVMInfo catVMInfoPrev;
        private CatVMInfo catVMInfoCurrent;
        private CatVMInfo catVMInfoNext;

        private CatVMCaress catVMCaress;

        public MainWindow()
        {
            InitializeComponent();

            cats.Add(new Cat("Musya", "red", 10));
            cats.Add(new Cat("Masha", "black", 5));
            cats.Add(new Cat("Sasha", "red", 14));
            cats.Add(new Cat("Rinat Igorievich", "bald", 48));
            cats.Add(new Cat("Artur", "gray", 3));
            cats.Add(new Cat("Denis", "black", 1));


            catVMEdit = new CatVMEdit(EditName, EditColor, EditAge);

            catVMInfoPrev = new CatVMInfo(InfoPrevious);
            catVMInfoCurrent = new CatVMInfo(InfoCurrent);
            catVMInfoNext = new CatVMInfo(InfoNext);

            catVMCaress = new CatVMCaress(Caress);

            UpdateBindings();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            catVMCaress.Caress();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
                counter--;

            UpdateBindings();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (counter < cats.Count - 1)
                counter++;

            UpdateBindings();
        }

        private void UpdateBindings()
        {
            catVMEdit.Bind(cats[counter]);

            catVMInfoPrev.Bind(cats[Math.Max(counter - 1, 0)]);
            catVMInfoCurrent.Bind(cats[counter]);
            catVMInfoNext.Bind(cats[Math.Min(counter + 1, cats.Count - 1)]);

            catVMCaress.Bind(cats[counter]);
        }
    }
}
