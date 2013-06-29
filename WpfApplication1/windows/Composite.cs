using System.Collections.Generic;

namespace WpfApplication1.windows
{
    class Composite
    {
        public string Name { get; set; }
        public bool Activo { get; set; }
        public int Indice { get; set; }
        public List<Composite> Children { get; set; }
    }
}