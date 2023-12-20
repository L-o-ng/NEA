using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal static class Globals
    {
        public static string? g_username = null;

        public const int g_cellWidth = 10;
        public const int g_cellHeight = 10;

        public const int g_keySize = 64;
        public const int g_iterations = 350000;
    }
}
