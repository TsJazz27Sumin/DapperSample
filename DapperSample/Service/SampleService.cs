using System;
using System.Linq;

namespace DapperSample.Service
{
    class SampleService
    {
        public static SampleService Instance = new SampleService();
        private static SampleDapper SampleDapper = SampleDapper.Instance;

        private SampleService() { }

        public void Execute()
        {
            //新規登録
            SampleDapper.Insert("0001", "k.jarrett", 73, "music");
            SampleDapper.Insert("0002", "c.corea", 77, "music");

            //検索
            var workerList = SampleDapper.Select();

            foreach (var worker in workerList)
            {
                Console.WriteLine($"Id = {worker.Id } Name = {worker.Name } Age = {worker.Age } Department = {worker.Department }");
            }

            //更新
            SampleDapper.Update("0001", 74);
            SampleDapper.Update("0002", 78);

            //検索
            var jarrett = SampleDapper.Select("0001");
            var corea = SampleDapper.Select("0002");

            Console.WriteLine($"jarrett => Id = {jarrett.Id } Name = {jarrett.Name } Age = {jarrett.Age } Department = {jarrett.Department }");
            Console.WriteLine($"corea => Id = {corea.Id } Name = {corea.Name } Age = {corea.Age } Department = {corea.Department }");

            //削除
            SampleDapper.Delete("0001");
            SampleDapper.Delete("0002");

            workerList = SampleDapper.Select();

            if (workerList.Count() == 0) {
                Console.WriteLine("No Worker.");
            }
        }
    }
}
