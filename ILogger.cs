using System;
using Serilog;

namespace PetWithOleksii
{
    public interface ILogger<out TCategoryName> : ILogger
    {

    }
}
