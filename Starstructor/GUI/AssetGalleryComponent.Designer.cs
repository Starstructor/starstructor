namespace Starstructor.GUI
{
    partial class AssetGalleryComponent
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
            this.AssetGalleryComponentTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AssetTypeLabel = new System.Windows.Forms.Label();
            this.AssetNameLabel = new System.Windows.Forms.Label();
            this.AssetPreviewImage = new Starstructor.GUI.NoAliasPictureBox();
            this.AssetGalleryComponentTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetPreviewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // AssetGalleryComponentTableLayout
            // 
            this.AssetGalleryComponentTableLayout.ColumnCount = 1;
            this.AssetGalleryComponentTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssetGalleryComponentTableLayout.Controls.Add(this.AssetNameLabel, 0, 2);
            this.AssetGalleryComponentTableLayout.Controls.Add(this.AssetPreviewImage, 0, 0);
            this.AssetGalleryComponentTableLayout.Controls.Add(this.AssetTypeLabel, 0, 1);
            this.AssetGalleryComponentTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetGalleryComponentTableLayout.Location = new System.Drawing.Point(0, 0);
            this.AssetGalleryComponentTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.AssetGalleryComponentTableLayout.Name = "AssetGalleryComponentTableLayout";
            this.AssetGalleryComponentTableLayout.RowCount = 3;
            this.AssetGalleryComponentTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssetGalleryComponentTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AssetGalleryComponentTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AssetGalleryComponentTableLayout.Size = new System.Drawing.Size(100, 140);
            this.AssetGalleryComponentTableLayout.TabIndex = 0;
            // 
            // AssetTypeLabel
            // 
            this.AssetTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetTypeLabel.Location = new System.Drawing.Point(0, 100);
            this.AssetTypeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AssetTypeLabel.Name = "AssetTypeLabel";
            this.AssetTypeLabel.Size = new System.Drawing.Size(100, 20);
            this.AssetTypeLabel.TabIndex = 1;
            this.AssetTypeLabel.Text = "Object";
            this.AssetTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssetNameLabel
            // 
            this.AssetNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetNameLabel.Location = new System.Drawing.Point(0, 120);
            this.AssetNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AssetNameLabel.Name = "AssetNameLabel";
            this.AssetNameLabel.Size = new System.Drawing.Size(100, 20);
            this.AssetNameLabel.TabIndex = 2;
            this.AssetNameLabel.Text = "apexshipthingy";
            this.AssetNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssetPreviewImage
            // 
            this.AssetPreviewImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetPreviewImage.Location = new System.Drawing.Point(0, 0);
            this.AssetPreviewImage.Margin = new System.Windows.Forms.Padding(0);
            this.AssetPreviewImage.Name = "AssetPreviewImage";
            this.AssetPreviewImage.Size = new System.Drawing.Size(100, 100);
            this.AssetPreviewImage.TabIndex = 0;
            this.AssetPreviewImage.TabStop = false;
            // 
            // AssetGalleryComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AssetGalleryComponentTableLayout);
            this.Name = "AssetGalleryComponent";
            this.Size = new System.Drawing.Size(100, 140);
            this.AssetGalleryComponentTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssetPreviewImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel AssetGalleryComponentTableLayout;
        private System.Windows.Forms.Label AssetNameLabel;
        private NoAliasPictureBox AssetPreviewImage;
        private System.Windows.Forms.Label AssetTypeLabel;
    }
}
