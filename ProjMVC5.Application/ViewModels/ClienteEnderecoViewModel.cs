using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMVC5.Application
{
    public class ClienteEnderecoViewModel
    {
        public ClienteEnderecoViewModel ClienteViewModel { get; set; }
        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}
