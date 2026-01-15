using ImcCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImcCalculator.ViewModels
{
    public class IMCViewModel
    {
        public IMC ImcModel { get; set; } = new() { Height = 173, Weigth=65};
        

    
    }
}
