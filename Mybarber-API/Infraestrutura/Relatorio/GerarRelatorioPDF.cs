using Aplicacao.Interfaces;
using Aplicacao.ObjetosDeTransferencia;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
namespace Infraestrutura.Relatorio
{
    public class GerarRelatorioPDF : IGerarRelatorioPdf
    {

        public void GerarRelatorio(DadosPreparadosParaRelatorio dadosPreparadosParaRelatorioPdf) 
        {
            int totalPaginas = 1;
            //configurar dados do PDF
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm,
                    15 * pxPorMm, 20 * pxPorMm);
            //Nome do arquivo
            var nomeArquivo = $"relatorio.{DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss")}.pdf";
            //Criando arquivo
            var arquivo = new FileStream(nomeArquivo, FileMode.Create);
            //Unindo arquivo a pdf
            var writer = PdfWriter.GetInstance(pdf, arquivo);

            pdf.Open();

            //Definindo a fonte
            var fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            //adiciona um título
            var fonteParagrafo = new iTextSharp.text.Font(fonteBase, 32,
                iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var titulo = new Paragraph("Relatório do Barbeiro\n\n", fonteParagrafo);
            titulo.Alignment = Element.ALIGN_LEFT;
            titulo.SpacingAfter = 4;
            pdf.Add(titulo);

            //adiciona uma imagem
            var caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "logoMb.png");

            if (File.Exists(caminhoImagem))
            {
                iTextSharp.text.Image logo =
                    iTextSharp.text.Image.GetInstance(caminhoImagem);
                float razaoLarguraAltura = logo.Width / logo.Height;
                float alturaLogo = 32;
                float larguraLogo = alturaLogo * razaoLarguraAltura;
                logo.ScaleToFit(larguraLogo, alturaLogo);
                var margemEsquerda = pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                logo.SetAbsolutePosition(margemEsquerda, margemTopo);
                writer.DirectContent.AddImage(logo, false);
            }

            //Resumo Relatorio
            var fonteTitulo = new iTextSharp.text.Font(fonteBase, 18,
                iTextSharp.text.Font.BOLD, BaseColor.Black);
            var fonteValor = new iTextSharp.text.Font(fonteBase, 18, iTextSharp.text.Font.NORMAL, BaseColor.Black);

            var tabelaResumo = new PdfPTable(2); // Cria uma tabela com duas colunas
            tabelaResumo.WidthPercentage = 90; // Define a largura da tabela 

            var faturamentoTitulo = new PdfPCell(new Phrase("Valor Faturado", fonteTitulo));
            var servicosTitulo = new PdfPCell(new Phrase("Número de serviços", fonteTitulo));
            
            var faturamentoValor = new PdfPCell(new Phrase("R$ " + dadosPreparadosParaRelatorioPdf.FaturamentoGeral.ToString(), fonteValor));
            var servicoValor = new PdfPCell(new Phrase(dadosPreparadosParaRelatorioPdf.ServicosPrestados.ToString(), fonteValor));
            faturamentoTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            servicosTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            faturamentoValor.HorizontalAlignment = Element.ALIGN_CENTER;
            servicoValor.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaResumo.AddCell(faturamentoTitulo);
            tabelaResumo.AddCell(servicosTitulo);
            tabelaResumo.AddCell(faturamentoValor);
            tabelaResumo.AddCell(servicoValor);
            pdf.Add(tabelaResumo);
            pdf.Add(new Paragraph("\n"));
            pdf.Add(new Paragraph("\n"));
            //adiciona uma tabela
            var tabela = new PdfPTable(5);
            float[] larguras = { 1f, 1f, 0.7f, 0.9f, 0.7f };
            tabela.SetWidths(larguras);
            tabela.DefaultCell.BorderWidth = 0;
            tabela.WidthPercentage = 100;

            //adiciona os títulos das colunas
            CriarCelulaTexto(tabela, "Barbeiro", PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTexto(tabela, "Número de serviços", PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTexto(tabela, "Faturamento", PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTexto(tabela, "Porcentagem", PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTexto(tabela, "Comissão", PdfPCell.ALIGN_CENTER, true);

            //adiciona valores as colunas
            foreach (BarbeiroRelatorioPdf barbeiro in dadosPreparadosParaRelatorioPdf.BarbeiroRelatorioPdf)
            {
                barbeiro.ObterComissao();
                CriarCelulaTexto(tabela, barbeiro.NomeBarbeiro, PdfPCell.ALIGN_CENTER, true);
                CriarCelulaTexto(tabela, barbeiro.NumeroServicos.ToString(), PdfPCell.ALIGN_LEFT, true);
                CriarCelulaTexto(tabela, "R$ " + barbeiro.Faturamento.ToString(), PdfPCell.ALIGN_CENTER, true); ;
                CriarCelulaTexto(tabela, (barbeiro.Porcentagem * 100) + " %", PdfPCell.ALIGN_CENTER, true);
                CriarCelulaTexto(tabela, "R$ " + barbeiro.Comissao, PdfPCell.ALIGN_CENTER, true);
            }

            //Adiciona Tabela
            pdf.Add(tabela);

            //Fecha a edição
            pdf.Close();
            arquivo.Close();

            //Salvando pdf
            var caminhoPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
            if (File.Exists(caminhoPDF))
            {
                Process.Start(new ProcessStartInfo()
                {
                    //Arguments = $"/c start firefox {caminhoPDF}",
                    Arguments = $"/c start {caminhoPDF}",
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
        }

        static void CriarCelulaTexto(PdfPTable tabela, string texto,
            int alinhamento = PdfPCell.ALIGN_LEFT,
            bool negrito = false, bool italico = false,
            int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int estilo = iTextSharp.text.Font.NORMAL;
            if (negrito && italico)
            {
                estilo = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                estilo = iTextSharp.text.Font.BOLD;
            }
            else if (italico)
            {
                estilo = iTextSharp.text.Font.ITALIC;
            }

            BaseFont fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font fonte = new iTextSharp.text.Font(fonteBase, tamanhoFonte,
                estilo, iTextSharp.text.BaseColor.Black);

            //cor de fundo diferente para linhas pares e ímpares
            var bgColor = iTextSharp.text.BaseColor.White;
            if (tabela.Rows.Count % 2 == 1)
                bgColor = new BaseColor(0.95f, 0.95f, 0.95f);

            PdfPCell celula = new PdfPCell(new Phrase(texto, fonte));
            celula.HorizontalAlignment = alinhamento;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.PaddingBottom = 5; //pra alinhar melhor verticalmente
            celula.FixedHeight = alturaCelula;
            celula.BackgroundColor = bgColor;
            tabela.AddCell(celula);
        }
    }
}
