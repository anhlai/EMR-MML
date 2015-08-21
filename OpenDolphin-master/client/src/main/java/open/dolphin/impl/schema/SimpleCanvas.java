/*
 * Baka.java
 *
 * Created on 2007/12/17, 19:10
 */

package open.dolphin.impl.schema;

/**
 *
 * @author  kazm
 */
public class SimpleCanvas extends javax.swing.JDialog {
    
    /** Creates new form Baka */
    public SimpleCanvas(java.awt.Frame parent, String title, boolean modal) {
        super(parent, title, modal);
        initComponents();
    }
    
    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    // <editor-fold defaultstate="collapsed" desc="Generated Code">                          
    private void initComponents() {

        lineBtn = new javax.swing.JToggleButton();
        rectBtn = new javax.swing.JToggleButton();
        ovalBtn = new javax.swing.JToggleButton();
        polyBtn = new javax.swing.JToggleButton();
        rectFillBtn = new javax.swing.JToggleButton();
        ovalFillBtn = new javax.swing.JToggleButton();
        polyFillBtn = new javax.swing.JToggleButton();
        textBtn = new javax.swing.JToggleButton();
        lineWidthCombo = new javax.swing.JComboBox();
        colorBtn = new javax.swing.JButton();
        undoBtn = new javax.swing.JButton();
        clearBtn = new javax.swing.JButton();
        canvasPanel = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        titleFld = new javax.swing.JTextField();
        jLabel2 = new javax.swing.JLabel();
        roleCombo = new javax.swing.JComboBox();
        okBtn = new javax.swing.JButton();
        cancelBtn = new javax.swing.JButton();
        selectBtn = new javax.swing.JToggleButton();
        openPathBtn = new javax.swing.JToggleButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        lineBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/LineOff.gif"))); // NOI18N
        lineBtn.setToolTipText("直線を描きます。");
        lineBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        rectBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/RectOff.gif"))); // NOI18N
        rectBtn.setToolTipText("四角形を描きます。");
        rectBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        ovalBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/OvalOff.gif"))); // NOI18N
        ovalBtn.setToolTipText("楕円を描きます。");
        ovalBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        polyBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/PolyOff.gif"))); // NOI18N
        polyBtn.setToolTipText("閉じたパスを描きます。");
        polyBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        rectFillBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/FillRectOff.gif"))); // NOI18N
        rectFillBtn.setToolTipText("塗りつぶしの四角形を描きます。");
        rectFillBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        ovalFillBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/FillOvalOff.gif"))); // NOI18N
        ovalFillBtn.setToolTipText("塗りつぶしの楕円を描きます。");
        ovalFillBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        polyFillBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/FillPolyOff.gif"))); // NOI18N
        polyFillBtn.setToolTipText("塗りつぶしのポリゴンを描きます。");
        polyFillBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        textBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/TextOff.gif"))); // NOI18N
        textBtn.setToolTipText("テキストを入力します。");
        textBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        lineWidthCombo.setToolTipText("描画線の太さを選びます。");

        colorBtn.setToolTipText("塗りつぶしの色を選択します");
        colorBtn.setMaximumSize(new java.awt.Dimension(32, 29));
        colorBtn.setMinimumSize(new java.awt.Dimension(32, 29));
        colorBtn.setPreferredSize(new java.awt.Dimension(32, 29));

        undoBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/undo_24.gif"))); // NOI18N
        undoBtn.setToolTipText("やり直しをします。");

        clearBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/remov_24.gif"))); // NOI18N
        clearBtn.setToolTipText("クリアします。");

        canvasPanel.setBackground(new java.awt.Color(255, 255, 255));

        jLabel1.setText("タイトル:");

        jLabel2.setText("用途:");

        roleCombo.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "検体検査", "内視鏡検査", "単純レントゲン写真", "上部消化管造影検査", "バリウム注腸検査", "CTスキャン注腸検査", "MRI", "R画像検査", "血管造影", "その他の放射線学的検査", "エコー", "心電図", "脳波", "筋電図", "心電図", "肺機能検査", "その他の生理学的検査", "処方箋", "熱型表", "理学的所見（図など）", "麻酔経過表", "病理検査（画像など）", "手術記録", "参考文献", "参考図", "処置（指示、記録など）", "上記に含まれないもの" }));

        okBtn.setText("カルテに展開");

        cancelBtn.setText("取消し");

        selectBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/move_24.gif"))); // NOI18N
        selectBtn.setToolTipText("図形を選択し移動します。");

        openPathBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/open/dolphin/impl/schema/resources/PolyLineOff.gif"))); // NOI18N
        openPathBtn.setToolTipText("開いたパスを描きます。");
        openPathBtn.setMargin(new java.awt.Insets(4, 4, 3, 3));

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, layout.createSequentialGroup()
                        .add(lineBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(rectBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(ovalBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .add(openPathBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(polyBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(rectFillBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(ovalFillBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(polyFillBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(textBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                        .add(lineWidthCombo, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 78, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(colorBtn, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(selectBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(undoBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(clearBtn)
                        .add(18, 18, 18))
                    .add(org.jdesktop.layout.GroupLayout.LEADING, layout.createSequentialGroup()
                        .add(jLabel1)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(titleFld, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 125, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(jLabel2)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(roleCombo, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(cancelBtn)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                        .add(okBtn))
                    .add(org.jdesktop.layout.GroupLayout.LEADING, canvasPanel, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 731, Short.MAX_VALUE))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .addContainerGap()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(lineBtn)
                    .add(rectBtn)
                    .add(ovalBtn)
                    .add(openPathBtn)
                    .add(polyBtn)
                    .add(rectFillBtn)
                    .add(ovalFillBtn)
                    .add(polyFillBtn)
                    .add(textBtn)
                    .add(colorBtn, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(undoBtn)
                    .add(selectBtn)
                    .add(clearBtn)
                    .add(lineWidthCombo, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(canvasPanel, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 347, Short.MAX_VALUE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel1)
                    .add(titleFld, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 28, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel2)
                    .add(roleCombo, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(cancelBtn)
                    .add(okBtn))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>                        

    
    // Variables declaration - do not modify                     
    private javax.swing.JButton cancelBtn;
    private javax.swing.JPanel canvasPanel;
    private javax.swing.JButton clearBtn;
    private javax.swing.JButton colorBtn;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JToggleButton lineBtn;
    private javax.swing.JComboBox lineWidthCombo;
    private javax.swing.JButton okBtn;
    private javax.swing.JToggleButton openPathBtn;
    private javax.swing.JToggleButton ovalBtn;
    private javax.swing.JToggleButton ovalFillBtn;
    private javax.swing.JToggleButton polyBtn;
    private javax.swing.JToggleButton polyFillBtn;
    private javax.swing.JToggleButton rectBtn;
    private javax.swing.JToggleButton rectFillBtn;
    private javax.swing.JComboBox roleCombo;
    private javax.swing.JToggleButton selectBtn;
    private javax.swing.JToggleButton textBtn;
    private javax.swing.JTextField titleFld;
    private javax.swing.JButton undoBtn;
    // End of variables declaration                   

    public javax.swing.JButton getCancelBtn() {
        return cancelBtn;
    }

    public javax.swing.JPanel getCanvasPanel() {
        return canvasPanel;
    }

    public javax.swing.JButton getClearBtn() {
        return clearBtn;
    }

    public javax.swing.JButton getColorBtn() {
        return colorBtn;
    }

    public javax.swing.JToggleButton getLineBtn() {
        return lineBtn;
    }

    public javax.swing.JComboBox getLineWidthCombo() {
        return lineWidthCombo;
    }

    public javax.swing.JButton getOkBtn() {
        return okBtn;
    }

    public javax.swing.JToggleButton getOvalBtn() {
        return ovalBtn;
    }

    public javax.swing.JToggleButton getOvalFillBtn() {
        return ovalFillBtn;
    }

    public javax.swing.JToggleButton getOpenPathBtn() {
        return openPathBtn;
    }

    public javax.swing.JToggleButton getPolyBtn() {
        return polyBtn;
    }

    public javax.swing.JToggleButton getPolyFillBtn() {
        return polyFillBtn;
    }

    public javax.swing.JToggleButton getRectBtn() {
        return rectBtn;
    }

    public javax.swing.JToggleButton getRectFillBtn() {
        return rectFillBtn;
    }

    public javax.swing.JComboBox getRoleCombo() {
        return roleCombo;
    }

    public javax.swing.JToggleButton getSelectBtn() {
        return selectBtn;
    }

    public javax.swing.JToggleButton getTextBtn() {
        return textBtn;
    }

    public javax.swing.JTextField getTitleFld() {
        return titleFld;
    }

    public javax.swing.JButton getUndoBtn() {
        return undoBtn;
    }
    
}
