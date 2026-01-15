using ImcCalculator.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ImcCalculator.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class IMCViewModel
    {
        public IMC ImcModel { get; set; } = new() { Height = 173, Weight = 65 };

        
  

      
    }
}
