using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;

namespace StadsApp_Windows.ViewModel.ParamDTO
{
    public class ParamDTO
    {
        public OndernemingRepository ondernemingRepo { get; set; }
        public Onderneming gekozenOnderneming { get; set; }
        public Vestiging gekozenVestiging { get; set; }
    }
}
