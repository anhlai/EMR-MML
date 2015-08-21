using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Globalization;

namespace SampleMmlLayout
{
    public class SampleMmlLayout : Yos731.MmlLayout.IMmlLayout
    {
        public event Yos731.MmlLayout.ShowMmlDocumentHandler ShowMmlDocument = null;

        public string getLayoutName()
        {
            return "Plug-in Sample";
        }

        public string getMmlModule()
        {
            return "MmlHeader";
        }

        public System.Windows.Controls.Canvas render(System.Xml.Linq.XElement mml)
        {
            // 引数mmlで渡されたMMLドキュメントの要素を解析し、戻り値のCanvasに描画するロジックを記述してください。

            MyCanvas canvas = new MyCanvas();
            canvas.Background = Brushes.White;

            canvas.Width = 300;
            canvas.Height = 300;

            // このサンプルでは、canvasをマウス左クリックすると、表示するMMLタグとして引数mmlをそのまま返しています。
            canvas.MouseLeftButtonUp += delegate(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                if (ShowMmlDocument != null)
                    ShowMmlDocument(mml);
            };

            return canvas;
        }

        internal class MyCanvas : Canvas
        {
            protected override void OnRender(DrawingContext dc)
            {
                string testString = "Formatted MML Document is displayed here!\nPlease implement the user oriented layout logic.";

                FormattedText formattedText = new FormattedText(testString, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 30, Brushes.Black);

                formattedText.MaxTextWidth = 280;
                formattedText.MaxTextHeight = 280;

                formattedText.SetForegroundBrush(new LinearGradientBrush(Colors.Blue, Colors.Teal, 90.0), 10, 12);

                formattedText.SetFontStyle(FontStyles.Italic, 36, 5);
                formattedText.SetForegroundBrush(new LinearGradientBrush(Colors.Pink, Colors.Crimson, 90.0), 36, 5);
                formattedText.SetFontSize(36, 36, 5);

                formattedText.SetFontWeight(FontWeights.Bold, 42, 48);

                dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, 300, 300));

                dc.DrawText(formattedText, new Point(10, 10));
            }
        }
    }
}
