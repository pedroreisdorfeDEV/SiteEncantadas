using System.Drawing;
using System.Drawing.Imaging;
using ZXing.Common;
using ZXing;

namespace SiteEncantadas.Business.QRCode
{
    public class QrCodeService
    {
        private const string PixKey = "03451346052"; // Substitua pela sua chave PIX
        private const string BeneficiaryName = "Pedro Vinícius Francisco Reisdorfer"; // Substitua pelo nome do beneficiário
        private const string City = "Novo Hamburgo"; // Substitua pela cidade do beneficiário

        public byte[] GenerateQrCode(decimal amount)
        {
            string pixPayload = GeneratePixPayload(PixKey, BeneficiaryName, City, amount);

            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 100,
                    Width = 100,
                    Margin = 0
                }
            };

            var pixelData = writer.Write(pixPayload);
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            {
                using (var ms = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        private string GeneratePixPayload(string pixKey, string beneficiaryName, string city, decimal amount)
        {
            // Gera o payload do PIX de acordo com o padrão do Banco Central do Brasil
            // Esta é uma versão simplificada do payload. Você pode seguir o padrão completo para maior conformidade.
            return $"00020126360014BR.GOV.BCB.PIX0114{pixKey}5204000053039865404{amount:0.00}5802BR5909{beneficiaryName}6008{city}62070503***6304";
        }
    }
}
