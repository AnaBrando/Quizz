using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);

        string EspacamentoQuebraLinha(string input);
    }
}
