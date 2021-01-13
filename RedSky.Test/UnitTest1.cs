using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedSky.Common;
using RedSky.Domain.Entities;
using RedSky.Infrastructure.NFSe;
using RedSky.Infrastructure.NFSe.Factories;

namespace RedSky.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDecimalRounding()
        {
            Assert.AreEqual(1m, 1.1m.DecimalTowardZero(0));
            Assert.AreEqual(1.1m, 1.11m.DecimalTowardZero(1));
            Assert.AreEqual(1.11m, 1.111m.DecimalTowardZero(2));
            Assert.AreEqual(1.111m, 1.1111m.DecimalTowardZero(3));
            Assert.AreEqual(1.1111m, 1.11111m.DecimalTowardZero(4));
            Assert.AreEqual(1m, 1.5m.DecimalTowardZero(0));
            Assert.AreEqual(1.5m, 1.55m.DecimalTowardZero(1));
            Assert.AreEqual(1.55m, 1.555m.DecimalTowardZero(2));
            Assert.AreEqual(1.555m, 1.5555m.DecimalTowardZero(3));
            Assert.AreEqual(1.5555m, 1.55555m.DecimalTowardZero(4));
            Assert.AreEqual(1m, 1.9m.DecimalTowardZero(0));
            Assert.AreEqual(1.9m, 1.99m.DecimalTowardZero(1));
            Assert.AreEqual(1.99m, 1.999m.DecimalTowardZero(2));
            Assert.AreEqual(1.999m, 1.9999m.DecimalTowardZero(3));
            Assert.AreEqual(1.9999m, 1.99999m.DecimalTowardZero(4));
        }

        [TestMethod]
        public void TestNFSeSorocabaDownload()
        {
            NFSeService svc = new NFSeService(new NFSeWSFactory());
            svc.DownloadNFSe(new Filial {Id = 2, Cidade = new Cidade(){Codigo = "7145"}},
                "https://www.issdigitalsod.com.br/nfse/visualizarNota.php?id_nota_fiscal=NjM0NDgxMjM=&temPrestador=Tg==&codCidIni=7145&rDecId=000330293",
                @"C:\Users\bcfru\Desktop\test.pdf");
        }
    }
}
