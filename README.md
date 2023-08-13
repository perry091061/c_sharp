# c_sharp
C# projects
 Application excel = null;
            Workbook wb = null;
            object missing = Type.Missing;
            Worksheet ws = null;
            Range range = null;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                wb = excel.Workbooks.Add();
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                ws.Range["A1"].Offset[0].Resize[1, 1].Value = "123   thest test";
                ws.Range["A1"].Offset[0].Font.Name = "Arial";
                ws.Range["A1"].Offset[0].Font.FontStyle = "Bold";
                ws.Range["A1"].Offset[0].Font.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbAntiqueWhite;
                ws.Range["A1:G1"].Offset[0].Columns.AutoFit();
                ws.Range["A1", "G1"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkBlue;
                var t = ws.PageSetup;
                t.CenterHeader = "&B&16&\"Arial Bold Italic\"TEST";
                excel.Visible = true;
                wb.Activate();
                Console.ReadLine();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error");
            }
        }
