using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Constants
{
    public static class PhotoConstrants
    {
        public static long MaxSize { get; } = 1024*1024;
        public static List<string> ValidExtensions { get; } =new() { ".png", ".jpg", ".jpeg" };
    }
}
