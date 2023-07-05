using navPaginas.Models;

namespace navPaginas.ViewModels
{
    public class ConsultaIdViewModel
    {
        public Login LoginID { get; }

        public ConsultaIdViewModel(Login todosLogins)
        {
            LoginID = todosLogins;
        }
    }
}
