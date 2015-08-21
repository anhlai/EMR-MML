namespace MedicalInterfaceTest {
    partial class TestForm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.ReadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OrcaPatInfoReadTestButton = new System.Windows.Forms.Button();
            this.OrcaDiseaseCreateButton = new System.Windows.Forms.Button();
            this.OrcaSampleReadTextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReadFileDialog
            // 
            this.ReadFileDialog.InitialDirectory = "D:\\yoshinori\\電子カルテ";
            // 
            // OrcaPatInfoReadTestButton
            // 
            this.OrcaPatInfoReadTestButton.Location = new System.Drawing.Point(12, 58);
            this.OrcaPatInfoReadTestButton.Name = "OrcaPatInfoReadTestButton";
            this.OrcaPatInfoReadTestButton.Size = new System.Drawing.Size(200, 23);
            this.OrcaPatInfoReadTestButton.TabIndex = 0;
            this.OrcaPatInfoReadTestButton.Text = "ORCA患者情報読み込みテスト";
            this.OrcaPatInfoReadTestButton.UseVisualStyleBackColor = true;
            this.OrcaPatInfoReadTestButton.Click += new System.EventHandler(this.OrcaPatInfoReadTestButton_Click);
            // 
            // OrcaDiseaseCreateButton
            // 
            this.OrcaDiseaseCreateButton.Location = new System.Drawing.Point(12, 87);
            this.OrcaDiseaseCreateButton.Name = "OrcaDiseaseCreateButton";
            this.OrcaDiseaseCreateButton.Size = new System.Drawing.Size(200, 23);
            this.OrcaDiseaseCreateButton.TabIndex = 1;
            this.OrcaDiseaseCreateButton.Text = "ORCA病名情報生成テスト";
            this.OrcaDiseaseCreateButton.UseVisualStyleBackColor = true;
            this.OrcaDiseaseCreateButton.Click += new System.EventHandler(this.OrcaDiseaseCreateButton_Click);
            // 
            // OrcaSampleReadTextButton
            // 
            this.OrcaSampleReadTextButton.Location = new System.Drawing.Point(12, 12);
            this.OrcaSampleReadTextButton.Name = "OrcaSampleReadTextButton";
            this.OrcaSampleReadTextButton.Size = new System.Drawing.Size(200, 23);
            this.OrcaSampleReadTextButton.TabIndex = 2;
            this.OrcaSampleReadTextButton.Text = "ORCAサンプル読み込みテスト";
            this.OrcaSampleReadTextButton.UseVisualStyleBackColor = true;
            this.OrcaSampleReadTextButton.Click += new System.EventHandler(this.OrcaSampleReadTextButton_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 263);
            this.Controls.Add(this.OrcaSampleReadTextButton);
            this.Controls.Add(this.OrcaDiseaseCreateButton);
            this.Controls.Add(this.OrcaPatInfoReadTestButton);
            this.Name = "TestForm";
            this.Text = "MMLテストフォーム";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ReadFileDialog;
        private System.Windows.Forms.Button OrcaPatInfoReadTestButton;
        private System.Windows.Forms.Button OrcaDiseaseCreateButton;
        private System.Windows.Forms.Button OrcaSampleReadTextButton;
    }
}

