using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjMVC5.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //LOG AUDITORIA
            //TAL USUARIO GRAVOU X INFORMAÇÃO NA MODEL

            if(filterContext.Exception != null)
            {
                //Manipular a EX
                //Injetar alguma LIB de tratamento de erro
                // ->Gravar log de erro no BD
                // -> Email para o admin
                // ->Retornar cod de erro amigável

            }

            base.OnActionExecuted(filterContext);
        }
    }
}
