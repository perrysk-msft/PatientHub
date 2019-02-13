using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PatientHub
{

    // Your class should look like this:
    public class DataGridViewBarGraphCell :
      DataGridViewTextBoxCell
    {
        const int HORIZONTALOFFSET = 20;
        const int SPACER = 4;

        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value, object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle
            advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds,
              cellBounds, rowIndex, cellState,
              value, "", errorText,
              cellStyle, advancedBorderStyle,
              paintParts);

            // Get the value of the cell:
            decimal cellValue = 0;
            decimal originalCellValue = 0;

            if (Convert.IsDBNull(value))
            {
                cellValue = 0;
            }
            else
            {
                cellValue = Convert.ToDecimal(value);
            }

            // If cell value is 0, you still
            // want to show something, so set the value
            // to 1.
            if (cellValue == 0)
            {
                cellValue = 1;
            }

            // Get the parent column and the maximum value:
            DataGridViewBarGraphColumn parent = (DataGridViewBarGraphColumn)this.OwningColumn;
            parent.CalcMaxValue();
            if (parent.MaxValue == 0) parent.MaxValue = 1;

            long maxValue = parent.MaxValue;

            Font fnt = parent.InheritedStyle.Font;

            SizeF maxValueSize = graphics.MeasureString(maxValue.ToString(), fnt);
            float availableWidth = cellBounds.Width - maxValueSize.Width - SPACER - (HORIZONTALOFFSET * 2);

            originalCellValue = cellValue;
            cellValue = Math.Round(Convert.ToDecimal((Convert.ToDouble(cellValue) / maxValue) * availableWidth),2);

            const int VERTOFFSET = 4;
            RectangleF newRect = new RectangleF(
              cellBounds.X + HORIZONTALOFFSET,
              cellBounds.Y + VERTOFFSET,
              Convert.ToSingle(cellValue),
              cellBounds.Height - (VERTOFFSET * 2));
            // TODO: Move to config
            if (originalCellValue < 20.00M)
            {
                graphics.FillRectangle(Brushes.Green, newRect);
            }
            else if (originalCellValue >= 20.00M && originalCellValue <= 50.00M)
            {
                graphics.FillRectangle(Brushes.Orange, newRect);
            }
            else if (originalCellValue > 50.00M && originalCellValue < 80.00M)
            {
                graphics.FillRectangle(Brushes.OrangeRed, newRect);
            }
            else 
            {
                graphics.FillRectangle(Brushes.Red, newRect);
            }

            string cellText = formattedValue.ToString();
            SizeF textSize =
             graphics.MeasureString(cellText, fnt);

            // Calculate where text would start:
            PointF textStart = new PointF(
              Convert.ToSingle(HORIZONTALOFFSET +
               cellValue + SPACER),
              (cellBounds.Height - textSize.Height) / 2);

            // Calculate the correct color:
            Color textColor = parent.InheritedStyle.ForeColor;
            if ((cellState &
              DataGridViewElementStates.Selected) ==
              DataGridViewElementStates.Selected)
            {
                textColor = parent.InheritedStyle.
                 SelectionForeColor;
            }


            // Draw the text:
            using (SolidBrush brush =
             new SolidBrush(textColor))
            {
                graphics.DrawString(cellText, fnt, brush,
                  cellBounds.X + textStart.X,
                  cellBounds.Y + textStart.Y);
            }

            


        }
    }

}
