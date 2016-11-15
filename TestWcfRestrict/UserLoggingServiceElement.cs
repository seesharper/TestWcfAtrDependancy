using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace TestWcfRestrict
{
    public class UserLoggingServiceElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(MyInspectorAttribute);
            }
        }

        protected override object CreateBehavior()
        {
            return new MyInspectorAttribute();
        }
    }
}