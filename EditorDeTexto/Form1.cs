using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorDeTexto
{
    public partial class FormMain : Form
    {
        StringReader leitura = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Salvar()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter escrita = new StreamWriter(arquivo);
                    escrita.Flush();
                    escrita.BaseStream.Seek(0, SeekOrigin.Begin);
                    escrita.Write(this.richTextBox1.Text);
                    escrita.Flush();
                    escrita.Close();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Erro ao salvar o arquivo: " + x.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\Carlos\Documents\Visual Studio 2022";
            openFileDialog1.Filter = "(*.txt)|*.txt";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader leitura = new StreamReader(arquivo);
                    leitura.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = leitura.ReadLine();
                    while (linha != null)
                    {
                        this.richTextBox1.AppendText(linha + "\n");
                        linha = leitura.ReadLine();
                    }
                    leitura.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Erro ao abrir o arquivo: " + x.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Copiar()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
            else
            {
                MessageBox.Show("Selecione um texto para copiar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btnColar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negrito()
        {
            string nomeFonte = richTextBox1.SelectionFont.Name;
            float tamanhoFonte = richTextBox1.SelectionFont.Size;
            bool negrito = richTextBox1.SelectionFont.Bold;
            bool italico = richTextBox1.SelectionFont.Italic;
            bool sublinhado = richTextBox1.SelectionFont.Underline;

            if (!negrito)
            {
                // Adiciona o negrito mantendo os outros estilos
                FontStyle estilo = FontStyle.Bold;
                if (italico) estilo |= FontStyle.Italic;
                if (sublinhado) estilo |= FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo);
            }
            else
            {
                // Remove apenas o negrito, mantendo os outros estilos
                FontStyle estilo = FontStyle.Regular;
                if (italico) estilo |= FontStyle.Italic;
                if (sublinhado) estilo |= FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo);
            }
        }

        private void Italico()
        {
            string nomeFonte = richTextBox1.SelectionFont.Name;
            float tamanhoFonte = richTextBox1.SelectionFont.Size;
            bool negrito = richTextBox1.SelectionFont.Bold;
            bool italico = richTextBox1.SelectionFont.Italic;
            bool sublinhado = richTextBox1.SelectionFont.Underline;

            if (!italico)
            {
                // Adiciona o itálico mantendo os outros estilos
                FontStyle estilo = FontStyle.Italic;
                if (negrito) estilo |= FontStyle.Bold;
                if (sublinhado) estilo |= FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo);
            }
            else
            {
                // remove apenas o italico, mantendo os outros estilos
                FontStyle estilo = FontStyle.Regular;
                if (negrito) estilo |= FontStyle.Bold;
                if (sublinhado) estilo |= FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo);
            }
        }

        private void Sublinhado()
        {
            string nomeFonte = richTextBox1.SelectionFont.Name;
            string tamanhoFonte = richTextBox1.SelectionFont.Size.ToString();
            bool negrito = richTextBox1.SelectionFont.Bold;
            bool italico = richTextBox1.SelectionFont.Italic;
            bool sublinhado = richTextBox1.SelectionFont.Underline;

            if (!sublinhado)
            {
                // Adiciona o sublinhado mantendo os outros estilos
                FontStyle estilo = FontStyle.Underline;
                if (negrito) estilo |= FontStyle.Bold;
                if (italico) estilo |= FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(nomeFonte, float.Parse(tamanhoFonte), estilo);
            }
            else
            {
                // Remove apenas o sublinhado, mantendo os outros estilos
                FontStyle estilo = FontStyle.Regular;
                if (negrito) estilo |= FontStyle.Bold;
                if (italico) estilo |= FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(nomeFonte, float.Parse(tamanhoFonte), estilo);
            }
        }

        private void Imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void AlinharEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void AlinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void AlinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnNegrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btnItalico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btnSublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void btnEsquerda_Click(object sender, EventArgs e)
        {
            AlinharEsquerda();
        }

        private void btnCentralizar_Click(object sender, EventArgs e)
        {
            AlinharCentro();
        }

        private void btnDireita_Click(object sender, EventArgs e)
        {
            AlinharDireita();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinharCentro();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinharEsquerda();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinharDireita();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPorPagina = 0;
            float posicaoY = 0;
            int contadorLinhas = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            if (margemEsquerda < 5) margemEsquerda = 20;
            if (margemSuperior < 5) margemSuperior = 20;
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPorPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            linha = leitura.ReadLine();
            while (contadorLinhas < linhasPorPagina)
            {
                posicaoY = margemSuperior + (contadorLinhas * fonte.GetHeight(e.Graphics));
                e.Graphics.DrawString(linha, fonte, pincel, margemEsquerda, posicaoY, new StringFormat());
                contadorLinhas++;
                linha = leitura.ReadLine();
            }
            if (linha != null)
            {
                e.HasMorePages = true; // Indica que há mais páginas a serem impressas
            }
            else
            {
                e.HasMorePages = false; // Não há mais páginas
                leitura.Close();
            }
            pincel.Dispose();
        }

        private void Fonte()
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void btnFonte_Click(object sender, EventArgs e)
        {
            Fonte();
        }
        
        private void Desfazer()
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
            else
            {
                MessageBox.Show("Não há ações para desfazer.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refazer()
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
                richTextBox1.ClearUndo();
            }
            else
            {
                MessageBox.Show("Não há ações para refazer.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Desfazer();
        }

        private void refazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refazer();
        }
    }
}
