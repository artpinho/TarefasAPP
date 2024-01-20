using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasApp.Enums
{
    public enum TaskStats
    {
        [Description("A fazer")]
        ToDo = 1,
        [Description("Em andamento")]
        OnGoing = 2,
        [Description("Concluído")]
        Done = 3
    }
}