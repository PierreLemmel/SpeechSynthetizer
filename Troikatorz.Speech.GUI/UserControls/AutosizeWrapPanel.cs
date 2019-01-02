using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Troikatorz.Speech.GUI.UserControls
{
    public class AutosizeWrapPanel : WrapPanel
    {
        #region Properties
        static AutosizeWrapPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutosizeWrapPanel), new FrameworkPropertyMetadata(typeof(AutosizeWrapPanel)));
        }

        public double ChildMinWidth
        {
            get => (double)GetValue(ChildMinWidthProperty);
            set => SetValue(ChildMinWidthProperty, value);
        }

        public static readonly DependencyProperty ChildMinWidthProperty
            = DependencyProperty.Register(
                nameof(ChildMinWidth),
                typeof(double),
                typeof(AutosizeWrapPanel),
                new PropertyMetadata(250.0, null, CoerceMinWidth));

        private static object CoerceMinWidth(DependencyObject d, object baseValue)
        {
            AutosizeWrapPanel self = (AutosizeWrapPanel)d;
            double minWidth = (double)baseValue;

            return Math.Max(minWidth, 0.0d);
        }
        #endregion

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            double childMinWidth = ChildMinWidth;
            double totalWidth = sizeInfo.NewSize.Width;

            if (totalWidth > childMinWidth)
            {
                double itemsPerLine = Math.Round(totalWidth / ChildMinWidth);
                double itemWidth = childMinWidth + Math.IEEERemainder(totalWidth, childMinWidth) / itemsPerLine;

                ItemWidth = itemWidth;
            }
            else
                ItemWidth = totalWidth;
        }
    }
}
