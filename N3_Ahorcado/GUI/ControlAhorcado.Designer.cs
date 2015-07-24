namespace N3_Ahorcado.GUI
{
    partial class ControlAhorcado
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIntentos = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblPalabra = new System.Windows.Forms.Label();
            this.pbxAhorcado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAhorcado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntentos
            // 
            this.lblIntentos.Location = new System.Drawing.Point(79, 14);
            this.lblIntentos.Name = "lblIntentos";
            this.lblIntentos.Size = new System.Drawing.Size(100, 16);
            this.lblIntentos.TabIndex = 1;
            this.lblIntentos.Text = "Quedan 6";
            this.lblIntentos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Location = new System.Drawing.Point(47, 199);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(162, 20);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPalabra
            // 
            this.lblPalabra.ForeColor = System.Drawing.Color.Blue;
            this.lblPalabra.Location = new System.Drawing.Point(0, 219);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(246, 32);
            this.lblPalabra.TabIndex = 3;
            this.lblPalabra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxAhorcado
            // 
            this.pbxAhorcado.Image = global::N3_Ahorcado.Properties.Resources.quedan6;
            this.pbxAhorcado.Location = new System.Drawing.Point(78, 34);
            this.pbxAhorcado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbxAhorcado.Name = "pbxAhorcado";
            this.pbxAhorcado.Size = new System.Drawing.Size(100, 161);
            this.pbxAhorcado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxAhorcado.TabIndex = 0;
            this.pbxAhorcado.TabStop = false;
            // 
            // ControlAhorcado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPalabra);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblIntentos);
            this.Controls.Add(this.pbxAhorcado);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ControlAhorcado";
            this.Size = new System.Drawing.Size(250, 256);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAhorcado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAhorcado;
        private System.Windows.Forms.Label lblIntentos;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblPalabra;
    }
}
