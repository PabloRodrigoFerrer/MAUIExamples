
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImcCalculator.Models
{

    [AddINotifyPropertyChangedInterface]
    public class IMC
    {
        public float Height { get; set; }

        public float Weight { get; set; }

        [DependsOn(nameof(Height), nameof(Weight))]
        public double Result => Math.Round(Weight / (Height * Height / 10000),2);

        public string State => Result switch
        {
            < 16 => "Delgadez severa(extrema)",
            < 16.99  => "Delgadez moderada",
            < 18.49 => "Delgadez aceptable",
            < 24.9 => "Peso normal",
            <29.9 => "Sobrepeso(Pre-obesidad)",
            <34.9 => "Obesidad grado I(Moderada)",
            <39.9 => "Obesidad grado II(Severa)",
            _ => "Obesidad grado III(Mórbida)"
           
        };

        public string LblResult => $"IMC: {Result}";

    }
}
