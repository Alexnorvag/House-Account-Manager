﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Accounting_Manager.all_classes.TypeEditors
{
    public class TypeEditor7 : UITypeEditor
    {
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            Bitmap img = new Bitmap(19, 12);
            Graphics gr = Graphics.FromImage(img);
            gr.Clear(Color.FromArgb(235, 225, 235));
            e.Graphics.DrawImage(img, new Point(2, 2));
            base.PaintValue(e);
        }

    }
}
