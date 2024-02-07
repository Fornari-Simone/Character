using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.ClientHTTP.Abstraction
{
    public interface IClientHTTP
    {
        Task<IActionResult> LevelUP(int ID, int level, CancellationToken cancellation = default);
        Task<IActionResult> Ascend(int ID, CancellationToken cancellation = default);
    }
}
