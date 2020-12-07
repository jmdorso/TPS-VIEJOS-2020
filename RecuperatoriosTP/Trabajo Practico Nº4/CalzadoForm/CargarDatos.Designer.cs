namespace CalzadoForm
{
    partial class CargarDatos
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
            this.textBoxTalle = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.labelTalle = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTalle
            // 
            this.textBoxTalle.Location = new System.Drawing.Point(200, 37);
            this.textBoxTalle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTalle.Name = "textBoxTalle";
            this.textBoxTalle.Size = new System.Drawing.Size(359, 22);
            this.textBoxTalle.TabIndex = 0;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(200, 98);
            this.textBoxPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(359, 22);
            this.textBoxPrecio.TabIndex = 1;
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(87, 152);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(360, 44);
            this.buttonAceptar.TabIndex = 3;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // labelTalle
            // 
            this.labelTalle.AutoSize = true;
            this.labelTalle.Location = new System.Drawing.Point(38, 37);
            this.labelTalle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTalle.Name = "labelTalle";
            this.labelTalle.Size = new System.Drawing.Size(121, 17);
            this.labelTalle.TabIndex = 0;
            this.labelTalle.Text = "Talle (de 30 a 46)";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Location = new System.Drawing.Point(38, 98);
            this.labelPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(154, 17);
            this.labelPrecio.TabIndex = 0;
            this.labelPrecio.Text = "Precio (minimo $3.000)";
            // 
            // CargarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 209);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.labelTalle);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.textBoxTalle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CargarDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTalle;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Label labelTalle;
        private System.Windows.Forms.Label labelPrecio;

    }
}