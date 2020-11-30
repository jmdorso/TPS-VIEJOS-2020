namespace CalzadoForm
{
    partial class VenderEmpresaBotines
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxVentas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxVentas
            // 
            this.listBoxVentas.BackColor = System.Drawing.Color.Black;
            this.listBoxVentas.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxVentas.ForeColor = System.Drawing.Color.Red;
            this.listBoxVentas.FormattingEnabled = true;
            this.listBoxVentas.ItemHeight = 21;
            this.listBoxVentas.Location = new System.Drawing.Point(13, 13);
            this.listBoxVentas.Name = "listBoxVentas";
            this.listBoxVentas.Size = new System.Drawing.Size(775, 424);
            this.listBoxVentas.TabIndex = 0;
            // 
            // Venta1x1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(806, 465);
            this.Controls.Add(this.listBoxVentas);
            this.ForeColor = System.Drawing.Color.ForestGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Venta1x1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendemos 1x1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Venta1x1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVentas;
    }
}