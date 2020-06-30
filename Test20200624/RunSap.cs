using SapNwRfc;

namespace Test20200624
{
    public class RunSap
    {
        public static void Run()
        {
            string connStr = "connectionstring";

            using var connection = new SapConnection(connStr);
            connection.Connect();

            using var someFunction = connection.CreateFunction("MySapfunction");
            var result = someFunction.Invoke<SomeFunctionResult>(new
            {
                VBELN = "partnumber",
            });
        }
    }

    class SomeFunctionResult
    {
        [SapName("SomeFunctionSet")]
        public SomeFunctionResultItem[] Items { get; set; }
    }

    class SomeFunctionResultItem
    {       
        public string WERKS { get; set; }
        public string MATNR { get; set; }
        public string VBELN { get; set; }
        public string POSNR { get; set; }
        public string STSTEXT { get; set; }
        public string UEPOS { get; set; }
    }
}
