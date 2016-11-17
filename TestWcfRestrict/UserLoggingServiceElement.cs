using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace TestWcfRestrict
{
    using LightInject;

    public class UserLoggingServiceElement : BehaviorExtensionElement
    {
        public static Func<MyInspectorAttribute> AttributeFactory { get;set; }


        public override Type BehaviorType
        {
            get
            {
                return typeof(MyInspectorAttribute);
            }
        }

        protected override object CreateBehavior()
        {
            return AttributeFactory();
        }
    }
}