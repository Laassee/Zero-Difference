using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zero_Difference
{
    /// <summary>
    /// Interaction logic for DragButton.xaml
    /// </summary>
    public partial class DragButton : UserControl
    {
        public DragButton()
        {
            InitializeComponent();
        }
        public DragButton(DragButton db)
        {
            InitializeComponent();
            this.dragButtonUI.Height = db.dragButtonUI.Height;
            this.dragButtonUI.Width = db.dragButtonUI.Width;
            this.dragButtonUI.Fill = db.dragButtonUI.Fill;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, dragButtonUI.Fill.ToString());
                data.SetData("Double", dragButtonUI.Height);
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
