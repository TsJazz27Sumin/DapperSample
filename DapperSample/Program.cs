using DapperSample.Service;
using System;

namespace DapperSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleService.Instance.Execute();
        }
    }
}
