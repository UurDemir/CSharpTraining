﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Main
{
    public class InformationContainer
    {
        public string MyField = "";
        public string Name { get; set; }
        public string CompanyName { get => "Veripark"; }
        public int Age { get; set; }

        [Display(Name = "Yer Tutucu")]
        public string Placeholder { get; set; }

        public void WriteToScreen()
        {
            Console.WriteLine("Ekrana yazıyorum");
        }

        public void WriteToScreen(string parameter)
        {
            Console.WriteLine("Ekrana yazıyorum. Parametre : "+ parameter);
        }

        public int Sum(int parameter)
        {
            return parameter + parameter;
        }

    }
}
