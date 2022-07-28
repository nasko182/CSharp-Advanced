using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Utilyties.Validators
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties().Where(p=>p.CustomAttributes.Any(a=>a.AttributeType.BaseType==typeof(MyValidationAttribute)))
                .ToArray();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                foreach (var attribute in propertyInfo.CustomAttributes)
                {
                    Type customAtrType = attribute.AttributeType;
                    object atributeInctance = propertyInfo.GetCustomAttribute(customAtrType);

                    MethodInfo method = customAtrType.GetMethod("IsValid");
                    bool result = (bool)method.Invoke(atributeInctance, new object[]
                    {
                        propertyInfo.GetValue(obj)
                    });
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
