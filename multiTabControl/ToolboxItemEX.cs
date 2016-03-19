using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Windows.Forms;

namespace ControlEX
{
    [Serializable] //ToolboxItem必须是可序列化的
    class ToolboxItemEX : ToolboxItem
    {
        // The add components dialog in VS looks for a public
        // ctor that takes a type.
        public ToolboxItemEX(Type toolType)
            : base(toolType)
        { }
        // And you must provide this special constructor for serialization.
        // If you add additional data to MyToolboxItem that you
        // want to serialize, you may override Deserialize and
        // Serialize methods to add that data.
        ToolboxItemEX(SerializationInfo info, StreamingContext context)
        { Deserialize(info, context); }
        // This implementation sets the new control's Text and
        // AutoSize properties.
        protected override IComponent[] CreateComponentsCore(
        IDesignerHost host,
        IDictionary defaultValues)
        {
            base.CreateComponentsCore(host,defaultValues);
            IComponent[] comps = base.CreateComponentsCore(host, defaultValues);

            //MessageBox.Show(((TabControlEX)comps[0]).TabPages.Count.ToString());
            if (comps.Length > 0) ((TabControlEX)comps[0]).TabPages.RemoveAt(0);//去掉默认添加的TabPage
            return comps;
        }
    }
}
