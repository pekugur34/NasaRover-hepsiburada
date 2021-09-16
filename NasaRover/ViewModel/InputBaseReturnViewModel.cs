
using System.Collections.Generic;
using NasaRover.Input;

namespace NasaRover.ViewModel
{
    public sealed class InputBaseReturnViewModel
    {
        public List<InputBase> InputBases { get; set; }
        public bool IsValidInput { get; set; }

    }
}